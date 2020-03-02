using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PRPServer
{
    public class PRPListener
    {
        IPEndPoint listenEndPoint;
        TcpListener listener;

        PRPListener(int port)
        {
            listenEndPoint.Address = IPAddress.Any;
            listenEndPoint.Port = port;
        }
        
        PRPListener(IPEndPoint endPoint)
        {
            listenEndPoint = endPoint;
        }

        PRPListener(string localIpAddr, int port = 7207)
        {
            listenEndPoint.Address = IPAddress.Parse(localIpAddr);
            listenEndPoint.Port = port;
        }

        void Listen(int backlog = 512)
        {
            listener = new TcpListener(listenEndPoint);
            listener.Start();
        }

        void Accept()
        {
            TcpClient client = listener.AcceptTcpClient();
            byte[] lenBuf = new byte[4];
            client.GetStream().Read(lenBuf, 0, 4);
            int len = BitConverter.ToInt32(lenBuf, 0);
            byte[] strBuf = new byte[len];
            client.GetStream().Read(strBuf, 0, len);
            string service = Encoding.UTF8.GetString(strBuf);
            IPEndPoint endPoint = PRPRegister.GetService(service);


        }
    }
}