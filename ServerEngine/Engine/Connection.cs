using ServerEngine.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerEngine.Engine
{
    public class Connection
    {
        public IPHostEntry host { get; set; }

        public IPAddress ipAddress { get; set; }

        public IPEndPoint endPoint { get; set; }

        public Socket listener { get; set; }

        public Socket handler { get; set; }

        public string httpAdress { get; set; }

        public List<Worker> connections { get; set; }

        public Connection(int port)
        {
            host = Dns.GetHostEntry("localHost");
            ipAddress = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddress, port);
            listener = new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            connections = new List<Worker>();   
            httpAdress = $"http://localhost:{port}/";
        }

        public void StartConnection()
        {
            try
            {
                listener.Bind(endPoint);
                listener.Listen(10);
                Console.WriteLine($"URL: {httpAdress}");
                Console.WriteLine(Messages.waitingForConnection);
            }

            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public void WaitConnection()
        {
            while (true)
            {
                ConnectionSucceded();
            }
        }

        public void ConnectionSucceded()
        {
            Socket temp = listener.Accept();
            Worker worker = new(temp, this);
            AddWorker(worker);  
            worker.Start();
            Messages.ConnectedMessage();
        }

        private void AddWorker(Worker worker)
        {
            lock(this)
            {
                connections.Add(worker);
            }
        }

        public void ComunicateWithClient()
        {
            lock(this)
            {          
                for (int i = 0; i < connections.Count; i++)
                {
                    try
                    {
                        connections[i].Comunicate();
                    }

                    catch (IOException) { }
                    catch (ObjectDisposedException) { }     
                }
            }
        }


        public void StopConnection(Worker worker)
        {
            lock (this)
            {
                connections.Remove(worker);
                worker.socket.Shutdown(SocketShutdown.Both);
                worker.socket.Close();
            }
        }

        public void ConnectionLoop()
        {

            //while(true)
            //{
            //    Data.ShowMenu(handler);
            //}

            //LOCAL APLICATION TEST
            StartConnection();
            WaitConnection();
            //HTTP Server Aplication test

        }
    }
}
