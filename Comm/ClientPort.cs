using System.Net.Sockets;

namespace Modbuslib.Comm
{
    public abstract class ClientPort
    {
        protected NetworkStream Stream;
        
        public bool Enabled;

        public ClientPort()
        {

        }

        public abstract void Open();
        public abstract void Close();
        
        public abstract int Read();
        public abstract int Read(byte[] buffer, int offset, int count);
        public abstract void Write(byte value);
        public abstract void Write(byte[] value, int offset, int count);
    }
}