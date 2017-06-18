using System.Collections.Generic;
using System.Drawing;

namespace ChessKing
{
	class Common
	{
        static public bool IsMode = false;
		static public bool IsSelectedSquare = false; //selected yet
		static public int IsTurn = 0; 

		static public ChessSquare[,] Board;// = new ChessSquare[8, 8];

		static public List<ChessSquare> CanMove = new List<ChessSquare>(); // create list, save position of piece can move

		static public int RowSelected =-1; //set value =-1, not in chessboard
		static public int ColSelected =-1; //set value =-1, not in chessboard

		static public Color OldBackGround;//keep back ground before change to violet

		static public bool CheckPromote = false; //phong hau
		static public int RowProQueen = -1;
		static public int ColProQueen = -1;

	}
}
