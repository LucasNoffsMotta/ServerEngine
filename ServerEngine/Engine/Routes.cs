using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServerEngine.Engine
{
    public static class Routes
    {
        public static string GetRoute(string rawString)
        {
            int routeStart = rawString.IndexOf("/");
            string routeBegin = rawString.Substring(routeStart + 1);
            string route = "/";

            foreach(char c in routeBegin)
            {
                if (c != ' ')
                {
                    route += c;
                }

                else
                {
                    break;
                }
            }
            return route;
        }
    }
}
