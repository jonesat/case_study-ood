using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace IFN563_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameFactory fivefactory = new FiveFactory();
            Game afivegame = fivefactory.CreateGame();
            afivegame.RunGame();
            ReadKey();
        }
    }
}
