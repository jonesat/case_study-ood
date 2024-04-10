using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace case_study-ood
{
    interface IGameElementFactory
    {
        public IBoard CreateBoard(int rows, int cols,int winPieces)
        {
            IBoard Board = new FiveBoard(rows, cols, winPieces);
            return Board;
        }

        User CreateUser(int position, Menu menu);

        Menu CreateMenu(string type,string title);
        IMove CreateMove(Menu turnMenu,User user, int turnNumber, List<string> validHashs);

        //ICommand CreateCommand();
        //ISelectable CreateSelectable();
        






    }
}
