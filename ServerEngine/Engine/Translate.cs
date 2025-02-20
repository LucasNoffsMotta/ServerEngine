using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace ServerEngine.Engine
{
    public static class Translate
    {
        public static void SendMessage(Socket handler, string msg)
        {
            try
            {
                byte[] translatedMsg = Encoding.ASCII.GetBytes(msg);
                handler.Send(translatedMsg);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ReceiveMessage(Socket handler)
        {
            try
            {
                string msg = "";
                byte[] buffer = new byte[1024];
                int size = handler.Receive(buffer);
                msg = Encoding.ASCII.GetString(buffer, 0, size);
                Console.Write(msg);
                return msg;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
