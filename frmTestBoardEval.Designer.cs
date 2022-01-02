namespace SrcChess {
    partial class frmTestBoardEval {
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxBlackBEval = new System.Windows.Forms.ComboBox();
            this.comboBoxWhiteBEval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.plyCount = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfPly = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plyCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxBlackBEval);
            this.groupBox6.Controls.Add(this.comboBoxWhiteBEval);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(396, 79);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Board Evaluation";
            // 
            // comboBoxBlackBEval
            // 
            this.comboBoxBlackBEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlackBEval.FormattingEnabled = true;
            this.comboBoxBlackBEval.Location = new System.Drawing.Point(252, 48);
            this.comboBoxBlackBEval.Name = "comboBoxBlackBEval";
            this.comboBoxBlackBEval.Size = new System.Drawing.Size(138, 21);
            this.comboBoxBlackBEval.TabIndex = 6;
            this.comboBoxBlackBEval.SelectedIndexChanged += new System.EventHandler(this.comboBoxBlackBEval_SelectedIndexChanged);
            // 
            // comboBoxWhiteBEval
            // 
            this.comboBoxWhiteBEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWhiteBEval.FormattingEnabled = true;
            this.comboBoxWhiteBEval.Location = new System.Drawing.Point(9, 48);
            this.comboBoxWhiteBEval.Name = "comboBoxWhiteBEval";
            this.comboBoxWhiteBEval.Size = new System.Drawing.Size(138, 21);
            this.comboBoxWhiteBEval.TabIndex = 5;
            this.comboBoxWhiteBEval.SelectedIndexChanged += new System.EventHandler(this.comboBoxWhiteBEval_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Method #2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Method #1";
            // 
            // gameCount
            // 
            this.gameCount.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gameCount.Location = new System.Drawing.Point(314, 109);
            this.gameCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.gameCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gameCount.Name = "gameCount";
            this.gameCount.Size = new System.Drawing.Size(90, 20);
            this.gameCount.TabIndex = 1;
            this.gameCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gameCount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.gameCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of games:";
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(233, 159);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(131, 159);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // plyCount
            // 
            this.plyCount.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.plyCount.Location = new System.Drawing.Point(100, 109);
            this.plyCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.plyCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.plyCount.Name = "plyCount";
            this.plyCount.Size = new System.Drawing.Size(34, 20);
            this.plyCount.TabIndex = 12;
            this.plyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.plyCount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.plyCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelNumberOfPly
            // 
            this.labelNumberOfPly.AutoSize = true;
            this.labelNumberOfPly.Location = new System.Drawing.Point(18, 111);
            this.labelNumberOfPly.Name = "labelNumberOfPly";
            this.labelNumberOfPly.Size = new System.Drawing.Size(76, 13);
            this.labelNumberOfPly.TabIndex = 11;
            this.labelNumberOfPly.Text = "Number of Ply:";
            // 
            // frmTestBoardEval
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(439, 203);
            this.Controls.Add(this.plyCount);
            this.Controls.Add(this.labelNumberOfPly);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gameCount);
            this.Controls.Add(this.groupBox6);
            this.Name = "frmTestBoardEval";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Board Evaluators";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plyCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBoxBlackBEval;
        private System.Windows.Forms.ComboBox comboBoxWhiteBEval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown gameCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.NumericUpDown plyCount;
        private System.Windows.Forms.Label labelNumberOfPly;
    }
}