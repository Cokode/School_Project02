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
            MovePosibility();  
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
                     position: po,
                     wallType: t
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

        public void MovePosibility()
        {
            Console.WriteLine("Press a key (Page Up, Page Down, End, Home) or press Q to quit...");
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                Console.Clear();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.PageUp:

                        MoveAndPlay(Direction.North);
                        break;
                    case ConsoleKey.PageDown:
                        MoveAndPlay(Direction.South);
                        break;
                    case ConsoleKey.End:
                        MoveAndPlay(Direction.East);
                        break;
                    case ConsoleKey.Home:
                        MoveAndPlay(Direction.West);
                        break;
                    case ConsoleKey.Enter:
                        BreakAWall();
                        BoardLogic.PrintBoard(Board.gameBoard);
                        break;
                    default:
                        BoardLogic.PrintBoard(Board.gameBoard);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Q);

            //
        }

        public void MoveAndPlay(Direction newDirection)
        {
            Position newPosition = BoardLogic.SetHeroDirection(newDirection, Hero);

            if (newPosition == null || !BoardLogic.ValidateCurrentIndex(newPosition))
            {
                BoardLogic.PrintBoard(Board.gameBoard);
                return;
            }

            if (!BoardLogic.IsWallExist(newPosition, Board.walls))
            {
                UpdateHeroPosition(newPosition);
                RewardAdder();
            }

            Hero.wallToBreak = newPosition;
            BoardLogic.PrintBoard(Board.gameBoard);
        }

        private void UpdateHeroPosition(Position newPosition)
        {
            Board.gameBoard[Hero.heroPosition.row, Hero.heroPosition.col] = ' ';
            Hero.heroPosition = newPosition;
            Board.gameBoard[Hero.heroPosition.row, Hero.heroPosition.col] = 'H'; // update hero position on gameBoard
        }

        public void RewardAdder() 
        {
            int newPoints = BoardLogic.CheckForReward(Hero, Board.rewards);
            Hero.points += newPoints;
            RewardStatement(newPoints);
            BoardLogic.CheckforWinning(Board.rewards, Queen, Hero);
        }

        public void RewardStatement(int reward)
        {
            if (reward > 0) Console.Write($"         {reward} points earned | Total Points: {Hero.points}");
        }

        public void BreakAWall()
        {
            if (Hero.wallToBreak == null)
            {
                Console.Write("         No wall to break");
                return;
            }

            if (Hero.points < 5)
            {
                Console.Write("         You need 5 points to break a wall");
                return;
            }

            var wallToRemove = Board.walls.FirstOrDefault(w => (w.WallPosition == Hero.wallToBreak));
            if (wallToRemove != null)
            {
                Hero.points -= 5;
                Board.gameBoard[Hero.wallToBreak.row, Hero.wallToBreak.col] = ' ';

                Board.walls.Remove(wallToRemove);
                Hero.wallToBreak = null;
            }

            
        }

    }
}
