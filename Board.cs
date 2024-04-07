using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public class Board
    {
        public char[,] gameBoard { get; set; }
        public List<Wall> walls { get; set; }
        public List<Reward> rewards { get; set; }
        private static Board? board;

        private Board() {
            gameBoard = new char[6, 6];
            rewards = []; // simplified initialization
            walls = []; // simplified initialization
        }

        public static Board InitializeGameBoard()
        {
            board ??= new Board();
            return board;
        }
    }
}
