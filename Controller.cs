using System;
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

        public Controller() { }

        public void LoadBoard()
        {
            BoardLogic.AddHero(Board.gameBoard, Hero);
            BoardLogic.AddQueen(Board.gameBoard, Queen);
            Board.walls = GenerateWalls(10, Board.walls);
            Board.rewards = GenerateRewards(4, Board.rewards);
            BoardLogic.LoadReward(Board.rewards, Board.gameBoard);
            BoardLogic.PrintBoard(Board.gameBoard);
            
        }

        public List<Wall> GenerateWalls(int numberOfWall, List<Wall> walls) 
        {
            Random rand = new();

            for (int i = 0; i < numberOfWall; i++)
            {
                Position po;
                do
                {
                    po = new(rand.Next(1, 5), rand.Next(1, 5));
                } while (IsPositionTaken(po, walls));

                Wall newWall = new Wall(
                    isUp: rand.Next(0, 2) == 1,
                    isDown: rand.Next(0, 2) == 1,
                    isLeft: rand.Next(0, 2) == 1,
                    isRight: rand.Next(0, 2) == 1,
                    position: po
                );

                walls.Add(newWall);
            }

            return walls;
        }

        public List<Reward> GenerateRewards(int numberOfReward, List<Reward> rewards)
        {
            Random rand = new Random();
         
            for (int i = 0; i < numberOfReward; i++)
            {
                Position po; 
                do
                {
                    po = new(rand.Next(0, 6), rand.Next(0, 6));
                } while (IsPositionTaken2(po, rewards));

                Reward reward = new Reward(
                     rewardPosition: po,
                     points: rand.Next(5, 20)
                 );

                rewards.Add(reward);
            }

            return rewards;
        }

        private bool IsPositionTaken2(Position position, List<Reward> rewards)
        {
            if ((position.row == 0 && position.col == 0) ||
                (position.row == 5 && position.col == 5)) return true; // ensure there is no wall in the hero start index

            foreach (var re in rewards)
            {
                if (re.rewardPosition == position)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPositionTaken(Position position, List<Wall> walls)
        {
            if (position.row == 0 && position.col == 0)
                return true; // Ensure there is no wall in the hero start index

            foreach (var wall in walls)
            {
                if (IsAdjacent(position, wall.WallPosition) || wall.WallPosition == position)
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
            //Console.WriteLine("Press a key (Page Up, Page Down, End, Home) or press Q to quit...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Position po;
            Wall? w;

            switch (keyInfo.Key)
            {
                case ConsoleKey.PageUp:
                    po = BoardLogic.SetHeroDirection(Direction.North, Hero);
                    if (BoardLogic.validMoveIndex(po))
                    {
                        w = BoardLogic.CheckForWall(Board.walls, Hero.heroPosition);
                        if (w != null)
                        {
                            if (BoardLogic.CheckBlockedArea(w, 'U'))
                            {
                                // not a possible move. 
                            }
                            else
                            {
                                // is a possible move
                                gameBaord[hero.heroPosition.row, hero.heroPosition.col] = ' ';
                                hero.heroPosition = po;
                                AddHero(gameBaord, hero);
                                rewardAdder(CheckForReward(hero, rewards), hero);
                            }
                        }
                    }

                    break;

                case ConsoleKey.PageDown: break;
                case ConsoleKey.End: break;
                case ConsoleKey.Home: break;
                default: break;
            }
        }

    }

}
