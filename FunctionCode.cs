namespace Modbuslib
{
    public enum FunctionCode : byte
    {
        ReadHoldingRegisters        = 0x03,
        WriteSingleRegiters         = 0x08,
        WriteMultipleRegiters       = 0x10,
    }
}