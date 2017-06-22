using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKing
{
	class Chess
	{
		enum ColorTeam
		{
			None,
			White,
			Black,
		};

		/// <summary>
		/// status of chess
		/// </summary>
		private bool _die = false;

		/// <summary>
		/// status of chess
		/// </summary>
		public bool IsDie
		{
			get
			{
				return _die;
			}
			set
			{
				_die = value;
			}
		}

		/// <summary>
		/// color of chess
		/// </summary>
		private int team = (int)ColorTeam.None;

		/// <summary>
		/// color of chess
		/// </summary>
		public int Team
		{
			get
			{
				return team;
			}
			set
			{
				team = value;
			}
		}

        protected bool isKing = false;
		public bool IsKing
		{
            get
            {
                return isKing;
            }
            set
            {
                isKing = value;
            }
		}

        protected bool isPawn = false;
        public bool IsPawn
        {
            get
            {
                return isPawn;
            }
            set
            {
                isPawn = value;
            }
        }

        protected bool isBishop = false;
        public bool IsBishop
        {
            get 
            {
                return isBishop;
            }
            set
            {
                isBishop = value;
            }
        }
        protected bool isCastle = false;
        public bool IsCastle
        {
            get
            {
                return isCastle;
            }
            set
            {
                isCastle = value;
            }
        }
        protected bool isKnight = false;
        public bool IsKnight
        {
            get
            {
                return isKnight;
            }
            set
            {
                isKnight = value;
            }
        }

        protected bool isQueen = false;
        public bool IsQueen
        {
            get
            {
                return isQueen;
            }
            set
            {
                isQueen = value;
            }
        }


        private int evaluation;
        public int Evaluation
        {
            get
            {
                return evaluation;
            }
            set
            {
                evaluation = value;
            }
        }
        //private double[,] pieceevaluation;

        public virtual void FindWay(ChessSquare[,] board, int row, int col)
		{

		}

	}
}
