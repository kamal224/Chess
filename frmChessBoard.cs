using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>
    /// Main form for the chess program
    /// </summary>
    /// TODO:   Improves board evaluation
    /// 
    public partial class frmChessBoard : Form, ChessControl.IMoveListUI {

        /// <summary>
        /// Override chess control to add information to the save board
        /// </summary>
        private class LocalChessControl : ChessControl {
            /// <summary>Father form</summary>
            private frmChessBoard   m_frmFather;

            //*********************************************************     
            //
            /// <summary>
            /// Class constructor
            /// </summary>
            //  
            //*********************************************************     
            public LocalChessControl() : base() {
            }

            //*********************************************************     
            //
            /// <summary>
            /// Father form
            /// </summary>
            //  
            //*********************************************************     
            public frmChessBoard Father {
                get {
                    return(m_frmFather);
                }
                set {
                    m_frmFather = value;
                }
            }

            //*********************************************************     
            //
            /// <summary>
            /// Load the game board
            /// </summary>
            /// <param name="reader">   Binary reader</param>
            /// <returns>
            /// true if succeed, false if failed
            /// </returns>
            //  
            //*********************************************************     
            public override bool LoadGame(BinaryReader reader) {
                bool            bRetVal;
                string          strVersion;
                PlayingModeE    ePlayingMode;
                
                strVersion = reader.ReadString();
                if (strVersion == "SRCCHESS095") {
                    bRetVal = base.LoadGame(reader);
                    if (bRetVal) {
                        ePlayingMode            = (PlayingModeE)reader.ReadInt32();
                        m_frmFather.PlayingMode = ePlayingMode;
                    } else {
                        bRetVal = false;
                    }
                } else {
                    bRetVal = false;
                }
                return(bRetVal);
            }

            //*********************************************************     
            //
            /// <summary>
            /// Save the game board
            /// </summary>
            /// <param name="writer">   Binary writer</param>
            //  
            //*********************************************************     
            public override void SaveGame(BinaryWriter writer) {
                writer.Write("SRCCHESS095");
                base.SaveGame(writer);
                writer.Write((int)m_frmFather.m_ePlayingMode);
            }

            //*********************************************************     
            //
            /// <summary>
            /// Create a new game using the specified list of moves
            /// </summary>
            /// <param name="chessBoardStarting">   Starting board or null if standard board</param>
            /// <param name="listMove">             List of moves</param>
            /// <param name="eNextMoveColor">       Color starting to play</param>
            /// <param name="strWhitePlayerName">   Name of the player playing white pieces</param>
            /// <param name="strBlackPlayerName">   Name of the player playing black pieces</param>
            /// <param name="eWhitePlayerType">     Type of player playing white pieces</param>
            /// <param name="eBlackPlayerType">     Type of player playing black pieces</param>
            /// <param name="spanPlayerWhite">      Timer for white</param>
            /// <param name="spanPlayerBlack">      Timer for black</param>
            //  
            //*********************************************************     
            public override void CreateGameFromMove(ChessBoard                  chessBoardStarting,
                                                    List<ChessBoard.MovePosS>   listMove,
                                                    ChessBoard.PlayerColorE     eNextMoveColor,
                                                    string                      strWhitePlayerName,
                                                    string                      strBlackPlayerName,
                                                    PgnParser.PlayerTypeE       eWhitePlayerType,
                                                    PgnParser.PlayerTypeE       eBlackPlayerType,
                                                    TimeSpan                    spanPlayerWhite,
                                                    TimeSpan                    spanPlayerBlack) {
                base.CreateGameFromMove(chessBoardStarting,
                                        listMove,
                                        eNextMoveColor,
                                        strWhitePlayerName,
                                        strBlackPlayerName,
                                        eWhitePlayerType,
                                        eBlackPlayerType,
                                        spanPlayerWhite,
                                        spanPlayerBlack);
                if (eWhitePlayerType == PgnParser.PlayerTypeE.Program) {
                    if (eBlackPlayerType == PgnParser.PlayerTypeE.Program) {
                        Father.PlayingMode              = PlayingModeE.ComputerAgainstComputer;
                    } else {
                        Father.PlayingMode              = PlayingModeE.PlayerAgainstComputer;
                        Father.m_eComputerPlayingColor  = ChessBoard.PlayerColorE.White;
                    }
                } else if (eBlackPlayerType == PgnParser.PlayerTypeE.Program) {
                    Father.PlayingMode              = PlayingModeE.PlayerAgainstComputer;
                    Father.m_eComputerPlayingColor  = ChessBoard.PlayerColorE.Black;
                } else {
                    Father.PlayingMode = PlayingModeE.PlayerAgainstPlayer;
                }
                Father.SetCmdState();
            }
        }
        
        /// <summary>Getting computer against computer playing statistic</summary>
        private class ComputerPlayingStat {
            public  ComputerPlayingStat() { m_timeSpanMethod1 = TimeSpan.Zero; m_timeSpanMethod2 = TimeSpan.Zero; m_eResult = ChessBoard.MoveResultE.NoRepeat; m_iMethod1MoveCount = 0; m_iMethod2MoveCount = 0; m_bUserCancel = false; }
            public  TimeSpan                m_timeSpanMethod1;
            public  TimeSpan                m_timeSpanMethod2;
            public  ChessBoard.MoveResultE  m_eResult;
            public  int                     m_iMethod1MoveCount;
            public  int                     m_iMethod2MoveCount;
            public  bool                    m_bUserCancel;
        };
        
        /// <summary>Use for computer move</summary>
        public enum MessageModeE {
            /// <summary>No message</summary>
            Silent      = 0,
            /// <summary>Only messages for move which are terminating the game</summary>
            CallEndGame = 1,
            /// <summary>All messages</summary>
            Verbose     = 2
        };
        
        /// <summary>Current playing mode</summary>
        public enum PlayingModeE {
            /// <summary>Player plays against another player</summary>
            PlayerAgainstPlayer,
            /// <summary>Player plays against computer</summary>
            PlayerAgainstComputer,
            /// <summary>Computer play against computer</summary>
            ComputerAgainstComputer,
            /// <summary>Design mode.</summary>
            DesignMode
        };
        
        /// <summary>Chess control. This control implements the board user interface.</summary>
        private LocalChessControl       m_chessCtl;
        /// <summary>Lost pieces control for black</summary>
        private LostPiecesControl       m_lostPieceBlack;
        /// <summary>Lost pieces control for white</summary>
        private LostPiecesControl       m_lostPieceWhite;
        /// <summary>Control showing the list of moves</summary>
        private MoveViewer              m_moveViewer;
        /// <summary>Playing mode (player vs player, player vs computer, computer vs computer</summary>
        private PlayingModeE            m_ePlayingMode;
        /// <summary>Color played by the computer</summary>
        public ChessBoard.PlayerColorE  m_eComputerPlayingColor;
        /// <summary>true if a secondary thread is busy computing a move</summary>
        private bool                    m_bSecondThreadBusy;
        /// <summary>Search mode</summary>
        private SearchEngine.SearchMode m_searchMode;
        /// <summary>Utility class to handle board evaluation objects</summary>
        private BoardEvaluationUtil     m_boardEvalUtil;


        //*********************************************************     
        //
        /// <summary>
        /// Form constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmChessBoard() {
            SrcChess.Properties.Settings            settings;
            SearchEngine.SearchMode.OptionE         eOption;
            SearchEngine.SearchMode.ThreadingModeE  eThreadingMode;
            int                                     iTransTableSize;
            IBoardEvaluation                        boardEvalWhite;
            IBoardEvaluation                        boardEvalBlack;
            ChessControl.ChessControlColorInfo      colorInfo;
            
            InitializeComponent();
            settings                        = SrcChess.Properties.Settings.Default;
            colorInfo.m_colBlackPiece       = NameToColor(settings.BlackPieceColor);
            colorInfo.m_colWhitePiece       = NameToColor(settings.WhitePieceColor);
            colorInfo.m_colLiteCase         = NameToColor(settings.LiteCaseColor);
            colorInfo.m_colDarkCase         = NameToColor(settings.DarkCaseColor);
            iTransTableSize                 = (settings.TransTableSize < 5 || settings.TransTableSize > 256) ? 32 : settings.TransTableSize;
            TransTable.TranslationTableSize = iTransTableSize / 32 * 1000000;
            eOption                         = settings.UseAlphaBeta ? SearchEngine.SearchMode.OptionE.UseAlphaBeta : SearchEngine.SearchMode.OptionE.UseMinMax;
            if (settings.UseBook) {
                eOption |= SearchEngine.SearchMode.OptionE.UseBook;
            }
            if (settings.UseTransTable) {
                eOption |= SearchEngine.SearchMode.OptionE.UseTransTable;
            }
            if (settings.UsePlyCountIterative) {
                eOption |= SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch;
            }
            switch(settings.UseThread) {
            case 0:
                eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.Off;
                break;
            case 1:
                eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch;
                break;
            default:
                eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch;
                break;
            }
            m_boardEvalUtil                     = new BoardEvaluationUtil();
            boardEvalWhite                      = m_boardEvalUtil.FindBoardEvaluator(settings.WhiteBoardEval);
            if (boardEvalWhite == null) {
                boardEvalWhite = m_boardEvalUtil.BoardEvaluators[0];
            }
            boardEvalBlack                      = m_boardEvalUtil.FindBoardEvaluator(settings.BlackBoardEval);
            if (boardEvalBlack == null) {
                boardEvalBlack = m_boardEvalUtil.BoardEvaluators[0];
            }
            m_searchMode                        = new SearchEngine.SearchMode(boardEvalWhite,
                                                                              boardEvalBlack,
                                                                              eOption,
                                                                              eThreadingMode,
                                                                              settings.UsePlyCount | settings.UsePlyCountIterative ? ((settings.PlyCount > 1 && settings.PlyCount < 9) ? settings.PlyCount : 6) : 0,  // Maximum depth
                                                                              settings.UsePlyCount | settings.UsePlyCountIterative ? 0 : (settings.AverageTime > 0 && settings.AverageTime < 1000) ? settings.AverageTime : 15,
                                                                              (settings.RandomMode >= 0 && settings.RandomMode <= 2) ? (SearchEngine.SearchMode.RandomModeE)settings.RandomMode : SearchEngine.SearchMode.RandomModeE.On); // Average time
            m_chessCtl                          = new LocalChessControl();
            m_chessCtl.Location                 = new Point(0, 0);
            m_chessCtl.Size                     = new Size(60 * 9, 60 * 9);
            m_chessCtl.UpdateCmdState          += new EventHandler(m_chessCtl_UpdateCmdState);
            m_chessCtl.Father                   = this;
            m_chessCtl.ColorInfo                = colorInfo;
            panelBoard.Controls.Add(m_chessCtl);
            PlayingMode                         = PlayingModeE.PlayerAgainstComputer;
            m_eComputerPlayingColor             = ChessBoard.PlayerColorE.Black;
            m_lostPieceBlack                    = new LostPiecesControl();
            m_lostPieceBlack.Location           = new Point(0,0);
            m_lostPieceBlack.Size               = new Size(200, 200);
            m_lostPieceBlack.Dock               = DockStyle.Fill;
            m_lostPieceBlack.ChessControl       = m_chessCtl;
            m_lostPieceBlack.Color              = true;
            panelBlackLostPiece.Controls.Add(m_lostPieceBlack);
            m_lostPieceWhite                    = new LostPiecesControl();
            m_lostPieceWhite.Location           = new Point(0,0);
            m_lostPieceWhite.Size               = new Size(200, 200);
            m_lostPieceWhite.Dock               = DockStyle.Fill;
            m_lostPieceWhite.ChessControl       = m_chessCtl;
            m_lostPieceWhite.Color              = false;
            panelWhiteLostPiece.Controls.Add(m_lostPieceWhite);
            m_moveViewer                        = new MoveViewer();
            m_moveViewer.Location               = new Point(0,0);
            m_moveViewer.Size                   = panelMoveList.Size;
            m_moveViewer.Dock                   = DockStyle.Fill;
            m_moveViewer.NewMoveSelected       += new MoveViewer.NewMoveSelectedHandler(m_moveViewer_NewMoveSelected);
            m_moveViewer.DisplayMode            = (settings.MoveNotation == 0) ? MoveViewer.DisplayModeE.MovePos : MoveViewer.DisplayModeE.PGN;
            panelMoveList.Controls.Add(m_moveViewer);
            m_chessCtl.MoveListUI               = this;
            m_chessCtl.MoveSelected            += new ChessControl.MoveSelectedEventHandler(m_chessCtl_MoveSelected);
            m_chessCtl.QueryPiece              += new ChessControl.QueryPieceEventHandler(m_chessCtl_QueryPiece);
            m_chessCtl.QueryPawnPromotionType  += new ChessControl.QueryPawnPromotionTypeEventHandler(m_chessCtl_QueryPawnPromotionType);
            m_bSecondThreadBusy                 = false;
            timer1.Tick                        += new EventHandler(timer1_Tick);
            timer1.Start();
            ResizeChessCtl();
            SetCmdState();
            ShowSearchMode();
            flashPieceToolStripMenuItem.Checked  = settings.FlashPiece;
            pgnNotationToolStripMenuItem.Checked = (m_moveViewer.DisplayMode == MoveViewer.DisplayModeE.PGN);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Convert a color name to a color
        /// </summary>
        /// <param name="strName">  Name of the color or hexa representation of the color</param>
        /// <returns>
        /// Color
        /// </returns>
        //  
        //*********************************************************     
        private Color NameToColor(string strName) {
            Color   colRetVal;
            int     iVal;
            
            if (strName.Length == 8 && (Char.IsLower(strName[0]) || Char.IsDigit(strName[0])) &&
                Int32.TryParse(strName, System.Globalization.NumberStyles.HexNumber, null, out iVal)) { 
                colRetVal = Color.FromArgb((iVal >> 24) & 255, (iVal >> 16) & 255, (iVal >> 8) & 255, iVal & 255);
            } else {
                colRetVal = Color.FromName(strName);
            }
            return(colRetVal);    
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the panel containing the board is resized
        /// </summary>
        //  
        //*********************************************************     
        private void ResizeChessCtl() {
            Rectangle   rect;
            int         iCtlSize;
            int         iXPos;
            int         iYPos;
            
            if (m_chessCtl != null) {
                rect                = panelBoard.ClientRectangle;
                iCtlSize            = (rect.Width < rect.Height) ? rect.Width : rect.Height;
                iXPos               = (rect.Width  - iCtlSize) / 2;
                iYPos               = (rect.Height - iCtlSize) / 2;
                m_chessCtl.Location = new Point(iXPos, iYPos);
                m_chessCtl.Size     = new Size(iCtlSize, iCtlSize);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the panel containing the board is resized
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        //  
        //*********************************************************     
        private void panelBoard_Resize(object sender, EventArgs e) {
            ResizeChessCtl();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Current playing mode (player vs player, player vs computer or computer vs computer)
        /// </summary>
        //  
        //*********************************************************     
        public PlayingModeE PlayingMode {
            get {
                return(m_ePlayingMode);
            }
            set {
                m_ePlayingMode                               = value;
                playerAgainstPlayerToolStripMenuItem.Checked = (m_ePlayingMode == PlayingModeE.PlayerAgainstPlayer);
                switch(value) {
                case PlayingModeE.PlayerAgainstPlayer:
                    m_chessCtl.WhitePlayerType = PgnParser.PlayerTypeE.Human;
                    m_chessCtl.BlackPlayerType = PgnParser.PlayerTypeE.Human;
                    break;
                case PlayingModeE.PlayerAgainstComputer:
                    if (m_eComputerPlayingColor == ChessBoard.PlayerColorE.White) {
                        m_chessCtl.WhitePlayerType = PgnParser.PlayerTypeE.Program;
                        m_chessCtl.BlackPlayerType = PgnParser.PlayerTypeE.Human;
                    } else {
                        m_chessCtl.WhitePlayerType = PgnParser.PlayerTypeE.Human;
                        m_chessCtl.BlackPlayerType = PgnParser.PlayerTypeE.Program;
                    }
                    break;
                default:
                    m_chessCtl.WhitePlayerType = PgnParser.PlayerTypeE.Program;
                    m_chessCtl.BlackPlayerType = PgnParser.PlayerTypeE.Program;
                    break;
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Set the current playing mode. Defined as a method so it can be called by a delegate
        /// </summary>
        /// <param name="ePlayingMode"> Playing mode</param>
        //  
        //*********************************************************     
        private void SetPlayingMode(PlayingModeE ePlayingMode) {
            PlayingMode = ePlayingMode;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Start asynchronous computing
        /// </summary>
        //  
        //*********************************************************     
        private void StartAsyncComputing() {
            bool    bDifferentThreadForUI;
            
            if (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch) {
                bDifferentThreadForUI   = true;
            } else if (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch) {
                bDifferentThreadForUI   = true;
            } else {
                bDifferentThreadForUI   = false;
            }
            if (bDifferentThreadForUI) {
                m_bSecondThreadBusy = true;
                SetCmdState();
            }
            toolStripStatusLabelMove.Text = "Finding Best Move...";
            toolStripStatusLabelPerm.Text = "";
            Cursor = Cursors.WaitCursor;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show a move in status bar
        /// </summary>
        /// <param name="ePlayerColor"> Color of the move</param>
        /// <param name="move">         Move</param>
        /// <param name="iPermCount">   Permutation analyzed. 0 for none. -1 for book</param>
        /// <param name="iDepth">       Depth of the search (-1 if none)</param>
        /// <param name="iCacheHit">    Nb of permutation found in the translation table</param>
        //  
        //*********************************************************     
        private void ShowMoveInStatusBar(ChessBoard.PlayerColorE ePlayerColor, ChessBoard.MovePosS move, int iPermCount, int iDepth, int iCacheHit) {
            string                              strPermCount;
            System.Globalization.CultureInfo    ci;
            
            ci = new System.Globalization.CultureInfo("en-US");
            switch(iPermCount) {
            case -1:
                strPermCount = "Found in Book.";
                break;
            case 0:
                strPermCount = "---";
                break;
            default:
                strPermCount = iPermCount.ToString("C0", ci).Replace("$", "") + " permutations evaluated. " + iCacheHit.ToString("C0", ci).Replace("$","") + " found in cache.";
                break;
            }
            if (iDepth != -1) {
                strPermCount += " " + iDepth.ToString() + " ply.";
            }
            strPermCount                 += " " + m_chessCtl.LastFindBestMoveTimeSpan.TotalSeconds.ToString() + " sec(s).";
            toolStripStatusLabelMove.Text = ((ePlayerColor == ChessBoard.PlayerColorE.Black) ? "Black " : "White ") + ChessBoard.GetHumanPos(move);
            toolStripStatusLabelPerm.Text = strPermCount;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show the current searching parameters in the status bar
        /// </summary>
        //  
        //*********************************************************     
        private void ShowSearchMode() {
            string  str;
            
            if ((m_searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseAlphaBeta) == SearchEngine.SearchMode.OptionE.UseAlphaBeta) {
                str = "Alpha-Beta ";
            } else {
                str = "Min-Max ";
            }
            if (m_searchMode.m_iSearchDepth == 0) {
                str += "(Iterative " + m_searchMode.m_iTimeOutInSec.ToString() + " secs) ";
            } else if ((m_searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch) == SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch) {
                str += "(Iterative " + m_searchMode.m_iSearchDepth.ToString() + " ply) ";
            } else {
                str += "(" + m_searchMode.m_iSearchDepth.ToString() + " ply) ";
            }
            if (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch) {
                str += "using " + Environment.ProcessorCount.ToString() + " processor";
                if (Environment.ProcessorCount > 1) {
                    str += "s";
                }
                str += ". ";
            } else {
                str += "using 1 processor. ";
            }
            toolStripStatusLabelSearchMode.Text = str;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Remove all moves from the list
        /// </summary>
        /// <param name="chessBoard">       Starting chess board</param>
        //  
        //*********************************************************     
        void ChessControl.IMoveListUI.Reset(ChessBoard chessBoard) {
            m_moveViewer.Reset(chessBoard);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Append a new move to the list
        /// </summary>
        /// <param name="iPermCount">   Permutation analyzed. 0 for none. -1 for book</param>
        /// <param name="iDepth">       Depth</param>
        /// <param name="iCacheHit">    Nb of permutation found in the translation table</param>
        //  
        //*********************************************************     
        void ChessControl.IMoveListUI.NewMoveDone(int iPermCount, int iDepth, int iCacheHit) {
            ChessBoard.MovePosS     movePos;
            ChessBoard.PlayerColorE eMoveColor;
            
            m_moveViewer.NewMoveDone(iPermCount, iDepth, iCacheHit);
            movePos     = m_chessCtl.ChessBoard.MovePosStack.CurrentMove;
            eMoveColor  = m_chessCtl.ChessBoard.CurrentMoveColor;
            ShowMoveInStatusBar(eMoveColor, movePos, iPermCount, iDepth, iCacheHit);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Remove the last move from the list
        /// </summary>
        //  
        //*********************************************************     
        void ChessControl.IMoveListUI.RedoPosChanged() {
            m_moveViewer.RedoPosChanged();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Display a message related to the MoveStateE
        /// </summary>
        /// <param name="eMoveResult">  Move result</param>
        /// <param name="eMessageMode"> Message mode</param>
        /// <returns>
        /// true if it's the end of the game. false if not
        /// </returns>
        //  
        //*********************************************************     
        private bool DisplayMessage(ChessBoard.MoveResultE eMoveResult, MessageModeE eMessageMode) {
            bool    bRetVal;
            string  strOpponent;
            
            if (m_ePlayingMode == PlayingModeE.PlayerAgainstComputer) {
                if (m_chessCtl.ChessBoard.NextMoveColor == m_eComputerPlayingColor) {
                    strOpponent = "Computer is ";
                } else {
                    strOpponent = "You are ";
                }
            } else {
                strOpponent = (m_chessCtl.ChessBoard.NextMoveColor == ChessBoard.PlayerColorE.White) ? "White player is " : "Black player is ";
            }
            switch(eMoveResult) {
            case ChessBoard.MoveResultE.NoRepeat:
                bRetVal = false;
                break;
            case ChessBoard.MoveResultE.TieNoMove:
                if (eMessageMode != MessageModeE.Silent) {
                    MessageBox.Show("Draw. " + strOpponent + "unable to move.");
                }
                bRetVal = true;
                break;
            case ChessBoard.MoveResultE.TieNoMatePossible:
                if (eMessageMode != MessageModeE.Silent) {
                    MessageBox.Show("Draw. Not enough pieces to make a checkmate.");
                }
                bRetVal = true;
                break;
            case ChessBoard.MoveResultE.ThreeFoldRepeat:
                if (eMessageMode != MessageModeE.Silent) {
                    MessageBox.Show("Draw. 3 times the same board.");
                }
                bRetVal = true;
                break;
            case ChessBoard.MoveResultE.FiftyRuleRepeat:
                if (eMessageMode != MessageModeE.Silent) {
                    MessageBox.Show("Draw. 50 moves without moving a pawn or eating a piece.");
                }
                bRetVal = true;
                break;
            case ChessBoard.MoveResultE.Check:
                if (eMessageMode == MessageModeE.Verbose) {
                    MessageBox.Show(strOpponent + "in check.");
                }
                bRetVal = false;
                break;
            case ChessBoard.MoveResultE.Mate:
                if (eMessageMode != MessageModeE.Silent) {
                    MessageBox.Show(strOpponent + "checkmate.");
                }
                bRetVal = true;
                break;
            default:
                bRetVal = false;
                break;
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when a move is selected from the MoveViewer
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void m_moveViewer_NewMoveSelected(object sender, MoveViewer.NewMoveSelectedEventArg e) {
            ChessBoard.MoveResultE  eResult;
            bool                    bSucceed;
            
            if (PlayingMode == PlayingModeE.PlayerAgainstPlayer) {
                eResult = m_chessCtl.SelectMove(e.NewIndex, out bSucceed);
                DisplayMessage(eResult, MessageModeE.Verbose);
                e.Cancel = !bSucceed;
            } else {
                e.Cancel = true;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the state of the commands need to be refreshed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void m_chessCtl_UpdateCmdState(object sender, EventArgs e) {
            m_lostPieceBlack.Invalidate();
            m_lostPieceWhite.Invalidate();
            SetCmdState();
        }
 
        //*********************************************************     
        //
        /// <summary>
        /// Reset the board.
        /// </summary>
        //  
        //*********************************************************     
        private void ResetBoard() {
            m_chessCtl.ResetBoard();
            SetCmdState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Determine which menu item is enabled
        /// </summary>
        //  
        //*********************************************************     
        private void SetCmdState() {
            bool    bDesignMode;            
            
            bDesignMode                                     = (PlayingMode == PlayingModeE.DesignMode);
            m_chessCtl.AutoSelection                        = !m_bSecondThreadBusy;
            newGameToolStripMenuItem.Enabled                = !(m_bSecondThreadBusy || bDesignMode);
            createAGameFromPGNToolStripMenuItem.Enabled     = !(m_bSecondThreadBusy || bDesignMode);
            loadGameToolStripMenuItem.Enabled               = !(m_bSecondThreadBusy || bDesignMode);
            toolStripButtonLoad.Enabled                     = !(m_bSecondThreadBusy || bDesignMode);
            saveGameToolStripMenuItem1.Enabled              = !(m_bSecondThreadBusy || bDesignMode);
            toolStripButtonSave.Enabled                     = !(m_bSecondThreadBusy || bDesignMode);
            quitToolStripMenuItem.Enabled                   = !m_bSecondThreadBusy;
            hintToolStripMenuItem.Enabled                   = !(m_bSecondThreadBusy || bDesignMode);
            toolStripButtonHint.Enabled                     = !(m_bSecondThreadBusy || bDesignMode);
            undoToolStripMenuItem.Enabled                   = !(m_bSecondThreadBusy || bDesignMode || m_chessCtl.UndoCount < ((m_ePlayingMode == PlayingModeE.PlayerAgainstPlayer) ? 1 : 2));
            toolStripButtonUndo.Enabled                     = !(m_bSecondThreadBusy || bDesignMode || m_chessCtl.UndoCount < ((m_ePlayingMode == PlayingModeE.PlayerAgainstPlayer) ? 1 : 2));
            redoToolStripMenuItem.Enabled                   = !(m_bSecondThreadBusy || bDesignMode || m_chessCtl.RedoCount == 0);
            toolStripButtonRedo.Enabled                     = !(m_bSecondThreadBusy || bDesignMode || m_chessCtl.RedoCount == 0);
            playerAgainstPlayerToolStripMenuItem.Enabled    = !(m_bSecondThreadBusy || bDesignMode);
            searchModeToolStripMenuItem.Enabled             = !m_bSecondThreadBusy;
            flashPieceToolStripMenuItem.Enabled             = !m_bSecondThreadBusy;
            automaticPlayToolStripMenuItem.Enabled          = !(m_bSecondThreadBusy || bDesignMode);
            fastAutomaticPlayToolStripMenuItem.Enabled      = !(m_bSecondThreadBusy || bDesignMode);
            designModeToolStripMenuItem.Enabled             = !m_bSecondThreadBusy;
            revertBoardToolStripMenuItem.Enabled            = !(m_bSecondThreadBusy || bDesignMode);
            createABookToolStripMenuItem.Enabled            = !(m_bSecondThreadBusy || bDesignMode);
            filterAPGNFileToolStripMenuItem.Enabled         = !(m_bSecondThreadBusy || bDesignMode);
            cancelPlayToolStripMenuItem.Enabled             = m_bSecondThreadBusy;
            toolStripButtonStop.Enabled                     = m_bSecondThreadBusy;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Unlock the chess board when asynchronous computing is finished
        /// </summary>
        //  
        //*********************************************************     
        private void UnlockBoard() {
            m_bSecondThreadBusy = false;
            Cursor = Cursors.Arrow;
            SetCmdState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Play the computer move found by the search.
        /// </summary>
        /// <param name="bFlash">       true to flash moving position</param>
        /// <param name="eMessageMode"> Which message to show</param>
        /// <param name="move">         Best move</param>
        /// <param name="iPermCount">   Permutation count</param>
        /// <param name="iDepth">       Depth of the search</param>
        /// <param name="iCacheHit">    Number of moves found in the translation table cache</param>
        /// <param name="stat">         Playing stat. Can be null</param>
        /// <returns>
        /// true if end of game, false if not
        /// </returns>
        //  
        //*********************************************************     
        private bool PlayComputerMove(bool bFlash, MessageModeE eMessageMode, ChessBoard.MovePosS move, int iPermCount, int iDepth, int iCacheHit, ComputerPlayingStat stat) {
            bool                        bRetVal;
            ChessBoard.MoveResultE      eResult;
            ChessBoard.PlayerColorE     eColorToPlay;
                                        
            eColorToPlay    = m_chessCtl.NextMoveColor;
            eResult         = m_chessCtl.DoMove(move,
                                                bFlash,
                                                iPermCount,
                                                iDepth,
                                                iCacheHit);
            if (stat != null) {
                stat.m_eResult = eResult;
            }
            bRetVal = DisplayMessage(eResult, eMessageMode);
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Computer play a move. Can be called asynchronously by a secondary thread.
        /// </summary>
        /// <param name="bFlash">           true to use flash when moving pieces</param>
        /// <param name="searchMode">       Search mode</param>
        //  
        //*********************************************************     
        private void PlayComputerAsync(bool bFlash, SearchEngine.SearchMode searchMode) {
            Func<bool>                      delPlayComputerMove;
            Action                          delUnlockBoard;
            Action                          delSetPlayingMode;
            ChessBoard                      chessBoard;
            ChessBoard.MovePosS             move;
            int                             iPermCount;
            int                             iCacheHit;
            int                             iMaxDepth;
            bool                            bEndOfGame;
            bool                            bMoveFound;
            bool                            bMultipleThread;

            chessBoard          = m_chessCtl.ChessBoard.Clone();
            bMultipleThread     = (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                                   searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            bMoveFound          = m_chessCtl.FindBestMove(searchMode,
                                                          chessBoard,
                                                          out move,
                                                          out iPermCount,
                                                          out iCacheHit,
                                                          out iMaxDepth);
            if (bMoveFound) {
                if (bMultipleThread) {
                    delPlayComputerMove = () => PlayComputerMove(bFlash, MessageModeE.CallEndGame, move, iPermCount, iMaxDepth, iCacheHit, null);
                    bEndOfGame          = (bool)Invoke(delPlayComputerMove);
                } else {
                    bEndOfGame          = PlayComputerMove(bFlash, MessageModeE.CallEndGame, move, iPermCount, iMaxDepth, iCacheHit, null);
                }
            } else {
                bEndOfGame = DisplayMessage(m_chessCtl.ChessBoard.CheckNextMove(), MessageModeE.CallEndGame);
            }
            if (bMultipleThread) {
                delUnlockBoard = () => UnlockBoard();
                Invoke(delUnlockBoard);
                if (bEndOfGame) {
                    delSetPlayingMode = () => SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                    Invoke(delSetPlayingMode);
                }
            } else {
                UnlockBoard();
                if (bEndOfGame) {
                    SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Computer find a best move and play it. If the book can be find in the opening book,
        /// the move is played directly. If not, the best move is found and played from a 
        /// secondary thread (if option is enabled).
        /// </summary>
        /// <param name="bFlash">           true to flash moving position</param>
        /// <param name="bSilent">          true to be silent up to the end of the game</param>
        /// <returns>
        /// true if computer is able to play, false if not
        /// </returns>
        //  
        //*********************************************************     
        private void PlayComputer(bool bFlash, bool bSilent) {
            bool    bMultipleThread;
            
            bMultipleThread = (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                               m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            StartAsyncComputing();
            if (bMultipleThread) {
                Task.Factory.StartNew(() => PlayComputerAsync(bFlash, m_searchMode));
            } else {
                PlayComputerAsync(bFlash, m_searchMode);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Let's the computer play against itself. Can be called asynchronously by a secondary thread.
        /// </summary>
        /// <param name="bFlash">           true to flash the moving piece</param>
        /// <param name="searchMode">       Search mode</param>
        //  
        //*********************************************************     
        private void PlayComputerAgainstComputerAsync(bool bFlash, SearchEngine.SearchMode searchMode) {
            bool                                        bEndOfGame;
            int                                         iCount;
            Func<ChessBoard.MovePosS,int,int,int,bool>  delPlayComputerMove = null;
            Action                                      delUnlockBoard;
            Action                                      delSetPlayingMode;
            ChessBoard                                  chessBoard;
            ChessBoard.MovePosS                         move;
            int                                         iPermCount;
            int                                         iCacheHit;
            int                                         iMaxDepth;
            bool                                        bMoveFound;
            bool                                        bMultipleThread;
            
            bMultipleThread = (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                               searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            if (bMultipleThread) {
                delPlayComputerMove = (a1,a2,a3,a4) => { return(PlayComputerMove(bFlash, MessageModeE.CallEndGame, a1, a2, a3, a4, null)); };
            }
            iCount = 0;
            do {
                chessBoard          = m_chessCtl.ChessBoard.Clone();
                bMoveFound          = m_chessCtl.FindBestMove(searchMode,
                                                              chessBoard,
                                                              out move,
                                                              out iPermCount,
                                                              out iCacheHit,
                                                              out iMaxDepth);
                if (bMoveFound) {
                    if (bMultipleThread) {
                        bEndOfGame  = (bool)Invoke(delPlayComputerMove, new object[] { move, iPermCount, iMaxDepth, iCacheHit });
                    } else {
                        bEndOfGame  = PlayComputerMove(bFlash, MessageModeE.CallEndGame, move, iPermCount, iMaxDepth, iCacheHit, null);
                    }
                } else {
                    bEndOfGame = DisplayMessage(m_chessCtl.ChessBoard.CheckNextMove(), MessageModeE.Verbose);
                }
                iCount++;
            } while (!bEndOfGame && PlayingMode == PlayingModeE.ComputerAgainstComputer && iCount < 500);
            if (PlayingMode != PlayingModeE.ComputerAgainstComputer) {
                MessageBox.Show("Automatic play canceled");
            } else {
                if (bMultipleThread) {
                    delSetPlayingMode = () => SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                    Invoke(delSetPlayingMode);
                } else {
                    SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                }
                if (iCount >= 500) {
                    MessageBox.Show("Tie!");
                }
            }
            if (bMultipleThread) {
                delUnlockBoard = () => UnlockBoard();
                Invoke(delUnlockBoard);
            } else {
                UnlockBoard();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Let's the computer play against itself
        /// </summary>
        /// <param name="bFlash">           true to flash pieces whem moving</param>
        //  
        //*********************************************************     
        private void PlayComputerAgainstComputer(bool bFlash) {
            bool    bMultipleThread;
            
            bMultipleThread     = (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                                   m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            PlayingMode         = PlayingModeE.ComputerAgainstComputer;
            StartAsyncComputing();
            if (bMultipleThread) {
                Task.Factory.StartNew(() => PlayComputerAgainstComputerAsync(bFlash, m_searchMode));
            } else {
                PlayComputerAgainstComputerAsync(bFlash, m_searchMode);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show the test result of a computer playing against a computer
        /// </summary>
        /// <param name="iGameCount">       Number of games played.</param>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="stat">             Statistic.</param>
        /// <param name="iMethod1Win">      Number of games won by method #1</param>
        /// <param name="iMethod2Win">      Number of games won by method #2</param>
        //  
        //*********************************************************     
        private void TestShowResult(int iGameCount, SearchEngine.SearchMode searchMode, ComputerPlayingStat stat, int iMethod1Win, int iMethod2Win) {
            string  strMsg;
            string  strMethod1;
            string  strMethod2;
            int     iTimeMethod1;
            int     iTimeMethod2;
            
            strMethod1      = searchMode.m_boardEvaluationWhite.Name;
            strMethod2      = searchMode.m_boardEvaluationBlack.Name;
            
            iTimeMethod1    = (stat.m_iMethod1MoveCount == 0) ? 0 : stat.m_timeSpanMethod1.Milliseconds / stat.m_iMethod1MoveCount;
            iTimeMethod2    = (stat.m_iMethod2MoveCount == 0) ? 0 : stat.m_timeSpanMethod2.Milliseconds / stat.m_iMethod2MoveCount;
            strMsg          = iGameCount.ToString() + " game(s) played.\r\n" +
                              iMethod1Win.ToString() + " win(s) for method #1 (" + strMethod1 + "). Average time = " + iMethod1Win.ToString() + " ms per move.\r\n" + 
                              iMethod2Win.ToString() + " win(s) for method #2 (" + strMethod2 + "). Average time = " + iMethod2Win.ToString() + " ms per move.\r\n" + 
                              (iGameCount - iMethod1Win - iMethod2Win).ToString() + " draw(s).";
            MessageBox.Show(strMsg);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Tests the computer playing against itself. Can be called asynchronously by a secondary thread.
        /// </summary>
        /// <param name="iGameCount">       Number of games to play.</param>
        /// <param name="searchMode">       Search mode</param>
        //  
        //*********************************************************     
        private void TestComputerAgainstComputerAsync(int iGameCount, SearchEngine.SearchMode searchMode) {
            int                                                             iCount;
            Func<ChessBoard.MovePosS,int,int,int,ComputerPlayingStat,bool>  delPlayComputerMove = null;
            Action                                                          delResetBoard = null;
            Action                                                          delUnlockBoard;
            Action                                                          delSetPlayingMode;
            Action                                                          delShowResultDel;
            ChessBoard                                                      chessBoard;
            ChessBoard.MovePosS                                             move;
            int                                                             iPermCount;
            int                                                             iCacheHit;
            int                                                             iMaxDepth;
            int                                                             iGameIndex;
            int                                                             iMethod1Win = 0;
            int                                                             iMethod2Win = 0;
            DateTime                                                        dateTime;
            bool                                                            bMoveFound;
            bool                                                            bMultipleThread;
            bool                                                            bEven;
            bool                                                            bEndOfGame;
            IBoardEvaluation                                                boardEvaluation1;
            IBoardEvaluation                                                boardEvaluation2;
            ComputerPlayingStat                                             stat;

            stat             = new ComputerPlayingStat();
            bMultipleThread  = (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                                searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            boardEvaluation1 = searchMode.m_boardEvaluationWhite;
            boardEvaluation2 = searchMode.m_boardEvaluationBlack;
            if (bMultipleThread) {
                delPlayComputerMove = (a1, a2, a3, a4, a5) => PlayComputerMove(false, MessageModeE.Silent, a1, a2, a3, a4, a5);
                delResetBoard       = () => ResetBoard();
            }
            iGameIndex = 0;
            while (iGameIndex < iGameCount && !stat.m_bUserCancel) {
                bEven = ((iGameIndex & 1) == 0);
                searchMode.m_boardEvaluationWhite   = bEven ? boardEvaluation1 : boardEvaluation2;
                searchMode.m_boardEvaluationBlack   = bEven ? boardEvaluation2 : boardEvaluation1;
                if (bMultipleThread) {
                    Invoke(delResetBoard);
                } else {
                    ResetBoard();
                }
                iCount = 0;
                do {
                    chessBoard  = m_chessCtl.ChessBoard.Clone();
                    dateTime    = DateTime.Now;
                    bMoveFound  = m_chessCtl.FindBestMove(searchMode,
                                                          chessBoard,
                                                          out move,
                                                          out iPermCount,
                                                          out iCacheHit,
                                                          out iMaxDepth);
                    if (bMoveFound) {
                        if ((m_chessCtl.NextMoveColor == ChessBoard.PlayerColorE.White && bEven) ||
                            (m_chessCtl.NextMoveColor == ChessBoard.PlayerColorE.Black && !bEven)) {
                            stat.m_timeSpanMethod1 += DateTime.Now - dateTime;
                            stat.m_iMethod1MoveCount++;
                        } else {
                            stat.m_timeSpanMethod2 += DateTime.Now - dateTime;
                            stat.m_iMethod2MoveCount++;
                        }
                        if (bMultipleThread) {
                            bEndOfGame = (bool)Invoke(delPlayComputerMove, new object[] { move, iPermCount, iMaxDepth, iCacheHit, stat } );
                        } else {
                            bEndOfGame = PlayComputerMove(false, MessageModeE.Silent, move, iPermCount, iMaxDepth, iCacheHit, stat);
                        }
                    } else {
                        bEndOfGame = true;
                    }
                    iCount++;
                } while (!bEndOfGame && PlayingMode == PlayingModeE.ComputerAgainstComputer && iCount < 250);
                if (PlayingMode != PlayingModeE.ComputerAgainstComputer) {
                    stat.m_bUserCancel = true;
                } else if (iCount < 250) {
                    if (stat.m_eResult == ChessBoard.MoveResultE.Mate) {
                        if ((m_chessCtl.NextMoveColor == ChessBoard.PlayerColorE.Black && bEven) ||
                            (m_chessCtl.NextMoveColor == ChessBoard.PlayerColorE.White && !bEven)) {
                            iMethod1Win++;
                        } else {
                            iMethod2Win++;
                        }
                    }
                }
                iGameIndex++;
            }
            searchMode.m_boardEvaluationWhite = boardEvaluation1;
            searchMode.m_boardEvaluationBlack = boardEvaluation2;
            if (bMultipleThread) {
                delSetPlayingMode   = () => SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                delUnlockBoard      = () => UnlockBoard();
                delShowResultDel    = () => TestShowResult(iGameIndex, searchMode, stat, iMethod1Win, iMethod2Win);
                Invoke(delShowResultDel);
                Invoke(delSetPlayingMode);
                Invoke(delUnlockBoard);
            } else {
                TestShowResult(iGameIndex, searchMode, stat, iMethod1Win, iMethod2Win);
                SetPlayingMode(PlayingModeE.PlayerAgainstPlayer);
                UnlockBoard();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Test the computer play against itself
        /// </summary>
        /// <param name="iGameCount">   Number of games to play</param>
        /// <param name="searchMode">   Searching mode</param>
        //  
        //*********************************************************     
        private void TestComputerAgainstComputer(int iGameCount, SearchEngine.SearchMode searchMode) {
            bool    bMultipleThread;
            
            bMultipleThread = (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                               m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            PlayingMode     = PlayingModeE.ComputerAgainstComputer;
            StartAsyncComputing();
            if (bMultipleThread) {
                Task.Factory.StartNew(() => TestComputerAgainstComputerAsync(iGameCount, searchMode));
            } else {
                TestComputerAgainstComputerAsync(iGameCount, searchMode);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Flash a hint
        /// </summary>
        /// <param name="move">         Move to show</param>
        /// <param name="iPermCount">   Permutation count</param>
        /// <param name="iDepth">       Search depth</param>
        /// <param name="iCacheHit">    Cache hit</param>
        //  
        //*********************************************************     
        private void ShowHintMove(ChessBoard.MovePosS move, int iPermCount, int iDepth, int iCacheHit) {
            ShowMoveInStatusBar(m_chessCtl.NextMoveColor, move, iPermCount, iDepth, iCacheHit);
            m_chessCtl.ShowHintMove(move);
        }       

        //*********************************************************     
        //
        /// <summary>
        /// Show a hint. Can be called asynchronously by a secondary thread.
        /// </summary>
        /// <param name="searchMode">       Search mode</param>
        //  
        //*********************************************************     
        private void ShowHintAsync(SearchEngine.SearchMode searchMode) {
            Action              delShowHintMove;
            Action              delUnlockBoard;
            ChessBoard          chessBoard;
            ChessBoard.MovePosS move;
            int                 iPermCount;
            int                 iCacheHit;
            int                 iMaxDepth;
            bool                bMoveFound;
            bool                bMultipleThread;

            chessBoard      = m_chessCtl.ChessBoard.Clone();
            bMultipleThread = (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                               searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            bMoveFound      = m_chessCtl.FindBestMove(searchMode,
                                                      chessBoard,
                                                      out move,
                                                      out iPermCount,
                                                      out iCacheHit,
                                                      out iMaxDepth);
            if (bMultipleThread) {
                if (bMoveFound) {
                    delShowHintMove = () => ShowHintMove(move, iPermCount, iMaxDepth, iCacheHit); 
                    Invoke(delShowHintMove);
                }
                delUnlockBoard = () => UnlockBoard();
                Invoke(delUnlockBoard);
            } else {
                if (bMoveFound) {
                    ShowHintMove(move, iPermCount, iMaxDepth, iCacheHit);
                }
                UnlockBoard();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show a hint
        /// </summary>
        //  
        //*********************************************************     
        private void ShowHint() {
            bool    bMultipleThread;
            
            bMultipleThread = (m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch ||
                               m_searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch);
            StartAsyncComputing();
            if (bMultipleThread) {
                Task.Factory.StartNew(() => ShowHintAsync(m_searchMode));
            } else {
                ShowHintAsync(m_searchMode);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Undo a user and computer move
        /// </summary>
        /// <param name="bPlayerAgainstComputer">   true if playing against computer</param>
        //  
        //*********************************************************     
        private void Undo(bool bPlayerAgainstComputer) {
            bool    bFlash;
            
            bFlash = flashPieceToolStripMenuItem.Checked;
            if (bPlayerAgainstComputer) {
                if (m_chessCtl.UndoCount > 1) {
                    m_chessCtl.UndoMove(bFlash);  // Computer
                    m_chessCtl.UndoMove(bFlash);  // User
                }
            } else {
                if (m_chessCtl.UndoCount != 0) {
                    m_chessCtl.UndoMove(bFlash);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Redo a user and computer move
        /// </summary>
        /// <param name="bPlayerAgainstComputer">   true if playing against computer</param>
        /// <returns>
        /// NoRepeat, FiftyRuleRepeat, ThreeFoldRepeat, Tie, Check, Mate
        /// </returns>
        //  
        //*********************************************************     
        private ChessBoard.MoveResultE RedoMove(bool bPlayerAgainstComputer) {
            ChessBoard.MoveResultE  eRetVal = ChessBoard.MoveResultE.NoRepeat;
            bool                    bFlash;
            
            bFlash = flashPieceToolStripMenuItem.Checked;
            if (m_chessCtl.RedoCount != 0) {
                eRetVal = m_chessCtl.RedoMove(bFlash);  // Computer
            }
            if (bPlayerAgainstComputer && m_chessCtl.RedoCount != 0) {
                eRetVal = m_chessCtl.RedoMove(bFlash);  // User
            }
            return(eRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Check if it's the computer time to move
        /// </summary>
        //  
        //*********************************************************     
        private void CheckIfComputerMustPlay() {
            switch(PlayingMode) {
            case PlayingModeE.ComputerAgainstComputer:
                Update();
                PlayComputerAgainstComputer(true);
                break;
            case PlayingModeE.PlayerAgainstComputer:
                if (m_chessCtl.NextMoveColor == m_eComputerPlayingColor) {
                    Update();
                    PlayComputer(flashPieceToolStripMenuItem.Checked, false);
                }
                break;
            default:
                break;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the user has selected a valid move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void m_chessCtl_MoveSelected(object sender, ChessControl.MoveSelectedEventArgs e) {
            bool                    bFlash;
            bool                    bEndOfGame;
            ChessBoard.MoveResultE  eMoveResult;
            
            bFlash      = flashPieceToolStripMenuItem.Checked;
            eMoveResult = m_chessCtl.DoMove(e.Move, bFlash, -1, 0, 0);
            bEndOfGame  = DisplayMessage(eMoveResult, MessageModeE.Verbose);
            if (!bEndOfGame) {
                CheckIfComputerMustPlay();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Toggle the design mode. In design mode, the user can create its own board
        /// </summary>
        //  
        //*********************************************************
        private void ToggleDesignMode() {
            if (PlayingMode == PlayingModeE.DesignMode) {
                PlayingMode = PlayingModeE.PlayerAgainstPlayer;
                if (frmGameParameter.AskGameParameter(this)) {
                    m_chessCtl.BoardDesignMode = false;
                    if (m_chessCtl.BoardDesignMode) {
                        PlayingMode = PlayingModeE.DesignMode;
                        MessageBox.Show("Invalid board configuration. Correct or reset.");
                    } else {
                        m_lostPieceBlack.BoardDesignMode = false;
                        panelWhiteLostPiece.Visible      = true;
                        CheckIfComputerMustPlay();
                    }
                } else {
                    PlayingMode = PlayingModeE.DesignMode;
                }
            } else {
                PlayingMode                      = PlayingModeE.DesignMode;
                m_lostPieceBlack.BoardDesignMode = true;
                panelWhiteLostPiece.Visible      = false;
                m_chessCtl.BoardDesignMode       = true;
            }
            SetCmdState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called to gets the selected piece for design mode
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void m_chessCtl_QueryPiece(object sender, ChessControl.QueryPieceEventArgs e) {
            e.Piece = m_lostPieceBlack.SelectedPiece;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called to gets the type of pawn promotion for the current move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void m_chessCtl_QueryPawnPromotionType(object sender, ChessControl.QueryPawnPromotionTypeEventArgs e) {
            frmQueryPawnPromotionType   frm;
            
            using(frm = new frmQueryPawnPromotionType(e.ValidPawnPromotion)) {
                if (frm.ShowDialog(this) == DialogResult.OK) {
                    e.PawnPromotionType = frm.PromotionType;
                } else {
                    e.PawnPromotionType = ChessBoard.MoveTypeE.Normal;
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the game need to be reinitialized
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
            if (frmGameParameter.AskGameParameter(this)) {
                ResetBoard();
                CheckIfComputerMustPlay();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show a hint to the user
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void hintToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowHint();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Undo the last move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            Undo((PlayingMode != PlayingModeE.PlayerAgainstPlayer));
        }

        //*********************************************************     
        //
        /// <summary>
        /// Redo the last undone move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void redoToolStripMenuItem_Click(object sender, EventArgs e) {
            ChessBoard.MoveResultE  eMoveResult;
            
            eMoveResult = RedoMove((PlayingMode != PlayingModeE.PlayerAgainstPlayer));
            DisplayMessage(eMoveResult, MessageModeE.Verbose);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Let the computer play against itself
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void automaticPlayToolStripMenuItem_Click(object sender, EventArgs e) {
            PlayComputerAgainstComputer(true);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Let the computer play against itself (No flash)
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void fastAutomaticPlayToolStripMenuItem_Click(object sender, EventArgs e) {
            PlayComputerAgainstComputer(false);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Close the game
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Toggle the design mode
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void designModeToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleDesignMode();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load a board
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e) {
            if (m_chessCtl.LoadFromFile()) {
                Invalidate();
                CheckIfComputerMustPlay();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Creates a game from a PGN text
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void createAGameFromPGNToolStripMenuItem_Click(object sender, EventArgs e) {
            if (m_chessCtl.CreateFromPGNText()) {
                PlayingMode = PlayingModeE.PlayerAgainstPlayer;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Save a board
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void saveGameToolStripMenuItem1_Click(object sender, EventArgs e) {
            m_chessCtl.SaveToFile();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Cancel the auto-play
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void cancelAutomaticPlayToolStripMenuItem_Click(object sender, EventArgs e) {
            if (PlayingMode == PlayingModeE.ComputerAgainstComputer) {
                PlayingMode = PlayingModeE.PlayerAgainstPlayer;
            } else {
                m_chessCtl.CancelSearch();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Toggle the player vs player mode.
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void playerAgainstPlayerToolStripMenuItem_Click(object sender, EventArgs e) {
            if (playerAgainstPlayerToolStripMenuItem.Checked) {
                PlayingMode = PlayingModeE.PlayerAgainstComputer;
                if (frmGameParameter.AskGameParameter(this)) {
                    CheckIfComputerMustPlay();
                }
            } else {
                PlayingMode = PlayingModeE.PlayerAgainstPlayer;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Revert the board so the computer play the actual user pieces
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void revertBoardToolStripMenuItem_Click(object sender, EventArgs e) {
            m_eComputerPlayingColor = (m_eComputerPlayingColor == ChessBoard.PlayerColorE.Black) ? ChessBoard.PlayerColorE.White :
                                                                                                   ChessBoard.PlayerColorE.Black;
            CheckIfComputerMustPlay();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Creates a book from a PGN file(s)
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void createABookToolStripMenuItem_Click(object sender, EventArgs e) {
            m_chessCtl.CreateBookFromFiles();
        }


        //*********************************************************     
        //
        /// <summary>
        /// Filter the content of a PGN file
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void filterAPGNFileToolStripMenuItem_Click(object sender, EventArgs e) {
             PgnUtil    pgnUtil;
             
             pgnUtil = new PgnUtil();
             pgnUtil.CreatePGNSubset();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Popup the about box
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAbout    frm;
            
            using(frm = new frmAbout()) {
                frm.ShowDialog(this);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Specifies the search mode
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void searchModeToolStripMenuItem_Click(object sender, EventArgs e) {
            frmSearchMode   frm;
            
            using(frm = new frmSearchMode(m_searchMode, m_boardEvalUtil)) {
                if (frm.ShowDialog(this) == DialogResult.OK) {
                    frm.UpdateSearchMode();
                    ShowSearchMode();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Test board evaluation routine
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void testBoardEvaluationToolStripMenuItem_Click(object sender, EventArgs e) {
            frmTestBoardEval        frm;
            SearchEngine.SearchMode searchMode;
            int                     iGameCount;
            
            using(frm = new frmTestBoardEval(m_boardEvalUtil, m_searchMode)) {
                if (frm.ShowDialog(this) == DialogResult.OK) {
                    searchMode  = frm.SearchMode;
                    iGameCount  = frm.GameCount;
                    TestComputerAgainstComputer(iGameCount, searchMode);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called each second for timer click
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        void timer1_Tick(object sender, EventArgs e) {
            GameTimer   gameTimer;
            
            gameTimer                       = m_chessCtl.GameTimer;
            toolStripLabelTimeWhite.Text    = GameTimer.GetHumanElapse(gameTimer.WhitePlayTime);
            toolStripLabelTimeBlack.Text    = GameTimer.GetHumanElapse(gameTimer.BlackPlayTime);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load a board
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonLoad_Click(object sender, EventArgs e) {
            loadGameToolStripMenuItem_Click(sender, e);
       }

        //*********************************************************     
        //
        /// <summary>
        /// Save a board
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonSave_Click(object sender, EventArgs e) {
            saveGameToolStripMenuItem1_Click(sender, e);
       }

        //*********************************************************     
        //
        /// <summary>
        /// Show a hint to the user
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonHint_Click(object sender, EventArgs e) {
            hintToolStripMenuItem_Click(sender, e);
       }

        //*********************************************************     
        //
        /// <summary>
        /// Undo the last move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonUndo_Click(object sender, EventArgs e) {
            undoToolStripMenuItem_Click(sender, e);
       }

        //*********************************************************     
        //
        /// <summary>
        /// Redo the last undone move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonRedo_Click(object sender, EventArgs e) {
            redoToolStripMenuItem_Click(sender, e);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Cancel the auto-play
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void toolStripButtonStop_Click(object sender, EventArgs e) {
            cancelAutomaticPlayToolStripMenuItem_Click(sender, e);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Toggle PGN/Move notation
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void pgnNotationToolStripMenuItem_Click(object sender, EventArgs e) {
            SrcChess.Properties.Settings   settings;
            
            m_moveViewer.DisplayMode    = (pgnNotationToolStripMenuItem.Checked) ? MoveViewer.DisplayModeE.PGN : MoveViewer.DisplayModeE.MovePos;
            settings                    = SrcChess.Properties.Settings.Default;
            settings.MoveNotation       = (m_moveViewer.DisplayMode == MoveViewer.DisplayModeE.MovePos) ? 0 : 1;
            settings.Save();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Toggle Flash piece
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void flashPieceToolStripMenuItem_Click(object sender, EventArgs e) {
            SrcChess.Properties.Settings   settings;
            
            settings            = SrcChess.Properties.Settings.Default;
            settings.FlashPiece = flashPieceToolStripMenuItem.Checked;
            settings.Save();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Choose drawing color
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void chooseColorsToolStripMenuItem_Click(object sender, EventArgs e) {
            frmPickupColor                      frm;
            Properties.Settings                 settings;
            ChessControl.ChessControlColorInfo  colorInfo;
            
            using(frm = new frmPickupColor(m_chessCtl.ColorInfo)) {
                if (frm.ShowDialog() == DialogResult.OK) {
                    colorInfo                   = frm.ColorInfo;
                    m_chessCtl.ColorInfo        = colorInfo;
                    settings                    = Properties.Settings.Default;
                    settings.WhitePieceColor    = colorInfo.m_colWhitePiece.Name;
                    settings.BlackPieceColor    = colorInfo.m_colBlackPiece.Name;
                    settings.LiteCaseColor      = colorInfo.m_colLiteCase.Name;
                    settings.DarkCaseColor      = colorInfo.m_colDarkCase.Name;
                    settings.Save();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Save the current game in PGN format
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void saveGameToPGNToolStripMenuItem_Click(object sender, EventArgs e) {
            m_chessCtl.SavePGNToFile();
        }
    }
}