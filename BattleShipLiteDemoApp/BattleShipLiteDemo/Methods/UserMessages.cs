using BattleShipLibrary.Methods;
using BattleShipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BattleShipLiteDemo.Methods
{
    public static class UserMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("*******WELCOME TO BATTLESHIP LITE******");
            Console.WriteLine("This version is created by David Latour");
            Console.WriteLine("***************************************");
            Console.WriteLine("RULES: EACH PLAYER WILL RECEIVE 5 SHIPS");
            Console.WriteLine("****** ONCE A PLAYER HAS NO SHIPS****** ");
            Console.WriteLine("*********THE GAME WILL END************");
            Console.WriteLine("********PRESS ENTER TO CONTINUE********");
            Console.ReadLine();
            Console.Clear();
        }
        public static PlayerModel CreatePlayer(string playerTitle)
        {
            PlayerModel output = new PlayerModel();

            Console.WriteLine($"Player informations for {playerTitle}");

            output.PlayerName = GetPlayerName();

            GameLogic.InitializeGrid(output);
            
            PlaceShips(output);

            Console.Clear();

            return output;
        }
        private static string GetPlayerName()
        {

            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }
        private static void PlaceShips(PlayerModel model)
        {
            do
            {
                Console.Write($"Where do you want to place ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(model, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("That was not a valid location. Please try again!");
                }
            } while (model.ShipLocations.Count < 5);
        }

        public static void IdentifyWinner(PlayerModel winner)
        {
            Console.WriteLine($"Congratulations {winner.PlayerName} for winning");
            Console.WriteLine($"{winner.PlayerName} took {GameLogic.GetShotCount(winner)} shots");
        }
    }
}
