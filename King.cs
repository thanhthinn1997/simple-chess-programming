using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessKing
{
	class King : Chess
	{
		string linkPoint = "Image\\circle.png";

		public King()
		{
			this.isKing = true;
		}

		public override void FindWay(ref ChessSquare[,] board, int row, int col)
		{
			if (row - 1 >= 0)
			{
				if (col - 1 >= 0)
				{
					if (board[row - 1, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col - 1]);
					}
					else
					{
						if (this.Team != board[row - 1, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (col + 1 < 8)
				{
					if (board[row - 1, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col + 1]);
					}
					else
					{
						if (this.Team != board[row - 1, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (row - 1 >= 0)
				{
					if (board[row - 1, col].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col]);
					}
					else
					{
						if (this.Team != board[row - 1, col].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col]);
						}
						else
						{
							//do nothing
						}
					}
				}
			}

			if (row + 1 < 8)
			{
				if (col - 1 >= 0)
				{
					if (board[row + 1, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col - 1]);
					}
					else
					{
						if (this.Team != board[row + 1, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (col + 1 < 8)
				{
					if (board[row + 1, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col + 1]);
					}
					else
					{
						if (this.Team != board[row + 1, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (row + 1 < 8)
				{
					if (board[row + 1, col].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col]);
					}
					else
					{
						if (this.Team != board[row + 1, col].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col]);
						}
						else
						{
							//do nothing
						}
					}
				}
			}

			if (col - 1 >= 0)
			{
				if (row - 1 >= 0)
				{
					if (board[row - 1, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col - 1]);
					}
					else
					{
						if (this.Team != board[row - 1, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (row + 1 < 8)
				{
					if (board[row + 1, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col - 1]);
					}
					else
					{
						if (this.Team != board[row + 1, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (col - 1 >= 0)
				{
					if (board[row, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row , col - 1]);
					}
					else
					{
						if (this.Team != board[row, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == false)
							    board[row, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row , col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
			}

			if (col + 1 < 8)
			{
				if (row - 1 >= 0)
				{
					if (board[row - 1, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == false)
						    board[row - 1, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col + 1]);
					}
					else
					{
						if (this.Team != board[row - 1, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (row + 1 < 8)
				{
					if (board[row + 1, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col + 1]);
					}
					else
					{
						if (this.Team != board[row + 1, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				if (col + 1 < 8)
				{
					if (board[row, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row, col + 1]);
					}
					else
					{
						if (this.Team != board[row, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
			}
		}
	}
}
