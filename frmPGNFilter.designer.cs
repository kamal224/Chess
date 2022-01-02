namespace SrcChess {
    partial class frmPGNFilter {
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
            this.checkedListBoxRange = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClearAllRange = new System.Windows.Forms.Button();
            this.butSelectAllRange = new System.Windows.Forms.Button();
            this.checkBoxIncludeUnrated = new System.Windows.Forms.CheckBox();
            this.checkBoxAllRanges = new System.Windows.Forms.CheckBox();
            this.groupBoxPlayer = new System.Windows.Forms.GroupBox();
            this.buttonClearAllPlayers = new System.Windows.Forms.Button();
            this.buttonSelectAllPlayers = new System.Windows.Forms.Button();
            this.checkBoxAllPlayer = new System.Windows.Forms.CheckBox();
            this.checkedListBoxPlayers = new System.Windows.Forms.CheckedListBox();
            this.groupBoxEnding = new System.Windows.Forms.GroupBox();
            this.buttonClearAllEndGame = new System.Windows.Forms.Button();
            this.buttonSelectAllEndGame = new System.Windows.Forms.Button();
            this.checkBoxAllEndGame = new System.Windows.Forms.CheckBox();
            this.checkedListBoxEnding = new System.Windows.Forms.CheckedListBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.labelDesc = new System.Windows.Forms.Label();
            this.butTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxPlayer.SuspendLayout();
            this.groupBoxEnding.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxRange
            // 
            this.checkedListBoxRange.CheckOnClick = true;
            this.checkedListBoxRange.FormattingEnabled = true;
            this.checkedListBoxRange.Location = new System.Drawing.Point(6, 49);
            this.checkedListBoxRange.Name = "checkedListBoxRange";
            this.checkedListBoxRange.Size = new System.Drawing.Size(200, 259);
            this.checkedListBoxRange.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClearAllRange);
            this.groupBox1.Controls.Add(this.butSelectAllRange);
            this.groupBox1.Controls.Add(this.checkBoxIncludeUnrated);
            this.groupBox1.Controls.Add(this.checkBoxAllRanges);
            this.groupBox1.Controls.Add(this.checkedListBoxRange);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 393);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ELO Ranges";
            // 
            // buttonClearAllRange
            // 
            this.buttonClearAllRange.Location = new System.Drawing.Point(6, 353);
            this.buttonClearAllRange.Name = "buttonClearAllRange";
            this.buttonClearAllRange.Size = new System.Drawing.Size(200, 30);
            this.buttonClearAllRange.TabIndex = 4;
            this.buttonClearAllRange.Text = "Clear All";
            this.buttonClearAllRange.UseVisualStyleBackColor = true;
            this.buttonClearAllRange.Click += new System.EventHandler(this.buttonClearAllRange_Click);
            // 
            // butSelectAllRange
            // 
            this.butSelectAllRange.Location = new System.Drawing.Point(6, 314);
            this.butSelectAllRange.Name = "butSelectAllRange";
            this.butSelectAllRange.Size = new System.Drawing.Size(200, 30);
            this.butSelectAllRange.TabIndex = 3;
            this.butSelectAllRange.Text = "Select All";
            this.butSelectAllRange.UseVisualStyleBackColor = true;
            this.butSelectAllRange.Click += new System.EventHandler(this.butSelectAllRange_Click);
            // 
            // checkBoxIncludeUnrated
            // 
            this.checkBoxIncludeUnrated.AutoSize = true;
            this.checkBoxIncludeUnrated.Location = new System.Drawing.Point(89, 26);
            this.checkBoxIncludeUnrated.Name = "checkBoxIncludeUnrated";
            this.checkBoxIncludeUnrated.Size = new System.Drawing.Size(107, 17);
            this.checkBoxIncludeUnrated.TabIndex = 2;
            this.checkBoxIncludeUnrated.Text = "Includes Unrated";
            this.checkBoxIncludeUnrated.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllRanges
            // 
            this.checkBoxAllRanges.AutoSize = true;
            this.checkBoxAllRanges.Location = new System.Drawing.Point(6, 26);
            this.checkBoxAllRanges.Name = "checkBoxAllRanges";
            this.checkBoxAllRanges.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAllRanges.TabIndex = 1;
            this.checkBoxAllRanges.Text = "All Ranges";
            this.checkBoxAllRanges.UseVisualStyleBackColor = true;
            this.checkBoxAllRanges.CheckedChanged += new System.EventHandler(this.checkBoxAllRanges_CheckedChanged);
            // 
            // groupBoxPlayer
            // 
            this.groupBoxPlayer.Controls.Add(this.buttonClearAllPlayers);
            this.groupBoxPlayer.Controls.Add(this.buttonSelectAllPlayers);
            this.groupBoxPlayer.Controls.Add(this.checkBoxAllPlayer);
            this.groupBoxPlayer.Controls.Add(this.checkedListBoxPlayers);
            this.groupBoxPlayer.Location = new System.Drawing.Point(256, 59);
            this.groupBoxPlayer.Name = "groupBoxPlayer";
            this.groupBoxPlayer.Size = new System.Drawing.Size(227, 393);
            this.groupBoxPlayer.TabIndex = 7;
            this.groupBoxPlayer.TabStop = false;
            this.groupBoxPlayer.Text = "Players";
            // 
            // buttonClearAllPlayers
            // 
            this.buttonClearAllPlayers.Location = new System.Drawing.Point(6, 353);
            this.buttonClearAllPlayers.Name = "buttonClearAllPlayers";
            this.buttonClearAllPlayers.Size = new System.Drawing.Size(200, 30);
            this.buttonClearAllPlayers.TabIndex = 5;
            this.buttonClearAllPlayers.Text = "Clear All";
            this.buttonClearAllPlayers.UseVisualStyleBackColor = true;
            this.buttonClearAllPlayers.Click += new System.EventHandler(this.buttonClearAllPlayers_Click);
            // 
            // buttonSelectAllPlayers
            // 
            this.buttonSelectAllPlayers.Location = new System.Drawing.Point(6, 314);
            this.buttonSelectAllPlayers.Name = "buttonSelectAllPlayers";
            this.buttonSelectAllPlayers.Size = new System.Drawing.Size(200, 30);
            this.buttonSelectAllPlayers.TabIndex = 4;
            this.buttonSelectAllPlayers.Text = "Select All";
            this.buttonSelectAllPlayers.UseVisualStyleBackColor = true;
            this.buttonSelectAllPlayers.Click += new System.EventHandler(this.buttonSelectAllPlayers_Click);
            // 
            // checkBoxAllPlayer
            // 
            this.checkBoxAllPlayer.AutoSize = true;
            this.checkBoxAllPlayer.Location = new System.Drawing.Point(6, 26);
            this.checkBoxAllPlayer.Name = "checkBoxAllPlayer";
            this.checkBoxAllPlayer.Size = new System.Drawing.Size(74, 17);
            this.checkBoxAllPlayer.TabIndex = 1;
            this.checkBoxAllPlayer.Text = "All Players";
            this.checkBoxAllPlayer.UseVisualStyleBackColor = true;
            this.checkBoxAllPlayer.CheckedChanged += new System.EventHandler(this.checkBoxAllPlayer_CheckedChanged);
            // 
            // checkedListBoxPlayers
            // 
            this.checkedListBoxPlayers.CheckOnClick = true;
            this.checkedListBoxPlayers.FormattingEnabled = true;
            this.checkedListBoxPlayers.Location = new System.Drawing.Point(6, 49);
            this.checkedListBoxPlayers.Name = "checkedListBoxPlayers";
            this.checkedListBoxPlayers.Size = new System.Drawing.Size(200, 259);
            this.checkedListBoxPlayers.TabIndex = 0;
            // 
            // groupBoxEnding
            // 
            this.groupBoxEnding.Controls.Add(this.buttonClearAllEndGame);
            this.groupBoxEnding.Controls.Add(this.buttonSelectAllEndGame);
            this.groupBoxEnding.Controls.Add(this.checkBoxAllEndGame);
            this.groupBoxEnding.Controls.Add(this.checkedListBoxEnding);
            this.groupBoxEnding.Location = new System.Drawing.Point(501, 59);
            this.groupBoxEnding.Name = "groupBoxEnding";
            this.groupBoxEnding.Size = new System.Drawing.Size(227, 393);
            this.groupBoxEnding.TabIndex = 8;
            this.groupBoxEnding.TabStop = false;
            this.groupBoxEnding.Text = "Ending";
            // 
            // buttonClearAllEndGame
            // 
            this.buttonClearAllEndGame.Location = new System.Drawing.Point(6, 353);
            this.buttonClearAllEndGame.Name = "buttonClearAllEndGame";
            this.buttonClearAllEndGame.Size = new System.Drawing.Size(200, 30);
            this.buttonClearAllEndGame.TabIndex = 5;
            this.buttonClearAllEndGame.Text = "Clear All";
            this.buttonClearAllEndGame.UseVisualStyleBackColor = true;
            this.buttonClearAllEndGame.Click += new System.EventHandler(this.buttonClearAllEndGame_Click);
            // 
            // buttonSelectAllEndGame
            // 
            this.buttonSelectAllEndGame.Location = new System.Drawing.Point(6, 314);
            this.buttonSelectAllEndGame.Name = "buttonSelectAllEndGame";
            this.buttonSelectAllEndGame.Size = new System.Drawing.Size(200, 30);
            this.buttonSelectAllEndGame.TabIndex = 4;
            this.buttonSelectAllEndGame.Text = "Select All";
            this.buttonSelectAllEndGame.UseVisualStyleBackColor = true;
            this.buttonSelectAllEndGame.Click += new System.EventHandler(this.buttonSelectAllEndGame_Click);
            // 
            // checkBoxAllEndGame
            // 
            this.checkBoxAllEndGame.AutoSize = true;
            this.checkBoxAllEndGame.Location = new System.Drawing.Point(6, 26);
            this.checkBoxAllEndGame.Name = "checkBoxAllEndGame";
            this.checkBoxAllEndGame.Size = new System.Drawing.Size(95, 17);
            this.checkBoxAllEndGame.TabIndex = 1;
            this.checkBoxAllEndGame.Text = "All End Games";
            this.checkBoxAllEndGame.UseVisualStyleBackColor = true;
            this.checkBoxAllEndGame.CheckedChanged += new System.EventHandler(this.checkBoxAllEndGame_CheckedChanged);
            // 
            // checkedListBoxEnding
            // 
            this.checkedListBoxEnding.CheckOnClick = true;
            this.checkedListBoxEnding.FormattingEnabled = true;
            this.checkedListBoxEnding.Location = new System.Drawing.Point(6, 49);
            this.checkedListBoxEnding.Name = "checkedListBoxEnding";
            this.checkedListBoxEnding.Size = new System.Drawing.Size(200, 259);
            this.checkedListBoxEnding.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(183, 474);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(121, 29);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "Ok";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(437, 474);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(121, 29);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // labelDesc
            // 
            this.labelDesc.Location = new System.Drawing.Point(9, 22);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(719, 23);
            this.labelDesc.TabIndex = 11;
            this.labelDesc.Text = "Description";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butTest
            // 
            this.butTest.Location = new System.Drawing.Point(310, 474);
            this.butTest.Name = "butTest";
            this.butTest.Size = new System.Drawing.Size(121, 29);
            this.butTest.TabIndex = 12;
            this.butTest.Text = "Test";
            this.butTest.UseVisualStyleBackColor = true;
            this.butTest.Click += new System.EventHandler(this.butTest_Click);
            // 
            // frmPGNFilter
            // 
            this.AcceptButton = this.butOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(740, 515);
            this.Controls.Add(this.butTest);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBoxEnding);
            this.Controls.Add(this.groupBoxPlayer);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPGNFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Filter Criterias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPlayer.ResumeLayout(false);
            this.groupBoxPlayer.PerformLayout();
            this.groupBoxEnding.ResumeLayout(false);
            this.groupBoxEnding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxAllRanges;
        private System.Windows.Forms.Button buttonClearAllRange;
        private System.Windows.Forms.Button butSelectAllRange;
        private System.Windows.Forms.CheckBox checkBoxIncludeUnrated;
        private System.Windows.Forms.GroupBox groupBoxPlayer;
        private System.Windows.Forms.Button buttonClearAllPlayers;
        private System.Windows.Forms.Button buttonSelectAllPlayers;
        private System.Windows.Forms.CheckBox checkBoxAllPlayer;
        private System.Windows.Forms.CheckedListBox checkedListBoxPlayers;
        private System.Windows.Forms.GroupBox groupBoxEnding;
        private System.Windows.Forms.Button buttonClearAllEndGame;
        private System.Windows.Forms.Button buttonSelectAllEndGame;
        private System.Windows.Forms.CheckBox checkBoxAllEndGame;
        private System.Windows.Forms.CheckedListBox checkedListBoxEnding;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Button butTest;
    }
}