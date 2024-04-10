using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace case_study-ood
{
   
    class FiveHumanUser: HumanUser
    {
        //private string usertype = "Human";
        public override string UserType { get { return usertype; } }
        public FiveHumanUser(string name, int pos) : base(name, pos) { }

    }

}
