using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HyperLib
{
    class ChatServer
    {
        private string ip;
        private int port;
        private TcpListener server;

        public delegate void ClientConnect();
        public event ClientConnect onClientConnect;

        public String LocalAdress { get { return ip; }
            set {
                Regex reg = new Regex(@"^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$");
                if (reg.IsMatch(value))
                    ip = value;
                else
                    throw new InvalidOperationException("Wrong format from LocalAdress (IP)");
            } }
        public int Port { get { return port; } set { port = value; } }
        public TcpListener getServer { get { return server; } }

        public ChatServer(string locaAdress, int port)
        {
            ip = locaAdress;
            this.port = port;
            server = new TcpListener(IPAddress.Parse(ip), port);
        }
    }
}
