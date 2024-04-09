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
            GenerateWalls(10);
            GenerateRewards(12);
            BoardLogic.LoadReward(Board.rewards, Board.gameBoard);
            BoardLogic.PrintBoard(Board.gameBoard);
            
        }

        //public void printBoard()
        //{
        //    BoardLogic.PrintBoard(Board.gameBoard);
        //}

        public void GenerateWalls(int row) 
        {
            _ = row % 2 == 0 ? '-' : '|';
            Position po;
            Wall newWall;

            for (int i = 0; i < 8; i++)
            { 
                do
                {
                    po = new(row, rand.Next(0, 11));
                } while (IsPositionTaken(po));

                    newWall = new Wall(
                    isAWall: rand.Next(0, 2) == 1,
                    position: po
                );

                Board.gameBoard[po.row, po.col] = newWall.wallType;
                Board.walls.Add(newWall);
            }
        }

        public void GenerateRewards(int numberOfReward)
        {
            Position po;
            Random rand = new Random();
         
            for (int i = 0; i < numberOfReward; i++)
            {
               
                do
                {
                    po = new(rand.Next(0, 18), rand.Next(0, 8));
                } while (IsPositionTaken2(po, Board.rewards));

                Reward reward = new Reward(
                     rewardPosition: po,
                     points: rand.Next(5, 20)
                 );

                Board.rewards.Add(reward);
            }

            Reward reward2 = new Reward(
                     rewardPosition: new Position(1, 0),
                     points: rand.Next(5, 20)
                 );

            Board.rewards.
                Add(reward2);
        }

        private bool IsPositionTaken2(Position position, List<Reward> rewards)
        {
            if ((position.row == 0 && position.col == 0) ||
                (position.row == 17 && position.col == 8)) return true; // ensure there is no wall in the hero start index

            foreach (var re in rewards)
            {
                if (re.rewardPosition == position)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPositionTaken(Position position)
        {
            int column = position.col;

            // Check if the position is occupied by the hero or queen
            if ((position.row == Hero.heroPosition.row && position.col == Hero.heroPosition.col) ||
                (position.row == Queen.queenPosition.row && position.col == Queen.queenPosition.col))
            {
                return true;
            }

            // Check if the column is an odd number
            if (column % 2 != 0)
            {
                return true;
            }

            return false;
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
            Position po;
            ConsoleKeyInfo keyInfo;
            
            do
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.PageUp:
                        po = BoardLogic.SetHeroDirection(Direction.North, Hero);
                        if (BoardLogic.validMoveIndex(po))
                        {
                            w = BoardLogic.CheckForWall(Board.walls, Hero.heroPosition);
                            if (w != null) // there is a wall 
                            {
                                if (BoardLogic.CheckBlockedArea(w, 'U'))
                                {
                                    // not a possible move. 
                                }
                                else
                                {
                                    // is a possible move
                                    ImplementMove(po);
                                }
                            }
                            else // there is no wall 
                            {
                                ImplementMove(po);
                            }
                        }
                        else
                        {
                            Console.WriteLine("This direction is not possible.");
                        }

                        break;

                    case ConsoleKey.PageDown: break;
                    case ConsoleKey.End: break;
                    case ConsoleKey.Home: break;
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
