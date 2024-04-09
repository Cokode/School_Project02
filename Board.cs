using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public class Board
    {
        public char[,] gameBoard {get;}
        public List<Wall> walls { get; set; }
        public List<Reward> rewards { get; set; }
        private static Board? board;
        private Queen? Queen {get;}

        private Board() {
            gameBoard = new char[18, 9];
            rewards = []; // simplified initialization
            walls = []; // simplified initialization
            Queen = new Queen();
        }

        public static Board InitializeGameBoard()
        {
            board ??= new Board();
            return board;
        }
    }
}
