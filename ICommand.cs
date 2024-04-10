using System;
using System.Collections.Generic;
using System.Text;

namespace IFN563_Project
{
    interface ICommand : IGameElement
    {
        void Execute();
        void Undo();

    }
}
