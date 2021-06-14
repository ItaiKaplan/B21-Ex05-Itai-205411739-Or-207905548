using System;
using System.Text;
using System.Threading;


namespace B21_Ex02_1
{
    public class UI
    {
        public static Board CreateBoard()
        {
            bool validInput = false;
            int size = 0;

            while(!validInput)
            {
                Console.Clear();
                Console.WriteLine("Enter size of board (a number between 3-9)");
                string stringSize = Console.ReadLine();
                size = 0;
                validInput = int.TryParse(stringSize, out size);

                if(!validInput || size < 3 || size > 9)
                {
                    Console.WriteLine("Invalid input, try again");
                    validInput = false;
                    Thread.Sleep(600);
                }
            }

            return new Board(size);
        }

        public static Player AddPlayer()
        {
            bool validInput = false;
            string userChoice = string.Empty;
            Player player2;

            while(!validInput)
            {
                Console.Clear();
                Console.WriteLine("Press 1 to play with a friend or 2 to play against an AI");
                userChoice = Console.ReadLine();
                if(!Equals(userChoice, "1") && !Equals(userChoice, "2"))
                {
                    Console.WriteLine("Invalid input, try again");
                    Thread.Sleep(600);
                } 
                else
                {
                    validInput = true;
                }
            }

            if(Equals(userChoice, "1"))
            {
                player2 = new Player(eSymbol.X, false);
            }
            else
            {
                player2 = new Player(eSymbol.X, true);
            }

            return player2;
        }

        private static string symbolToString(eSymbol i_Symbol)
        {
            string symbol;

            switch(i_Symbol)
            {
                case eSymbol.O:
                    symbol = "O";
                    break;
                case eSymbol.X:
                    symbol = "X";
                    break;
                default:
                    symbol = " ";
                    break;
            }

            return symbol;
        }

        private static void showBoard(Board i_Board)
        {
            StringBuilder line = new StringBuilder("  ");
            StringBuilder divideRow = new StringBuilder(" =");

            for(int i = 0; i < i_Board.Size; i++)
            {
                line.Append($"{i+1}     ");
                divideRow.Append("======");
            }

            Console.WriteLine(line);

            for(int i = 0; i < i_Board.Size; i++)
            {
                line.Clear();
                line.Append($"{i+1}|");
                for(int j = 0; j < i_Board.Size; j++)
                {
                    line.Append($"  {symbolToString(i_Board.BoardGrid[i, j])}  |");
                }

                Console.WriteLine(line);
                Console.WriteLine(divideRow);
            }
        }
        // $G$ CSS-999 (-5) Out parameters should start with o_PascaleCased
        private static void getMove(out int o_RowOfMove, out int o_ColumnOfMove, out bool o_UserWantToExit, Board i_Board)
        {
            bool validInput = false;
            string userInput;
            o_UserWantToExit = false;
            o_RowOfMove = 0;
            o_ColumnOfMove = 0;

            while(!validInput)
            {
                Console.WriteLine($"Enter row number between 1 to {i_Board.Size}");
                userInput = Console.ReadLine();
                if(Equals(userInput, "q") || Equals(userInput, "Q"))
                {
                    o_UserWantToExit = true;
                    break;
                }
                else
                {
                    validInput = int.TryParse(userInput, out o_RowOfMove);
                    if((o_RowOfMove > i_Board.Size) || (o_RowOfMove < 1))
                    {
                        Console.WriteLine("Invalid input, try again");
                        validInput = false;
                        Thread.Sleep(600);
                        Console.Clear();
                        showBoard(i_Board);
                    }
                }
            }

            validInput = false;
            while(!validInput && !o_UserWantToExit)
            {
                Console.WriteLine($"Enter column number between 1 to {i_Board.Size}");
                userInput = Console.ReadLine();
                if(Equals(userInput, "q") || Equals(userInput, "Q"))
                {
                    o_UserWantToExit = true;
                    break;
                }
                else
                {
                    validInput = int.TryParse(userInput, out o_ColumnOfMove);
                    if((o_ColumnOfMove > i_Board.Size) || (o_ColumnOfMove < 1))
                    {
                        Console.WriteLine("Invalid input");
                        validInput = false;
                        Thread.Sleep(600);
                        Console.Clear();
                        showBoard(i_Board);
                    }
                }
            }
        }

        private static void showScore(GameLogic i_Game)
        {
            Console.WriteLine(
@"
Player {0} has {1} Points
Player {2} has {3} Points",
i_Game.Player1.Symbol,
i_Game.Player1.Points, 
i_Game.Player2.Symbol, 
i_Game.Player2.Points);
        }
        
        public static void StartGame(GameLogic i_Game)
        {
            bool gameRunning = true;
            Board board = i_Game.Board;
            AI AI = new AI(i_Game);
            bool userWantToExit = false;
            int rowOfMove;
            int columnOfMove;
            string userInput;

            while(gameRunning)
            {
                Console.Clear();
                if(i_Game.CurrentPlayer.IsAI)
                {
                    showBoard(board);
                    AI.PlayAITurn();
                }
                else
                {
                    showBoard(board);
                    getMove(out rowOfMove, out columnOfMove, out userWantToExit, board);
                    if(userWantToExit)
                    {
                        break;
                    }

                    while(!i_Game.PlayTurn(rowOfMove - 1, columnOfMove - 1))
                    {
                        Console.WriteLine("The cell you selected is full, try again");
                        Thread.Sleep(800);
                        Console.Clear();
                        showBoard(board);
                        getMove(out rowOfMove, out columnOfMove, out userWantToExit, board);
                    }
                }

                if(i_Game.CheckWinner())
                {
                    Console.Clear();
                    showBoard(board);
                    Console.WriteLine($"Player {symbolToString(i_Game.CurrentPlayer.Symbol)} won!");
                    i_Game.AddPointToWinner();
                    showScore(i_Game);
                    gameRunning = false;
                }

                if(i_Game.CheckIfTie())
                {
                    Console.Clear();
                    showBoard(board);
                    Console.WriteLine("There is a tie!");
                    showScore(i_Game);
                    gameRunning = false;
                }

                if(!gameRunning)
                {
                    Console.WriteLine(
@"If you want to play another round press p,
if not press any key to exit.");
                    userInput = Console.ReadLine();
                    if(Equals(userInput, "p") || Equals(userInput, "P"))
                    {
                        i_Game.ResetGame();
                        board = i_Game.Board;
                        showBoard(board);
                        gameRunning = true;
                    }
                    else
                    {
                        gameRunning = false;
                    }
                }
            }

            Console.WriteLine("Exiting...");
            Thread.Sleep(600);
        }
    }
}
