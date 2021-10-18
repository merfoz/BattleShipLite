using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel player1 = CreatePlayer("Player 1");
            PlayerInfoModel player2 = CreatePlayer("Player 2");

            Console.ReadLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to BattleShip Lite");
            Console.WriteLine("Created by Metin Aralioglu");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer(string playerTitle)
        {
            PlayerInfoModel output = new PlayerInfoModel();
            Console.WriteLine($"Player information for {playerTitle}");
            output.UsersName = AskForUsersName();
            GameLogic.InitializeGrid(output);
            PlaceShips(output);
            return output;
        }

        private static string AskForUsersName()
        {
            Console.WriteLine("What is your name?");
            string output = Console.ReadLine();
            return output;
        }

        private static void PlaceShips(PlayerInfoModel model)
        {
            do
            {
                Console.WriteLine($"Where do you want to place ship number {model.ShipLocations.Count + 1} : ");

                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.StoreShot(model, location);
                if (!isValidLocation)
                {
                    Console.WriteLine("That was not a valid location.Please try again");
                }

            } while (model.ShipLocations.Count<5);
        }

    }
}
