using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessKing
{
	class Castle : Chess
	{
        string linkPoint = "Image\\circle.png";
       public Castle()
		{
			this.isCastle = true;
		}
        public override void FindWay( ChessSquare[,] board, int row, int col)
		{
			for (int j = col-1; j >= 0; j--)
			{
				if (board[row,j].Chess == null)
				{
					//load blue poin on button, in the way of piece
                    if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
					    board[row, j].Image = Image.FromFile(linkPoint);
					Common.CanMove.Add(board[row, j]);
				}
				else
				{
					//square is not empty, check color ,if diffirence about color, change back color
					if (this.Team != board[row, j].Chess.Team)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row, j].BackColor = Color.Red;
						Common.CanMove.Add(board[row, j]);
					}
					else
					{ 
						//do nothing 
					}
					break;
				}
				
			}

			for (int j = col+1; j <8 ; j++)
			{
				if (board[row,j].Chess == null)
				{
                    if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
					    board[row, j].Image = Image.FromFile(linkPoint);
					Common.CanMove.Add(board[row, j]);
				}
				else
				{
					if (this.Team != board[row, j].Chess.Team)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[row, j].BackColor = Color.Red;
						Common.CanMove.Add(board[row, j]);
					}
					else
					{
						//do nothing 
					}
					break;
				}
			}

			for (int i = row-1; i >= 0; i--)
			{
				if (board[i,col].Chess == null)
				{
                    if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
					    board[i, col].Image = Image.FromFile(linkPoint);
					Common.CanMove.Add(board[i, col]);
				}
				else
				{
					if (this.Team != board[i, col].Chess.Team)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[i, col].BackColor = Color.Red;
						Common.CanMove.Add(board[i, col]);
					}
					else
					{
						//do nothing 
					}
					break;
				}
			}

			for (int i = row+1; i < 8; i++)
			{
				if (board[i,col].Chess == null)
				{
                    if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
					    board[i, col].Image = Image.FromFile(linkPoint) ;
					Common.CanMove.Add(board[i, col]);
				}
				else
				{
					if (this.Team != board[i, col].Chess.Team)
					{
                        if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
						    board[i, col].BackColor = Color.Red;
						Common.CanMove.Add(board[i, col]);
					}
					else
					{
						//do nothing 
					}
					break;
				}
			}
		}
	}
}
