using Modbuslib.Transaction;

namespace Modbuslib
{
    public static class MBTransactionFactory
    {
        public static MBTransaction Create(FunctionCode code, ushort transactionID)
        {
            MBTransaction transaction = null; 
            switch(code)
            {
                case FunctionCode.ReadHoldingRegisters:         return funcReadHoldingRegiters(transactionID);
                case FunctionCode.WriteSingleRegiters:          return funcWriteSingleRegister(transactionID);
                case FunctionCode.WriteMultipleRegiters:        return funcWriteMultipleRegisters(transactionID);
                default: return null;
            }
        }

        private static FuncReadHoldingRegiters funcReadHoldingRegiters(ushort tID)
        {

            return new FuncReadHoldingRegiters() {
                TransactionID = tID,
            };
        }
        private static FuncWriteSingleRegister funcWriteSingleRegister(ushort tID)
        {
            return new FuncWriteSingleRegister(){
                TransactionID = tID,
            };
        }
        private static FuncWriteMultipleRegisters funcWriteMultipleRegisters(ushort tID)
        {
            return new FuncWriteMultipleRegisters(){
                TransactionID = tID,
            };
        }
    }
}