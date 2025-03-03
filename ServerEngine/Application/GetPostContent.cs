namespace ServerEngine.Application
{
    public static class GetPostContent
    {
        public static void CreateFormReponseHTML(string userName, string userEmail)
        {
            string html = "<!DOCTYPE html>" +
                "\r\n<html lang=\"pt-br\">\r\n" +
                "<head>\r\n    " +
                "<meta charset=\"UTF-8\">\r\n    " +
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                "<title>Resposta do Formulário</title>\r\n    " +
                "<link rel=\"stylesheet\" href=\"formResponse.css\">\r\n</head>\r\n<body>\r\n   " +
                " <div class=\"response-container\">\r\n       " +
                " <h1>Obrigado por enviar seu formulário!</h1>\r\n        " +
                "<p class=\"message\">Seu formulário foi enviado com sucesso. Em breve, entraremos em contato com você.</p>\r\n        " +
                "<div class=\"response-details\">\r\n            " +
                "<h2>Detalhes Enviados:</h2>\r\n            " +
                $"<p><strong>Nome:</strong> {userName}</p>\r\n            " +
                $"<p><strong>Email:</strong> {userEmail}</p>\r\n            " +
                "<p><strong>Mensagem:</strong> Gostaria de saber mais sobre seus serviços.</p>\r\n        " +
                "</div>\r\n        " +
                "<a href=\"index.html\" class=\"back-link\">Voltar para a página inicial</a>\r\n    " +
                "</div>\r\n</body>\r\n</html>";

            string path = @"C:\Users\lnoff\source\repos\ServerEngine\ServerEngine\Application\html\formResponse.html";

            File.WriteAllText(path, html);
        }

        public static string GetInfoStringFromRawClientResponse(string request)
        {
            string[] splitedRequest = request.Split('\n');

            foreach (string s in splitedRequest)
            {
                if (s.StartsWith("firstname"))
                {
                    return s;
                }
            }
            return "none";
        }

        public static Dictionary<string, string> GetFinalParsedInfo(string infoString)
        {
            string[] subStrings = infoString.Split('&');
            Dictionary<string, string> userInfo = new Dictionary<string, string>();

            foreach (string s in subStrings)
            {
                if (s.StartsWith("firstname"))
                {
                    userInfo["firstname"] = GetUserInfoFromSubString(s);
                }

                else if (s.StartsWith("lastname"))
                {
                    userInfo["lastname"] = GetUserInfoFromSubString(s);
                }

                else if (s.StartsWith("race"))
                {
                    userInfo["race"] = GetUserInfoFromSubString(s);
                }

                else if (s.StartsWith("email"))
                {
                    string rawEmail = GetUserInfoFromSubString(s);
                    userInfo["email"] = ParseEmail(rawEmail);
                }

                else if (s.StartsWith("password"))
                {
                    userInfo["password"] = GetUserInfoFromSubString(s);
                }

                else if (s.StartsWith("age"))
                {
                    userInfo["age"] = GetUserInfoFromSubString(s);
                }
            }
            return userInfo;
        }

        public static string ParseEmail(string rawEmail)
        {
            string[] emailBody = rawEmail.Split("%");

            string emailDomain = "";

            foreach(char c in emailBody[1])
            {
                if(c != '4' && c != '0')
                {
                    emailDomain += c;
                }
            }
            return emailBody[0] + '@' + emailDomain;
        }

        public static string GetUserInfoFromSubString(string infoSubString)
        {
            string info = "";

            int nameStartIndex = infoSubString.IndexOf('=');

            for (int i = nameStartIndex + 1; i < infoSubString.Length; i++)
            {
                info += infoSubString[i];
            }
            return info;
        }
    }
}
