using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerEngine.Engine
{
    public class Worker
    {
        public Socket socket { get; set; }

        public Connection server { get; set; }


        public Worker(Socket socket, Connection server)
        {
            this.socket = socket;
            this.server = server;
        }

        public void Start()
        {
            new Thread(Run).Start();
        }

        public void Comunicate()
        {
            try
            {
                Map.MapGet(this.socket);
            }

            catch
            {
                server.StopConnection(this);
            }
        }

        public void Run()
        {
            while (true)
            {
                server.ComunicateWithClient();
            }
        }
    }
}
