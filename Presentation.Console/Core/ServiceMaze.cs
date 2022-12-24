public class ServiceMaze
{
    public (int FieldValue, char GameObject) Path { get; } = new(0, '.');
    public (int FieldValue, char GameObject) Wall { get; } = new(1, '#');
    public (int FieldValue, char GameObject) Start { get; } = new(2, 'S');
    public (int FieldValue, char GameObject) Exit { get; } = new(3, 'E');
    public (int FieldValue, char GameObject) Gamer { get; } = new(4, 'X');

    public int[,] GetMaze()
    {
        var maze = new int[,]
        {
                {1,1,1,1,1,1,1,1,1,1},
                {1,2,1,1,0,1,0,0,0,1},
                {1,0,0,0,0,1,0,1,0,1},
                {1,1,1,1,0,1,0,1,0,1},
                {1,0,0,0,0,1,0,1,0,1},
                {1,1,0,1,1,1,0,1,0,1},
                {1,0,0,0,0,0,0,1,0,1},
                {1,1,1,1,1,1,1,1,0,1},
                {1,0,0,0,0,0,0,0,0,1},
                {1,1,1,1,1,1,3,1,1,1}
        };

        return maze;
    }

    public (int X, int Y) GetStartPosition(int[,] maze)
    {
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] == Start.FieldValue) return new(i, j);
            }
        }

        throw new Exception("there is no start point");
    }

    public void DrawMaze(int[,] maze)
    {
        Console.Clear();

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                if (maze[i, j] == Wall.FieldValue) Console.Write(Wall.GameObject);
                if (maze[i, j] == Path.FieldValue) Console.Write(Path.GameObject);
                if (maze[i, j] == Start.FieldValue) Console.Write(Start.GameObject);
                if (maze[i, j] == Exit.FieldValue) Console.Write(Exit.GameObject);
            }

            Console.WriteLine();
        }
    }

    public void DrawGamer((int X, int Y) position)
    {
        Console.CursorLeft = position.X;
        Console.CursorTop = position.Y;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(Gamer.GameObject);

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public void InputProcessing(int[,] maze, ref (int X, int Y) position, ConsoleKeyInfo keyInfo)
    {
        var leftFieldValue = maze[position.Y, position.X - 1];
        var rightFieldValue = maze[position.Y, position.X + 1];
        var topFieldValue = maze[position.Y - 1, position.X];
        var bottomFieldValue = maze[position.Y + 1, position.X];

        if (keyInfo.Key == ConsoleKey.LeftArrow && (leftFieldValue != Wall.FieldValue)) position.X--;
        if (keyInfo.Key == ConsoleKey.RightArrow && (rightFieldValue != Wall.FieldValue)) position.X++;
        if (keyInfo.Key == ConsoleKey.UpArrow && (topFieldValue != Wall.FieldValue)) position.Y--;
        if (keyInfo.Key == ConsoleKey.DownArrow && (bottomFieldValue != Wall.FieldValue)) position.Y++;
    }

    public bool CloseGame(ConsoleKeyInfo keyInfo)
    {
        return keyInfo.Key == ConsoleKey.Escape;
    }

    public bool YouAreWinner(int[,] maze, (int X, int Y) position)
    {
        return maze[position.Y, position.X] == Exit.FieldValue;
    }
}