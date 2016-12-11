using System;

namespace Modbuslib.Transaction
{
    public class FuncReadHoldingRegiters : MBTransaction
    {
        public FuncReadHoldingRegiters()
        {
            base.FunctionCode = (byte)Modbuslib.FunctionCode.ReadHoldingRegisters;
            base.Count = 6;
        }

        protected override byte[] GetRequestPDU()
        {
            byte[] buffer = new byte[5];
            // funcion code
            buffer[0] = (byte) (FunctionCode);
            
            // address
            buffer[1] = (byte) (Address >> 8);
            buffer[2] = (byte) (Address & 0x00FF);
            // data
            buffer[3] = (byte) (Data[0] >> 8);
            buffer[4] = (byte) (Data[0] & 0x00FF);

            return buffer;
        }
    }   
}