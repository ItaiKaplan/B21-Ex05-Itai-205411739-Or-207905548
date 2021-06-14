using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    class TicTacToeButton : Button
    {
        private const int k_Size = 75;
        private readonly int r_RowIndex;
        private readonly int r_ColIndex;

        public int RowIndex
        {
            get
            {
                return this.r_RowIndex;
            }
        }
        public int ColIndex
        {
            get
            {
                return this.r_ColIndex;
            }
        }

        public TicTacToeButton(int i_Row, int i_Col) : base()
        {
            this.Size = new System.Drawing.Size(k_Size, k_Size);
            this.r_RowIndex = i_Row;
            this.r_ColIndex = i_Col;
        }

        public void RestartButton()
        {
            this.Enabled = true;
            this.Text = String.Empty;
        }
    }
}
