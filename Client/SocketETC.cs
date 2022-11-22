using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class SocketETC
    {
        private const string IP = "127.0.0.1";
        private const int PORT = 8080;

        private IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void connect()
        {
            if(!socket.Connected)
                socket.Connect(tcpEndPoint);
        }

        public void disconnect()
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }

        public void send(byte[] thing)
        {
            socket.Send(thing);
        }
        public int receive(byte[] thing)
        {
            return socket.Receive(thing);
        }

        public bool availableBiggerThanZero()
        {
            if (socket.Available > 0)
                return true;
            else
                return false;
        }
    }
}
