using B21_Ex02_1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    class TicTacToeForm : Form
    {
        private GameSettingsForm m_GameSettingsForm = new GameSettingsForm();
        private TicTacToeButton[,] Board;
        private Label m_LabelPlayer1 = new Label();
        private Label m_LabelPlayer2 = new Label();
        private Label m_LabelPlayer1Score = new Label();
        private Label m_LabelPlayer2Score = new Label();
        private const int k_Margin = 12;
        private GameLogic m_GameLogic;

        public GameSettingsForm gameSettingsForm
        {
            get
            {
                return this.m_GameSettingsForm;
            }
        }


        public TicTacToeForm()
        {
            if(this.gameSettingsForm.ShowDialog() == DialogResult.OK)
            {
                this.initializecomponents();
                Player player1 = new Player(eSymbol.O, false);
                bool AIFlag = !this.gameSettingsForm.CheckBoxPlayer2Checked;
                Player player2 = new Player(eSymbol.X, AIFlag);
                Board logicBoard = new Board(this.gameSettingsForm.BoardSize);
                this.m_GameLogic = new GameLogic(player1, player2, logicBoard);
                this.ShowDialog();
            }
        } 

        private void initializecomponents()
        {  
            int BoardSize = this.gameSettingsForm.BoardSize;
            this.Board = new TicTacToeButton[BoardSize, BoardSize];
            String Player1Name = this.gameSettingsForm.Player1Name;
            String Player2Name = this.m_GameSettingsForm.Player2Name;

            this.Text = "Reverse TicTacToe";
            this.ClientSize = new Size(87*BoardSize + k_Margin, 87*BoardSize + 3*k_Margin);
            for(int i = 0; i < BoardSize; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    Board[i, j] = new TicTacToeButton(i, j);
                    setButtonLocation(i, j);
                    Board[i, j].Click += TicTacToeForm_Click;
                    this.Controls.Add(Board[i, j]);
                }
            }
            this.m_LabelPlayer1.Text = this.m_GameSettingsForm.Player1Name;
            this.m_LabelPlayer2.Text = this.m_GameSettingsForm.Player2Name;
            this.m_LabelPlayer1Score.Text = "0";
            this.m_LabelPlayer2Score.Text = "0";
            this.m_LabelPlayer1.Location = 
                new Point(ClientSize.Width/2 - 
                (this.m_LabelPlayer1.Width),
                ClientSize.Height - (2*k_Margin));
            this.m_LabelPlayer2.Location = new Point(ClientSize.Width / 2 + (BoardSize * 10), ClientSize.Height - (2 * k_Margin));
            this.m_LabelPlayer1.BackColor = Color.Green;
            this.m_LabelPlayer1Score.Location = new Point(this.m_LabelPlayer1.Left + this.m_LabelPlayer1.Width, ClientSize.Height - (2 * k_Margin));
            this.m_LabelPlayer2Score.Location = new Point(this.m_LabelPlayer2.Left + this.m_LabelPlayer2.Width, ClientSize.Height - (2 * k_Margin));
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayer2);
            this.Controls.Add(this.m_LabelPlayer1Score);
            this.Controls.Add(this.m_LabelPlayer2Score);
        }

        private void TicTacToeForm_Click(object sender, EventArgs e)
        {
            TicTacToeButton ClickedButton = (sender as TicTacToeButton);
            int row = ClickedButton.RowIndex;
            int col = ClickedButton.ColIndex;
            this.m_GameLogic.PlayTurn(row, col);
            ClickedButton.Text = m_GameLogic.CurrentPlayer.Symbol.ToString();
            ClickedButton.Enabled = false;
        }

        private void setButtonLocation(int i, int j)
        {
            int x = (k_Margin + this.Board[i, j].Width) * i + k_Margin;
            int y = (k_Margin + this.Board[i, j].Width) * j + k_Margin;
            this.Board[i, j].Location = new Point(x, y);
        }
    }
}
