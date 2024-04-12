
#### __Program Professors__
 _István Hegyes, chief of software development, L-Soft Zrt., Nyíregyháza guest_

 __Sándor Vályi (PhD), University of Nyíregyháza, Department of Mathematics and Informatics
valyi.sandor at nye dot hu_


### Project Description 
This project is a console-based game implemented in C#. The objective is to guide a hero through a grid-based board, avoiding obstacles and gathering rewards along the way. The game features random generation of walls and rewards, and players can use earned points to break walls. By default, the hero starts with 15 points, allowing them to break free if trapped between walls at the beginning of the game. 

### Classes

#### Wall
Represents a wall obstacle on the game board.

- `char wallType`: Indicates the type of wall.
- `bool isAWall`: Specifies if the object is a wall.
- `Position? WallPosition`: The position of the wall on the game board.

#### Hero
Represents the main character of the game.

- `int points`: The current score of the hero.
- `string name`: The name of the hero.
- `Position heroPosition`: The position of the hero on the game board.
- `Position? wallToBreak`: The position of a wall the hero can break.

#### Board
Manages the game board and its components.

- `char[,] gameBoard`: Represents the grid-based game board.
- `List<Wall> walls`: A collection of walls on the game board.
- `List<Reward> rewards`: A collection of rewards on the game board.
- `Queen? Queen`: Represents the queen character on the game board.

#### Controller
Controls the flow of the game.

- `void LoadBoard()`: Initializes and loads the game board.
- `void GenerateWalls(int row)`: Generates walls on the game board.
- `void LoadWalls()`: Loads walls onto the game board.
- `void GenerateRewards(int row)`: Generates rewards on the game board.
- `void LoadRewards()`: Loads rewards onto the game board.
- `void MovePosibility()`: Handles player movement and gameplay.
- `void BreakAWall()`: Allows the hero to break a wall using points.

#### BoardLogic
Provides logic for game board operations.

- `void PrintBoard(char[,] gameBoard)`: Prints the game board.
- `void AddPiece(char[,] gameBoard, Position position, char symbol)`: Adds a piece to the game board.
- `void AddHero(char[,] gameBoard, Hero hero)`: Adds the hero to the game board.
- `void AddQueen(char[,] gameBoard, Queen queen)`: Adds the queen to the game board.
- `Position? SetHeroDirection(Direction direction, Hero hero)`: Sets the direction of the hero's movement.
- `bool IsWallExist(Position newPosition, List<Wall> walls)`: Checks if a wall exists at a given position.
- `bool ValidateCurrentIndex(Position position)`: Validates the current index position.
- `bool CheckForWall(List<Wall> walls, Position position)`: Checks for a wall at a given position.
- `int CheckForReward(Hero hero, List<Reward> rewards)`: Checks for rewards collected by the hero.

### How to Play

- Navigate the hero using the arrow keys (Page Up, Page Down, End, Home).
- Collect rewards ($) to earn points.
- Use points to break walls and hidden walls (Enter key).
- Avoid obstacles such as walls.
- Reach the queen's position to win the game.
