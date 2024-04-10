using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;


namespace IFN563_Project
{
    class FiveGame: Game
    {
        // Game Attributes
        readonly string gameName = "Gomoku";
        readonly int winPieces = 5;

        // Player Definitions for Gomoku
        readonly int participantCount = 2;
        readonly string[] types = { "Human", "Computer" };


        // Board Definitions for Tic-Tac-Toe
        readonly int rows= 15;
        readonly int columns = 15;

        // Game State Information
        private User activeUser;
        private int turnCount;
        private User victor;
                
        // Factory
        FiveGameElementFactory fivegef;

        // Created Things
        User[] participants;
        IBoard gameBoard;
        FiveTurnMenu turnmenu;
        FiveUserCreationMenu usermenu;
        List<IMove> moveList = new List<IMove>();

        public override void MakeMaker()
        {
            // This function creates an instance of the Abstract Factory derived for this game.
            // Additionally this factory is kept as a game parameter for later use.
            fivegef = new FiveGameElementFactory(gameName, participantCount, types, winPieces);
        }
        public override void MakeMenus()
        {
            // This function makes a set of menus, assigns them titles and then adds them to the game properties for later use.
            // Here we make the user menu which will display during character creation.
            string userMenuTitle = $"{gameName} Character Creation";
            usermenu = (FiveUserCreationMenu)fivegef.CreateMenu("User", userMenuTitle);

            // Here we make the turn menu which will display during the turn proper.
            string turnMenuTitle = $"{gameName} - Let's Play";
            turnmenu = (FiveTurnMenu)fivegef.CreateMenu("Turn", turnMenuTitle);
        }
        public override void RunGame()
        {
            //This method creates the elements needed to make the game and then begins the game.
            MakeMaker();
            MakeMenus();
            gameBoard = fivegef.CreateBoard(rows, columns);
            participants = CreateParticipants();
            GameLoop();
        }


        public override User[] CreateParticipants()
        {
            // This function creates the new participant users in the game and out puts the created users.
            User[] users = new User[participantCount];
            
            // Looping over the total number of players to create all necessary users
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = fivegef.CreateUser(i+1,usermenu);
            }
            return users;

        }
        public override void GameLoop()
        {
            // Initialize Game instance parameters.
            turnCount = 1; activeUser = participants[0]; FiveMove aMove,tempMove;
            List<string> boardgraphic = gameBoard.GetBoard(); 
            bool isValidMove, isWon;
                       

            do
            {
                StartTurn(boardgraphic);
                //do
                do
                {                    
                    tempMove = UserTurn(gameBoard,out isValidMove);
                } while (!isValidMove && gameBoard.GetLength() < gameBoard.Capacity);
                aMove = tempMove;
                moveList.Add(aMove);
                gameBoard.PlaceElement(moveList[turnCount-1]);
                boardgraphic = gameBoard.GetBoard();
                isWon = gameBoard.CheckVictory(aMove);
                //while(isn't placed)

                if (isWon)
                {
                    
                    turnmenu.GetGraphic(boardgraphic);
                    turnmenu.DisplayMenu();
                    victor = aMove.Controller;
                }
                
                SetActiveUser(ref activeUser, participants);
                turnCount++;
            } while (gameBoard.GetLength() < gameBoard.Capacity && !isWon);
            EndOfGame(isWon);           
        }
        public void SetActiveUser(ref User activeUser,User[] participants)
        {
            if(activeUser == participants[0])
            {
                activeUser = participants[1];
            }
            else
                activeUser = participants[0];

        }
        public override void StartTurn(List<string> boardgraphic)
        {
            // This function should probably live inside of the turn menu but its purpose is to load up the menu with content to display and welcome the user to their turn.
            string menusubtitle = $"It is turn {turnCount} and it is {activeUser.Name}'s turn - {activeUser.Name} uses the '{activeUser.Token}' token";
            turnmenu.GetSubTitle(menusubtitle);
            turnmenu.AccumulateContent($"Press enter to start your turn, {activeUser.Name}");
            turnmenu.GetGraphic(boardgraphic);
            turnmenu.DisplayMenu();
        }
        public override FiveMove UserTurn(IBoard gameBoard, out bool isValidMove)
        {
            List<string> validHashs = gameBoard.ValidHashs();
            FiveMove aMove = (FiveMove)fivegef.CreateMove(turnmenu, this.activeUser, turnCount, validHashs);
            //WriteLine("Move: ({0},{1})", aMove.Row, aMove.Column);
            //ReadKey();
            isValidMove = gameBoard.ValidatePlacement(aMove);
            if (!isValidMove)
            {
                turnmenu.AccumulateContent($"Error: {this.activeUser.Name}'s move ({aMove.Row},{aMove.Column}) is invalid try one of the following row-column pairs:");
                turnmenu.AccumulateContent(String.Join(',', validHashs));
            }
            return aMove;
        }
        public override void EndOfGame(bool isWon)
        {
            if (gameBoard.GetLength() == gameBoard.Capacity && !isWon)
            {
                WriteLine("Draw");
                ReadKey();
                System.Environment.Exit(0);
            }
            else if (gameBoard.GetLength() <= gameBoard.Capacity && isWon)
            {
                WriteLine("Victory for {0}", victor.Name);
                ReadKey();
                System.Environment.Exit(0);
            }
        }

    }
}
