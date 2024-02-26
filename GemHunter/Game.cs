namespace GemHunter
{
    internal class Game
    {

        #region properties
        /// <summary>
        /// Player
        /// </summary>
        public Board Board { get; set; }
        /// <summary>
        /// Player
        /// </summary>
        public Player Player1 { get; set; }
        /// <summary>
        /// Player
        /// </summary>
        public Player Player2 { get; set; }
        /// <summary>
        /// Reference to the player whose turn it is
        /// </summary>
        public Player? CurrentTurn { get; set; }
        /// <summary>
        /// Keeps track of the number of turns that have passed
        /// </summary>
        public int TotalTurns { get; set; }
        #endregion


        #region constructor
        /// <summary>
        /// Initializes the game with a board and two players
        /// </summary>
        public Game()
        {
            Board = new Board();
            Player1 = new Player { Name = "P1", Position = new Position(0, 0) };
            Player2 = new Player { Name = "P2", Position = new Position(5, 5) };
            CurrentTurn = Player1;
            TotalTurns = 0;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Begins the game, displays the board, and alternates player turns
        /// </summary>
        public void Start()
        {
            while (!IsGameOver())
            {
                Board.Display();

                Console.WriteLine($"Enter the Move of {CurrentTurn.Name} (U, D, L, R):");
                var playerMove = Console.ReadLine();

                // Validate and handle player input
                if (Board.IsValidMove(CurrentTurn, playerMove[0]))
                {

                    // Check and collect gems
                    Board.CollectGem(CurrentTurn, playerMove[0]);

                    // Move the player
                    CurrentTurn.Move(playerMove[0], Board);

                    // Switch turn for the next player
                    SwitchTurn();
                    TotalTurns++;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }

            // Game over, announce the winner
            AnnounceWinner();
        }
        /// <summary>
        /// Switches between Player1 and Player2.
        /// </summary>
        public void SwitchTurn()
        {
            CurrentTurn = (CurrentTurn == Player1) ? Player2 : Player1;
        }
        /// <summary>
        /// Checks if the game has reached its end condition.
        /// </summary>
        public bool IsGameOver()
        {
            return TotalTurns >= 30 || !Board.AreGemsRemaining() || (Player1.GemCount + Player2.GemCount) >= 30;
        }

        /// <summary>
        /// Determines and announces the winner based on GemCount of both players.
        /// </summary>
        public void AnnounceWinner()
        {
            Console.WriteLine("--------------Game Over!-----------------");
            Console.WriteLine($"Player1 GemCount: {Player1.GemCount}");
            Console.WriteLine($"Player2 GemCount: {Player2.GemCount}");

            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine("Player1 wins!");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine("Player2 wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
        #endregion

    }
}
