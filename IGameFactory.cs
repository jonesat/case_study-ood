using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;


namespace IFN563_Project
{
    interface IGameFactory
    {
        public Game CreateGame();

    }
}
