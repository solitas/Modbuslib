using System;

namespace Modbuslib.Transaction
{
    public class FuncWriteMultipleRegisters : MBTransaction
    {
        public ushort RegistersCount ;
        public FuncWriteMultipleRegisters()
        {
            base.FunctionCode = (byte)Modbuslib.FunctionCode.WriteMultipleRegiters;
        }

        protected override byte[] GetRequestPDU()
        {
            Count = (ushort)(6 + (2 * RegistersCount));

            int length = 7 + (2 * RegistersCount);
            int offset = 0;
            byte[] buffer = new byte[Count];

            buffer[0] = (byte) FunctionCode;
            // Starting address
            buffer[1] = (byte) (Address >> 8);
            buffer[2] = (byte) (Address & 0xFF);
            buffer[3] = (byte) (RegistersCount >> 8);
            buffer[4] = (byte) (RegistersCount & 0xFF);
            buffer[5] = (byte) (RegistersCount * 2);
            
            offset += 6;
            for (int i = 0; i < RegistersCount; i++)
            {
                buffer[offset++] = (byte) (Data[i] >> 8);
                buffer[offset++] = (byte) (Data[i] & 0x00FF);
            }
            return buffer;
        }
    }
}