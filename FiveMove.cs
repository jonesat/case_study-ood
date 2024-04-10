using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;


namespace case_study-ood
{
    class FiveMove:IMove
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Token { get; set; }
        public User Controller { get; set; }

        private int turn_created;
        public int Turn_Created
        {
            get
            {
                return this.turn_created;
            }
        }

        private bool isplaced;
        public bool IsPlaced
        {
            get
            {
                return this.isplaced;
            }
        }
        public FiveMove(int row, int col, User user, int turn)
        {
            this.Row = row;
            this.Column = col;
            this.Token = user.Token;
            this.Controller = user;
            this.turn_created = turn;         

        }
        public void PlaceMove()
        {
            this.isplaced = true;
        }
        public void UnPlaceMove()
        {
            this.isplaced = false;
        }
        public string GetHash()
        {
            string hash = $"{this.Row}-" +
                $"{this.Column}";
            return hash;
        }

    }
}
