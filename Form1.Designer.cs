namespace ChessKing
{
	partial class frmChessKing
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn2Player = new System.Windows.Forms.Button();
			this.bnt1Player = new System.Windows.Forms.Button();
			this.bntQuit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn2Player
			// 
			this.btn2Player.Location = new System.Drawing.Point(607, 78);
			this.btn2Player.Name = "btn2Player";
			this.btn2Player.Size = new System.Drawing.Size(75, 25);
			this.btn2Player.TabIndex = 0;
			this.btn2Player.Text = "2 Player";
			this.btn2Player.UseVisualStyleBackColor = true;
			this.btn2Player.Click += new System.EventHandler(this.btn2Player_Click);
			// 
			// bnt1Player
			// 
			this.bnt1Player.Location = new System.Drawing.Point(607, 135);
			this.bnt1Player.Name = "bnt1Player";
			this.bnt1Player.Size = new System.Drawing.Size(75, 23);
			this.bnt1Player.TabIndex = 1;
			this.bnt1Player.Text = "1 Player";
			this.bnt1Player.UseVisualStyleBackColor = true;
			this.bnt1Player.Click += new System.EventHandler(this.bnt1Player_Click);
			// 
			// bntQuit
			// 
			this.bntQuit.Location = new System.Drawing.Point(611, 201);
			this.bntQuit.Name = "bntQuit";
			this.bntQuit.Size = new System.Drawing.Size(75, 23);
			this.bntQuit.TabIndex = 2;
			this.bntQuit.Text = "Quit";
			this.bntQuit.UseVisualStyleBackColor = true;
			this.bntQuit.Click += new System.EventHandler(this.bntQuit_Click);
			// 
			// frmChessKing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.bntQuit);
			this.Controls.Add(this.bnt1Player);
			this.Controls.Add(this.btn2Player);
			this.Name = "frmChessKing";
			this.Text = "Chess King";
			this.Load += new System.EventHandler(this.frmChessKing_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn2Player;
		private System.Windows.Forms.Button bnt1Player;
		private System.Windows.Forms.Button bntQuit;
	}
}

