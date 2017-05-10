using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessKing
{
	class Bishop : Chess
	{
		string linkPoint = "Image\\circle.png";
		public override void FindWay(ref ChessSquare[,] board, int row, int col)
		{
			int _row = row;
			int _col = col;

			//left up
			int flag = 0;
			for (int i = _row - 1; i >= 0; i--)
			{
				if(flag == 0)
				{
					for (int j = _col - 1; j >= 0; j--)
					{
						if (board[i, j].Chess == null)
						{
							//load blue poin on button, in the way of piece
							board[i, j].Image = Image.FromFile(linkPoint);
							Common.CanMove.Add(board[i, j]);
						}
						else
						{
							//square is not empty, check color ,if diffirence about color, change back color
							if (this.Team != board[i, j].Chess.Team)
							{
								board[i, j].BackColor = Color.Red;
								Common.CanEat.Add(board[i, j]);
							}
							else
							{
								//do nothing 
							}
							flag = 1;
						}
						_col = _col - 1;
						break;
					}
				}
				else
				{
					break;
				}
			}

			//left down
			flag = 0;
			_row = row;
			_col = col;
			for (int i = _row + 1; i < 8; i++)
			{
				if(flag == 0)
				{
					for (int j = _col - 1;   j >= 0; j--)
					{
						if (board[i, j].Chess == null)
						{
							//load blue poin on button, in the way of piece
							board[i, j].Image = Image.FromFile(linkPoint);
							Common.CanMove.Add(board[i, j]);
						}
						else
						{
							//square is not empty, check color ,if diffirence about color, change back color
							if (this.Team != board[i, j].Chess.Team)
							{
								board[i, j].BackColor = Color.Red;
								Common.CanEat.Add(board[i, j]);
							}
							else
							{
								//do nothing 
							}
							flag = 1;
						}
						_col = _col - 1;
						break;
					}
				}
				else
				{
					break;
				}
			}

			//right up
			flag = 0;
			_row = row;
			_col = col;
			for (int i = _row - 1; i >= 0; i--)
			{
				if (flag == 0)
				{
					for (int j = _col + 1; j < 8; j++) //do tru 1 o tren
					{
						if (board[i, j].Chess == null)
						{
							//load blue poin on button, in the way of piece
							board[i, j].Image = Image.FromFile(linkPoint);
							Common.CanMove.Add(board[i, j]);
						}
						else
						{
							//square is not empty, check color ,if diffirence about color, change back color
							if (this.Team != board[i, j].Chess.Team)
							{
								board[i, j].BackColor = Color.Red;
								Common.CanEat.Add(board[i, j]);
							}
							else
							{
								//do nothing 
							}
							flag = 1;
						}
						_col = _col + 1;
						break;
					}
				}
				else
				{
					break;
				}
			}

			//right down
			flag = 0;
			_row = row;
			_col = col;
			for (int i = _row + 1; i < 8; i++)
			{
				if(flag == 0)
				{
					for (int j = _col + 1; j<8 ; j++)
					{
						if (board[i, j].Chess == null)
						{
							//load blue poin on button, in the way of piece
							board[i, j].Image = Image.FromFile(linkPoint);
							Common.CanMove.Add(board[i, j]);
						}
						else
						 {
							//square is not empty, check color ,if diffirence about color, change back color
							if (this.Team != board[i, j].Chess.Team)
							{
								board[i, j].BackColor = Color.Red;
								Common.CanEat.Add(board[i, j]);
							}
							else
							{
								//do nothing 
							}
							flag = 1;
						}
						_col = _col + 1;
						break;
					}
				}
				else
				{
					break;
				}
			}
		}
	}
}
