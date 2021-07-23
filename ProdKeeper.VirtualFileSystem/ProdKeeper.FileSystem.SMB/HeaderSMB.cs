using ProdKeeper.FileSystem.SMB.Helper;
using ProdKeeper.FileSystem.SMB.SMB;
using ProdKeeper.FileSystem.SMB.SMB.Command;
using ProdKeeper.VirtualFileSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdKeeper.FileSystem.SMB
{
    public class HeaderSMB : IHeader
    {
        public const int SignatureOffset = 48;

        public static readonly byte[] ProtocolSignature = new byte[] { 0xFE, 0x53, 0x4D, 0x42 };

        private byte[] protocolId; // 4 bytes, 0xFE followed by "SMB"
        private ushort structureSize;
        private ushort creditCharge;
        private NTStatus status;
        private SMB2CommandName command;
        private ushort credits; // CreditRequest or CreditResponse (The number of credits granted to the client)
        private SMB2PacketHeaderFlags flags;
        private uint nextCommand; // offset in bytes
        private ulong messageID;
        private uint reserved; // Sync
        private uint treeID;   // Sync
        private ulong asyncID; // Async
        private ulong sessionID;
        private byte[] signature; // 16 bytes (present if SMB2_FLAGS_SIGNED is set)

        public int BodyLength { get; set; }
        public byte[] Content { get { return GetContent(); } set { ParseContent(value); } }
        public byte[] ProtocolId { get => protocolId; set => protocolId = value; }
        public ushort StructureSize { get => structureSize; set => structureSize = value; }
        public ushort CreditCharge { get => creditCharge; set => creditCharge = value; }
        public NTStatus Status { get => status; set => status = value; }
        public SMB2CommandName Command { get => command; set => command = value; }
        public ushort Credits { get => credits; set => credits = value; }
        public SMB2PacketHeaderFlags Flags { get => flags; set => flags = value; }
        public uint NextCommand { get => nextCommand; set => nextCommand = value; }
        public ulong MessageID { get => messageID; set => messageID = value; }
        public uint Reserved { get => reserved; set => reserved = value; }
        public uint TreeID { get => treeID; set => treeID = value; }
        public ulong AsyncID { get => asyncID; set => asyncID = value; }
        public ulong SessionID { get => sessionID; set => sessionID = value; }
        public byte[] Signature { get => signature; set => signature = value; }
        

        private byte[] GetContent(int offset=0)
        {
            byte[] buffer = new byte[64];
            
            ByteWriter.WriteBytes(buffer, offset + 0, ProtocolId);
            LittleEndianWriter.WriteUInt16(buffer, offset + 4, StructureSize);
            LittleEndianWriter.WriteUInt16(buffer, offset + 6, CreditCharge);
            LittleEndianWriter.WriteUInt32(buffer, offset + 8, (uint)Status);
            LittleEndianWriter.WriteUInt16(buffer, offset + 12, (ushort)Command);
            LittleEndianWriter.WriteUInt16(buffer, offset + 14, Credits);
            LittleEndianWriter.WriteUInt32(buffer, offset + 16, (uint)Flags);
            LittleEndianWriter.WriteUInt32(buffer, offset + 20, NextCommand);
            LittleEndianWriter.WriteUInt64(buffer, offset + 24, MessageID);
            if ((Flags & SMB2PacketHeaderFlags.AsyncCommand) > 0)
            {
                LittleEndianWriter.WriteUInt64(buffer, offset + 32, AsyncID);
            }
            else
            {
                LittleEndianWriter.WriteUInt32(buffer, offset + 32, Reserved);
                LittleEndianWriter.WriteUInt32(buffer, offset + 36, TreeID);
            }
            LittleEndianWriter.WriteUInt64(buffer, offset + 40, SessionID);
            if ((Flags & SMB2PacketHeaderFlags.Signed) > 0)
            {
                ByteWriter.WriteBytes(buffer, offset + 48, Signature);
            }
            return buffer;
        }

        private void ParseContent(byte[] value, int offset=0)
        {
            ProtocolId = ByteReader.ReadBytes(value, offset + 0, 4);
            StructureSize = LittleEndianConverter.ToUInt16(value, offset + 4);
            CreditCharge = LittleEndianConverter.ToUInt16(value, offset + 6);
            Status = (NTStatus)LittleEndianConverter.ToUInt32(value, offset + 8);
            Command = (SMB2CommandName)LittleEndianConverter.ToUInt16(value, offset + 12);
            BodyLength = CommandFactory.CreateCommand(command).BodySize;
            Credits = LittleEndianConverter.ToUInt16(value, offset + 14);
            Flags = (SMB2PacketHeaderFlags)LittleEndianConverter.ToUInt32(value, offset + 16);
            NextCommand = LittleEndianConverter.ToUInt32(value, offset + 20);
            MessageID = LittleEndianConverter.ToUInt64(value, offset + 24);
            if ((Flags & SMB2PacketHeaderFlags.AsyncCommand) > 0)
            {
                AsyncID = LittleEndianConverter.ToUInt64(value, offset + 32);
            }
            else
            {
                Reserved = LittleEndianConverter.ToUInt32(value, offset + 32);
                TreeID = LittleEndianConverter.ToUInt32(value, offset + 36);
            }
            SessionID = LittleEndianConverter.ToUInt64(value, offset + 40);
            if ((Flags & SMB2PacketHeaderFlags.Signed) > 0)
            {
                Signature = ByteReader.ReadBytes(value, offset + 48, 16);
            }
        }
    }
}
