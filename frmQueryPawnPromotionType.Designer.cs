namespace SrcChess {
    partial class frmQueryPawnPromotionType {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonPawn = new System.Windows.Forms.RadioButton();
            this.radioButtonKnight = new System.Windows.Forms.RadioButton();
            this.radioButtonBishop = new System.Windows.Forms.RadioButton();
            this.radioButtonRook = new System.Windows.Forms.RadioButton();
            this.radioButtonQueen = new System.Windows.Forms.RadioButton();
            this.butOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonPawn);
            this.groupBox1.Controls.Add(this.radioButtonKnight);
            this.groupBox1.Controls.Add(this.radioButtonBishop);
            this.groupBox1.Controls.Add(this.radioButtonRook);
            this.groupBox1.Controls.Add(this.radioButtonQueen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Promotion Type";
            // 
            // radioButtonPawn
            // 
            this.radioButtonPawn.AutoSize = true;
            this.radioButtonPawn.Location = new System.Drawing.Point(250, 36);
            this.radioButtonPawn.Name = "radioButtonPawn";
            this.radioButtonPawn.Size = new System.Drawing.Size(52, 17);
            this.radioButtonPawn.TabIndex = 4;
            this.radioButtonPawn.TabStop = true;
            this.radioButtonPawn.Text = "Pawn";
            this.radioButtonPawn.UseVisualStyleBackColor = true;
            // 
            // radioButtonKnight
            // 
            this.radioButtonKnight.AutoSize = true;
            this.radioButtonKnight.Location = new System.Drawing.Point(189, 36);
            this.radioButtonKnight.Name = "radioButtonKnight";
            this.radioButtonKnight.Size = new System.Drawing.Size(55, 17);
            this.radioButtonKnight.TabIndex = 3;
            this.radioButtonKnight.TabStop = true;
            this.radioButtonKnight.Text = "Knight";
            this.radioButtonKnight.UseVisualStyleBackColor = true;
            // 
            // radioButtonBishop
            // 
            this.radioButtonBishop.AutoSize = true;
            this.radioButtonBishop.Location = new System.Drawing.Point(126, 36);
            this.radioButtonBishop.Name = "radioButtonBishop";
            this.radioButtonBishop.Size = new System.Drawing.Size(57, 17);
            this.radioButtonBishop.TabIndex = 2;
            this.radioButtonBishop.TabStop = true;
            this.radioButtonBishop.Text = "Bishop";
            this.radioButtonBishop.UseVisualStyleBackColor = true;
            // 
            // radioButtonRook
            // 
            this.radioButtonRook.AutoSize = true;
            this.radioButtonRook.Location = new System.Drawing.Point(69, 36);
            this.radioButtonRook.Name = "radioButtonRook";
            this.radioButtonRook.Size = new System.Drawing.Size(51, 17);
            this.radioButtonRook.TabIndex = 1;
            this.radioButtonRook.TabStop = true;
            this.radioButtonRook.Text = "Rook";
            this.radioButtonRook.UseVisualStyleBackColor = true;
            // 
            // radioButtonQueen
            // 
            this.radioButtonQueen.AutoSize = true;
            this.radioButtonQueen.Location = new System.Drawing.Point(6, 36);
            this.radioButtonQueen.Name = "radioButtonQueen";
            this.radioButtonQueen.Size = new System.Drawing.Size(57, 17);
            this.radioButtonQueen.TabIndex = 0;
            this.radioButtonQueen.TabStop = true;
            this.radioButtonQueen.Text = "Queen";
            this.radioButtonQueen.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(134, 113);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 1;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // frmQueryPawnPromotionType
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 150);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmQueryPawnPromotionType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selection of the Pawn Promotion Type";
            this.Load += new System.EventHandler(this.frmQueryPawnPromotionType_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPawn;
        private System.Windows.Forms.RadioButton radioButtonKnight;
        private System.Windows.Forms.RadioButton radioButtonBishop;
        private System.Windows.Forms.RadioButton radioButtonRook;
        private System.Windows.Forms.RadioButton radioButtonQueen;
        private System.Windows.Forms.Button butOk;
    }
}