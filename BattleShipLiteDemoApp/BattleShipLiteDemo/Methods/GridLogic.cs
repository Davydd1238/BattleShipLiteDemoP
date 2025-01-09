using BattleShipLibrary.Methods;
using BattleShipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipLiteDemo.Methods
{
    public static class GridLogic
    {
        public static void DisplayShotGrid(PlayerModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" { gridSpot.SpotLetter }{ gridSpot.SpotNumber } ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write("X ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write("O ");
                }
                else if (gridSpot.Status == GridSpotStatus.Sunk)
                {
                    Console.Write("S ");
                }
                else
                {
                    Console.WriteLine("??");
                }
            }
        }

        public static void RecordPlayerShot(PlayerModel activePlayer, PlayerModel opponent)
    {
            bool isValidShot = false;
            string row = "";
            int column = 0;
        do
        {
                string shot = GridLogic.AskForShot($"{activePlayer.PlayerName}");

                try
                {
                    (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);

                    isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    isValidShot =false;
                }

                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid shot location. Please try again!");
                }

        } while (isValidShot == false);
            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);
            
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);
            GameLogic.DisplayShotResult(isAHit);
    }

        private static string AskForShot(string playerTitle)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"{playerTitle} Please enter your shot selection: ");
            string output = Console.ReadLine();

            return output;
        }
    }
}
