using BattleShipLibrary.Models;
using BattleShipLibrary.Methods;
using BattleShipLiteDemo.Methods;
using System.Numerics;
using System.Security.Cryptography;

UserMessages.WelcomeMessage();

PlayerModel activePlayer = UserMessages.CreatePlayer("Player 1");
PlayerModel opponent = UserMessages.CreatePlayer("Player 2");

PlayerModel winner = null;

do
{
    GridLogic.DisplayShotGrid(activePlayer);
   
    GridLogic.RecordPlayerShot(activePlayer, opponent);

    bool doesGameContinue = GameLogic.PlayerStillActive(activePlayer);

    if (doesGameContinue)
    {
        (activePlayer, opponent) = (opponent, activePlayer);
    }
    else
    {
        winner = activePlayer;
    }
    
} while (winner == null);
UserMessages.IdentifyWinner(winner);





Console.ReadLine();