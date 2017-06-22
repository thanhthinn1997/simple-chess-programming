using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChessKing
{
	class Pawn : Chess
	{
        string linkPoint = "Image\\circle.png";
       
        public Pawn()
        {
            this.isPawn = true;
        }

        public override void FindWay( ChessSquare[,] board, int row, int col)
		{
			//check mau -> xet quan co di tu duoi len
			if (board[row, col].Chess.Team == (int)ColorTeam.White)
			{
				if (row < 7)
				{
					if (col - 1 >= 0 && row > 0)
					{
						//check duong cheo
						if (board[row - 1, col - 1].Chess != null)
						{
							if (this.Team != board[row - 1, col - 1].Chess.Team)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[row - 1, col - 1].BackColor = Color.Red;

								if (row - 1 == 0 && board[row, col].Chess.Team == 1)
								{
									Common.CheckPromote = true;
								}
								Common.CanMove.Add(board[row - 1, col - 1]);
							}
							else
							{ }
						}
						else
						{ }
					}
					else
					{ }

					if (col + 1 < 8 && row > 0)
					{
						if (board[row - 1, col + 1].Chess != null)
						{
							if (this.Team != board[row - 1, col + 1].Chess.Team)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[row - 1, col + 1].BackColor = Color.Red;

								if (row - 1 == 0 && board[row, col].Chess.Team == 1)
								{
									Common.CheckPromote = true;
								}
								Common.CanMove.Add(board[row - 1, col + 1]);
							}
							else
							{ }
						}
						else
						{ }
					}
					else
					{ }

					if (row == 6)
					{
						for (int i = row - 1; i >= 4; i--)
						{
							if (board[i, col].Chess == null)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[i, col].Image = Image.FromFile(linkPoint);
								Common.CanMove.Add(board[i, col]);
							}
							else
								break;
						}
					}

					else
					{
						if (board[row - 1, col].Chess == null)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							    board[row - 1, col].Image = Image.FromFile(linkPoint);
							if (row - 1 == 0 && board[row, col].Chess.Team == 1)
							{
								Common.CheckPromote = true;
							}
							Common.CanMove.Add(board[row - 1, col]);
							//Dk phong hau
							
						}
						else
						{ }
					}
				}
				else
				{ }
				
			}
			//check mau, xet quan co tu tren xuong duoi
			else
			{
				if (row >= 1)
				{
					if (col - 1 >= 0 && row < 7)
					{
						if (board[row + 1, col - 1].Chess != null)
						{
							if (this.Team != board[row + 1, col - 1].Chess.Team)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[row + 1, col - 1].BackColor = Color.Red;

								if (row + 1 == 0 && board[row, col].Chess.Team == 2)
								{
									Common.CheckPromote = true;
								}
								Common.CanMove.Add(board[row + 1, col - 1]);
							}
							else
							{ }
						}
						else
						{ }
					}
					else
					{ }

					if (col + 1 < 8 && row < 7)
					{
						if (board[row + 1, col + 1].Chess != null)
						{
							if (this.Team != board[row + 1, col + 1].Chess.Team)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[row + 1, col + 1].BackColor = Color.Red;

								if (row + 1 == 0 && board[row, col].Chess.Team == 2)
								{
									Common.CheckPromote = true;
								}
								Common.CanMove.Add(board[row + 1, col + 1]);
							}
							else
							{ }
						}
						else
						{ }
					}
					else
					{ }


					if (row == 1)
					{
						for (int i = row + 1; i <= 3; i++)
						{
							if (board[i, col].Chess == null)
							{
                                if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
								    board[i, col].Image = Image.FromFile(linkPoint);
								Common.CanMove.Add(board[i, col]);
							}
							else
								break;
						}
					}
					else
					{
						if (row < 7 && board[row + 1, col].Chess == null)
						{
                            if (Common.IsTurn % 2 == 0 || Common.IsMode == true)
							board[row + 1, col].Image = Image.FromFile(linkPoint);
							if (row + 1 == 7 && board[row, col].Chess.Team == 2)
							{
								Common.CheckPromote = true;
							}
							Common.CanMove.Add(board[row + 1, col]);
							//dk phong hau
							
						}
						else
						{ }
					}
				}
				else
				{ }
			}
		}
	}

}