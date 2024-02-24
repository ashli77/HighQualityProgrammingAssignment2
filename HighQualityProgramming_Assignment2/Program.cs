using System;

class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Player
{
    public string Name { get; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U':
                if (Position.Y > 0)
                    Position.Y--;
                break;
            case 'D':
                if (Position.Y < 5)
                    Position.Y++;
                break;
            case 'L':
                if (Position.X > 0)
                    Position.X--;
                break;
            case 'R':
                if (Position.X < 5)
                    Position.X++;
                break;
            default:
                break;
        }
    }
}

class Cell
{
    public string Occupant { get; set; }

    public Cell()
    {
        Occupant = "-";
    }
}

class Board
{
    public Cell[,] Grid { get; }

    public Board()
    {
        Grid = new Cell[6, 6];
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        // Set up players
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

        // Set up gems (random positions)
        Random rand = new Random();
        for (int i = 0; i < 10; i++)
        {
            int x = rand.Next(6);
            int y = rand.Next(6);
            if (Grid[x, y].Occupant == "-")
                Grid[x, y].Occupant = "G";
            else
                i--;
        }

        // Set up obstacles (random positions)
        for (int i = 0; i < 8; i++)
        {
            int x = rand.Next(6);
            int y = rand.Next(6);
            if (Grid[x, y].Occupant == "-")
                Grid[x, y].Occupant = "O";
            else
                i--;
        }
    }

    public void Display()
    {
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 6; x++)
            {
                Console.Write(Grid[x, y].Occupant + " ");
            }
            Console.WriteLine();
        }
    }

    public bool IsValidMove(Player player, char direction)
    {
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'U':
                newY--;
                break;
            case 'D':
                newY++;
                break;
            case 'L':
                newX--;
                break;
            case 'R':
                newX++;
                break;
            default:
                break;
        }

        if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
            return false;

        if (Grid[newX, newY].Occupant == "O")
            return false;

        return true;
    }

    