using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace IFN563_Project
{
    abstract class ComputerUser : User
    {
        protected string usertype = "Computer";
        
        public ComputerUser(string name, int pos) : base(name, pos) { }
        public override string AnnounceSelf()
        {
            return $"My name is: " + this.Name + " and I am a " + this.usertype + " player - Press enter to continue";
        }
        public virtual int[] MakeValidSelection(List<string> hashList)
        {
            const string DASH = "-";
            string hash;
            var random = new Random();
            int index = random.Next(hashList.Count);
            
            hash = hashList[index];
            
            int[] outputs = new int[2];
            for(int i =0; i < outputs.Length; i++)
            {
                outputs[i] = int.Parse(hash.Split(DASH)[i]);
            }           
            
            return outputs;


        }
    }
}
