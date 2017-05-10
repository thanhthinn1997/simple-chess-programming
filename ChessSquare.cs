using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ChessKing

{
	class ChessSquare : Button
	{
		public FindWayAction findWayAction;
		enum ColorTeam
		{
			None,
			White,
			Black,
		};

		private Chess chess;

		/// <summary>
		/// status of chess
		/// </summary>
		public Chess Chess
		{
			get
			{
				return chess;
			}
			set
			{
				chess = value;
			}
		}

		private int row;

		public int Row
		{
			get
			{
				return row;
			}
			set
			{
				row = value;
			}
		}

		private int col;

		public int Col
		{
			get
			{
				return col;
			}
			set
			{
				col = value;
			}
		}


		public void BackChessBoard()
		{
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					if (row % 2 == 0)
					{
						if (col % 2 == 0)
						{
							Common.Board[row, col].BackColor = Color.NavajoWhite;
						}
						else
						{
							Common.Board[row, col].BackColor = Color.SaddleBrown;
						}
					}
					else
					{
						if (col % 2 == 0)
						{
							Common.Board[row, col].BackColor = Color.SaddleBrown;
						}
						else
						{
							Common.Board[row, col].BackColor = Color.NavajoWhite;
						}
					}
				}
			}
		}

		/// <summary>
		/// constructer for game
		/// </summary>
		public ChessSquare()
		{
			//change properties of button
			this.Size = new System.Drawing.Size(60, 60);
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
		}

		protected override void OnClick(EventArgs e)
		{
			if (Common.RowSelected == this.Row && Common.ColSelected == this.Col ) //squares click itsefl for 2 time, hide the way and return old background
			{
				Common.IsSelectedSquare = false; //selected yet
				for (int i = 0; i < Common.CanMove.Count; i++)
				{
					Common.CanMove[i].Image = null;
				}
					BackChessBoard();
				this.BackColor = Common.OldBackGround;
				Common.CanEat.Clear();//clear list
				Common.CanMove.Clear();
				Common.RowSelected = -1;
				Common.ColSelected = -1;
				return;
			}
			if (this.Chess == null && !Common.IsSelectedSquare)
			{
				return; 
			}

			//create turn for 2 team, white go fist
			if (Common.IsTurn % 2 == 0)
			{
				if (Common.IsSelectedSquare == false)
				{
					if (this.Chess.Team == (int)ColorTeam.White)
					{
						this.ChangeTurn(); 
					}
					else
						return;
				}
				else
				{
					this.ChangeTurn();
				}
			}
			else
			{
				if (Common.IsSelectedSquare == false)
				{
					if (this.Chess.Team == (int)ColorTeam.Black)
					{
						this.ChangeTurn();
					}
					else
						return;
				}
				else
				{
					this.ChangeTurn();
				}
			}
		}

		protected void ChangeTurn()
		{
			//select yet
			if (Common.IsSelectedSquare == false) 
			{
				Common.IsSelectedSquare = true; //selected

				//check square is not Empty 
				if (this.Chess != null)
				{
					Common.OldBackGround = Common.Board[Row, Col].BackColor; //keep background color of chess square 
					this.Chess.FindWay(ref Common.Board, Row, Col); //findway can move and eat
					this.findWayAction(); 
					this.BackColor = System.Drawing.Color.Violet; //change background to violet
					Common.RowSelected = Row; //keep the row
					Common.ColSelected = Col; //keep the col

				}
				else
				{
					//do nothing
				}
			}
			//selected
			else
			{
				Common.IsSelectedSquare = false;
				Common.BackGroundEat = Common.Board[Common.RowSelected, Common.ColSelected].BackColor;//keep backgroundcolor of square can die
				//eat
				if (Common.Board[Row, Col].Chess != null)
				{
					if (Common.CanEat.Contains(this))//inside list Can EAT
					{
						//hide the way can move and can eat
						for (int i = 0; i < Common.CanMove.Count; i++)
						{
							Common.CanMove[i].Image = null;
						}
						this.Image = Common.Board[Common.RowSelected, Common.ColSelected].Image; 
						Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
						Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
						BackChessBoard();

						//Check end game
						if (this.Chess.IsKing)
						{
							if (this.Chess.Team == (int)ColorTeam.Black)
							{
								MessageBox.Show("The White Team Win!!!");
							}
							else
							{
								MessageBox.Show("The Black Team Win!!!");
							}
						}
						else
						{ }

						this.Chess = Common.Board[Common.RowSelected, Common.ColSelected].Chess;
						Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;
						Common.IsSelectedSquare = false;////

						Common.IsTurn++; //change turn
						Common.CanEat.Clear();//clear list
						Common.CanMove.Clear();
					}
					else //not inside caneat list
					{
						Common.IsSelectedSquare = false;
						Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;//return back ground color after change to violet
						for (int i = 0; i < Common.CanMove.Count; i++)
						{
							Common.CanMove[i].Image = null;
						}
						BackChessBoard();
						Common.CanMove.Clear();
						Common.CanEat.Clear();
					}
				
				}
				else
				{
					//move
					if (Common.CanMove.Contains(this))//compare
					{
						for (int i = 0; i < Common.CanMove.Count; i++)
						{
							Common.CanMove[i].Image = null;
						}
						BackChessBoard();
						this.Image = Common.Board[Common.RowSelected, Common.ColSelected].Image; 
						this.Chess = Common.Board[Common.RowSelected, Common.ColSelected].Chess;
						Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
						Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
						Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;
						Common.IsSelectedSquare = false;/////

						Common.IsTurn++;
						Common.CanMove.Clear();
						Common.CanEat.Clear();
					}
					else
					{
						Common.IsSelectedSquare = false;
						Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
						for (int i = 0; i < Common.CanMove.Count; i++)
						{
							Common.CanMove[i].Image = null;
						}
						BackChessBoard();
						Common.CanMove.Clear();
						Common.CanEat.Clear();
					}
				}
			}

			if (Common.IsSelectedSquare == false)
			{
				Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
				this.BackChessBoard();
			}
		}
	}
}
 