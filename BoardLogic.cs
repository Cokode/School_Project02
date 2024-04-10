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


        public void AddWall(List<Wall> walls, char[,] gameBoard)
        {
            foreach (var item in walls)
            {
                gameBoard[item.WallPosition.row, item.WallPosition.col] = '^';
            }
        }

        public void AddHero(char[,] gameBoard, Hero hero)
        {
            if (gameBoard != null)
            {
                gameBoard[hero.heroPosition.row,
                    hero.heroPosition.col] = 'H';
            }
        }

        public void AddQueen(char[,] gameBoard, Queen queen)
        {
            if (gameBoard != null && queen != null)
            {
                gameBoard[queen.queenPosition.row, queen.queenPosition.col] = 'Q';
            }
        }

        public bool CheckPosition(Wall wall, char[,] gameBoard)
        {
            int row = wall.WallPosition.row;
            int col = wall.WallPosition.col;

            return gameBoard[row, col].Equals("");
        }

        public void LoadReward(List<Reward> rewards, char[,] gameBoard)
        {
            foreach (var item in rewards)
            {
                gameBoard[item.rewardPosition.row, item.rewardPosition.col] = '+';
            }
        }

        public void HeroMove(Hero hero, char[,] gameBoard)
        {
            Position heroPosition = hero.heroPosition;
            if (heroPosition != null) { }
        }

        public Position SetHeroDirection(Direction direction, Hero hero)
        {
            Position? po;
            int row = hero.heroPosition.row;
            int column = hero.heroPosition.col;

            switch (direction)
            {
                case Direction.North:
                    row -= 2;
                    po = new Position(row, column);
                    break;

                case Direction.South:
                    row += 2;
                    po = new Position(row, column);
                    break;
                case Direction.West:
                    column -= 2;
                    po = new Position(row, column);
                    break;
                case Direction.East:
                    column += 2;
                    po = new Position(row, ++column);
                    break;

                default:
                    po = null;
                    break;
            }

            return po;
        }


        public bool validMoveIndex(Position position)
        {
            return (position.row < 6 && position.row >= 0) 
                && (position.col >= 0 && position.col < 6);
        }


        public void implementMove(Hero hero, char direction, List<Wall> walls) {


        }


        public Wall CheckForWall(List<Wall> walls, Position position) // should take hero position as parameter
        {
            Wall? wall = null;

            foreach (var item in walls)
            {
                if (item.WallPosition.Equals(position))
                {
                    wall = item; break;
                }
            }
            return wall;
        }

        public bool CheckBlockedArea(Wall wall, char directionToGo) // checks for what direction is blocked
        {
            var direction = directionToGo switch
            {
                'U' => wall.isAWall,
                //'D' => wall.isDown,
                //'L' => wall.isLeft,
                //'R' => wall.isRight,
                _ => false,
            };
            return direction;
        }


        public int CheckForReward(Hero hero, List<Reward> rewards) // check position for reward and return reward point
        {
            int point = 0;

            foreach (var item in rewards)
            {
                if (item.rewardPosition.Equals(hero.heroPosition))
                {
                    point = item.points;
                    rewards.Remove(item);
                    break;
                }
            }
            return point;
        }
        public void rewardAdder(int points, Hero hero)
        {
            hero.points += points;
            Console.WriteLine($"{points} added to Hero ");
        }
    }
}

