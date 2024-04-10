using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace IFN563_Project
{
    abstract class Game
    {
        // Game Attributes
        readonly string gameName;
        readonly int winPieces;

        // Player Definitions for Game
        readonly int participantCount;
        readonly string[] types;

        // Board Definitions for Game
        readonly int rows;
        readonly int columns;

        // Game State use array.Append(obj).ToArray
        // Game State use array.Append(obj).ToArray
        IMove[] movesList;
        public abstract void RunGame();
        public abstract void MakeMaker();
        public abstract void MakeMenus();

        
        public abstract User[] CreateParticipants();
        public abstract void GameLoop();
        public abstract void StartTurn(List<string> boardgraphic);
        public abstract FiveMove UserTurn(IBoard gameBoard, out bool isValidMove);
        public abstract void EndOfGame(bool isWon);



    }
}
