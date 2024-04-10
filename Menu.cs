using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;


namespace IFN563_Project
{
    public abstract class Menu : IGameElement
    {
        protected const string LINE = "________________________________________________________________________________________________________________________";
        protected const string EDGE = "\n|                                                                                                     |";
        protected List<string> content = new List<string>();
        protected string title;
        protected string subtitle;

        public string DisplayMenu()
        {
            string input;
            Clear();
            WriteLine(LINE);
            WriteTitle();
            WriteSubTitle();
            input = GetContent();

            this.content = new List<string>();
            return input;

        }
        public virtual void WriteTitle()
        {
            string title = "- - - " + this.title + " - - -";
            WriteLine("\n{0,-75}",title);
            WriteLine("\n{0}", LINE);
        }
        public virtual void WriteSubTitle()
        {
            string subtitle = "--- " + this.subtitle + " ---";
            WriteLine("\n{0,-75}",subtitle);
            WriteLine("\n{0}", LINE);
        }

        public virtual void GetTitle(string input)
        {
            this.title = input;
        }
        public virtual void GetSubTitle(string input)
        {
            this.subtitle = input;
        }
        
        //protected abstract void GetMenuItems(ISelectable selectable);
        protected virtual string GetContent()
        {
            string input;
            Write("\n");
            foreach (string i in content)
            {
                WriteLine(i);
            }
            WriteLine(LINE);
            input = Prompt();
            return input;
        }
        public virtual string Prompt()
        {
            string input;
            Write("\n{0,45}",">>");
            input = ReadLine();
            return input;
        }
        public void AccumulateContent(string newcontent)
        {
            this.content.Add(newcontent);
        }


    }
}
