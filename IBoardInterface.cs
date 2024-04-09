using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public interface IBoardInterface
    {
        // Hero hero, char[,] board, Queen queen, Reward reward than the market that we make. 
        //public void LoadBoard(char[,] gameBaord); //
        public void AddWall(List<Wall> walls, char[,] gameBaord);
        public bool CheckPosition(Wall wall, char[,] gameBoard);
        public void AddQueen(char[,] gameBoard, Queen queen);


    }
}
