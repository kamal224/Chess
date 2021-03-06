using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>
    /// User interface displaying the list of moves
    /// </summary>
    public partial class MoveViewer : UserControl, ChessControl.IMoveListUI {
        
        /// <summary>How the move are displayed: Move position (E2-E4) or PGN (e4)</summary>
        public enum DisplayModeE {
            /// <summary>Display move using starting-ending position</summary>
            MovePos,
            /// <summary>Use PGN notation</summary>
            PGN
        }
        
        /// <summary>Argument for the NewMoveSelected event</summary>
        public class NewMoveSelectedEventArg : System.ComponentModel.CancelEventArgs {
            /// <summary>New selected index in the list</summary>
            public int  NewIndex;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="iNewIndex">    New index</param>
            public NewMoveSelectedEventArg(int iNewIndex) : base(false) {
                NewIndex = iNewIndex;
            }
        }
        
        /// <summary>Delegates for the NewMoveSelected event</summary>
        public delegate void                                    NewMoveSelectedHandler(object sender, NewMoveSelectedEventArg e);
        /// <summary>Called when a move has been selected by the control</summary>
        public event NewMoveSelectedHandler                     NewMoveSelected;
        private ChessBoard                                      m_chessBoard;
        private DisplayModeE                                    m_eDisplayMode;
        private bool                                            m_bIgnoreChg;

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        public MoveViewer() {
            InitializeComponent();
            listViewMoveList.SelectedIndexChanged += new EventHandler(listViewMoveList_SelectedIndexChanged);
            m_chessBoard        = null;
            m_eDisplayMode      = DisplayModeE.MovePos;
            m_bIgnoreChg        = false;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the description of a move
        /// </summary>
        /// <param name="movePos">  Move to describe</param>
        /// <returns>
        /// Move description
        /// </returns>
        //  
        //*********************************************************     
        private string GetMoveDesc(ChessBoard.MovePosS movePos) {
            string  strRetVal;
            
            if (m_eDisplayMode == DisplayModeE.MovePos) {
                strRetVal = ChessBoard.GetHumanPos(movePos);
            } else {
                strRetVal = PgnUtil.GetPGNMoveFromMove(m_chessBoard, movePos, false);
                if ((movePos.Type & ChessBoard.MoveTypeE.MoveFromBook) == ChessBoard.MoveTypeE.MoveFromBook) {
                    strRetVal = "(" + strRetVal + ")";
                }
            }
            return(strRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Redisplay all the moves using the current setting
        /// </summary>
        //  
        //*********************************************************     
        private void Redisplay() {
            string[]                arrMoveName;
            int                     iMoveCount;
            MovePosStack            movePosStack;
            ChessBoard.MovePosS     movePos;
            string                  strMove;
            string                  strMoveIndex;
            
            if (m_chessBoard != null) {
                movePosStack    = m_chessBoard.MovePosStack;
                iMoveCount      = movePosStack.Count;
                if (iMoveCount != 0) {
                    if (m_eDisplayMode == DisplayModeE.MovePos) {
                        arrMoveName = null;
                    } else {
                        arrMoveName = PgnUtil.GetPGNArrayFromMoveList(m_chessBoard);
                    }
                    listViewMoveList.SuspendLayout();
                    for (int iIndex = 0; iIndex < iMoveCount; iIndex++) {
                        movePos = movePosStack[iIndex];
                        if (m_eDisplayMode == DisplayModeE.MovePos) {
                            strMove         = ChessBoard.GetHumanPos(movePos);
                            strMoveIndex    = (iIndex + 1).ToString();
                        } else {
                            strMove         = arrMoveName[iIndex];
                            strMoveIndex    = (iIndex / 2 + 1).ToString() + ((Char)('a' + (iIndex & 1))).ToString();
                        }
                        listViewMoveList.Items[iIndex].Text             = strMoveIndex;
                        listViewMoveList.Items[iIndex].SubItems[2].Text = strMove;
                    }
                    listViewMoveList.ResumeLayout();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Add the current move of the board
        /// </summary>
        //  
        //*********************************************************     
        private void AddCurrentMove() {
            ListViewItem            item;
            string                  strMove;
            string                  strMoveIndex;
            int                     iMoveCount;
            int                     iItemCount;
            int                     iIndex;
            ChessBoard.MovePosS     movePos;
            ChessBoard.PlayerColorE ePlayerToMove;
                        
            m_bIgnoreChg    = true;
            movePos         = m_chessBoard.MovePosStack.CurrentMove;
            ePlayerToMove   = m_chessBoard.CurrentMoveColor;
            m_chessBoard.UndoMove();
            iMoveCount      = m_chessBoard.MovePosStack.Count;
            iItemCount      = listViewMoveList.Items.Count;
            while (iItemCount >= iMoveCount) {
                iItemCount--;
                listViewMoveList.Items.RemoveAt(iItemCount);
            }
            strMove = GetMoveDesc(movePos);
            m_chessBoard.RedoMove();
            iIndex       = iItemCount;
            strMoveIndex = (m_eDisplayMode == DisplayModeE.MovePos) ? (iIndex + 1).ToString() : (iIndex / 2 + 1).ToString() + ((Char)('a' + (iIndex & 1))).ToString();
            item = listViewMoveList.Items.Add(strMoveIndex);
            item.SubItems.Add((ePlayerToMove == ChessBoard.PlayerColorE.Black) ? "Black" : "White");
            item.SubItems.Add(strMove);
            m_bIgnoreChg    = false;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Select the current move
        /// </summary>
        //  
        //*********************************************************     
        private void SelectCurrentMove() {
            int             iIndex;
            ListViewItem    item;
            
            m_bIgnoreChg = true;
            iIndex       = m_chessBoard.MovePosStack.PositionInList;
            if (iIndex == -1) {
                listViewMoveList.SelectedItems.Clear();
            } else {
                item            = listViewMoveList.Items[iIndex];
                item.Selected   = true;
                item.EnsureVisible();
            }
            m_bIgnoreChg = false;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Display Mode (Position or PGN)
        /// </summary>
        //  
        //*********************************************************     
        public DisplayModeE DisplayMode {
            get {
                return(m_eDisplayMode);
            }
            set {
                if (value != m_eDisplayMode) {
                    m_eDisplayMode = value;
                    Redisplay();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Reset the control so it represents the specified chessboard
        /// </summary>
        /// <param name="chessBoard">   Chess board. Starting one if null</param>
        //  
        //*********************************************************     
        public void Reset(ChessBoard chessBoard) {
            int     iCurPos;
            int     iCount;
            
            listViewMoveList.Items.Clear();
            m_chessBoard    = chessBoard;
            iCurPos         = chessBoard.MovePosStack.PositionInList;
            iCount          = chessBoard.MovePosStack.Count;
            chessBoard.UndoAllMoves();
            for (int iIndex = 0; iIndex < iCount; iIndex++) {
                chessBoard.RedoMove();
                AddCurrentMove();
            }
            SelectCurrentMove();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when a new move has been done
        /// </summary>
        /// <param name="iPermCount">   Permutation analyzed. 0 for none. -1 for book</param>
        /// <param name="iDepth">       Depth of the search, -1 if none.</param>
        /// <param name="iCacheHit">    Nb of permutation found in the translation table</param>
        //  
        //*********************************************************     
        public void NewMoveDone(int iPermCount, int iDepth, int iCacheHit) {
            AddCurrentMove();
            SelectCurrentMove();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when position of the redo buffer changed
        /// </summary>
        //  
        //*********************************************************     
        public void RedoPosChanged() {
            SelectCurrentMove();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Trigger the NewMoveSelected argument
        /// </summary>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        protected void OnNewMoveSelected(NewMoveSelectedEventArg e) {
            if (NewMoveSelected != null) {
                NewMoveSelected(this, e);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the user select a move
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        void listViewMoveList_SelectedIndexChanged(object sender, EventArgs e) {
            NewMoveSelectedEventArg evArg;
            int                     iCurPos;
            int                     iNewPos;
            
            if (!m_bIgnoreChg) {
                m_bIgnoreChg = true;
                iCurPos = m_chessBoard.MovePosStack.PositionInList;
                if (listViewMoveList.SelectedIndices.Count != 0) {
                    iNewPos = listViewMoveList.SelectedIndices[0];
                    if (iNewPos != iCurPos) {
                        evArg = new NewMoveSelectedEventArg(iNewPos);
                        OnNewMoveSelected(evArg);
                        if (evArg.Cancel) {
                            if (iCurPos == -1) {
                                listViewMoveList.SelectedItems.Clear();
                            } else {
                                listViewMoveList.Items[iCurPos].Selected = true;
                            }
                        }
                    }
                }
                m_bIgnoreChg = false;
            }
        }
    }
}
