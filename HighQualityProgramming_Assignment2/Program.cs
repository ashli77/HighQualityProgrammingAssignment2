using System.Numerics;

namespace GemHunter
{
    public class Board
    {
        #region properties
        public Cell[,] Grid { get; }
        private static bool isBoardInitialized { get; set; }

        #endregion

        #region constructor
        /// <summary>
        /// Initializes the board with players, gems, and obstacles.
        /// </summary>
        public Board()
        {
            Grid = new Cell[6, 6];
            InitializeBoard();
        }
        #endregion

        #region methods
        /// <summary>
        /// Prints the current state of the board to the console.
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Console.Write(Grid[i, j].Occupant + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Checks if the move is valid.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;

            // Update new position based on the direction
            switch (direction)
            {
                case 'U':
                    newX--;
                    break;
                case 'D':
                    newX++;
                    break;
                case 'L':
                    newY--;
                    break;
                case 'R':
                    newY++;
                    break;
                default:
                    return false; // Invalid direction
            }
            // Check if the new position is within the bounds of the board
            if (newX < 0 || newX >= Grid.GetLength(0) || newY < 0 || newY >= Grid.GetLength(1))
            {
                return false; // Move is out of bounds
            }

            // Check if the new position contains an obstacle
            if (Grid[newX, newY].Occupant == "O")
            {
                return false; // Move is blocked by an obstacle
            }

            return true; // Move is valid
        }

        /// <summary>
        /// Checks if the player's new position contains a gem and updates the player's GemCount.
        /// </summary>
        /// <param name="player"></param>
        public void CollectGem(Player player, char direction)
        {
            int x = player.Position.X;
            int y = player.Position.Y;

            switch (direction)
            {
                case 'U':
                    x--;
                    break;
                case 'D':
                    x++;
                    break;
                case 'L':
                    y--;
                    break;
                case 'R':
                    y++;
                    break;
            }

            // Check if the player's new position contains a gem
            if (Grid[x, y].Occupant == "G")
            {
                // Update player's GemCount
                player.GemCount++;

                // Remove the gem from the board
                Grid[x, y].Occupant = "-";
            }
        }

        private void InitializeBoard()
        {
            if (isBoardInitialized)
            {
                return; // Board has already been initialized
            }

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Cell { Occupant = "-" };
                }
            }

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int gemX = random.Next(Grid.GetLength(0));
                int gemY = random.Next(Grid.GetLength(1));
                Grid[gemX, gemY].Occupant = "G";

                int obstacleX = random.Next(Grid.GetLength(0));
                int obstacleY = random.Next(Grid.GetLength(1));
                Grid[obstacleX, obstacleY].Occupant = "O";
            }

            Grid[0, 0].Occupant = "P1";
            Grid[5, 5].Occupant = "P2";
            isBoardInitialized = true;
        }
        #endregion
    }
}
