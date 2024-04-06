using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public interface IBoardInterface
    {
        // Hero hero, char[,] board, Queen queen, Reward reward
        public void LoadBoard(char[,] gameBaord);
        public void LoadWalls(Wall wall, char[,] gameBaord);

        public bool CheckPosition(Wall wall, char[,] gameBoard);


    }
}
