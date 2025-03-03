using ServerEngine.Application;
using System.Net.Sockets;


namespace ServerEngine.Engine
{
    public static class ServeWebPages
    {
        public static string htmlMainPagePath = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\html\mainPage.html";
        public static string htmlBackDoorPagePath = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\html\backdoor.html";
        public static string cssMainpagePath = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\css\style.css";
        public static string htmlFormResponsePath = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\html\formResponse.html";
        public static string cssFormReponsePath = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\css\formResponse.css";



        public static void SendHttp(Socket handler, string clientResponse, string type, string route)
        {
            string serverResponse = "";
            string generatedFile = "";
            bool serverResponded = false;

            if (type.Equals("GET"))
            {
                if (route == "/")
                {
                     generatedFile = File.ReadAllText(htmlMainPagePath);
                     serverResponse = Messages.GenerateHtmlResponseToHttp(generatedFile) + generatedFile;
                     Translate.SendMessage(handler, serverResponse);
                }

                else if (route == "/style.css")
                {
                    generatedFile = File.ReadAllText(cssMainpagePath);
                    serverResponse = Messages.GenerateCssResponseToHttp(generatedFile) + generatedFile;
                    Translate.SendMessage(handler, serverResponse);
                }

                else if (route == "/formResponse.css")
                {
                    generatedFile = File.ReadAllText(cssFormReponsePath);
                    serverResponse = Messages.GenerateCssResponseToHttp(generatedFile) + generatedFile;
                    Translate.SendMessage(handler, serverResponse);
                }

                else if (route == "/backdoor")
                {
                    generatedFile = File.ReadAllText(htmlBackDoorPagePath);
                    serverResponse = Messages.GenerateHtmlResponseToHttp(generatedFile) + generatedFile;
                    Translate.SendMessage(handler, serverResponse);
                }

                else if (route == "/race")
                {
                    generatedFile = File.ReadAllText(htmlFormResponsePath);
                    serverResponse = Messages.GenerateHtmlResponseToHttp(generatedFile) + generatedFile;
                    Translate.SendMessage(handler, serverResponse);
                }

                else
                {
                    serverResponse = Messages.GenerateHttpErrorResponse("204 No Content");
                    Translate.SendMessage(handler, serverResponse);
                }
                serverResponded = true;
            }


            else if (type.Equals("POST"))
            {
                string infoString = GetPostContent.GetInfoString(clientResponse);
                Dictionary<string, string> userInfo = GetPostContent.GetParsedInfo(infoString);
                GetPostContent.CreateFormReponseHTML(userInfo["firstname"] + " " + userInfo["lastname"], userInfo["email"]);
                generatedFile = File.ReadAllText(htmlFormResponsePath);
                serverResponse = Messages.GenerateHtmlResponseToHttp(generatedFile) + generatedFile;
                Translate.SendMessage(handler, serverResponse);
                serverResponded = true;
            }


            if (serverResponded)
            {
                Console.WriteLine($"\nSERVER RESPONSE: {serverResponse}\n");
                serverResponded = false;
            }
        }
    }
}
