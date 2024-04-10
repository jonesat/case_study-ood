using System;
using System.Collections.Generic;
using System.Text;

namespace case_study-ood
{
    interface ICommand : IGameElement
    {
        void Execute();
        void Undo();

    }
}
