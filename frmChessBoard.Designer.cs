namespace SrcChess {
    partial class frmChessBoard {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChessBoard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAGameFromPGNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToPGNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.revertBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.playerAgainstPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.automaticPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastAutomaticPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.designModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.flashPieceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pgnNotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.chooseColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createABookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterAPGNFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBoardEvaluationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panelBlackLostPiece = new System.Windows.Forms.Panel();
            this.panelWhiteLostPiece = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSearchMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMove = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPerm = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMoveList = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelTimeWhite = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelTimeBlack = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonHint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(840, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.loadGameToolStripMenuItem,
            this.createAGameFromPGNToolStripMenuItem,
            this.saveGameToolStripMenuItem1,
            this.saveGameToPGNToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.newGameToolStripMenuItem.Text = "&New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(213, 6);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.loadGameToolStripMenuItem.Text = "&Load Game...";
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // createAGameFromPGNToolStripMenuItem
            // 
            this.createAGameFromPGNToolStripMenuItem.Name = "createAGameFromPGNToolStripMenuItem";
            this.createAGameFromPGNToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.createAGameFromPGNToolStripMenuItem.Text = "&Create a Game from PGN...";
            this.createAGameFromPGNToolStripMenuItem.Click += new System.EventHandler(this.createAGameFromPGNToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem1
            // 
            this.saveGameToolStripMenuItem1.Name = "saveGameToolStripMenuItem1";
            this.saveGameToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveGameToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.saveGameToolStripMenuItem1.Text = "&Save Game...";
            this.saveGameToolStripMenuItem1.Click += new System.EventHandler(this.saveGameToolStripMenuItem1_Click);
            // 
            // saveGameToPGNToolStripMenuItem
            // 
            this.saveGameToPGNToolStripMenuItem.Name = "saveGameToPGNToolStripMenuItem";
            this.saveGameToPGNToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.saveGameToPGNToolStripMenuItem.Text = "Save Game to &PGN...";
            this.saveGameToPGNToolStripMenuItem.Click += new System.EventHandler(this.saveGameToPGNToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(213, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hintToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem4,
            this.revertBoardToolStripMenuItem,
            this.toolStripMenuItem5,
            this.playerAgainstPlayerToolStripMenuItem,
            this.toolStripMenuItem6,
            this.automaticPlayToolStripMenuItem,
            this.fastAutomaticPlayToolStripMenuItem,
            this.cancelPlayToolStripMenuItem,
            this.toolStripMenuItem1,
            this.designModeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hintToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.hintToolStripMenuItem.Text = "&Hint";
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(222, 6);
            // 
            // revertBoardToolStripMenuItem
            // 
            this.revertBoardToolStripMenuItem.Name = "revertBoardToolStripMenuItem";
            this.revertBoardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.revertBoardToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.revertBoardToolStripMenuItem.Text = "Revert &Board";
            this.revertBoardToolStripMenuItem.Click += new System.EventHandler(this.revertBoardToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(222, 6);
            // 
            // playerAgainstPlayerToolStripMenuItem
            // 
            this.playerAgainstPlayerToolStripMenuItem.Name = "playerAgainstPlayerToolStripMenuItem";
            this.playerAgainstPlayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playerAgainstPlayerToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.playerAgainstPlayerToolStripMenuItem.Text = "&Player against player";
            this.playerAgainstPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerAgainstPlayerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(222, 6);
            // 
            // automaticPlayToolStripMenuItem
            // 
            this.automaticPlayToolStripMenuItem.Name = "automaticPlayToolStripMenuItem";
            this.automaticPlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.automaticPlayToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.automaticPlayToolStripMenuItem.Text = "&Automatic play";
            this.automaticPlayToolStripMenuItem.Click += new System.EventHandler(this.automaticPlayToolStripMenuItem_Click);
            // 
            // fastAutomaticPlayToolStripMenuItem
            // 
            this.fastAutomaticPlayToolStripMenuItem.Name = "fastAutomaticPlayToolStripMenuItem";
            this.fastAutomaticPlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.fastAutomaticPlayToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.fastAutomaticPlayToolStripMenuItem.Text = "&Fast Automatic play";
            this.fastAutomaticPlayToolStripMenuItem.Click += new System.EventHandler(this.fastAutomaticPlayToolStripMenuItem_Click);
            // 
            // cancelPlayToolStripMenuItem
            // 
            this.cancelPlayToolStripMenuItem.Name = "cancelPlayToolStripMenuItem";
            this.cancelPlayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelPlayToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.cancelPlayToolStripMenuItem.Text = "&Cancel Play";
            this.cancelPlayToolStripMenuItem.Click += new System.EventHandler(this.cancelAutomaticPlayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 6);
            // 
            // designModeToolStripMenuItem
            // 
            this.designModeToolStripMenuItem.Name = "designModeToolStripMenuItem";
            this.designModeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.designModeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.designModeToolStripMenuItem.Text = "&Design Mode";
            this.designModeToolStripMenuItem.Click += new System.EventHandler(this.designModeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchModeToolStripMenuItem,
            this.toolStripSeparator1,
            this.flashPieceToolStripMenuItem,
            this.pgnNotationToolStripMenuItem,
            this.toolStripSeparator6,
            this.chooseColorsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // searchModeToolStripMenuItem
            // 
            this.searchModeToolStripMenuItem.Name = "searchModeToolStripMenuItem";
            this.searchModeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.searchModeToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.searchModeToolStripMenuItem.Text = "&Search Mode...";
            this.searchModeToolStripMenuItem.Click += new System.EventHandler(this.searchModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // flashPieceToolStripMenuItem
            // 
            this.flashPieceToolStripMenuItem.Checked = true;
            this.flashPieceToolStripMenuItem.CheckOnClick = true;
            this.flashPieceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flashPieceToolStripMenuItem.Name = "flashPieceToolStripMenuItem";
            this.flashPieceToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.flashPieceToolStripMenuItem.Text = "&Flash piece";
            this.flashPieceToolStripMenuItem.Click += new System.EventHandler(this.flashPieceToolStripMenuItem_Click);
            // 
            // pgnNotationToolStripMenuItem
            // 
            this.pgnNotationToolStripMenuItem.CheckOnClick = true;
            this.pgnNotationToolStripMenuItem.Name = "pgnNotationToolStripMenuItem";
            this.pgnNotationToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.pgnNotationToolStripMenuItem.Text = "&PGN Notation";
            this.pgnNotationToolStripMenuItem.Click += new System.EventHandler(this.pgnNotationToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(194, 6);
            // 
            // chooseColorsToolStripMenuItem
            // 
            this.chooseColorsToolStripMenuItem.Name = "chooseColorsToolStripMenuItem";
            this.chooseColorsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.chooseColorsToolStripMenuItem.Text = "&Choose Colors...";
            this.chooseColorsToolStripMenuItem.Click += new System.EventHandler(this.chooseColorsToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createABookToolStripMenuItem,
            this.filterAPGNFileToolStripMenuItem,
            this.testBoardEvaluationToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // createABookToolStripMenuItem
            // 
            this.createABookToolStripMenuItem.Name = "createABookToolStripMenuItem";
            this.createABookToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.createABookToolStripMenuItem.Text = "&Create a Book...";
            this.createABookToolStripMenuItem.Click += new System.EventHandler(this.createABookToolStripMenuItem_Click);
            // 
            // filterAPGNFileToolStripMenuItem
            // 
            this.filterAPGNFileToolStripMenuItem.Name = "filterAPGNFileToolStripMenuItem";
            this.filterAPGNFileToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.filterAPGNFileToolStripMenuItem.Text = "&Filter a PGN File...";
            this.filterAPGNFileToolStripMenuItem.Click += new System.EventHandler(this.filterAPGNFileToolStripMenuItem_Click);
            // 
            // testBoardEvaluationToolStripMenuItem
            // 
            this.testBoardEvaluationToolStripMenuItem.Name = "testBoardEvaluationToolStripMenuItem";
            this.testBoardEvaluationToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.testBoardEvaluationToolStripMenuItem.Text = "&Test Board Evaluation...";
            this.testBoardEvaluationToolStripMenuItem.Click += new System.EventHandler(this.testBoardEvaluationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelBoard
            // 
            this.panelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoard.Location = new System.Drawing.Point(14, 67);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(530, 530);
            this.panelBoard.TabIndex = 1;
            this.panelBoard.Resize += new System.EventHandler(this.panelBoard_Resize);
            // 
            // panelBlackLostPiece
            // 
            this.panelBlackLostPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBlackLostPiece.BackColor = System.Drawing.Color.White;
            this.panelBlackLostPiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlackLostPiece.Location = new System.Drawing.Point(733, 67);
            this.panelBlackLostPiece.Name = "panelBlackLostPiece";
            this.panelBlackLostPiece.Size = new System.Drawing.Size(100, 100);
            this.panelBlackLostPiece.TabIndex = 3;
            // 
            // panelWhiteLostPiece
            // 
            this.panelWhiteLostPiece.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWhiteLostPiece.BackColor = System.Drawing.Color.White;
            this.panelWhiteLostPiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWhiteLostPiece.Location = new System.Drawing.Point(733, 173);
            this.panelWhiteLostPiece.Name = "panelWhiteLostPiece";
            this.panelWhiteLostPiece.Size = new System.Drawing.Size(100, 100);
            this.panelWhiteLostPiece.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSearchMode,
            this.toolStripStatusLabelMove,
            this.toolStripStatusLabelPerm});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(840, 24);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSearchMode
            // 
            this.toolStripStatusLabelSearchMode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelSearchMode.Name = "toolStripStatusLabelSearchMode";
            this.toolStripStatusLabelSearchMode.Size = new System.Drawing.Size(98, 19);
            this.toolStripStatusLabelSearchMode.Text = "Alpha-Beta 6 ply";
            // 
            // toolStripStatusLabelMove
            // 
            this.toolStripStatusLabelMove.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelMove.Name = "toolStripStatusLabelMove";
            this.toolStripStatusLabelMove.Size = new System.Drawing.Size(41, 19);
            this.toolStripStatusLabelMove.Text = "Move";
            // 
            // toolStripStatusLabelPerm
            // 
            this.toolStripStatusLabelPerm.Name = "toolStripStatusLabelPerm";
            this.toolStripStatusLabelPerm.Size = new System.Drawing.Size(73, 19);
            this.toolStripStatusLabelPerm.Text = "Permutation";
            // 
            // panelMoveList
            // 
            this.panelMoveList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMoveList.Location = new System.Drawing.Point(550, 67);
            this.panelMoveList.Name = "panelMoveList";
            this.panelMoveList.Size = new System.Drawing.Size(177, 530);
            this.panelMoveList.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Toolbar32.bmp");
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelMoveList);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelWhiteLostPiece);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelBlackLostPiece);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panelBoard);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(840, 606);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(840, 654);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabelTimeWhite,
            this.toolStripSeparator5,
            this.toolStripLabel2,
            this.toolStripLabelTimeBlack});
            this.toolStrip2.Location = new System.Drawing.Point(289, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(274, 39);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 36);
            this.toolStripLabel1.Text = "White:";
            // 
            // toolStripLabelTimeWhite
            // 
            this.toolStripLabelTimeWhite.Name = "toolStripLabelTimeWhite";
            this.toolStripLabelTimeWhite.Size = new System.Drawing.Size(70, 36);
            this.toolStripLabelTimeWhite.Text = "00:00:00";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(49, 36);
            this.toolStripLabel2.Text = "Black:";
            // 
            // toolStripLabelTimeBlack
            // 
            this.toolStripLabelTimeBlack.Name = "toolStripLabelTimeBlack";
            this.toolStripLabelTimeBlack.Size = new System.Drawing.Size(70, 36);
            this.toolStripLabelTimeBlack.Text = "00:00:00";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoad,
            this.toolStripButtonSave,
            this.toolStripSeparator2,
            this.toolStripButtonHint,
            this.toolStripSeparator3,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSeparator4,
            this.toolStripButtonStop});
            this.toolStrip1.Location = new System.Drawing.Point(9, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(237, 39);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "Text";
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLoad.Text = "Load...";
            this.toolStripButtonLoad.ToolTipText = "Load a New Game";
            this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSave.Text = "Save...";
            this.toolStripButtonSave.ToolTipText = "Save the Game";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonHint
            // 
            this.toolStripButtonHint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHint.Image")));
            this.toolStripButtonHint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHint.Name = "toolStripButtonHint";
            this.toolStripButtonHint.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonHint.Text = "Hint";
            this.toolStripButtonHint.ToolTipText = "Give a Hint";
            this.toolStripButtonHint.Click += new System.EventHandler(this.toolStripButtonHint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.ToolTipText = "Undo Last Move";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.toolStripButtonUndo_Click);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.ToolTipText = "Redo Last Move";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.toolStripButtonRedo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonStop.Text = "Stop Computing";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // frmChessBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 654);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmChessBoard";
            this.Text = "Chess Board (Version 1.10)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flashPieceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem automaticPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastAutomaticPlayToolStripMenuItem;
        private System.Windows.Forms.Panel panelBlackLostPiece;
        private System.Windows.Forms.Panel panelWhiteLostPiece;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem designModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMove;
        private System.Windows.Forms.ToolStripMenuItem revertBoardToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createABookToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPerm;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterAPGNFileToolStripMenuItem;
        private System.Windows.Forms.Panel panelMoveList;
        private System.Windows.Forms.ToolStripMenuItem createAGameFromPGNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem testBoardEvaluationToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.ToolStripButton toolStripButtonHint;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTimeWhite;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTimeBlack;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSearchMode;
        private System.Windows.Forms.ToolStripMenuItem pgnNotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem chooseColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToPGNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerAgainstPlayerToolStripMenuItem;
    }
}