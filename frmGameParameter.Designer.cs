namespace SrcChess {
    partial class frmGameParameter {
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.radioButtonPlayerAgainstComputer = new System.Windows.Forms.RadioButton();
            this.radioButtonPlayerAgainstPlayer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonComputerAgainstComputer = new System.Windows.Forms.RadioButton();
            this.groupBoxComputerPlay = new System.Windows.Forms.GroupBox();
            this.radioButtonComputerPlayBlack = new System.Windows.Forms.RadioButton();
            this.radioButtonComputerPlayWhite = new System.Windows.Forms.RadioButton();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxComputerPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPlayerAgainstComputer
            // 
            this.radioButtonPlayerAgainstComputer.AutoSize = true;
            this.radioButtonPlayerAgainstComputer.Location = new System.Drawing.Point(6, 19);
            this.radioButtonPlayerAgainstComputer.Name = "radioButtonPlayerAgainstComputer";
            this.radioButtonPlayerAgainstComputer.Size = new System.Drawing.Size(140, 17);
            this.radioButtonPlayerAgainstComputer.TabIndex = 0;
            this.radioButtonPlayerAgainstComputer.TabStop = true;
            this.radioButtonPlayerAgainstComputer.Text = "Player Against &Computer";
            this.radioButtonPlayerAgainstComputer.UseVisualStyleBackColor = true;
            this.radioButtonPlayerAgainstComputer.CheckedChanged += new System.EventHandler(this.radioButtonPlayerAgainstComputer_CheckedChanged);
            // 
            // radioButtonPlayerAgainstPlayer
            // 
            this.radioButtonPlayerAgainstPlayer.AutoSize = true;
            this.radioButtonPlayerAgainstPlayer.Location = new System.Drawing.Point(6, 42);
            this.radioButtonPlayerAgainstPlayer.Name = "radioButtonPlayerAgainstPlayer";
            this.radioButtonPlayerAgainstPlayer.Size = new System.Drawing.Size(124, 17);
            this.radioButtonPlayerAgainstPlayer.TabIndex = 1;
            this.radioButtonPlayerAgainstPlayer.TabStop = true;
            this.radioButtonPlayerAgainstPlayer.Text = "Player Against &Player";
            this.radioButtonPlayerAgainstPlayer.UseVisualStyleBackColor = true;
            this.radioButtonPlayerAgainstPlayer.CheckedChanged += new System.EventHandler(this.radioButtonPlayerAgainstPlayer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonComputerAgainstComputer);
            this.groupBox1.Controls.Add(this.radioButtonPlayerAgainstComputer);
            this.groupBox1.Controls.Add(this.radioButtonPlayerAgainstPlayer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 94);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opponents";
            // 
            // radioButtonComputerAgainstComputer
            // 
            this.radioButtonComputerAgainstComputer.AutoSize = true;
            this.radioButtonComputerAgainstComputer.Location = new System.Drawing.Point(6, 65);
            this.radioButtonComputerAgainstComputer.Name = "radioButtonComputerAgainstComputer";
            this.radioButtonComputerAgainstComputer.Size = new System.Drawing.Size(156, 17);
            this.radioButtonComputerAgainstComputer.TabIndex = 2;
            this.radioButtonComputerAgainstComputer.TabStop = true;
            this.radioButtonComputerAgainstComputer.Text = "Computer Against C&omputer";
            this.radioButtonComputerAgainstComputer.UseVisualStyleBackColor = true;
            this.radioButtonComputerAgainstComputer.CheckedChanged += new System.EventHandler(this.radioButtonComputerAgainstComputer_CheckedChanged);
            // 
            // groupBoxComputerPlay
            // 
            this.groupBoxComputerPlay.Controls.Add(this.radioButtonComputerPlayBlack);
            this.groupBoxComputerPlay.Controls.Add(this.radioButtonComputerPlayWhite);
            this.groupBoxComputerPlay.Location = new System.Drawing.Point(186, 12);
            this.groupBoxComputerPlay.Name = "groupBoxComputerPlay";
            this.groupBoxComputerPlay.Size = new System.Drawing.Size(200, 94);
            this.groupBoxComputerPlay.TabIndex = 3;
            this.groupBoxComputerPlay.TabStop = false;
            this.groupBoxComputerPlay.Text = "Computer plays";
            // 
            // radioButtonComputerPlayBlack
            // 
            this.radioButtonComputerPlayBlack.AutoSize = true;
            this.radioButtonComputerPlayBlack.Location = new System.Drawing.Point(6, 50);
            this.radioButtonComputerPlayBlack.Name = "radioButtonComputerPlayBlack";
            this.radioButtonComputerPlayBlack.Size = new System.Drawing.Size(52, 17);
            this.radioButtonComputerPlayBlack.TabIndex = 2;
            this.radioButtonComputerPlayBlack.TabStop = true;
            this.radioButtonComputerPlayBlack.Text = "Black";
            this.radioButtonComputerPlayBlack.UseVisualStyleBackColor = true;
            // 
            // radioButtonComputerPlayWhite
            // 
            this.radioButtonComputerPlayWhite.AutoSize = true;
            this.radioButtonComputerPlayWhite.Location = new System.Drawing.Point(6, 27);
            this.radioButtonComputerPlayWhite.Name = "radioButtonComputerPlayWhite";
            this.radioButtonComputerPlayWhite.Size = new System.Drawing.Size(53, 17);
            this.radioButtonComputerPlayWhite.TabIndex = 1;
            this.radioButtonComputerPlayWhite.TabStop = true;
            this.radioButtonComputerPlayWhite.Text = "&White";
            this.radioButtonComputerPlayWhite.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(101, 145);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(223, 145);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // frmGameParameter
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(399, 192);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBoxComputerPlay);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGameParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Parameters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxComputerPlay.ResumeLayout(false);
            this.groupBoxComputerPlay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonPlayerAgainstComputer;
        private System.Windows.Forms.RadioButton radioButtonPlayerAgainstPlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonComputerAgainstComputer;
        private System.Windows.Forms.GroupBox groupBoxComputerPlay;
        private System.Windows.Forms.RadioButton radioButtonComputerPlayBlack;
        private System.Windows.Forms.RadioButton radioButtonComputerPlayWhite;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
    }
}