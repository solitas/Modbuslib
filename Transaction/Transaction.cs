using System;
using System.Linq;

namespace Modbuslib.Transaction
{
    public abstract class MBTransaction
    {
        protected const ushort MBAP_HEADER_SIZE = 7;

        public ushort TransactionID             { set; get; }
        public ushort ProtocolID                { set; get; }
        public byte UnitID                      { set; get; }
        public ushort Count                     { set; get; }
        public ushort Address                   { set; get; }
        public ushort[] Data                      { set; get; }

        public byte FunctionCode                { set; get; }

        protected byte[] GetMBAPHeader(ushort length)
        {
            ushort len = (ushort)(length + 1);
            byte[] buffer = new byte[7];
            buffer[0] = (byte) (TransactionID >> 8);
            buffer[1] = (byte) (TransactionID & 0x00FF);
            buffer[2] = (byte) (ProtocolID >> 8);
            buffer[3] = (byte) (ProtocolID & 0x00FF);
            buffer[4] = (byte) (len >> 8);
            buffer[5] = (byte) (len & 0x00FF);
            buffer[6] = (byte) (UnitID);
            return buffer;
        }

        protected abstract byte[] GetRequestPDU();

        public byte[] RequestADU()
        {
            var pdu = GetRequestPDU();
            var header = GetMBAPHeader((ushort)pdu.Length);
                        
            return header.Concat(pdu).ToArray();
        }
    }
}