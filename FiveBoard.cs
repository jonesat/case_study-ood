using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using static System.Array;

namespace case_study-ood
{
    class FiveBoard: IBoard
    {
        private int capacity;
        private int winPieces;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Capacity
        { 
            get { return capacity; } 
        }
        
        protected IMove[,] Positions;

        public int GetLength()
        {
            int moveCount = 0;
            for(int i =0; i < Rows; i++)
            {
                for(int j =0; j < Columns; j++)
                {
                    if (Positions[i, j] != null)
                    {
                        moveCount++;
                    }
                }
            }                       
            return moveCount;
        }

        public FiveBoard(int rows, int cols, int winPiece)
        {
            Rows = rows;
            Columns = cols;
            Positions = new IMove[rows, cols];
            capacity = rows * cols;
            winPieces = winPiece;
        }

        

        public bool ValidatePlacement(IMove move)
        {
            List<string> validHashs = ValidHashs();
            bool isValidMove = false;
            foreach(string hash in validHashs)
            {                
                if (move.GetHash() == hash)
                {
                    isValidMove = true;
                }
            }
            return isValidMove;
        }
        public void PlaceElement(IMove move)
        {            
            move.PlaceMove();            
            Positions[move.Row-1, move.Column-1] = move;        
        }
        public List<string> GetBoard()
        {
            List<string> grid = new List<string> { };
            string gridLine;
            string[] columnHeader = new string[Columns];
            for(int x = 0; x < Columns; x++)
            {
                columnHeader[x] = $"{x+1} ";
            }

            grid.Add("   "+string.Join("",columnHeader));
            for(int i = 0; i<Rows; i++)
            {
                gridLine = $"{i+1,2} ";
                for(int j = 0; j<Columns; j++)
                {
                    if (Positions[i,j]!=null)
                    {
                        gridLine+=$"{Positions[i, j].Token} ";
                    }
                    else
                    {
                        gridLine+=". ";
                    }     
                }                
                grid.Add(gridLine);
                
            }
            return grid;
        }
        public List<string> ValidHashs()
        {
            List<string> hashList = new List<string> { };
            
            for (int i = 0; i < Rows; i++)
            {   
                for (int j = 0; j < Columns; j++)
                {
                    if (Positions[i, j] == null)
                    {
                        
                        hashList.Add($"{i+1}-{j+1}");
                    }                    
                }
            }            
            return hashList;
        }
        public bool CheckVictory(IMove move)
        {
            bool isWon = false; bool keepLooking = true;
            string neighbourOwner;
            int tokensInRow; int baseRow = move.Row; int baseColumn = move.Column; int searchRow, searchColumn; int distance = 1;
            int[,] axes = new int[2, 4] { { -1, -1, 0, 1 }, { 0, 1, 1, 1 } }; // row 1 = i, rows, row 2 = j, columns
            int[] direction = new int[2] { 1, -1 };
            for (int x = 0;x < axes.GetLength(1); x++)
            {
                tokensInRow = 1;
                for (int y = 0; y < direction.Length; y++)
                {
                    do
                    {
                        searchRow = baseRow + distance*direction[y] * axes[0, x];
                        searchColumn = baseColumn + distance*direction[y] * axes[1, x];
                        //WriteLine("{0},{1} - direction {2} and axis {3}", baseRow, baseColumn, y, x);
                        
                        if (searchRow - 1 < Rows && searchRow - 1 >= 0 && searchColumn - 1 < Columns && searchColumn - 1 >= 0)
                        {
                            //WriteLine("The row is {0} and the column is {1}", searchRow, searchColumn);
                            //WriteLine("I'm searching adjacent square ({0},{1}) that is in bounds along axis {2} in direction{3}", searchRow,searchColumn, x, y);
                            //ReadKey();
                            if (Positions[searchRow - 1, searchColumn - 1] != null)
                            {
                                //WriteLine("I found a neighbour along axis {0} in direction{1}",x,y);
                                //ReadKey();
                                neighbourOwner = Positions[searchRow - 1, searchColumn - 1].Controller.Name;
                                if (move.Controller.Name == neighbourOwner)
                                {
                                    
                                    tokensInRow++;
                                    //WriteLine("There are {0} along axis {1}",tokensInRow,x);
                                    //ReadKey();
                                    distance++;
                                    keepLooking = true;
                                    if (tokensInRow == winPieces)
                                    {
                                        //WriteLine("Someone is about to win");
                                        //ReadKey();
                                        isWon = true;
                                        keepLooking = false;
                                        break;
                                    }
                                }
                                else
                                    keepLooking = false;
                            }
                            else
                                keepLooking = false;
                        }
                        else
                            keepLooking = false;
                    } while (keepLooking);
                }
                
               
            }
            return isWon;
        }

    }
}
