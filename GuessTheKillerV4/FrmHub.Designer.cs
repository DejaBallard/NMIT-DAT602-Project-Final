namespace GuessTheKiller
{
    partial class FrmHub
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
            this.btnSignOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lstChat = new System.Windows.Forms.ListBox();
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LABEL1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.tmrChat = new System.Windows.Forms.Timer(this.components);
            this.tmrWait = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnSignOut
            // 
            this.btnSignOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(448, 474);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(118, 75);
            this.btnSignOut.TabIndex = 14;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 47);
            this.label2.TabIndex = 19;
            this.label2.Text = "Player";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(83, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 47);
            this.label6.TabIndex = 23;
            this.label6.Text = "Score";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(155, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 47);
            this.label7.TabIndex = 24;
            this.label7.Text = "Status";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstPlayers
            // 
            this.lstPlayers.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.ItemHeight = 20;
            this.lstPlayers.Location = new System.Drawing.Point(16, 228);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(210, 324);
            this.lstPlayers.TabIndex = 25;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 2000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lstChat
            // 
            this.lstChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstChat.Enabled = false;
            this.lstChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstChat.FormattingEnabled = true;
            this.lstChat.ItemHeight = 20;
            this.lstChat.Location = new System.Drawing.Point(232, 229);
            this.lstChat.Name = "lstChat";
            this.lstChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstChat.Size = new System.Drawing.Size(334, 244);
            this.lstChat.TabIndex = 26;
            // 
            // txtChatBox
            // 
            this.txtChatBox.Location = new System.Drawing.Point(233, 479);
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.Size = new System.Drawing.Size(209, 20);
            this.txtChatBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(545, 47);
            this.label3.TabIndex = 28;
            this.label3.Text = "Double click on a player to start a game with them";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LABEL1
            // 
            this.LABEL1.Font = new System.Drawing.Font("Axure Handwriting", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL1.Location = new System.Drawing.Point(6, 9);
            this.LABEL1.Name = "LABEL1";
            this.LABEL1.Size = new System.Drawing.Size(566, 110);
            this.LABEL1.TabIndex = 29;
            this.LABEL1.Text = "Guess The Killer";
            this.LABEL1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 47);
            this.label4.TabIndex = 31;
            this.label4.Text = "Chat";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(232, 505);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(210, 44);
            this.btnEnter.TabIndex = 32;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // tmrChat
            // 
            this.tmrChat.Enabled = true;
            this.tmrChat.Tick += new System.EventHandler(this.tmrChat_Tick);
            // 
            // tmrWait
            // 
            this.tmrWait.Tick += new System.EventHandler(this.tmrWait_Tick);
            // 
            // FrmHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnSignOut;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LABEL1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChatBox);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSignOut);
            this.Name = "FrmHub";
            this.Text = "FrmHub";
            this.Load += new System.EventHandler(this.FrmHub_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LABEL1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Timer tmrChat;
        private System.Windows.Forms.Timer tmrWait;
    }
}