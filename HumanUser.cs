using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace IFN563_Project
{
    public abstract class HumanUser:User
    {
        protected string usertype = "Human";
        
        public HumanUser(string name, int pos) : base(name, pos) { }
        public override string AnnounceSelf()
        {
            return $"My name is: " + this.Name + " and I am a " + this.usertype +" player - Press enter to continue";
        }
    }
    
}
