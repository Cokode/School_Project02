using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public interface IBoardInterface
    {

        public void AddQueen(char[,] gameBoard, Queen queen);
        public void AddHero(char[,] gameBoard, Hero hero);
        public int CheckForReward(Hero hero, List<Reward> rewards);
        public bool CheckForWall(List<Wall> walls, Position position);
        public bool ValidateCurrentIndex(Position position);
        public bool IsWallExist(Position newPosition, List<Wall> walls);
        public Position? SetHeroDirection(Direction direction, Hero hero);
        public void AddPiece(char[,] gameBoard, Position position, char symbol);

    }
}
