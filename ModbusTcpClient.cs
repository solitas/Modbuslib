using System;
using Modbuslib.Comm;
using Modbuslib.Transaction;
namespace Modbuslib
{
    public class ModbusTcpClient
    {
        private ushort  _transactionId = 0;
        private ushort _modbusProtocolID = 0x0000;

        public byte UnitID { get; set;}
        ClientPort _clientPort;
        public ModbusTcpClient(byte unitID = 0x00)
        {
            UnitID = unitID;
        }
        public ModbusTcpClient(ClientPort clientPort, byte unitID = 0x00)
        {
            _clientPort = clientPort;
            UnitID = unitID;
        }

        public void ReadHoldingRegisters(ushort address, ushort count, ushort[] data)
        {
            FuncReadHoldingRegiters transaction = (FuncReadHoldingRegiters) MBTransactionFactory.Create(FunctionCode.ReadHoldingRegisters, _transactionId++);
            transaction.Address = address;
            transaction.Data = new ushort[1] { count };

            byte[] aduBuffer = transaction.RequestADU();
            ToStringHex(aduBuffer);
        }
        public void WriteSingleRegister(ushort address, ushort value)
        {
            FuncWriteSingleRegister transaction = (FuncWriteSingleRegister) MBTransactionFactory.Create(FunctionCode.WriteSingleRegiters, _transactionId++);
            transaction.Address = address;
            transaction.Data = new ushort[1] { value };

            byte[] aduBuffer = transaction.RequestADU();
            ToStringHex(aduBuffer);
        }
        public void WriteMultipleRegiters(ushort address, ushort count, ushort[] data)
        {
            FuncWriteMultipleRegisters transaction = (FuncWriteMultipleRegisters) MBTransactionFactory.Create(FunctionCode.WriteMultipleRegiters, _transactionId++);
            transaction.Address = address;
            transaction.Data = data;
            transaction.RegistersCount = count;
            byte[] aduBuffer = transaction.RequestADU();
            ToStringHex(aduBuffer);
        }

        private void ToStringHex(byte[] buffer)
        {
            foreach (var b in buffer)
            {
                Console.Write("0x{0:X2} ", b);
            }
            Console.WriteLine();
        }
    }
}