namespace B21_Ex02_1
{
    public delegate void BoardUpdate(int i, int j);

    public class GameLogic
    {
        // $G$ CSS-999 (-3) this member should be readonly
        private readonly Player m_Player1;
        private readonly Player m_Player2;
        private readonly Board m_Board;

        public event BoardUpdate boardUpdater;
        private Player m_CurrentPlayer;
        private int m_TurnsLeft;
        
        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }

        public int TurnsLeft
        {
            get
            {
                return m_TurnsLeft;
            }

            set
            {
                m_TurnsLeft = value;
            }
        }

        public GameLogic(Player i_Player1, Player i_Player2, Board i_Board)
        {
            this.m_Player1 = i_Player1;
            this.m_Player2 = i_Player2;
            this.m_Board = i_Board;
            this.m_TurnsLeft = Board.Size * Board.Size;
            this.m_CurrentPlayer = i_Player1;
        }

        private bool checkRow()
        {
            bool winFlag = false;
            eSymbol pivotSymbol;

            for(int i = 0; i < this.Board.Size; i++)
            {
                pivotSymbol = this.Board.BoardGrid[i, 0];
                if(pivotSymbol == eSymbol.empty)
                {
                    continue;
                }

                for(int j = 1; j < this.Board.Size; j++)
                {
                    if(pivotSymbol != this.Board.BoardGrid[i, j])
                    {
                        break;
                    }

                    if(j == this.Board.Size - 1)
                    {
                        winFlag = true;
                    }
                }

                if(winFlag)
                {
                    break;
                }
            }

            return winFlag;
        }

        private bool checkColumn()
        {
            bool winFlag = false;
            eSymbol pivotSymbol;

            for(int i = 0; i < this.Board.Size; i++)
            {
                pivotSymbol = this.Board.BoardGrid[0, i];
                if (pivotSymbol == eSymbol.empty)
                {
                    continue;
                }

                for(int j = 1; j < this.Board.Size; j++)
                {
                    if(pivotSymbol != this.Board.BoardGrid[j, i])
                    {
                        break;
                    }

                    if(j == this.Board.Size - 1)
                    {
                        winFlag = true;
                    }
                }

                if(winFlag)
                {
                    break;
                }
            }

            return winFlag;
        }

        private bool checkMainDiagonal()
        {
            bool winFlag = true;

            for(int i = 0; i < this.Board.Size; i++)
            {
                if(this.Board.BoardGrid[0, 0] != this.Board.BoardGrid[i, i])
                {
                    winFlag = false;
                }
            }

            return winFlag && this.Board.BoardGrid[0, 0] != eSymbol.empty;
        }

        private bool checkSecondDiagonal()
        {
            bool winFlag = true;

            for(int i = 0; i < this.Board.Size; i++)
            {
                if(this.Board.BoardGrid[this.Board.Size - 1 - i, i] != this.Board.BoardGrid[this.Board.Size - 1, 0])
                {
                    winFlag = false;
                }
            }

            return winFlag && this.Board.BoardGrid[this.Board.Size - 1, 0] != eSymbol.empty;
        }

        public bool CheckWinner()
        {
            bool winner = false;

            if(checkRow() || checkMainDiagonal() || checkColumn() || checkSecondDiagonal())
            {
                addPointToWinner();
                winner = true;
            }

            return winner;
        }

        private void changeTurn()
        {
            if(this.CurrentPlayer == Player1)
            {
                this.CurrentPlayer = Player2;
            }
            else
            {
                this.CurrentPlayer = Player1;
            }
        }

        public bool PlayTurn(int i_Row, int i_Column)
        {
            bool turnSucceed = true;

            if(!this.Board.CheckIfCellEmpty(i_Row, i_Column))
            {
                turnSucceed = false;
            }
            else
            {
                this.Board.UpdateBoard(i_Row, i_Column, this.CurrentPlayer.Symbol);
                this.TurnsLeft--;
                this.changeTurn();
            }

            this.boardUpdater.Invoke(i_Row, i_Column);

            return turnSucceed;
        }

        public void ResetGame()
        {
            this.Board.ResetBoard();
            this.CurrentPlayer = this.Player1;
            this.TurnsLeft = this.Board.Size * this.Board.Size;
        }

        private void addPointToWinner()
        {
            this.CurrentPlayer.AddPoint();
        }

        public bool CheckIfTie()
        {
            return this.TurnsLeft == 0 && !CheckWinner();
        }
    }
}
