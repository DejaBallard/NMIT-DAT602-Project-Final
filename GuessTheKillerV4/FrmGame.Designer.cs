namespace GuessTheKiller
{
    partial class FrmGame
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
            this.components = new System.ComponentModel.Container();
            this.LABEL1 = new System.Windows.Forms.Label();
            this.btnV1 = new System.Windows.Forms.Button();
            this.btnV4 = new System.Windows.Forms.Button();
            this.btnV2 = new System.Windows.Forms.Button();
            this.btnV5 = new System.Windows.Forms.Button();
            this.btnV3 = new System.Windows.Forms.Button();
            this.btnV6 = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlayer1Name = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlayer1Score = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPlayer2Score = new System.Windows.Forms.Label();
            this.txtPlayer2Name = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            this.tmrCountDown = new System.Windows.Forms.Timer(this.components);
            this.tmrConnection = new System.Windows.Forms.Timer(this.components);
            this.tmrWaiting = new System.Windows.Forms.Timer(this.components);
            this.lable10 = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LABEL1
            // 
            this.LABEL1.Font = new System.Drawing.Font("Axure Handwriting", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL1.Location = new System.Drawing.Point(6, 9);
            this.LABEL1.Name = "LABEL1";
            this.LABEL1.Size = new System.Drawing.Size(566, 110);
            this.LABEL1.TabIndex = 11;
            this.LABEL1.Text = "Guess The Killer";
            this.LABEL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnV1
            // 
            this.btnV1.Enabled = false;
            this.btnV1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV1.Location = new System.Drawing.Point(12, 143);
            this.btnV1.Name = "btnV1";
            this.btnV1.Size = new System.Drawing.Size(100, 150);
            this.btnV1.TabIndex = 13;
            this.btnV1.Text = "One";
            this.btnV1.UseVisualStyleBackColor = true;
            this.btnV1.Click += new System.EventHandler(this.btnV1_Click);
            // 
            // btnV4
            // 
            this.btnV4.Enabled = false;
            this.btnV4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV4.Location = new System.Drawing.Point(12, 299);
            this.btnV4.Name = "btnV4";
            this.btnV4.Size = new System.Drawing.Size(100, 150);
            this.btnV4.TabIndex = 14;
            this.btnV4.Text = "Four";
            this.btnV4.UseVisualStyleBackColor = true;
            this.btnV4.Click += new System.EventHandler(this.btnV4_Click);
            // 
            // btnV2
            // 
            this.btnV2.Enabled = false;
            this.btnV2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV2.Location = new System.Drawing.Point(118, 143);
            this.btnV2.Name = "btnV2";
            this.btnV2.Size = new System.Drawing.Size(100, 150);
            this.btnV2.TabIndex = 15;
            this.btnV2.Text = "Two";
            this.btnV2.UseVisualStyleBackColor = true;
            this.btnV2.Click += new System.EventHandler(this.btnV2_Click);
            // 
            // btnV5
            // 
            this.btnV5.Enabled = false;
            this.btnV5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV5.Location = new System.Drawing.Point(118, 299);
            this.btnV5.Name = "btnV5";
            this.btnV5.Size = new System.Drawing.Size(100, 150);
            this.btnV5.TabIndex = 16;
            this.btnV5.Text = "Five";
            this.btnV5.UseVisualStyleBackColor = true;
            this.btnV5.Click += new System.EventHandler(this.btnV5_Click);
            // 
            // btnV3
            // 
            this.btnV3.Enabled = false;
            this.btnV3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV3.Location = new System.Drawing.Point(224, 143);
            this.btnV3.Name = "btnV3";
            this.btnV3.Size = new System.Drawing.Size(100, 150);
            this.btnV3.TabIndex = 17;
            this.btnV3.Text = "Three";
            this.btnV3.UseVisualStyleBackColor = true;
            this.btnV3.Click += new System.EventHandler(this.btnV3_Click);
            // 
            // btnV6
            // 
            this.btnV6.Enabled = false;
            this.btnV6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnV6.Location = new System.Drawing.Point(224, 299);
            this.btnV6.Name = "btnV6";
            this.btnV6.Size = new System.Drawing.Size(100, 150);
            this.btnV6.TabIndex = 18;
            this.btnV6.Text = "Six";
            this.btnV6.UseVisualStyleBackColor = true;
            this.btnV6.Click += new System.EventHandler(this.btnV6_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeave.Location = new System.Drawing.Point(372, 474);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(200, 75);
            this.btnLeave.TabIndex = 19;
            this.btnLeave.Text = "Leave";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "You:";
            // 
            // txtPlayer1Name
            // 
            this.txtPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer1Name.Location = new System.Drawing.Point(372, 173);
            this.txtPlayer1Name.Name = "txtPlayer1Name";
            this.txtPlayer1Name.Size = new System.Drawing.Size(200, 30);
            this.txtPlayer1Name.TabIndex = 21;
            this.txtPlayer1Name.Text = "John";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 30);
            this.label4.TabIndex = 22;
            this.label4.Text = "Score:";
            // 
            // txtPlayer1Score
            // 
            this.txtPlayer1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer1Score.Location = new System.Drawing.Point(372, 233);
            this.txtPlayer1Score.Name = "txtPlayer1Score";
            this.txtPlayer1Score.Size = new System.Drawing.Size(200, 30);
            this.txtPlayer1Score.TabIndex = 23;
            this.txtPlayer1Score.Text = "0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(372, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 30);
            this.label7.TabIndex = 25;
            this.label7.Text = "Opponent:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(372, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 30);
            this.label8.TabIndex = 26;
            this.label8.Text = "Score:";
            // 
            // txtPlayer2Score
            // 
            this.txtPlayer2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer2Score.Location = new System.Drawing.Point(372, 429);
            this.txtPlayer2Score.Name = "txtPlayer2Score";
            this.txtPlayer2Score.Size = new System.Drawing.Size(200, 30);
            this.txtPlayer2Score.TabIndex = 27;
            this.txtPlayer2Score.Text = "0";
            // 
            // txtPlayer2Name
            // 
            this.txtPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayer2Name.Location = new System.Drawing.Point(372, 369);
            this.txtPlayer2Name.Name = "txtPlayer2Name";
            this.txtPlayer2Name.Size = new System.Drawing.Size(200, 30);
            this.txtPlayer2Name.TabIndex = 28;
            this.txtPlayer2Name.Text = "Sue";
            // 
            // txtTime
            // 
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(12, 474);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(312, 75);
            this.txtTime.TabIndex = 30;
            this.txtTime.Text = "Time left: 5";
            this.txtTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrCountDown
            // 
            this.tmrCountDown.Interval = 1000;
            this.tmrCountDown.Tick += new System.EventHandler(this.tmrCountDown_Tick);
            // 
            // tmrConnection
            // 
            this.tmrConnection.Interval = 2000;
            this.tmrConnection.Tick += new System.EventHandler(this.tmrConnection_Tick);
            // 
            // tmrWaiting
            // 
            this.tmrWaiting.Interval = 1000;
            this.tmrWaiting.Tick += new System.EventHandler(this.tmrWaiting_Tick);
            // 
            // lable10
            // 
            this.lable10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable10.Location = new System.Drawing.Point(14, 100);
            this.lable10.Name = "lable10";
            this.lable10.Size = new System.Drawing.Size(228, 30);
            this.lable10.TabIndex = 31;
            this.lable10.Text = "Current Player Turn:";
            // 
            // lblTurn
            // 
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.Location = new System.Drawing.Point(248, 100);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(228, 30);
            this.lblTurn.TabIndex = 32;
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.lable10);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtPlayer2Name);
            this.Controls.Add(this.txtPlayer2Score);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPlayer1Score);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlayer1Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnV6);
            this.Controls.Add(this.btnV3);
            this.Controls.Add(this.btnV5);
            this.Controls.Add(this.btnV2);
            this.Controls.Add(this.btnV4);
            this.Controls.Add(this.btnV1);
            this.Controls.Add(this.LABEL1);
            this.Name = "FrmGame";
            this.Text = "FrmGame";
            this.Load += new System.EventHandler(this.FrmGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LABEL1;
        private System.Windows.Forms.Button btnV1;
        private System.Windows.Forms.Button btnV4;
        private System.Windows.Forms.Button btnV2;
        private System.Windows.Forms.Button btnV5;
        private System.Windows.Forms.Button btnV3;
        private System.Windows.Forms.Button btnV6;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtPlayer1Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtPlayer1Score;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtPlayer2Score;
        private System.Windows.Forms.Label txtPlayer2Name;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.Timer tmrCountDown;
        private System.Windows.Forms.Timer tmrConnection;
        private System.Windows.Forms.Timer tmrWaiting;
        private System.Windows.Forms.Label lable10;
        private System.Windows.Forms.Label lblTurn;
    }
}