using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;


namespace IFN563_Project
{
    class FiveGameElementFactory : IGameElementFactory
    {
        // Creation Parameters
        private string gameName;
        private int playerCount;
        private string[] playerTypes;
        private int winPieces;

        
        public FiveGameElementFactory(string gameName, int playerCount, string[] types, int winPieces)
        {
            this.gameName = gameName;
            this.playerCount = playerCount;
            this.playerTypes = types;
            this.winPieces = winPieces;

        }
        public User CreateUser(int position, Menu usermenu)
        {
            User userOut;
            bool isValidInput, isValidType = false;
            int inputType;
            string rawInput,inputName;
            
            do
            {
                usermenu.GetSubTitle($"For player in position {position}. please input a valid number to set them to the corresponding type:");
                DisplayUserTypes(playerTypes, usermenu);
                rawInput = usermenu.DisplayMenu();
                isValidInput = int.TryParse(rawInput, out inputType);

                if (!isValidInput)
                {
                    usermenu.AccumulateContent("\nError, please enter a valid user type");
                }
                else if(isValidInput && (inputType!=1 && inputType != 2))
                {
                    usermenu.AccumulateContent("\nError, please enter a valid user type");
                }
                else
                {
                    isValidType = true;
                }
                    
            } while (!(isValidInput&&isValidType));
            usermenu.GetSubTitle($"Thank you for assigning player {position} a type.");
            usermenu.AccumulateContent($"Player {position}, please enter your name: ");
            inputName = usermenu.DisplayMenu();
            
            if (inputType == 1)
            {
                userOut = new FiveHumanUser(inputName, position);
                usermenu.GetSubTitle("The new player is:");
                usermenu.AccumulateContent(userOut.AnnounceSelf());
                rawInput = usermenu.DisplayMenu();
                //ReadKey();
                return userOut;

            }
            else 
            {
                userOut = new FiveComputerUser(inputName, position);
                usermenu.AccumulateContent(userOut.AnnounceSelf());
                rawInput = usermenu.DisplayMenu();
                //ReadKey();
                return userOut;
            }
           

        }
        public void DisplayUserTypes(string[] types, Menu usermenu)
        {
            string newcontent;
            for (int j = 0; j < types.Length; j++)
            {
                newcontent= $"Type: [{j+1}] {types[j],-8}";
                usermenu.AccumulateContent(newcontent);
            }
            
        }

        public IBoard CreateBoard(int rows, int columns)
        {
            IBoard gameboard = new FiveBoard(rows, columns,winPieces);
            return gameboard;
        }
        
        public Menu CreateMenu(string menuType, string title)
        {
            if (menuType == "User") {
                FiveUserCreationMenu usermenu = new FiveUserCreationMenu();
                usermenu.GetTitle(title);
                return usermenu;
            }
            else if(menuType == "Turn")
            {
                FiveTurnMenu turnmenu = new FiveTurnMenu();
                turnmenu.GetTitle(title);
                return turnmenu;
            }
            else
            {
                Menu usermenu = new FiveUserCreationMenu();
                return usermenu;
            }

            

        }
        public IMove CreateMove(Menu turnMenu, User user, int turnNumber, List<string> validHashs)
        {
            if (user.UserType == "Human")
            {
                int[] input = new int[2];
                string[] dimensions = new string[2] { "row", "column" };
                for (int i = 0; i < dimensions.Length; i++)
                {
                    do
                    {
                        turnMenu.AccumulateContent($"Enter the {dimensions[i]} number where you would like to place your piece: ");
                    } while (!int.TryParse(turnMenu.DisplayMenu(), out input[i]));
                }

                //do { WriteLine("Enter the column number: "); } while (!int.TryParse(ReadLine(), out inputCol));
                IMove usermove = new FiveMove(input[0], input[1], user, turnNumber);
                return usermove;
            }
            else if( user.UserType == "Computer")
            {
                //WriteLine("I am thinking about what move to make...");
                //foreach(string item in validHashs)
                // {
                 //   WriteLine(item);
                // }
                
                ComputerUser temp = (ComputerUser)user;
                int[] input = temp.MakeValidSelection(validHashs);
                //WriteLine("A valid move is: ({0},{1})", input[0], input[1]);
                IMove usermove = new FiveMove(input[0], input[1], user, turnNumber);
                //WriteLine($"The move I will make is row {usermove.Row}, column {usermove.Column}.");
                //ReadKey();
                return usermove;
            }
            else
            {
                turnMenu.AccumulateContent($"It is unclear what kind of player should be acting here a move will be made at random for {user.Name}.");
                turnMenu.DisplayMenu();
                string hash;
                var random = new Random();
                int index = random.Next(validHashs.Count);
                hash =validHashs[index];
                int[] outputs = new int[hash.Length];
                for (int i = 0; i < hash.Length; i++)
                {
                    outputs[i] = hash[i];
                }
                IMove usermove = new FiveMove(outputs[0], outputs[1], user, turnNumber);
                return usermove;
            }




        }
        //public ICommand CreateCommand() { }
        //public ISelectable CreateSelectable(){}
    }
}
