using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace case_study-ood
{
    interface IBoard: IGameElement
    {
        int Capacity { get; }
       
        bool ValidatePlacement(IMove move);
        void PlaceElement(IMove move);
        public bool CheckVictory(IMove move);
        List<string> GetBoard();
        int GetLength();

        List<string> ValidHashs();

    }
}
