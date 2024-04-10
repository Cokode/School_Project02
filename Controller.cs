using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolProject
{
    public class Controller
    {
        private Board Board = Board.InitializeGameBoard();
        private BoardLogic BoardLogic = new BoardLogic();
        private Hero Hero = Hero.InitializeHero();
        private Queen Queen = new Queen();
        private Random rand = new();

        public Controller() { }

        public void LoadBoard()
        {
            BoardLogic.AddHero(Board.gameBoard, Hero);
            BoardLogic.AddQueen(Board.gameBoard, Queen);
            LoadWalls();
            LoadRewards();
            BoardLogic.PrintBoard(Board.gameBoard);
            
        }

        public void GenerateWalls(int row) 
        {
            char t = (row + 1) % 2 == 0 ? '-' : '|';

            Position po;
            Wall newWall;

            for (int i = 0; i < 8; i++)
            {
                do
                {
                    po = new(row, rand.Next(0, 15));
                } while (IsPositionTaken(po, t));

                bool rando = rand.Next(0, 2) == 1;

                if (rando)
                {
                    newWall = new Wall(
                     isAWall: rando,
                     position: po
                    );

                    Board.gameBoard[po.row, po.col] = t;
                    Board.walls.Add(newWall);
                } 
            }
        }

        public void LoadWalls()
        {
            int row = 0;
            do
            {
                GenerateWalls(row);
                row++;
            } while (row < Board.gameBoard.GetLength(0));
        }

        public void GenerateRewards(int row)
        {
            char t = (row + 1) % 2 == 0 ? ' ' : '$';
            Position po;
            Reward? reward;

            for (int i = 0; i < 8; i++)
            {
                do
                {
                    po = new(row, rand.Next(0, 15));
                } while (IsPositionTaken2(po));

                bool rando = rand.Next(0, 2) == 1;

                if (!(Board.gameBoard[po.row, po.col] == '|') && rando )
                {
                    reward = new Reward(
                        rewardPosition: po,
                        points: rand.Next(0, 25),
                        isHaveReward: rando
                     );

                    Board.gameBoard[po.row, po.col] = t;
                    Board.rewards.Add(reward);
                }
            }
        }
        public void LoadRewards()
        {
            int row = 0;
            do
            {
                GenerateRewards(row);
                row++;
            } while (row < Board.gameBoard.GetLength(0));
        }

        private bool IsPositionTaken2(Position position)
        {
            int column = position.col;

            // Check if the position is occupied by the hero or queen
            if ((position.row == Hero.heroPosition.row && position.col == Hero.heroPosition.col) ||
                (position.row == Queen.queenPosition.row && position.col == Queen.queenPosition.col))
            {
                return true;
            }

            // Check if the column is an odd number
            if ((column + 1) % 2 == 0)
            {
                return false;
            }

            return true;
        }

        private bool IsPositionTaken(Position position, char t)
        {
            int column = position.col;

            // Check if the position is occupied by the hero or queen
            if ((position.row == Hero.heroPosition.row && position.col == Hero.heroPosition.col) ||
                (position.row == Queen.queenPosition.row && position.col == Queen.queenPosition.col))
            {
                return true;
            }

            // Check if the column is an odd number
            if (t == '|')
            {
                if ((column + 1) % 2 == 0)
                {
                    return false;
                }
                
            } else
            {
                return false ;
            }
            

            return true;
        }


        private bool IsAdjacent(Position pos1, Position pos2)
        {
             // TODO check for index out of bound   

            int rowDiff = Math.Abs(pos1.row - pos2.row);
            int colDiff = Math.Abs(pos1.col - pos2.col);

            // Check if positions are adjacent horizontally or vertically
            return (rowDiff == 1 && colDiff == 0) || (rowDiff == 0 && colDiff == 1);
        }

        public void MovePosibility()
        {
            Console.WriteLine("Press a key (Page Up, Page Down, End, Home) or press Q to quit...");

            Wall? w;
            Position? po;
            ConsoleKeyInfo keyInfo;
           
            do
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.PageUp:
                        po = BoardLogic.SetHeroDirection(Direction.North, Hero);
                        break;
                    case ConsoleKey.PageDown:
                        po = BoardLogic.SetHeroDirection(Direction.South, Hero); 
                        break;
                    case ConsoleKey.End:
                        po = BoardLogic.SetHeroDirection(Direction.East, Hero);
                        break;
                    case ConsoleKey.Home:
                        po = BoardLogic.SetHeroDirection(Direction.West, Hero);
                        break;
                    default:
                        Console.WriteLine("You've entered the wrong key.");
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Q);

            
        }



        public void ImplementMove(Position po)
        {
            Board.gameBoard[Hero.heroPosition.row, Hero.heroPosition.col] = ' ';
            Hero.heroPosition = po;
            BoardLogic.AddHero(Board.gameBoard, Hero);
            BoardLogic.rewardAdder(BoardLogic.CheckForReward(Hero, Board.rewards), Hero);
        }

    }

}
