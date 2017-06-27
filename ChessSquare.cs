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
		string linkBlackQueen = "Image\\Chess_qdt60.png";
		string linkWhiteQueen = "Image\\Chess_qlt60.png";
		public ChessSquare(ChessSquare a)
		{
			Chess = a.Chess;
			Image = a.Image;
			Row = a.Row;
			Col = a.Col;
		}

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
					//if (Common.Board[row, col].Chess != null && Common.Board[row, col].Chess.IsKing == true && this.Check() == true)
					//{
					//do nothing
					//}
					//else
					{
						if (row % 2 == 0)
						{
							if (col % 2 == 0)
							{
								Common.Board[row, col].BackColor = Color.LavenderBlush;
							}
							else
							{
								Common.Board[row, col].BackColor = Color.DarkSlateGray;
							}
						}
						else
						{
							if (col % 2 == 0)
							{
								Common.Board[row, col].BackColor = Color.DarkSlateGray;
							}
							else
							{
								Common.Board[row, col].BackColor = Color.LavenderBlush;
							}
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

		private List<ChessSquare[,]> avalBoard = new List<ChessSquare[,]>();

		protected override void OnClick(EventArgs e)
		{

			if (Common.RowSelected == this.Row && Common.ColSelected == this.Col) //squares click itself for 2 time, hide the way and return old background
			{
				Common.IsSelectedSquare = false; //selected yet
				for (int i = 0; i < Common.CanMove.Count; i++)
				{
					if (Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
				}
				this.BackChessBoard();
				this.BackColor = Common.OldBackGround;
				Common.CanMove.Clear();
				Common.RowSelected = -1;
				Common.ColSelected = -1;
				return;
			}
			if (this.Chess == null && !Common.IsSelectedSquare)
			{
				return;
			}

			//Mode = true is 2 player, Mode = false is 1 player
			if (Common.IsTurn % 2 == 0) //white
			{
				if (Common.IsSelectedSquare == false) // chua click 
				{
					if (this.Chess.Team == (int)ColorTeam.White)
					{
						this.ChangeTurn();
					}
					else
						return;
				}
				else //da click
				{
					this.ChangeTurn();
				}
			}
			else // black
			{
				if (Common.IsMode == false) //1 player
				{
					//nope
				}
				else //2 player
				{
					if (Common.IsSelectedSquare == false)//chua click
					{
						if (this.Chess.Team == (int)ColorTeam.Black) // check xem co dung team dang duoc di hay khong
						{
							this.ChangeTurn();
						}
						else
							return;
					}
					else //da click
					{
						this.ChangeTurn();
					}
				}
			}
		}

        protected void Undo(ref ChessSquare[,] temp, int befRow, int befCol, Chess tempChess, Image tempImage)
        {
            temp[befRow, befCol].Chess = temp[this.Row, this.Col].Chess;
            temp[befRow, befCol].Image = temp[this.Row, this.Col].Image;
            temp[this.Row, this.Col].Chess = tempChess;
            temp[this.Row, this.Col].Image = tempImage;
        }

        protected void minimaxRoot()
        {
            int depth = Common.Depth;
            double valueint = -9999;
            double value = 0;
            double alpha = -10000, beta = 10000;
            bool isMax = true;
            ChessSquare[,] temp = new ChessSquare[8, 8];
            ChessSquare[,] bestMove = new ChessSquare[8, 8];
            ChessSquare[,] a = new ChessSquare[8, 8];
            temp = Common.Board;
            //this.createList(temp, 2, avalBoard);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (temp[i, j].Chess != null && temp[i, j].Chess.Team == (int)ColorTeam.Black)
                    {
                        List<ChessSquare> RootTemp = new List<ChessSquare>();

                        int befRow = i;
                        int befCol = j;
                        temp[i, j].Chess.FindWay(temp, i, j);

                        for (int k = 0; k < Common.CanMove.Count; k++)
                        {
                            RootTemp.Add(Common.CanMove[k]);
                        }
                        Common.CanMove.Clear();

                        Chess tempChess = new Chess();
                        Image tempImage = null;

                        for (int k = 0; k < RootTemp.Count; k++)
                        {
                            tempChess = temp[RootTemp[k].Row, RootTemp[k].Col].Chess;
                            tempImage = temp[RootTemp[k].Row, RootTemp[k].Col].Image;

                            temp[RootTemp[k].Row, RootTemp[k].Col].Chess = temp[befRow, befCol].Chess;
                            temp[RootTemp[k].Row, RootTemp[k].Col].Image = temp[befRow, befCol].Image;
                            temp[befRow, befCol].Chess = null;
                            temp[befRow, befCol].Image = null;

                            value = minimax(depth - 1, ref temp, alpha, beta, !isMax);
                            if (value >= valueint)
                            {
                                for(int m = 0; m < 8; m++)
                                {
                                    for(int n = 0; n < 8; n++)
                                    {
                                        bestMove[m, n] = new ChessSquare(temp[m, n]);
                                    }
                                }
                                //bestMove = temp;
                                valueint = value;
                            }
                            temp[RootTemp[k].Row, RootTemp[k].Col].Undo(ref temp, befRow, befCol, tempChess, tempImage);
                        }
                        RootTemp.Clear();
                    }

                }
            }

            for (int k = 0; k < 8; k++)
            {
                for (int l = 0; l < 8; l++)
                {
                    Common.Board[k, l].Row = bestMove[k, l].Row;
                    Common.Board[k, l].Col = bestMove[k, l].Col;
                    Common.Board[k, l].Chess = bestMove[k, l].Chess;
                    Common.Board[k, l].Image = bestMove[k, l].Image;
                }
            }

            Common.IsTurn++;
        }

        protected double minimax(int depth, ref ChessSquare[,] root, double alpha, double beta, bool isMax)
        {

            if (depth == 0)
                return -this.BestValue(root);
            ChessSquare[,] a = new ChessSquare[8, 8];

            double valueint;

            int team = 0;
            if (isMax == true)
            {
                team = 2;
                valueint = -9999;
            } //black
            else
            {
                team = 1;
                valueint = 9999;
            } //white

            //ke list can move from root
            //List<ChessSquare[,]> tempList = new List<ChessSquare[,]>();
            //createList(root, team, tempList);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (root[i, j].Chess != null && root[i, j].Chess.Team == team)
                    {
                        List<ChessSquare> RootTemp = new List<ChessSquare>();

                        int befRow = i;
                        int befCol = j;
                        root[i, j].Chess.FindWay(root, i, j);

                        for (int k = 0; k < Common.CanMove.Count; k++)
                        {
                            RootTemp.Add(Common.CanMove[k]);
                        }
                        Common.CanMove.Clear();

                        Chess tempChess = new Chess();
                        Image tempImage = null;

                        for (int k = 0; k < RootTemp.Count; k++)
                        {
                            tempChess = root[RootTemp[k].Row, RootTemp[k].Col].Chess;
                            tempImage = root[RootTemp[k].Row, RootTemp[k].Col].Image;

                            root[RootTemp[k].Row, RootTemp[k].Col].Chess = root[befRow, befCol].Chess;
                            root[RootTemp[k].Row, RootTemp[k].Col].Image = root[befRow, befCol].Image;
                            root[befRow, befCol].Chess = null;
                            root[befRow, befCol].Image = null;

                            if (team == 2)
                            {
                                valueint = Math.Max(valueint, minimax(depth - 1, ref root, alpha, beta, !isMax));
                                alpha = Math.Max(alpha, valueint);
                                if (beta <= alpha)
                                {
                                    root[RootTemp[k].Row, RootTemp[k].Col].Undo(ref root, befRow, befCol, tempChess, tempImage);
                                    return valueint;
                                }
                            }
                            else
                            {
                                valueint = Math.Min(valueint, minimax(depth - 1, ref root, alpha, beta, !isMax));
                                beta = Math.Min(beta, valueint);
                                if (beta <= alpha)
                                {
                                    root[RootTemp[k].Row, RootTemp[k].Col].Undo(ref root, befRow, befCol, tempChess, tempImage);
                                    return valueint;
                                }
                            }
                            root[RootTemp[k].Row, RootTemp[k].Col].Undo(ref root, befRow, befCol, tempChess, tempImage);
                        }
                        RootTemp.Clear();
                    }
                }
            }    
            return valueint;
        }

		protected void ChangeTurn()
		{
			//select yet
			if (Common.IsSelectedSquare == false)
			{
				//check square is not Empty 
				if (this.Chess != null)
				{
					Common.IsSelectedSquare = true;

					Common.OldBackGround = Common.Board[this.row, this.col].BackColor; //keep background color of chess square 
					this.Chess.FindWay(Common.Board, this.row, this.col); //findway can move and eat
					this.findWayAction();
					this.BackColor = System.Drawing.Color.Violet; //change background to violet
					Common.RowSelected = this.row; //keep the row
					Common.ColSelected = this.col; //keep the col

				}
				else
				{
					//do nothing
				}
			}
			//selected
			else
			{
				Common.IsSelectedSquare = false;//gan lai bang false de lan sau con thuc hien

				if (Common.CanMove.Contains(this))//inside list Can Move
				{
					Common.RowProQueen = this.Row;
					Common.ColProQueen = this.Col;
					for (int i = 0; i < Common.CanMove.Count; i++)
					{
						if (Common.CanMove[i].Chess == null)
						{
							Common.CanMove[i].Image = null;
						}
					}
					//thay doi hinh anh
					this.Image = Common.Board[Common.RowSelected, Common.ColSelected].Image;
					Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
					//tra ve background cu
					Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
					this.BackChessBoard();
					//thay doi quan co
					this.Chess = Common.Board[Common.RowSelected, Common.ColSelected].Chess;
					Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;

					Common.IsTurn++; //change turn
					Common.CanMove.Clear();

					for (int j = 0; j < 8; j++)
					{
						if (Common.Board[0, j].Chess != null && Common.Board[0, j].Chess.IsPawn) phongHau(ref Common.Board[0, j]);
						if (Common.Board[7, j].Chess != null && Common.Board[7, j].Chess.IsPawn) phongHau(ref Common.Board[7, j]);
					}

					if (Common.IsMode == false && Common.IsTurn % 2 == 1)
					{
						this.minimaxRoot();
						this.BackChessBoard();
					}

					bool CheckKing = false;
					ChessSquare Kingtemp = new ChessSquare();

					this.Check(ref CheckKing, ref Kingtemp);
					if (CheckKing == true)
					{
						//MessageBox.Show(CheckKing.ToString());
						Common.CanMove.Clear();
						Checkmate(Kingtemp);
					}
					else
					{ }

                    int tempKing = 0;
                    int color = 0;

					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
						{
                            if (Common.Board[i, j].Chess == null) Common.Board[i, j].Image = null;
                            else if (Common.Board[i, j].Chess.IsKing) { tempKing++; color = Common.Board[i, j].Chess.Team; }
						}

                    if(tempKing == 1)
                    {
                        if (color == 1) MessageBox.Show("The White Wins!");
                        else MessageBox.Show("The Black Wins!");
                    }
                    else
                    { }

					Common.CanEat.Clear();
					Common.CanMove.Clear();

					BackChessBoard();
					if (Kingtemp.Chess != null && Kingtemp.Chess.IsKing == true)
					{
						Common.Board[Kingtemp.Row, Kingtemp.Col].BackColor = Color.BlueViolet;
					}

				}
				else //not inside caneat list
				{
					Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
					for (int i = 0; i < Common.CanMove.Count; i++)
					{
						if (Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
					}
					this.BackChessBoard();
					Common.CanMove.Clear();
				}
			}
		}

		private void phongHau(ref ChessSquare temp)
		{
			Chess newQueen = new Queen();
			if (temp.Chess.Team == 1) //white
			{
				//Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
				//Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;
				newQueen.Team = (int)ColorTeam.White;
				temp.Chess = newQueen;
				temp.Image = Image.FromFile(linkWhiteQueen);
				temp.Chess.Evaluation = 90;
			}
			else //black
			{
				newQueen.Team = (int)ColorTeam.Black;
				temp.Chess = newQueen;
				temp.Image = Image.FromFile(linkBlackQueen);
				temp.Chess.Evaluation = -90;
			}
		}

		private void Check(ref bool temp, ref ChessSquare KingTemp)
		{
			//check if King is danger
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
				{
					if (Common.Board[i, j].Chess != null)
					{
						Common.Board[i, j].Chess.FindWay(Common.Board, Common.Board[i, j].row, Common.Board[i, j].col);
						for (int k = 0; k < Common.CanMove.Count; k++)
						{
							if (Common.CanMove[k].Chess == null)
							{
								Common.CanMove[k].Image = null;
							}
							else
							{
								if (Common.CanMove[k].Chess.IsKing == true)
								{
									temp = true;
									KingTemp = new ChessSquare(Common.CanMove[k]);
								}
								else
								{ }
							}
						}
					}
					else { }
					Common.CanMove.Clear();
				}
			if (temp == true) return;
			temp = false;
		}

		private void Checkmate(ChessSquare temp)
		{
			bool checkmate = true;
			//temp.Chess.FindWay(Common.Board, temp.Row, temp.Col);

			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
				{
					if (Common.Board[i, j].Chess != null)
					{
						if (Common.Board[i, j].Chess.Team != temp.Chess.Team)
						{
							Common.Board[i, j].Chess.FindWay(Common.Board, Common.Board[i, j].Row, Common.Board[i, j].Col);
							for (int k = 0; k < Common.CanMove.Count; k++)
							{
								if (Common.CanMove[k].Chess == null)
								{
									Common.CanMove[k].Image = null;
								}
								Common.CanEat.Add(Common.CanMove[k]);
							}
							Common.CanMove.Clear();
						}
					}
					else
					{
					}
				}
			Common.CanMove.Clear();

			temp.Chess.FindWay(Common.Board, temp.Row, temp.Col);

			for (int i = 0; i < Common.CanMove.Count; i++)
			{
				if (Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
			}

			if (Common.CanMove.Count == 1)
			{
				if (Common.CanEat.Contains(Common.CanMove[Common.CanMove.Count - 1]))
				{
					ChessSquare temp2 = new ChessSquare(Common.CanMove[Common.CanMove.Count - 1]);
					Common.CanMove.Clear();

					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
						{
							if (Common.Board[i, j].Chess != null)
							{
								if (Common.Board[i, j].Chess.Team == temp.Chess.Team)
								{
									Common.Board[i, j].Chess.FindWay(Common.Board, Common.Board[i, j].Row, Common.Board[i, j].Col);
									for (int k = 0; k < Common.CanMove.Count; k++)
									{
										if (Common.CanMove[k].Chess == null)
										{
											Common.CanMove[k].Image = null;
										}
										if (Common.CanMove[k].Col == temp2.Col && Common.CanMove[k].Row == temp2.Row)
										{
											checkmate = false;
											break;
										}
									}
									Common.CanMove.Clear();
								}
							}
							else
							{
							}
						}
				}
			}
			else
			{
				while (Common.CanMove.Count > 0)
				{
					if (!Common.CanEat.Contains(Common.CanMove[Common.CanMove.Count - 1])) checkmate = false;
					Common.CanMove.Remove(Common.CanMove[Common.CanMove.Count - 1]);
				}
			}

			if (checkmate == true)
			{
				if (temp.Chess.Team == (int)ColorTeam.White) MessageBox.Show("The Black Wins");
				else MessageBox.Show("The White Wins");
			}
		}

		public double PieceEvaluation(double[,] a, int row, int col)
		{
			return a[row, col];
		}

		public double getPieceEvaluation(ChessSquare[,] board, int row, int col)
		{
			if (board[row, col] == null)
			{
				return 0;
			}
			if (board[row, col].Chess.IsPawn == true) //pawn
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.PawnWhite, row, col) : PieceEvaluation(Common.PawnBlack, row, col);
			}
			else if (board[row, col].Chess.IsCastle == true) //Castle
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.CastleWhite, row, col) : PieceEvaluation(Common.CastleBlack, row, col);
			}
			else if (board[row, col].Chess.IsKnight == true) //Knight
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.KnightWhite, row, col) : PieceEvaluation(Common.KnightBlack, row, col);
			}
			else if (board[row, col].Chess.IsBishop == true) //Bishop
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.BishopWhite, row, col) : PieceEvaluation(Common.BishopBlack, row, col);
			}
			else if (board[row, col].Chess.IsQueen == true) //Queen
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.QueenWhite, row, col) : PieceEvaluation(Common.QueenBlack, row, col);
			}
			else //if (board[row, col].Chess.IsKing == true) //King
			{
				return (board[row, col].Chess.Evaluation > 0) ? PieceEvaluation(Common.KingWhite, row, col) : PieceEvaluation(Common.KingBlack, row, col);
			}
		}
		public double BestValue(ChessSquare[,] board)
		{
			double Val = 0;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (board[i, j].Chess != null)
					{
						if (Common.IsEvaluation == true)
						{
							Val = Val + board[i, j].Chess.Evaluation + ((board[i, j].Chess.Evaluation > 0) ? getPieceEvaluation(board, i, j) : -getPieceEvaluation(board, i, j));
						}
						else
						{
							Val = Val + board[i, j].Chess.Evaluation;
						}
					}
				}
			}
			return Val;
		}
	}
}
