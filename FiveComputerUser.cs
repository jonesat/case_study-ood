using System;
using System.Collections.Generic;
using System.Text;

namespace IFN563_Project
{
    class FiveComputerUser : ComputerUser
    {
        //private string usertype = "Computer";
        public override string UserType { get { return usertype; } }
        public FiveComputerUser(string name, int pos) : base(name, pos) { }



    }
}
