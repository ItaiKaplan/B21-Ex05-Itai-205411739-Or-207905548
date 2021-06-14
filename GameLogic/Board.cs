namespace B21_Ex02_1
{
	public class Board
	{
        
		private readonly eSymbol[,] m_Board;
		private readonly int m_Size;

		public eSymbol[,] BoardGrid
		{
			get
			{
				return m_Board;
			}
        }

		public int Size
        {
            get
            {
				return m_Size;
            }
        }
		
		public Board(int i_sizeOfBoard)
		{
			this.m_Size = i_sizeOfBoard;
			this.m_Board = new eSymbol[i_sizeOfBoard, i_sizeOfBoard];

			for(int i = 0; i < this.Size; i++)
            {
				for(int j = 0; j < this.Size; j++)
                {
					this.BoardGrid[i, j] = eSymbol.empty;
                }
			}
		}

		public void UpdateBoard(int i_row, int i_column, eSymbol i_Symbol)
		{
			this.BoardGrid[i_row, i_column] = i_Symbol;
		}

		public bool CheckIfCellEmpty(int i_row, int i_column)
        {
			return this.BoardGrid[i_row, i_column] == eSymbol.empty;
        }


		public void ResetBoard()
        {
			for(int i = 0; i < this.Size; i++)
			{
				for(int j = 0; j < this.Size; j++)
				{
					this.BoardGrid[i, j] = eSymbol.empty;
				}
			}
		}
	}
}
