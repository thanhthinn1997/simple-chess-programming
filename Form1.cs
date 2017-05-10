using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessKing
{
	public delegate void FindWayAction();

	enum ColorTeam
	{
		None,
		White,
		Black,
	};

	public partial class frmChessKing : Form
	{
		ChessSquare[,] Board = new ChessSquare[8, 8];
	
		string linkWhiteCastle = "Image\\Chess_rlt60.png";
		string linkWhiteBishop = "Image\\Chess_blt60.png";
		string linkWhiteKnight = "Image\\Chess_nlt60.png";
		string linkWhiteQueen = "Image\\Chess_qlt60.png";
		string linkWhiteKing = "Image\\Chess_klt60.png";
		string linkWhitePawn = "Image\\Chess_plt60.png";
		string linkBlackCastle = "Image\\Chess_rdt60.png";
		string linkBlackBishop = "Image\\Chess_bdt60.png";
		string linkBlackKnight = "Image\\Chess_ndt60.png";
		string linkBlackQueen = "Image\\Chess_qdt60.png";
		string linkBlackKing = "Image\\Chess_kdt60.png";
		string linkBlackPawn = "Image\\Chess_pdt60.png";



		public frmChessKing()
		{
			InitializeComponent();
		}

		private void frmChessKing_Load(object sender, EventArgs e)
		{
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					ChessSquare temp = new ChessSquare();
					if (row % 2 == 0)
					{
						if (col % 2 == 0)
						{
							temp.BackColor = Color.NavajoWhite;
						}
						else
						{
							temp.BackColor = Color.SaddleBrown;
						}
					}
					else
					{
						if (col % 2 == 0)
						{
							temp.BackColor = Color.SaddleBrown;
						}
						else
						{
							temp.BackColor = Color.NavajoWhite;
						}
					}

					temp.Location = new Point((col + 1) * 60, (row + 1) * 60);
					temp.Row = row;
					temp.Col = col;
					Board[row, col] = temp;

					Board[row, col].findWayAction += new FindWayAction(OnAction);
					this.Controls.Add(Board[row, col]);
				}
			}
		}

		private void OnAction()
		{
			//Refresh board
			Board = Common.Board;
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			
			Chess tempChess;

			//pawn
			for (int i = 0; i < 16; i++)
			{
				tempChess = new Pawn();
				if (i < 8)
				{
					tempChess.Team = (int)ColorTeam.Black;
					Board[1, i].Chess = tempChess;
					Board[1, i].Image = Image.FromFile(linkBlackPawn);

				}
				else
				{
					tempChess.Team = (int)ColorTeam.White;
					Board[6, i - 8].Chess = tempChess;
					Board[6, i - 8].Image = Image.FromFile(linkWhitePawn);
				}
			}

			//Castle
			for (int i = 0; i < 4; i++)
			{
				tempChess = new Castle();
				if (i < 2)
				{
					tempChess.Team = (int)ColorTeam.Black;
					Board[0, 0].Chess = tempChess;
					Board[0, 7].Chess = tempChess;
					Board[0, 0].Image = Image.FromFile(linkBlackCastle);
					Board[0, 7].Image = Image.FromFile(linkBlackCastle);
				}
				else
				{
					tempChess.Team = (int)ColorTeam.White;
					Board[7, 0].Chess = tempChess;
					Board[7, 7].Chess = tempChess;
					Board[7, 0].Image = Image.FromFile(linkWhiteCastle);
					Board[7, 7].Image = Image.FromFile(linkWhiteCastle);
				}
			}

			//Knight
			for (int i = 0; i < 4; i++)
			{
				tempChess = new Knight();
				if (i < 2)
				{
					tempChess.Team = (int)ColorTeam.Black;
					Board[0, 1].Chess = tempChess;
					Board[0, 6].Chess = tempChess;
					Board[0, 1].Image = Image.FromFile(linkBlackKnight);
					Board[0, 6].Image = Image.FromFile(linkBlackKnight);

				}
				else
				{
					tempChess.Team = (int)ColorTeam.White;
					Board[7, 1].Chess = tempChess;
					Board[7, 6].Chess = tempChess;
					Board[7, 1].Image = Image.FromFile(linkWhiteKnight);
					Board[7, 6].Image = Image.FromFile(linkWhiteKnight);
				}
			}

			//Bishop
			for (int i = 0; i < 4; i++)
			{
				tempChess = new Bishop();
				if (i < 2)
				{
					tempChess.Team = (int)ColorTeam.Black;
					Board[0, 2].Chess = tempChess;
					Board[0, 5].Chess = tempChess;
					Board[0, 2].Image = Image.FromFile(linkBlackBishop);
					Board[0, 5].Image = Image.FromFile(linkBlackBishop);

				}
				else
				{
					tempChess.Team = (int)ColorTeam.White;
					Board[7, 2].Chess = tempChess;
					Board[7, 5].Chess = tempChess;
					Board[7, 2].Image = Image.FromFile(linkWhiteBishop);
					Board[7, 5].Image = Image.FromFile(linkWhiteBishop);
				}
			}

			//Queen
			tempChess = new Queen();
			tempChess.Team = (int)ColorTeam.Black;
			Board[0, 3].Chess = tempChess;
			Board[0, 3].Image = Image.FromFile(linkBlackQueen);

			tempChess = new Queen();
			tempChess.Team = (int)ColorTeam.White;
			Board[7, 3].Chess = tempChess;
			Board[7, 3].Image = Image.FromFile(linkWhiteQueen);

			//King
			tempChess = new King();
			tempChess.Team = (int)ColorTeam.Black;
			Board[0, 4].Chess = tempChess;
			Board[0, 4].Image = Image.FromFile(linkBlackKing);

			tempChess = new King();
			tempChess.Team = (int)ColorTeam.White;
			Board[7, 4].Chess = tempChess;
			Board[7, 4].Image = Image.FromFile(linkWhiteKing);

			Common.Board = Board;
		}

	}
}

