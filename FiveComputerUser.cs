using System;
using System.Collections.Generic;
using System.Text;

namespace case_study-ood
{
    class FiveComputerUser : ComputerUser
    {
        //private string usertype = "Computer";
        public override string UserType { get { return usertype; } }
        public FiveComputerUser(string name, int pos) : base(name, pos) { }



    }
}
