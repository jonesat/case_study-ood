using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace case_study-ood
{
    class FiveUserCreationCommand : ICommand
    {
        IGameElementFactory tgef;
        int turn;
        string title;
        public FiveUserCreationCommand(IGameElementFactory gef,int turn,string title)
        {
            this.tgef = gef;
            this.turn = turn;
            this.title = title;
        }
        public void Execute()
        {
            Menu usermenu = tgef.CreateMenu("FiveUserCreationMenu",title);
            this.tgef.CreateUser(turn,usermenu);
        }
        public void Undo()
        {
            WriteLine("I Have Undone.");
        }
    }
}
