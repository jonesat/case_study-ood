using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace IFN563_Project
{
     class FiveFactory: IGameFactory
    {
        public Game CreateGame()
        {
            Game fiveGame = new FiveGame();
            return fiveGame;
        }

    }
}
