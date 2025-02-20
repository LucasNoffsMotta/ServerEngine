using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerEngine.Engine
{
    public static class Messages
    {
        public static readonly string waitingForConnection = "Waiting for connection...";
        public static readonly string closingConnection = "Closing connection...";

        public static void ConnectedMessage()
        {
            Console.WriteLine($"New client connected!");
        }

        public static string GenerateHtmlResponseToHttp(string responseBody)
        {
            return "HTTP/1.1 200 OK\r\n" +
                                                  "Content-Type: text/html; charset=UTF-8\r\n" +
                                                  $"Content-Length: {responseBody.Length}\r\n" +
                                                  "Connection: keep-alive\r\n\r\n";
        }

        public static string GenerateCssResponseToHttp(string responseBody)
        {
            return "HTTP/1.1 200 OK\r\n" +
                                                  "Content-Type: text/css; charset=UTF-8\r\n" +
                                                  $"Content-Length: {responseBody.Length}\r\n" +
                                                  "Connection: keep-alive\r\n\r\n";
        }

        public static string GenerateHttpErrorResponse(string error)
        {
            return  $"HTTP/1.1 {error}\r\n" +
                                   "Content-Length: 0\r\n" +
                                   "Connection: keep-alive\r\n\r\n";
        }


    }
}
