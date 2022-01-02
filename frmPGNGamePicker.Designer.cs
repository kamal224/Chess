namespace SrcChess {
    partial class frmPGNGamePicker {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            if (m_streamInp != null) {
                m_streamInp.Dispose();
                m_streamInp = null;
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.textBoxGame = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(12, 12);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.Size = new System.Drawing.Size(770, 238);
            this.listBoxGames.Sorted = true;
            this.listBoxGames.TabIndex = 0;
            this.listBoxGames.SelectedIndexChanged += new System.EventHandler(this.listBoxGames_SelectedIndexChanged);
            this.listBoxGames.DoubleClick += new System.EventHandler(this.butOk_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(284, 533);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(110, 23);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(400, 533);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(110, 23);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxGame
            // 
            this.textBoxGame.Location = new System.Drawing.Point(12, 256);
            this.textBoxGame.Multiline = true;
            this.textBoxGame.Name = "textBoxGame";
            this.textBoxGame.ReadOnly = true;
            this.textBoxGame.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGame.Size = new System.Drawing.Size(770, 257);
            this.textBoxGame.TabIndex = 3;
            this.textBoxGame.TabStop = false;
            // 
            // frmPGNGamePicker
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(794, 572);
            this.Controls.Add(this.textBoxGame);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.listBoxGames);
            this.Name = "frmPGNGamePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select the Game from the PGN File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TextBox textBoxGame;
    }
}