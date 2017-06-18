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
                    if (Common.Board[row, col].BackColor == Color.Blue && Common.Board[row, col].Chess != null && Common.Board[row, col].Chess.IsKing == true)
                    {
                        //do nothing
                    }
                    else
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

		protected void minimaxRoot()
		{
			int depth = 1;
			int valueint = -9999;
			int value = 0;
			int alpha = -10000, beta = 10000;
			bool isMax = true;
			ChessSquare[,] temp = new ChessSquare[8, 8];
			ChessSquare[,] bestMove = new ChessSquare[8, 8];
			ChessSquare[,] a = new ChessSquare[8, 8];
			temp = Common.Board;
			this.createList(temp, 2, avalBoard);
			/*value = minimax(depth - 1, ref temp, alpha, beta, !isMax);
            for (int i = 0; i < avalBoard.Count; i++) {
                a = avalBoard[i];
                if (value == BestValue(ref a)) {
                    bestMove = a;
                    break;
                }
            }*/
			for (int i = 0; i < avalBoard.Count; i++)
			{
				//Copy(ref a,  ref avalBoard[i]);
				a = avalBoard[i];
				value = minimax(depth - 1, ref a, alpha, beta, !isMax);
				if (value >= valueint)
				{
					bestMove = a;
					valueint = value;
				}
			}
			for (int k = 0; k < 8; k++)
			{
				for (int l = 0; l < 8; l++)
				{
					Common.Board[k, l].Chess = bestMove[k, l].Chess;
					Common.Board[k, l].Image = bestMove[k, l].Image;
				}
			}
			Common.IsTurn++;
			avalBoard.Clear();
		}

		List<ChessSquare[,]> tempList = new List<ChessSquare[,]>();

		protected int minimax(int depth, ref ChessSquare[,] root, int alpha, int beta, bool isMax)
		{

			if (depth == 0)
				return isMax ? this.BestValue(ref root) : -this.BestValue(ref root);
			ChessSquare[,] a = new ChessSquare[8, 8];

			int team = 0;
			if (isMax == true) team = 2; //black
			else team = 1;                 //white

			//ke list can move from root
			createList(root, team, tempList);
			if (team == 2)
			{
				int valueint = -9999;
				for (int i = 0; i < tempList.Count; i++)
				{
					a = tempList[i];
					valueint = Math.Max(valueint, minimax(depth - 1, ref a, alpha, beta, !isMax));
					/*alpha = Math.Max(alpha, valueint);
                    if (beta <= alpha)
                        return valueint;
                     */
				}
				tempList.Clear();
				return valueint;
			}
			else
			{
				int valueint = 9999;
				for (int i = 0; i < tempList.Count; i++)
				{
					a = tempList[i];
					valueint = Math.Min(valueint, minimax(depth - 1, ref a, alpha, beta, !isMax));
					/*beta = Math.Min(beta, valueint);
					 if (beta <= alpha)
						 return valueint;
					*/
				}
				tempList.Clear();
				return valueint;
			}
			//your code is here lol...

		}
		protected void createList(ChessSquare[,] temp, int team, List<ChessSquare[,]> listRoot)
		{

			// ChessSquare[,] tempB = new ChessSquare[8, 8];
			int tempRow, tempCol;
			//tempB = (ChessSquare[,])temp.Clone();
			for (int row = 0; row < 8; row++)
			{
				for (int col = 0; col < 8; col++)
				{
					if (temp[row, col].Chess != null)
					{
						if (temp[row, col].Chess.Team == team)
						{

							temp[row, col].Chess.FindWay(ref temp, row, col);

							if (Common.CanMove.Count != 0)
							{
								for (int i = 0; i < Common.CanMove.Count; i++)
								{
									ChessSquare[,] tempA = new ChessSquare[8, 8];
									Copy(ref temp, ref tempA);
									tempRow = Common.CanMove[i].row;
									tempCol = Common.CanMove[i].col;
									tempA[tempRow, tempCol].Image = tempA[row, col].Image;
									tempA[tempRow, tempCol].Chess = tempA[row, col].Chess;
									tempA[row, col].Image = null;
									tempA[row, col].Chess = null;

									listRoot.Add(tempA);
								}
								Common.CanMove.Clear();
							}
						}
					}
					/* else
					 {
						 Copy(ref temp, ref tempA);

					 }*/
				}
			}
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
                    this.Chess.FindWay(ref Common.Board, this.row, this.col); //findway can move and eat
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
					//phong hau cho tot

					if (Common.CheckPromote == true)
					{
							
							if (Common.Board[Common.RowProQueen, Common.ColProQueen].Chess.Team == 1) //white
							{
								//Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
								//Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;
							this.Chess = new Queen();
							this.Chess.Team = (int)ColorTeam.White;
								Common.Board[Common.RowProQueen, Common.ColProQueen].Chess = this.Chess;
							Common.Board[Common.RowProQueen, Common.ColProQueen].Image = Image.FromFile(linkWhiteQueen);
								Common.Board[Common.RowProQueen, Common.ColProQueen].Chess.Evaluation = 90;
							}
							else //black
							{
								Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
								Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;
							this.Chess = new Queen();
							this.Chess.Team = (int)ColorTeam.Black;
								Common.Board[Common.RowProQueen, Common.ColProQueen].Chess = this.Chess;
								Common.Board[Common.RowProQueen, Common.ColProQueen].Image = Image.FromFile(linkWhiteQueen);
								Common.Board[Common.RowProQueen, Common.ColProQueen].Chess.Evaluation = -90;
							}
							Common.CheckPromote = false;
					}

					Common.IsTurn++; //change turn
					Common.CanMove.Clear();


                    //check if King is danger
                    this.Chess.FindWay(ref Common.Board, this.row, this.col);
                    this.BackChessBoard();
                    for (int i = 0; i < Common.CanMove.Count; i++)
                    {
                        if (Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
                        else
                        {
                            if (Common.CanMove[i].Chess.IsKing == true) Common.CanMove[i].BackColor = Color.Blue;
                        }
                        
                    }
                    Common.CanMove.Clear();

                    if(Common.IsMode == false && Common.IsTurn % 2 == 1)
                    this.minimaxRoot();
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

        public int BestValue(ref ChessSquare[,] board)
        {
            int Val = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j].Chess != null)
                    {
                        Val += board[i, j].Chess.Evaluation;
                    }
                }
            }
            return Val;
        }
        public void Copy(ref ChessSquare[,] src, ref ChessSquare[,] dst)
        {
            for (int k = 0; k < 8; k++)
            {
                for (int l = 0; l < 8; l++)
                {
                    dst[k, l] = new ChessSquare(src[k, l]);
                }
            }
        }
    }
}
 