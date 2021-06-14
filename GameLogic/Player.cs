namespace B21_Ex02_1
{
    public class Player
    {
        private eSymbol m_Symbol;
        private int m_Points;
        private bool m_IsAI;

        public eSymbol Symbol
        {
            get
            {
                return m_Symbol;
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
                return m_IsAI;
            }
        }

        public Player(eSymbol i_Symbol, bool i_IsAI)
        {
            this.m_Points = 0;
            this.m_Symbol = i_Symbol;
            this.m_IsAI = i_IsAI;
        }

        public void AddPoint()
        {
            Points++;
        }
    }
}
