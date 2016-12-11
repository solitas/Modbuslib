using System;
using System.Linq;

namespace Modbuslib.Transaction
{
    public abstract class MBTransaction
    {
        public ushort TransactionID             { set; get; }
        public ushort ProtocolID                { set; get; }
        public byte UnitID                      { set; get; }
        public ushort Count                     { set; get; }
        public ushort Address                   { set; get; }
        public ushort[] Data                      { set; get; }

        public byte FunctionCode                { set; get; }

        protected byte[] GetMBAPHeader()
        {
            byte[] buffer = new byte[7];
            buffer[0] = (byte) (TransactionID >> 8);
            buffer[1] = (byte) (TransactionID & 0x00FF);
            buffer[2] = (byte) (ProtocolID >> 8);
            buffer[3] = (byte) (ProtocolID & 0x00FF);
            buffer[4] = (byte) (Count >> 8);
            buffer[5] = (byte) (Count & 0x00FF);
            buffer[6] = (byte) (UnitID);
            return buffer;
        }

        protected abstract byte[] GetRequestPDU();

        public byte[] RequestADU()
        {
            var header = GetMBAPHeader();
            var pdu = GetRequestPDU();
            
            return header.Concat(pdu).ToArray();
        }
    }
}