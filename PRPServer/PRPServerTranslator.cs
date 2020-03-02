using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PortReuseProtocol
{
    class PRPServerTranslator
    {
        private TcpClient Remote;
        private IPEndPoint ServerEndPoint;
        private TcpClient Server;

        PRPServerTranslator(TcpClient remote, IPEndPoint servEndPoint)
        {
            Remote = remote;
            ServerEndPoint = servEndPoint;
            Server.Connect(ServerEndPoint);
        }

        private void Translate()
        {
            using var remoteStream = Remote.GetStream();
            using var serverStream = Server.GetStream();
            while (Remote.Connected && Server.Connected)
            {
                remoteStream.CopyTo(serverStream);
                serverStream.CopyTo(remoteStream);
            }
        }
    }
}
