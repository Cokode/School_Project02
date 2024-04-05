// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Collins!");

char[,] Fboard = new char[6,6]; 

for (int i = 0; i < 6; i++) 
{
    for (int j = 0; j < 12; j++)
    {
        Console.Write("  _");
    }
    Console.WriteLine();

    for (int k = 0; k < 2; k++)
    {
        Console.WriteLine("|");
    }
    
}

for (int i = 0;i < Fboard.GetLength(0); i++)
{
    for (int j = 0;j < Fboard.GetLength(1); j++)
    { 
        if(j == 3)
        {
            Fboard[i, j] = 'H';
            Console.Write(Fboard[i, j]);
        } else
        {
            Console.Write(Fboard[i, j] + "   ");
        }
    }
       

    Console.WriteLine("\n");
}

ConsoleKeyInfo direction = Console.ReadKey(true);
Console.WriteLine(direction);


Console.WriteLine(value: Fboard.ToString);