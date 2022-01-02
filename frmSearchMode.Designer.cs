namespace SrcChess {
    partial class frmSearchMode {
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
            this.labelNumberOfPly = new System.Windows.Forms.Label();
            this.labelAvgTime = new System.Windows.Forms.Label();
            this.textBoxTimeInSec = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFixDepthIterative = new System.Windows.Forms.RadioButton();
            this.plyCount = new System.Windows.Forms.NumericUpDown();
            this.radioButtonAvgTime = new System.Windows.Forms.RadioButton();
            this.radioButtonFixDepth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonAlphaBeta = new System.Windows.Forms.RadioButton();
            this.radioButtonMinMax = new System.Windows.Forms.RadioButton();
            this.checkBoxBookOpening = new System.Windows.Forms.CheckBox();
            this.checkBoxTransTable = new System.Windows.Forms.CheckBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonOneForUI = new System.Windows.Forms.RadioButton();
            this.radioButtonOnePerProc = new System.Windows.Forms.RadioButton();
            this.radioButtonNoThread = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxTransSize = new System.Windows.Forms.TextBox();
            this.labelTransSize = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonRndOnRep = new System.Windows.Forms.RadioButton();
            this.radioButtonRndOff = new System.Windows.Forms.RadioButton();
            this.radioButtonRndOn = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxBlackBEval = new System.Windows.Forms.ComboBox();
            this.comboBoxWhiteBEval = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plyCount)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelNumberOfPly
            // 
            this.labelNumberOfPly.AutoSize = true;
            this.labelNumberOfPly.Location = new System.Drawing.Point(161, 30);
            this.labelNumberOfPly.Name = "labelNumberOfPly";
            this.labelNumberOfPly.Size = new System.Drawing.Size(76, 13);
            this.labelNumberOfPly.TabIndex = 1;
            this.labelNumberOfPly.Text = "Number of Ply:";
            // 
            // labelAvgTime
            // 
            this.labelAvgTime.AutoSize = true;
            this.labelAvgTime.Location = new System.Drawing.Point(135, 60);
            this.labelAvgTime.Name = "labelAvgTime";
            this.labelAvgTime.Size = new System.Drawing.Size(102, 13);
            this.labelAvgTime.TabIndex = 2;
            this.labelAvgTime.Text = "Average Time (sec):";
            // 
            // textBoxTimeInSec
            // 
            this.textBoxTimeInSec.Location = new System.Drawing.Point(243, 59);
            this.textBoxTimeInSec.MaxLength = 3;
            this.textBoxTimeInSec.Name = "textBoxTimeInSec";
            this.textBoxTimeInSec.Size = new System.Drawing.Size(43, 20);
            this.textBoxTimeInSec.TabIndex = 4;
            this.textBoxTimeInSec.Text = "15";
            this.textBoxTimeInSec.TextChanged += new System.EventHandler(this.textBoxTimeInSec_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFixDepthIterative);
            this.groupBox1.Controls.Add(this.plyCount);
            this.groupBox1.Controls.Add(this.radioButtonAvgTime);
            this.groupBox1.Controls.Add(this.radioButtonFixDepth);
            this.groupBox1.Controls.Add(this.textBoxTimeInSec);
            this.groupBox1.Controls.Add(this.labelNumberOfPly);
            this.groupBox1.Controls.Add(this.labelAvgTime);
            this.groupBox1.Location = new System.Drawing.Point(312, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Time/Depth";
            // 
            // radioButtonFixDepthIterative
            // 
            this.radioButtonFixDepthIterative.AutoSize = true;
            this.radioButtonFixDepthIterative.Location = new System.Drawing.Point(6, 44);
            this.radioButtonFixDepthIterative.Name = "radioButtonFixDepthIterative";
            this.radioButtonFixDepthIterative.Size = new System.Drawing.Size(117, 17);
            this.radioButtonFixDepthIterative.TabIndex = 1;
            this.radioButtonFixDepthIterative.TabStop = true;
            this.radioButtonFixDepthIterative.Text = "Fix Depth (Iterative)";
            this.radioButtonFixDepthIterative.UseVisualStyleBackColor = true;
            this.radioButtonFixDepthIterative.CheckedChanged += new System.EventHandler(this.radioButtonFixDepthIterative_CheckedChanged);
            // 
            // plyCount
            // 
            this.plyCount.Location = new System.Drawing.Point(243, 28);
            this.plyCount.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.plyCount.Name = "plyCount";
            this.plyCount.Size = new System.Drawing.Size(34, 20);
            this.plyCount.TabIndex = 3;
            this.plyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.plyCount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.plyCount.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // radioButtonAvgTime
            // 
            this.radioButtonAvgTime.AutoSize = true;
            this.radioButtonAvgTime.Location = new System.Drawing.Point(6, 67);
            this.radioButtonAvgTime.Name = "radioButtonAvgTime";
            this.radioButtonAvgTime.Size = new System.Drawing.Size(91, 17);
            this.radioButtonAvgTime.TabIndex = 2;
            this.radioButtonAvgTime.TabStop = true;
            this.radioButtonAvgTime.Text = "Average Time";
            this.radioButtonAvgTime.UseVisualStyleBackColor = true;
            // 
            // radioButtonFixDepth
            // 
            this.radioButtonFixDepth.AutoSize = true;
            this.radioButtonFixDepth.Location = new System.Drawing.Point(6, 21);
            this.radioButtonFixDepth.Name = "radioButtonFixDepth";
            this.radioButtonFixDepth.Size = new System.Drawing.Size(70, 17);
            this.radioButtonFixDepth.TabIndex = 0;
            this.radioButtonFixDepth.TabStop = true;
            this.radioButtonFixDepth.Text = "Fix Depth";
            this.radioButtonFixDepth.UseVisualStyleBackColor = true;
            this.radioButtonFixDepth.CheckedChanged += new System.EventHandler(this.radioButtonFixDepth_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonAlphaBeta);
            this.groupBox2.Controls.Add(this.radioButtonMinMax);
            this.groupBox2.Controls.Add(this.checkBoxBookOpening);
            this.groupBox2.Location = new System.Drawing.Point(12, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Method";
            // 
            // radioButtonAlphaBeta
            // 
            this.radioButtonAlphaBeta.AutoSize = true;
            this.radioButtonAlphaBeta.Location = new System.Drawing.Point(6, 26);
            this.radioButtonAlphaBeta.Name = "radioButtonAlphaBeta";
            this.radioButtonAlphaBeta.Size = new System.Drawing.Size(77, 17);
            this.radioButtonAlphaBeta.TabIndex = 0;
            this.radioButtonAlphaBeta.TabStop = true;
            this.radioButtonAlphaBeta.Text = "Alpha Beta";
            this.radioButtonAlphaBeta.UseVisualStyleBackColor = true;
            this.radioButtonAlphaBeta.CheckedChanged += new System.EventHandler(this.radioButtonAlphaBeta_CheckedChanged);
            // 
            // radioButtonMinMax
            // 
            this.radioButtonMinMax.AutoSize = true;
            this.radioButtonMinMax.Location = new System.Drawing.Point(6, 56);
            this.radioButtonMinMax.Name = "radioButtonMinMax";
            this.radioButtonMinMax.Size = new System.Drawing.Size(101, 17);
            this.radioButtonMinMax.TabIndex = 1;
            this.radioButtonMinMax.TabStop = true;
            this.radioButtonMinMax.Text = "MinMax (slower)";
            this.radioButtonMinMax.UseVisualStyleBackColor = true;
            // 
            // checkBoxBookOpening
            // 
            this.checkBoxBookOpening.AutoSize = true;
            this.checkBoxBookOpening.Location = new System.Drawing.Point(148, 42);
            this.checkBoxBookOpening.Name = "checkBoxBookOpening";
            this.checkBoxBookOpening.Size = new System.Drawing.Size(116, 17);
            this.checkBoxBookOpening.TabIndex = 2;
            this.checkBoxBookOpening.Text = "Use Book Opening";
            this.checkBoxBookOpening.UseVisualStyleBackColor = true;
            // 
            // checkBoxTransTable
            // 
            this.checkBoxTransTable.AutoSize = true;
            this.checkBoxTransTable.Location = new System.Drawing.Point(11, 26);
            this.checkBoxTransTable.Name = "checkBoxTransTable";
            this.checkBoxTransTable.Size = new System.Drawing.Size(65, 17);
            this.checkBoxTransTable.TabIndex = 2;
            this.checkBoxTransTable.Text = "Activate";
            this.checkBoxTransTable.UseVisualStyleBackColor = true;
            // 
            // butOk
            // 
            this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOk.Location = new System.Drawing.Point(223, 260);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 4;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(325, 260);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonOneForUI);
            this.groupBox3.Controls.Add(this.radioButtonOnePerProc);
            this.groupBox3.Controls.Add(this.radioButtonNoThread);
            this.groupBox3.Location = new System.Drawing.Point(12, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(294, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Multi-Threading";
            // 
            // radioButtonOneForUI
            // 
            this.radioButtonOneForUI.AutoSize = true;
            this.radioButtonOneForUI.Location = new System.Drawing.Point(126, 25);
            this.radioButtonOneForUI.Name = "radioButtonOneForUI";
            this.radioButtonOneForUI.Size = new System.Drawing.Size(97, 17);
            this.radioButtonOneForUI.TabIndex = 2;
            this.radioButtonOneForUI.TabStop = true;
            this.radioButtonOneForUI.Text = "One for Search";
            this.radioButtonOneForUI.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnePerProc
            // 
            this.radioButtonOnePerProc.AutoSize = true;
            this.radioButtonOnePerProc.Location = new System.Drawing.Point(6, 25);
            this.radioButtonOnePerProc.Name = "radioButtonOnePerProc";
            this.radioButtonOnePerProc.Size = new System.Drawing.Size(114, 17);
            this.radioButtonOnePerProc.TabIndex = 0;
            this.radioButtonOnePerProc.TabStop = true;
            this.radioButtonOnePerProc.Text = "One Per Processor";
            this.radioButtonOnePerProc.UseVisualStyleBackColor = true;
            // 
            // radioButtonNoThread
            // 
            this.radioButtonNoThread.AutoSize = true;
            this.radioButtonNoThread.Location = new System.Drawing.Point(229, 25);
            this.radioButtonNoThread.Name = "radioButtonNoThread";
            this.radioButtonNoThread.Size = new System.Drawing.Size(57, 17);
            this.radioButtonNoThread.TabIndex = 1;
            this.radioButtonNoThread.TabStop = true;
            this.radioButtonNoThread.Text = "Debug";
            this.radioButtonNoThread.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxTransSize);
            this.groupBox4.Controls.Add(this.labelTransSize);
            this.groupBox4.Controls.Add(this.checkBoxTransTable);
            this.groupBox4.Location = new System.Drawing.Point(312, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(294, 61);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transposition Table";
            this.groupBox4.Visible = false;
            // 
            // textBoxTransSize
            // 
            this.textBoxTransSize.Location = new System.Drawing.Point(210, 25);
            this.textBoxTransSize.Name = "textBoxTransSize";
            this.textBoxTransSize.Size = new System.Drawing.Size(57, 20);
            this.textBoxTransSize.TabIndex = 4;
            this.textBoxTransSize.TextChanged += new System.EventHandler(this.textBoxTransSize_TextChanged);
            // 
            // labelTransSize
            // 
            this.labelTransSize.AutoSize = true;
            this.labelTransSize.Location = new System.Drawing.Point(91, 27);
            this.labelTransSize.Name = "labelTransSize";
            this.labelTransSize.Size = new System.Drawing.Size(113, 13);
            this.labelTransSize.TabIndex = 3;
            this.labelTransSize.Text = "Size / Processor (MB):";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonRndOnRep);
            this.groupBox5.Controls.Add(this.radioButtonRndOff);
            this.groupBox5.Controls.Add(this.radioButtonRndOn);
            this.groupBox5.Location = new System.Drawing.Point(12, 188);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(294, 61);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Random Move";
            // 
            // radioButtonRndOnRep
            // 
            this.radioButtonRndOnRep.AutoSize = true;
            this.radioButtonRndOnRep.Location = new System.Drawing.Point(68, 25);
            this.radioButtonRndOnRep.Name = "radioButtonRndOnRep";
            this.radioButtonRndOnRep.Size = new System.Drawing.Size(96, 17);
            this.radioButtonRndOnRep.TabIndex = 2;
            this.radioButtonRndOnRep.TabStop = true;
            this.radioButtonRndOnRep.Text = "On (Repetitive)";
            this.radioButtonRndOnRep.UseVisualStyleBackColor = true;
            // 
            // radioButtonRndOff
            // 
            this.radioButtonRndOff.AutoSize = true;
            this.radioButtonRndOff.Location = new System.Drawing.Point(6, 25);
            this.radioButtonRndOff.Name = "radioButtonRndOff";
            this.radioButtonRndOff.Size = new System.Drawing.Size(39, 17);
            this.radioButtonRndOff.TabIndex = 0;
            this.radioButtonRndOff.TabStop = true;
            this.radioButtonRndOff.Text = "Off";
            this.radioButtonRndOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonRndOn
            // 
            this.radioButtonRndOn.AutoSize = true;
            this.radioButtonRndOn.Location = new System.Drawing.Point(184, 25);
            this.radioButtonRndOn.Name = "radioButtonRndOn";
            this.radioButtonRndOn.Size = new System.Drawing.Size(39, 17);
            this.radioButtonRndOn.TabIndex = 1;
            this.radioButtonRndOn.TabStop = true;
            this.radioButtonRndOn.Text = "On";
            this.radioButtonRndOn.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxBlackBEval);
            this.groupBox6.Controls.Add(this.comboBoxWhiteBEval);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Location = new System.Drawing.Point(312, 121);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(294, 61);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Board Evaluation";
            // 
            // comboBoxBlackBEval
            // 
            this.comboBoxBlackBEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlackBEval.FormattingEnabled = true;
            this.comboBoxBlackBEval.Location = new System.Drawing.Point(150, 32);
            this.comboBoxBlackBEval.Name = "comboBoxBlackBEval";
            this.comboBoxBlackBEval.Size = new System.Drawing.Size(138, 21);
            this.comboBoxBlackBEval.TabIndex = 6;
            // 
            // comboBoxWhiteBEval
            // 
            this.comboBoxWhiteBEval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWhiteBEval.FormattingEnabled = true;
            this.comboBoxWhiteBEval.Location = new System.Drawing.Point(6, 32);
            this.comboBoxWhiteBEval.Name = "comboBoxWhiteBEval";
            this.comboBoxWhiteBEval.Size = new System.Drawing.Size(138, 21);
            this.comboBoxWhiteBEval.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Black:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "White:";
            // 
            // frmSearchMode
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(622, 297);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSearchMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Mode";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plyCount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNumberOfPly;
        private System.Windows.Forms.Label labelAvgTime;
        private System.Windows.Forms.TextBox textBoxTimeInSec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAvgTime;
        private System.Windows.Forms.RadioButton radioButtonFixDepth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonAlphaBeta;
        private System.Windows.Forms.RadioButton radioButtonMinMax;
        private System.Windows.Forms.CheckBox checkBoxTransTable;
        private System.Windows.Forms.CheckBox checkBoxBookOpening;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonOneForUI;
        private System.Windows.Forms.RadioButton radioButtonOnePerProc;
        private System.Windows.Forms.RadioButton radioButtonNoThread;
        private System.Windows.Forms.NumericUpDown plyCount;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxTransSize;
        private System.Windows.Forms.Label labelTransSize;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonRndOnRep;
        private System.Windows.Forms.RadioButton radioButtonRndOff;
        private System.Windows.Forms.RadioButton radioButtonRndOn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBoxBlackBEval;
        private System.Windows.Forms.ComboBox comboBoxWhiteBEval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonFixDepthIterative;
    }
}