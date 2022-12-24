Console.CursorVisible = false;

var serviceMaze = new ServiceMaze();

var maze = serviceMaze.GetMaze();

var position = serviceMaze.GetStartPosition(maze);

while (true)
{
    serviceMaze.DrawMaze(maze);
    serviceMaze.DrawGamer(position);

    var keyInfo = Console.ReadKey(true);

    if (serviceMaze.CloseGame(keyInfo))
    {
        Console.Clear();
        Console.Write("You are exit");
        break;
    }

    serviceMaze.InputProcessing(maze, ref position, keyInfo);

    if (serviceMaze.YouAreWinner(maze, position))
    {
        Console.Clear();
        Console.Write("You are WINNER!!!");
        break;
    }
}

Console.ReadLine();