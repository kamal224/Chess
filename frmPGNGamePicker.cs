using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SrcChess {

    //*********************************************************     
    //
    /// <summary>
    /// Pickup a game from a PGN file.
    /// </summary>
    //
    //*********************************************************     
    public partial class frmPGNGamePicker : Form {
        private PgnUtil                     m_pgnUtil;
        private Stream                      m_streamInp;
        private List<ChessBoard.MovePosS>   m_arrMoveList;
        private string                      m_strSelectedGame;
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
        public frmPGNGamePicker() {
            InitializeComponent();
            m_pgnUtil               = new PgnUtil();
            m_strSelectedGame       = null;
            m_eStartingColor        = ChessBoard.PlayerColorE.White;
            m_chessBoardStarting    = null;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the selected game content
        /// </summary>
        /// <returns>
        /// Game or null if none selected
        /// </returns>
        //
        //*********************************************************     
        private string GetSelectedGame() {
            string                  strRetVal;
            PgnUtil.PGNGameDescItem itemDesc;
            int                     iSelectedIndex;
            
            iSelectedIndex = listBoxGames.SelectedIndex;
            if (iSelectedIndex != -1) {
                itemDesc  = listBoxGames.SelectedItem as PgnUtil.PGNGameDescItem;
                strRetVal = m_pgnUtil.GetNGame(m_streamInp, itemDesc.Index);
            } else {
                strRetVal = null;
            }
            return(strRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Refresh the textbox containing the selected game content
        /// </summary>
        //
        //*********************************************************     
        private void RefreshGameDisplay() {
            m_strSelectedGame = GetSelectedGame();
            textBoxGame.Text  = (m_strSelectedGame == null) ? "" : m_strSelectedGame;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Initialize the form with the content of the PGN file
        /// </summary>
        /// <param name="strFileName">  PGN file name</param>
        /// <returns>
        /// true if at least one game has been found.
        /// </returns>
        //
        //*********************************************************     
        public bool InitForm(string strFileName) {
            bool    bRetVal;
            
            m_streamInp = m_pgnUtil.OpenInpFile(strFileName);
            if (m_streamInp == null) {
                bRetVal = false;
            } else {
                if (m_pgnUtil.FillListBoxWithDesc(m_streamInp, listBoxGames) < 1) {
                    MessageBox.Show("No games found in the PGN File '" + strFileName + "'");
                    bRetVal = false;
                } else {
                    listBoxGames.SelectedIndex = 0;
                    bRetVal                    = true;
                }
            }
            return(bRetVal);
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
            
            strGame = GetSelectedGame();
            if (strGame != null) {
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
                    MessageBox.Show("The game is incomplete. Select another game.");
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
        /// Called when the game selection is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        //
        //*********************************************************     
        private void listBoxGames_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshGameDisplay();
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
        /// Selected game
        /// </summary>
        //
        //*********************************************************     
        public string SelectedGame {
            get {
                return(m_strSelectedGame);
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