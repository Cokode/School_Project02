using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{

    public class BoardLogic : IBoardInterface
    {

        public void LoadBoard(char[,] gameBoard)
        {
            Console.WriteLine("          . . . . . . . . . ."); 

            for (int i = 0; i < gameBoard.GetLength(0); i++)
                {
                int innerLoop = gameBoard.GetLength(1);

                    for (int j = 0; j < innerLoop; j++)
                    {
                    char hero = gameBoard[i, j];


                    if (j == 0)
                    {
                        

                        if (hero == 'H')
                        {
                            
                            Console.Write("          ." + hero);
                        }
                        else
                        {
                           // Console.Write("    ");
                            Console.Write("          .");
                        }

                    } else if (j == innerLoop-1)
                    {
                       
                        if(hero == 'H')
                        {
                            Console.Write(hero + ".");
                        }else
                        {
                            Console.Write(" .");
                        }
                       
                    } else
                    {

                        if (hero == 'H')
                        {
                            Console.Write("   "+hero);
                        }
                        else
                        {
                            Console.Write("    ");
                        }                    
                    }
                }
                    
                 Console.WriteLine();
             }

            Console.WriteLine("          . . . . . . . . . .");
        }
         
        public void LoadWalls(Wall wall, char[,] gameBoard)
        {
            if (wall != null && gameBoard != null)
            {
                gameBoard[wall.WallPosition.col, wall.WallPosition.row] = 'H'; 
            } 
        }

        public bool CheckPosition(Wall wall, char[,] gameBoard)
        {
            int row = wall.WallPosition.row;
            int col = wall.WallPosition.col;

            return gameBoard[row, col].Equals("");
        }


    }
}
