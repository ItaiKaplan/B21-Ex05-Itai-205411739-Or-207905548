namespace TicTacToeLogic
{
    public class Player
    {
        private readonly bool r_IsAI;
        private readonly string r_Name;
        private readonly eSymbol r_Symbol;
        private int m_Points;

        public eSymbol Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public int Points
        {
            get
            {
                return m_Points;
            }

            set
            {
                m_Points = value;
            }
        }

        public bool IsAI
        {
            get
            {
                return r_IsAI;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public Player(eSymbol i_Symbol, bool i_IsAI, string i_Name)
        {
            this.m_Points = 0;
            this.r_Symbol = i_Symbol;
            this.r_IsAI = i_IsAI;
            this.r_Name = i_Name;
        }

        public void AddPoint()
        {
            Points++;
        }
    }
}
