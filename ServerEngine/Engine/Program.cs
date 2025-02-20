// See https://aka.ms/new-console-template for more information
using ServerEngine.Engine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public static class Server
{
    public static int Main(string[] args)
    {
        RunServer();
        return 0;
    }


    public static void RunServer()
    {
        Connection conn = new Connection(8800);
        conn.ConnectionLoop();
    }
}


