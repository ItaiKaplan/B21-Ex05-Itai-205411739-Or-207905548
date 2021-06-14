namespace B21_Ex02_1
{


    // $G$ SFN-016 (+16) AI Implementation

    public class Program
    {
        public static void Main()
        {
            Board gameBoard = UI.CreateBoard();
            Player player1 = new Player(eSymbol.O, false);
            Player player2 = UI.AddPlayer();
            GameLogic game = new GameLogic(player1, player2, gameBoard);
            UI.StartGame(game);
        }
    }
}
