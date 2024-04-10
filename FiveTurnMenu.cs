using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace case_study-ood
{
    class FiveTurnMenu : Menu
    {
        List<string> boardGraphic;
        public void GetGraphic(List<string> graphic)
        {
            this.boardGraphic = graphic;
        }
        protected override string GetContent()
        {
            string input;
            Write("\n");
            foreach (string i in content)
            {
                WriteLine(i);
            }
            Write("\n");
            foreach (string i in this.boardGraphic)
            {
                WriteLine("{0,-40}",i);
            }

            WriteLine(LINE);
            input = Prompt();
            return input;
        }
        /*public override void WriteTitle()
        {
            string title = "- - - " + this.title + " - - -";
            WriteLine($"\n{title,-75}");
            WriteLine("\n{0}", LINE);
        }
        public override void WriteSubTitle()
        {
            string subtitle = "--- " + this.subtitle + " ---";
            WriteLine($"\n{subtitle,-75}");
            WriteLine("\n{0}", LINE);
        }*/
    }
}
