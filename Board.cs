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
        public List<Wall> walls { get;}
        public List<Reward> rewards { get;}
        private static Board? board;
        private Queen? Queen {get;}

        private Board() {
            gameBoard = new char[21, 15];
            rewards = []; 
            walls = [];
            Queen = new Queen();
        }

        public static Board InitializeGameBoard()
        {
            board ??= new Board();
            return board;
        }
    }
}
