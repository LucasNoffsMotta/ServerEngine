using ServerEngine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ServerEngine.Application
{

//Local console connection aplication Data

    public static class Data
    {
        public static List<Player> players = new List<Player>();

        public static void IncludeNewPlayer(Socket handler)
        {
            Translate.SendMessage(handler, "<EOF> What is the player name? ");
            string playerName = Translate.ReceiveMessage(handler);
            Player newPLayer = new(playerName, players.Count());
            players.Add(newPLayer);
            Translate.SendMessage(handler, $"New Player Created: \nName = {newPLayer.Name}\nLevel = {newPLayer.Level}" +
                $"\nId = {newPLayer.PlayerID}\n");
        }

        public static void ShowMenu(Socket handler)
        {
            string response = " ";

            while (response != "5")
            {
                string options = "<EOF>\n1. Create new Player \n2. Delete Player \n3. Update Player\n4. View All Players\n5. Exit program\n";
                Translate.SendMessage(handler, options);
                response = Translate.ReceiveMessage(handler);

                if (response == "1")
                {
                    IncludeNewPlayer(handler);
                }

                if (response == "2")
                {
                    Translate.SendMessage(handler, "<EOF>Wich player do you want to erase? ");
                    response = Translate.ReceiveMessage(handler);
                    players.RemoveAll(player => player.Name == response);
                }

                if (response == "3")
                {
                    Translate.SendMessage(handler, "NOT READY");
                }

                if (response == "4")
                {
                    string allPlayers = "Current players: \n";

                    foreach (Player player in players)
                    {
                        allPlayers += player.Name + "\n";
                    }
                    allPlayers += "\n---------------------------";
                    Translate.SendMessage(handler, allPlayers);

                }

                if (response == "5")
                {     
                    break;
                }
            }

        }

    }
}
