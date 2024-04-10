using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace IFN563_Project
{
    public abstract class User: IGameElement
    {
        protected string usertype;
        protected const char PONE = 'O';
        protected const char PTWO = 'X';
        protected char token;
        protected int position;
        public string Name { get; set; }
        bool ActivePlayer { get; set; } = false;
        public int Position
        {
            get
            {
                return position;
            }
            
        }
        public char Token 
        { 
            get
            {
                return token; 
            }
        }
        public virtual string UserType { get; }


        protected User(string name,int pos)
        {
            //Validate input function needed
            Name = name;
            position = pos;
            
            if (pos == 1)
            {
                this.token = PONE;

            }
            else if (pos == 2)
            {
                this.token = PTWO;
            }
        }

        public virtual string AnnounceSelf()
        {
            return $"My name is: " + this.Name;
        }

        
    }
}
