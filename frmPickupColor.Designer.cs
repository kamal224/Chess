namespace SrcChess {
    partial class frmPickupColor {
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butWhitePieceColor = new System.Windows.Forms.Button();
            this.butBlackPieceColor = new System.Windows.Forms.Button();
            this.butLiteSquareColor = new System.Windows.Forms.Button();
            this.butDarkSquareColor = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butResetToDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(263, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 350);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "White Piece Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Black Piece Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lite Square Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dark Square Color";
            // 
            // butWhitePieceColor
            // 
            this.butWhitePieceColor.Location = new System.Drawing.Point(110, 34);
            this.butWhitePieceColor.Name = "butWhitePieceColor";
            this.butWhitePieceColor.Size = new System.Drawing.Size(122, 23);
            this.butWhitePieceColor.TabIndex = 5;
            this.butWhitePieceColor.UseVisualStyleBackColor = true;
            this.butWhitePieceColor.Click += new System.EventHandler(this.butWhitePieceColor_Click);
            // 
            // butBlackPieceColor
            // 
            this.butBlackPieceColor.Location = new System.Drawing.Point(110, 61);
            this.butBlackPieceColor.Name = "butBlackPieceColor";
            this.butBlackPieceColor.Size = new System.Drawing.Size(122, 23);
            this.butBlackPieceColor.TabIndex = 6;
            this.butBlackPieceColor.UseVisualStyleBackColor = true;
            this.butBlackPieceColor.Click += new System.EventHandler(this.butBlackPieceColor_Click);
            // 
            // butLiteSquareColor
            // 
            this.butLiteSquareColor.Location = new System.Drawing.Point(110, 90);
            this.butLiteSquareColor.Name = "butLiteSquareColor";
            this.butLiteSquareColor.Size = new System.Drawing.Size(122, 23);
            this.butLiteSquareColor.TabIndex = 7;
            this.butLiteSquareColor.UseVisualStyleBackColor = true;
            this.butLiteSquareColor.Click += new System.EventHandler(this.butLiteSquareColor_Click);
            // 
            // butDarkSquareColor
            // 
            this.butDarkSquareColor.Location = new System.Drawing.Point(110, 119);
            this.butDarkSquareColor.Name = "butDarkSquareColor";
            this.butDarkSquareColor.Size = new System.Drawing.Size(122, 23);
            this.butDarkSquareColor.TabIndex = 8;
            this.butDarkSquareColor.UseVisualStyleBackColor = true;
            this.butDarkSquareColor.Click += new System.EventHandler(this.butDarkSquareColor_Click);
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(208, 419);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(341, 419);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butResetToDefault
            // 
            this.butResetToDefault.Location = new System.Drawing.Point(61, 170);
            this.butResetToDefault.Name = "butResetToDefault";
            this.butResetToDefault.Size = new System.Drawing.Size(115, 23);
            this.butResetToDefault.TabIndex = 11;
            this.butResetToDefault.Text = "Reset to Default";
            this.butResetToDefault.UseVisualStyleBackColor = true;
            this.butResetToDefault.Click += new System.EventHandler(this.butResetToDefault_Click);
            // 
            // frmPickupColor
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(625, 459);
            this.Controls.Add(this.butResetToDefault);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.butDarkSquareColor);
            this.Controls.Add(this.butLiteSquareColor);
            this.Controls.Add(this.butBlackPieceColor);
            this.Controls.Add(this.butWhitePieceColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPickupColor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPickupColor";
            this.Load += new System.EventHandler(this.frmPickupColor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butWhitePieceColor;
        private System.Windows.Forms.Button butBlackPieceColor;
        private System.Windows.Forms.Button butLiteSquareColor;
        private System.Windows.Forms.Button butDarkSquareColor;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butResetToDefault;
    }
}