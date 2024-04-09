// See https://aka.ms/new-console-template for more information
using schoolProject;

Console.WriteLine("Hello, World!");
Controller controller = new Controller();

controller.LoadBoard();

BoardLogic boardLogic2 = new();
//boardLogic2.LoadBoard();


//for (int i = 0; i < isMe.GetLength(0); i++)
//{
//    for (int j = 0; j < isMe.GetLength(1); j++)
//    {
//        Console.Write(isMe[i,j] + "         .");
//    }
//    Console.WriteLine();
//}

Console.WriteLine("Press a key (Page Up, Page Down, End, Home) or press Q to quit...");

while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Read key without displaying it

    if (keyInfo.Key == ConsoleKey.PageUp)
    {
        Console.WriteLine("Page Up key pressed");
    }
    else if (keyInfo.Key == ConsoleKey.PageDown)
    {
        Console.WriteLine("Page Down key pressed");
    }
    else if (keyInfo.Key == ConsoleKey.End)
    {
        Console.WriteLine("End key pressed");
    }
    else if (keyInfo.Key == ConsoleKey.Home)
    {
        Console.WriteLine("Home key pressed");
    }
    else if (keyInfo.Key == ConsoleKey.Q)
    {
        Console.WriteLine("Quitting...");
        break;
    }
    else
    {
        Console.WriteLine($"Key pressed: {keyInfo.KeyChar}");
    }
}