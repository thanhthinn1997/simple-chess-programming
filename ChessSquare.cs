﻿using System;
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

        private List<ChessSquare[,]> avalBoard;

		protected override void OnClick(EventArgs e)
		{

			if (Common.RowSelected == this.Row && Common.ColSelected == this.Col ) //squares click itself for 2 time, hide the way and return old background
			{
				Common.IsSelectedSquare = false; //selected yet
				for (int i = 0; i < Common.CanMove.Count; i++)
				{
					if(Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
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
			if (Common.IsTurn % 2 == 0)
			{
                //create turn for 2 team, white go first
                if (Common.IsMode == true)
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
                    this.minimaxRoot();
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

        protected void minimaxRoot()
        {
            int depth = 2;
            int value = -9999;
            bool isMax = true;
            ChessSquare[,] temp = new ChessSquare[8, 8];
            ChessSquare[,] bestMove = new ChessSquare[8, 8];
            temp = Common.Board;
            this.createList(ref temp , 1, avalBoard);
            //coding minimax in here; //having this minimax(depth-1, nowBoard, !isMax);

            Common.Board = bestMove;
            Common.IsTurn++;
        }

        List<ChessSquare[,]> tempList;

        /*protected int minimax(int depth, ref ChessSquare[,] root, bool isMax)
        {
            int team = 0;
            if (isMax == true) team = 1;
            else team = 2;

            if (depth == 0) return -this.BestValue(ref root);

            //make list can move from root
            createList(ref root, team, tempList);

            //your code is here lol...
        }*/

        protected void createList(ref ChessSquare[,] temp, int team, List<ChessSquare[,] > listRoot)
        {
            ChessSquare[,] tempA = new ChessSquare[8, 8];
            int tempRow, tempCol;
            for (int row = 0; row < 8; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    if(temp[row,col].Chess.Team == team)
                    {
                        temp[row,col].Chess.FindWay(ref temp, row, col);
                        if(Common.CanMove.Count != 0)
                        {
                            for(int i = 0; i < Common.CanMove.Count; i++)
                            {
                                tempA = temp;
                                tempRow = Common.CanMove[i].row;
                                tempCol = Common.CanMove[i].col;
                                tempA[tempRow, tempCol].Image = temp[row, col].Image;
                                tempA[tempRow, tempCol].Chess = temp[row, col].Chess;
                                tempA[row, col].Image = null;
                                tempA[row, col].Chess = null;

                                listRoot.Add(tempA);
                            }
                            Common.CanMove.Clear();
                        }
                    }
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
				Common.IsSelectedSquare = false;
				if (Common.CanMove.Contains(this))//inside list Can EAT
				{
                    for(int i = 0; i < Common.CanMove.Count; i++)
                    {
                        if (Common.CanMove[i].Chess == null) Common.CanMove[i].Image = null;
                    }
					this.Image = Common.Board[Common.RowSelected, Common.ColSelected].Image; 
					Common.Board[Common.RowSelected, Common.ColSelected].Image = null;
					Common.Board[Common.RowSelected, Common.ColSelected].BackColor = Common.OldBackGround;
					this.BackChessBoard();

					this.Chess = Common.Board[Common.RowSelected, Common.ColSelected].Chess;
				    Common.Board[Common.RowSelected, Common.ColSelected].Chess = null;

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
    }
}
 