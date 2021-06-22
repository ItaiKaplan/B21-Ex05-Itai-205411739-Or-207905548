using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace ReverseTicTacToe
{
    public class TicTacToeForm : Form
    {
        private const int k_Margin = 12;
        private readonly AI r_AI;
        private GameSettingsForm m_GameSettingsForm = new GameSettingsForm();
        private TicTacToeButton[,] m_Board;
        private Label m_LabelPlayer1 = new Label();
        private Label m_LabelPlayer2 = new Label();
        private Label m_LabelPlayer1Score = new Label();
        private Label m_LabelPlayer2Score = new Label();
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
                Player player1 = new Player(eSymbol.O, false, this.gameSettingsForm.Player1Name);
                bool AIFlag = !this.gameSettingsForm.CheckBoxPlayer2Checked;
                Player player2 = new Player(eSymbol.X, AIFlag, this.gameSettingsForm.Player2Name);
                Board logicBoard = new Board(this.gameSettingsForm.BoardSize);
                this.m_GameLogic = new GameLogic(player1, player2, logicBoard);
                if(AIFlag)
                {
                    this.r_AI = new AI(this.m_GameLogic);
                }

                this.initializecomponents();
                this.ShowDialog();
            }
        }

        private void initializecomponents()
        {  
            int BoardSize = this.gameSettingsForm.BoardSize;
            this.m_Board = new TicTacToeButton[BoardSize, BoardSize];
            string Player1Name = this.gameSettingsForm.Player1Name;
            string Player2Name = this.m_GameSettingsForm.Player2Name;

            this.Text = "Reverse TicTacToe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size((87 * BoardSize) + k_Margin, (87 * BoardSize) + (3 * k_Margin));
            for(int i = 0; i < BoardSize; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    m_Board[i, j] = new TicTacToeButton(i, j);
                    setButtonLocation(i, j);
                    m_Board[i, j].Click += TicTacToeForm_Click;
                    this.Controls.Add(m_Board[i, j]);
                }
            }

            this.m_GameLogic.UpdatingBoard += updateVisualBoard;
            this.m_LabelPlayer1.Text = this.gameSettingsForm.Player1Name;
            this.m_LabelPlayer2.Text = this.gameSettingsForm.Player2Name;
            this.m_LabelPlayer1Score.Text = this.m_GameLogic.Player1.Points.ToString();
            this.m_LabelPlayer2Score.Text = this.m_GameLogic.Player2.Points.ToString();
            m_LabelPlayer1.AutoSize = false;
            m_LabelPlayer1.TextAlign = ContentAlignment.TopRight;
            m_LabelPlayer2.AutoSize = true;
            this.m_LabelPlayer1Score.Size = new Size(this.m_LabelPlayer1Score.Text.Length * 10, 20);
            this.m_LabelPlayer2Score.Size = new Size(this.m_LabelPlayer2Score.Text.Length * 10, 20);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayer2);
            this.m_LabelPlayer1.Location = new Point(
                (ClientSize.Width / 2) - this.m_LabelPlayer1.Width - this.m_LabelPlayer1Score.Width,
                ClientSize.Height - (2 * k_Margin));
            this.m_LabelPlayer2.Location = new Point((this.ClientSize.Width / 2) + 10, ClientSize.Height - (2 * k_Margin));
            this.m_LabelPlayer1Score.Location = new Point(
                this.m_LabelPlayer1.Left + this.m_LabelPlayer1.Width, 
                ClientSize.Height - (2 * k_Margin));
            this.m_LabelPlayer2Score.Location = new Point(
                this.m_LabelPlayer2.Right, 
                ClientSize.Height - (2 * k_Margin));

            this.Controls.Add(this.m_LabelPlayer1Score);
            this.Controls.Add(this.m_LabelPlayer2Score);
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void updateVisualBoard(int i, int j)
        {
            this.m_Board[i, j].Text = this.m_GameLogic.CurrentPlayer.Symbol.ToString();
            this.m_Board[i, j].Enabled = false;
            nextTurn();
        }

        private void TicTacToeForm_Click(object sender, EventArgs e)
        {
            TicTacToeButton ClickedButton = sender as TicTacToeButton;
            int row = ClickedButton.RowIndex;
            int col = ClickedButton.ColIndex;
            this.m_GameLogic.PlayTurn(row, col);
        }

        private void nextTurn()
        {
            if(this.m_GameLogic.CheckWinner())
            {
                announceWinner();
            }
            else if(this.m_GameLogic.CheckIfTie())
            {
                announceTie();
            }
            else if(this.m_GameLogic.CurrentPlayer.IsAI)
            {
                playAITurn();
            }
        }

        private void announceWinner()
        {
            if(MessageBox.Show(
                string.Format(
                    @"
The winner is {0}!
Would you like to play another round?", 
this.m_GameLogic.CurrentPlayer.Name), 
"A Win!", 
MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                this.Close();
            }
        }

        private void announceTie()
        {
            if(MessageBox.Show(
                @"
Tie!
Would you like to play another round?", 
"A Tie!", 
MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                this.Close();
            }
        }

        private void playAnotherRound()
        {
            this.m_GameLogic.ResetGame();
            resetVisualBoard();
            this.m_LabelPlayer1Score.Text = this.m_GameLogic.Player1.Points.ToString();
            this.m_LabelPlayer2Score.Text = this.m_GameLogic.Player2.Points.ToString();
        }

        private void resetVisualBoard()
        {
            foreach(TicTacToeButton button in m_Board)
            {
                button.RestartButton();
            }
        }

        private void playAITurn()
        {
            r_AI.PlayAITurn();
        }

        private void setButtonLocation(int i, int j)
        {
            int x = ((k_Margin + this.m_Board[i, j].Width) * i) + k_Margin;
            int y = ((k_Margin + this.m_Board[i, j].Width) * j) + k_Margin;
            this.m_Board[i, j].Location = new Point(x, y);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TicTacToeForm
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "TicTacToeForm";
            this.Load += new System.EventHandler(this.TicTacToeForm_Load);
            this.ResumeLayout(false);
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
        }
    }
}
