using System;
using Modbuslib;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ModbusTcpClient client = new ModbusTcpClient();
            ushort[] recvBuffer = new ushort[2];

            client.ReadHoldingRegisters(0x0001, 2, recvBuffer);
            client.ReadHoldingRegisters(0x0002, 2, recvBuffer);
            client.ReadHoldingRegisters(0x0003, 2, recvBuffer);
            client.ReadHoldingRegisters(0x0004, 2, recvBuffer);

            client.WriteSingleRegister(0x0002, 4);

            ushort[] sendBuffer = new ushort[] {
                0x0012, 0x0013, 0x0014, 0x0015
            };

            client.WriteMultipleRegiters(0x0005, 4, sendBuffer);
        }
    }
}
