using ProdKeeper.VirtualFileSystem.Abstractions.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using ProdKeeper.VirtualFileSystem.Abstractions.Server;
using ProdKeeper.VirtualFileSystem.Abstractions;

namespace ProdKeeper.VirtualFileSystem
{
    public class Server
    {
        private List<Thread> _threads;
        private List<IChannel> _channels;

        public Server()
        {
            _threads = new List<Thread>();
            _channels = new List<IChannel>();
        }

        public void Start()
        {
            Console.WriteLine("Start Server.......");


            foreach (IChannel serv in _channels)
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

        public void AddChannel<TCommand>(Channel<TCommand> Channel) where TCommand:Message,new()
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

            IChannel chan = (IChannel)channel;
            Console.WriteLine("Start Channel {0} on port {1}.......",chan.Name, chan.Port);
            chan.Start();
        }

    }
}
