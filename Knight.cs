using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessKing
{
	class Knight : Chess
	{
        string linkPoint = "Image\\circle.png";
        public Knight()
		{
			this.isKnight = true;
		}
        public override void FindWay( ChessSquare[,] board, int row, int col)
		{
			//row-2
			if (row - 2 >= 0)
			{
				//col-1
				if (col - 1 >= 0)
				{
					if (board[row - 2, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true) //trang
						    board[row - 2, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 2, col - 1]);
					}
					else
					{
						if (this.Team != board[row - 2, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 2, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 2, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }

				//col+1
				if (col + 1 < 8)
				{
					if (board[row - 2, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 2, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 2, col + 1]);
					}
					else
					{
						if (this.Team != board[row - 2, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 2, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 2, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }
			}

			//row-1
			if (row - 1 >= 0)
			{
				//col-2
				if (col - 2 >= 0)
				{
					if (board[row - 1, col - 2].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col - 2].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col - 2]);
					}
					else
					{
						if (this.Team != board[row - 1, col - 2].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col - 2].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col - 2]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }

				//col +2
				if (col + 2 < 8)
				{
					if (board[row - 1, col + 2].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row - 1, col + 2].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row - 1, col + 2]);
					}
					else
					{
						if (this.Team != board[row - 1, col + 2].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col + 2].BackColor = Color.Red;
							Common.CanMove.Add(board[row - 1, col + 2]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }
			}

			//row+2
			if (row + 2 < 8)
			{
				//col -1
				if (col - 1 >= 0)
				{
					if (board[row + 2, col - 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 2, col - 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 2, col - 1]);
					}
					else
					{
						if (this.Team != board[row + 2, col - 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 2, col - 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 2, col - 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }

				//col+1
				if (col + 1 < 8)
				{
					if (board[row + 2, col + 1].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 2, col + 1].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 2, col + 1]);
					}
					else
					{
						if (this.Team != board[row + 2, col + 1].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 2, col + 1].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 2, col + 1]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }
			}

			//row+1
			if (row + 1 < 8)
			{
				//col -2
				if (col - 2 >= 0)
				{
					if (board[row + 1, col - 2].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
                             board[row + 1, col - 2].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col - 2]);
					}
					else
					{
						if (this.Team != board[row + 1, col - 2].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col - 2].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col - 2]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }

				//col +2
				if (col + 2 < 8)
				{
					if (board[row + 1, col + 2].Chess == null)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row + 1, col + 2].Image = Image.FromFile(linkPoint);
						Common.CanMove.Add(board[row + 1, col + 2]);
					}
					else
					{
						if (this.Team != board[row + 1, col + 2].Chess.Team)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row + 1, col + 2].BackColor = Color.Red;
							Common.CanMove.Add(board[row + 1, col + 2]);
						}
						else
						{
							//do nothing
						}
					}
				}
				else
				{ }
			}
		}
	}
}