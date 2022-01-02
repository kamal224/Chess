using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {

    //*********************************************************     
    //
    /// <summary>
    /// Creates a game from a PGN text.
    /// </summary>
    //
    //*********************************************************     
    public partial class frmCreatePGNGame : Form {
        private List<ChessBoard.MovePosS>   m_arrMoveList;
        private ChessBoard.PlayerColorE     m_eStartingColor;
        private ChessBoard                  m_chessBoardStarting;
        private string                      m_strWhitePlayerName;
        private string                      m_strBlackPlayerName;
        private PgnParser.PlayerTypeE       m_eWhiteType;
        private PgnParser.PlayerTypeE       m_eBlackType;
        private TimeSpan                    m_spanWhitePlayer;
        private TimeSpan                    m_spanBlackPlayer;

        //*********************************************************     
        //
        /// <summary>
        /// Default constructor
        /// </summary>
        //
        //*********************************************************     
        public frmCreatePGNGame() {
            InitializeComponent();
            m_arrMoveList           = null;
            m_eStartingColor        = ChessBoard.PlayerColorE.White;
            m_chessBoardStarting    = null;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Accept the content of the form
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        //
        //*********************************************************     
        private void butOk_Click(object sender, EventArgs e) {
            string                      strGame;
            PgnParser                   parser;
            List<ChessBoard.MovePosS>   listGame;
            int                         iSkip;
            int                         iTruncated;
            
            strGame = textBox1.Text;
            if (String.IsNullOrEmpty(strGame)) {
                MessageBox.Show("No PGN text has been pasted.");
            } else {
                listGame    = new List<ChessBoard.MovePosS>(256);
                parser      = new PgnParser(false);
                if (!parser.ParseSingle(strGame,
                                        false,
                                        listGame,
                                        out iSkip,
                                        out iTruncated,
                                        out m_chessBoardStarting,
                                        out m_eStartingColor,
                                        out m_strWhitePlayerName,
                                        out m_strBlackPlayerName,
                                        out m_eWhiteType,
                                        out m_eBlackType,
                                        out m_spanWhitePlayer,
                                        out m_spanBlackPlayer)) {
                    MessageBox.Show("The specified board is invalid.");
                } else if (iSkip != 0) {
                    MessageBox.Show("The game is incomplete. Paste another game.");
                } else if (iTruncated != 0) {
                    MessageBox.Show("The selected game includes an unsupported pawn promotion (only pawn promotion to queen is supported).");
                } else if (listGame.Count == 0 && m_chessBoardStarting == null) {
                    MessageBox.Show("Game is empty.");
                } else {
                    m_arrMoveList = listGame;
                    DialogResult  = DialogResult.OK;
                    Close();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// List of moves for the current game
        /// </summary>
        //
        //*********************************************************     
        public List<ChessBoard.MovePosS> MoveList {
            get {
                return(m_arrMoveList);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Starting board. Null if standard board
        /// </summary>
        //
        //*********************************************************     
        public ChessBoard StartingChessBoard {
            get {
                return(m_chessBoardStarting);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Starting color
        /// </summary>
        //
        //*********************************************************     
        public ChessBoard.PlayerColorE StartingColor {
            get {
                return(m_eStartingColor);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// White Player Name
        /// </summary>
        //
        //*********************************************************     
        public string WhitePlayerName {
            get {
                return(m_strWhitePlayerName);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Black Player Name
        /// </summary>
        //
        //*********************************************************     
        public string BlackPlayerName {
            get {
                return(m_strBlackPlayerName);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// White Player Type
        /// </summary>
        //
        //*********************************************************     
        public PgnParser.PlayerTypeE WhitePlayerType {
            get {
                return(m_eWhiteType);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Black Player Type
        /// </summary>
        //
        //*********************************************************     
        public PgnParser.PlayerTypeE BlackPlayerType {
            get {
                return(m_eBlackType);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// White Timer
        /// </summary>
        //
        //*********************************************************     
        public TimeSpan WhiteTimer {
            get {
                return(m_spanWhitePlayer);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Black Timer
        /// </summary>
        //
        //*********************************************************     
        public TimeSpan BlackTimer {
            get {
                return(m_spanBlackPlayer);
            }
        }
    }
}