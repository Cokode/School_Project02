using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    internal class Board
    {

        //char[,] Board { set; get; }
        List<Wall> Walls { get; set; }
        private static Board? gameBoard;

        public Board() {}

        public static Board InitializeGameBoard()
        {
          
            if(gameBoard == null )
            {
                gameBoard = new Board();
            }

            return gameBoard;

        }



    }
}
