namespace GemHunter
{
    public class Player
    {
        #region properties
        /// <summary>
        /// Get or set Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or set position
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// Get orr set position
        /// </summary>
        public int GemCount { get; set; }

        #endregion

        #region Constructors
        // Default constructor
        public Player()
        {
            // Initialize properties if needed
            Position = new Position(0, 0);
            GemCount = 0;
        }

        // Parameterized constructor
        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }
        #endregion

        #region Method
        /// <summary>
        /// Updates the player's position based on the input direction (U, D, L, R).
        /// </summary>
        /// <param name="direction"></param>
        public void Move(char direction, Board board)
        {
            int originalX = Position.X;
            int originalY = Position.Y;

            switch (direction)
            {
                case 'U':
                    Position.X--;
                    break;
                case 'D':
                    Position.X++;
                    break;
                case 'L':
                    Position.Y--;
                    break;
                case 'R':
                    Position.Y++;
                    break;
                // to handle unexpected input 
                default:
                    Console.WriteLine("Invalid direction. Please use U, D, L, or R.");
                    break;
            }

            // Update the board with the new player position
            board.Grid[originalX, originalY].Occupant = "-";
            board.Grid[Position.X, Position.Y].Occupant = (Name == "P1") ? "P1" : "P2";

        }

        #endregion

    }
}
