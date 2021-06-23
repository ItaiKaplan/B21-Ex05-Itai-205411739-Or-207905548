namespace ReverseTicTacToe
{
    public partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_LabelNUDCols = new System.Windows.Forms.Label();
            this.m_LabelNUDRows = new System.Windows.Forms.Label();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(68, 112);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(95, 24);
            this.m_CheckBoxPlayer2.TabIndex = 0;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(48, 277);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(347, 44);
            this.m_ButtonStart.TabIndex = 1;
            this.m_ButtonStart.Text = "Start!";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click_1);
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(194, 110);
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(201, 26);
            this.m_TextBoxPlayer2.TabIndex = 2;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(194, 64);
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(201, 26);
            this.m_TextBoxPlayer1.TabIndex = 3;
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(64, 64);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(69, 20);
            this.m_LabelPlayer1.TabIndex = 4;
            this.m_LabelPlayer1.Text = "Player 1:";
            // 
            // m_LabelNUDCols
            // 
            this.m_LabelNUDCols.AutoSize = true;
            this.m_LabelNUDCols.Location = new System.Drawing.Point(269, 219);
            this.m_LabelNUDCols.Name = "m_LabelNUDCols";
            this.m_LabelNUDCols.Size = new System.Drawing.Size(44, 20);
            this.m_LabelNUDCols.TabIndex = 5;
            this.m_LabelNUDCols.Text = "Cols:";
            // 
            // m_LabelNUDRows
            // 
            this.m_LabelNUDRows.AutoSize = true;
            this.m_LabelNUDRows.Location = new System.Drawing.Point(64, 221);
            this.m_LabelNUDRows.Name = "m_LabelNUDRows";
            this.m_LabelNUDRows.Size = new System.Drawing.Size(53, 20);
            this.m_LabelNUDRows.TabIndex = 6;
            this.m_LabelNUDRows.Text = "Rows:";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(44, 174);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.m_LabelBoardSize.TabIndex = 7;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(44, 21);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(64, 20);
            this.m_LabelPlayers.TabIndex = 8;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(147, 219);
            this.nUDRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(47, 26);
            this.nUDRows.TabIndex = 9;
            this.nUDRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(348, 215);
            this.nUDCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(47, 26);
            this.nUDCols.TabIndex = 10;
            this.nUDCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 368);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.m_LabelPlayers);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_LabelNUDRows);
            this.Controls.Add(this.m_LabelNUDCols);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSettings";
            this.Load += new System.EventHandler(this.GameSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.Button m_ButtonStart;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.Label m_LabelNUDCols;
        private System.Windows.Forms.Label m_LabelNUDRows;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.NumericUpDown nUDCols;
    }
}