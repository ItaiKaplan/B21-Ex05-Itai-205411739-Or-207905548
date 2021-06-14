namespace B21_Ex02_1
{
    public class AI
    {
        // $G$ CSS-999 (-3) this member should be readonly
        private readonly GameLogic r_Game;

        public GameLogic Game
        {
            get
            {
                return r_Game;
            }
        }

        public AI(GameLogic i_Game)
        {
            this.r_Game = i_Game;
        }

        private int getRowScore(int i_Row)
        {
            int score = 0;

            for(int i = 0; i < this.Game.Board.Size; i++)
            {
                if(this.Game.CurrentPlayer.Symbol == this.Game.Board.BoardGrid[i_Row, i])
                {
                    score++;
                }
            }

            return score;
        }

        private int getColumnScore(int i_Column)
        {
            int score = 0;

            for(int i = 0; i < this.Game.Board.Size; i++)
            {
                if(this.Game.CurrentPlayer.Symbol == this.Game.Board.BoardGrid[i, i_Column])
                {
                    score++;
                }
            }

            return score;
        }

        private int getDiagonalsScore(int i_Row, int i_Column)
        {
            int score = 0;

            if(i_Row == i_Column)
            {
                score++;
                for(int i = 0; i < this.Game.Board.Size; i++)
                {
                    if(this.Game.CurrentPlayer.Symbol == this.Game.Board.BoardGrid[i, i])
                    {
                        score++;
                    }
                }
            }

            if(i_Column + i_Row + 1 == this.Game.Board.Size)
            {
                score++;

                for(int i = 0; i < this.Game.Board.Size; i++)
                {
                    if(this.Game.CurrentPlayer.Symbol == this.Game.Board.BoardGrid[this.Game.Board.Size - 1 - i, i])
                    {
                        score++;
                    }
                }
            }

            return score;
        }

        private int getCellScore(int i_Row, int i_Column)
        {
            int score = 0;

            score += getRowScore(i_Row) + getColumnScore(i_Column) + getDiagonalsScore(i_Row, i_Column);

            return score;
        }

        public void PlayAITurn()
        {
            int bestRow = 0;
            int bestColumn = 0;
            int bestScore = 100;
            int currentScore = 0;

            for(int i = 0; i < this.Game.Board.Size; i++)
            {
                for(int j = 0; j < this.Game.Board.Size; j++)
                {
                    if(eSymbol.empty == this.Game.Board.BoardGrid[i, j])
                    {
                        currentScore = getCellScore(i, j);
                        if(currentScore < bestScore)
                        {
                            bestRow = i;
                            bestColumn = j;
                            bestScore = currentScore;
                        }
                    }
                }
            }
           
            this.Game.PlayTurn(bestRow, bestColumn);
        }
    }
}
