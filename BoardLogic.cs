using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{

    public class BoardLogic : IBoardInterface
    {

       
        public void PrintBoard(char[,] gameBoard)
        {
            const string horizontalLine = "              . . . . . . . . . . . . . . . . . . . . . . . .";
            Console.WriteLine();   
            Console.WriteLine(horizontalLine);

            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                Console.Write("              .");

                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    char hero = gameBoard[i, j];
                    char displayChar = ' ';

                    if (hero == 'H' || hero == 'Q' || hero == '$' || hero == '|' || hero == '-')
                    {
                        displayChar = hero;
                    }

                    Console.Write($" {displayChar} ");

                    if (j == gameBoard.GetLength(1) - 1)
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(horizontalLine);
        }


        public void AddPiece(char[,] gameBoard, Position position, char symbol)
        {
            if (gameBoard != null)
            {
                gameBoard[position.row, position.col] = symbol;
            }
        }

        public void AddHero(char[,] gameBoard, Hero hero)
        {
            AddPiece(gameBoard, hero.heroPosition, 'H');
        }

        public void AddQueen(char[,] gameBoard, Queen queen)
        {
            AddPiece(gameBoard, queen.queenPosition, 'Q');
        }


        public Position? SetHeroDirection(Direction direction, Hero hero)
        {
            int row = hero.heroPosition.row;
            int column = hero.heroPosition.col;

            Position? newPosition = direction switch
            {
                Direction.North => new Position(--row, column),
                Direction.South => new Position(++row, column),
                Direction.West => new Position(row, --column),
                Direction.East => new Position(row, ++column),
                _ => null,
            };

            return newPosition;
        }

        public bool IsWallExist(Position newPosition, List<Wall> walls)
        {     
            return CheckForWall(walls, newPosition);
        }


        public bool ValidateCurrentIndex(Position position)
        {
            return (position.row) >= 0 && (position.row < 21)
                && (position.col >= 0 && position.col < 15);
        }


        public bool CheckForWall(List<Wall> walls, Position position)
        {
            foreach (var wall in walls.ToList()) // Iterate over a copy to allow removal
            {
                if (wall.wallType == ' ')
                {
                    Console.WriteLine("Wall with no type");
                    walls.Remove(wall);
                    continue; // Skip to the next iteration
                }

                if (wall.WallPosition.Equals(position))
                {
                    Console.Write($"         There is a wall. | " +
                        $"Press `Enter` to break wall with 5 points");
                    return true;
                }
            }
            return false;
        }


        public int CheckForReward(Hero hero, List<Reward> rewards)
        {
            foreach (var item in rewards.ToList())
            {
                if (item.rewardPosition.Equals(hero.heroPosition))
                {
                    rewards.Remove(item);
                    return item.points;
                }
            }
            return 0;
        }

        public void CheckforWinning(List<Reward> rewards, Queen queen, Hero hero)
        {
            int count = rewards.Count;
            if ((queen.queenPosition == hero.heroPosition) && !queen.queenIsCaptured)
            {
                Console.Write($"         You've captured the queen! You may press Q to end Game now. Total points earned: {hero.points}. ");
                queen.queenIsCaptured = true;
            }
        }


    }
}

