using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    internal class Board
    {
        private char[,] gameBoard;
        private List<Wall> walls { get; set; }
        private static Board? board;

        public Board() {
            gameBoard = new char[6, 6];
        }

        public static Board InitializeGameBoard()
        {
          
            if(board == null )
            {
                board = new Board();
            }

            return board;

        }
    }
}
