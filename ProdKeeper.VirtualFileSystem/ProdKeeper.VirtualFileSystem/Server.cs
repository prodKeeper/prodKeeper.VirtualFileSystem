﻿using ProdKeeper.VirtualFileSystem.Abstractions.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;

namespace ProdKeeper.VirtualFileSystem
{
    public class Server
    {
        private List<Thread> _threads;
        private List<Channel> _channels;

        public void Start()
        {
            foreach (Channel serv in _channels)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(StartServer));
                thread.Start(serv);
                _threads.Add(thread);
            }
            bool allThreadAlive = true;
            while (allThreadAlive)
            {
                allThreadAlive = (from t in _threads where t.IsAlive == true select t).Count() > 0;
                Thread.Sleep(200);
            }
            
        }

        public void AddChannel(Channel Channel)
        {
            bool alreadyAssign = (from c in _channels where c.Port == Channel.Port select c).FirstOrDefault() != null;
            if (alreadyAssign)
            {
                throw new Exception();
            }
            _channels.Add(Channel);
        }

        private void StartServer(object channel)
        {

            Channel chan = (Channel)channel;
            chan.Start();
        }

    }
}