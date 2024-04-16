// See https://aka.ms/new-console-template for more information
using schoolProject;

Controller controller = new Controller();

controller.LoadBoard();
Board Board = Board.InitializeGameBoard();
Console.WriteLine(Board.rewards.Count);
Console.WriteLine(Board.walls.Count);