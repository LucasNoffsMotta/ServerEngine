using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerEngine.Engine
{
    public static class Map
    {
        public static void MapGet(Socket handler)
        {
            string request = Translate.ReceiveMessage(handler);
            string type = GetType(request);
            string route = Routes.GetRoute(request);
            ServeWebPages.SendHttp(handler, type, route);
        }

        public static string GetType(string request)
        {
            //INCLUIR POST
            if (request.StartsWith("GET"))
            {
                return "GET";
            }

            else if (request.StartsWith("POST"))
            {
                return "POST";
            }

            else
            {
                return "ERROR";
            }

            //return request.StartsWith("GET") ? "GET" : "ERROR";
        }
    }
}
