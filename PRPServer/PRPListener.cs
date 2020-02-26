using System;
using System.Net;
using System.Net.Sockets;

namespace PRPServer
{
    public class PRPListener
    {
        IPEndPoint listenEndPoint;
        Socket listener;

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
            listener = new Socket(AddressFamily.InterNetwork & AddressFamily.InterNetworkV6,
                SocketType.Stream,
                ProtocolType.Tcp);
            listener.Bind(listenEndPoint);
            listener.Listen(backlog);
        }
    }
}
