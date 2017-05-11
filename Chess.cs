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

		private bool isKing = false;

		/// <summary>
		/// color of chess
		/// </summary>
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

		private bool isDie = false;

		/// <summary>
		/// color of chess
		/// </summary>
		public bool IsDie
		{
			get
			{
				return isDie;
			}
			set
			{
				isDie = value;
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

		public virtual void FindWay(ref ChessSquare[,] board, int row, int col)
		{
			
		}

	}
}
