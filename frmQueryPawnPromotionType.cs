using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>Query the promotion type of a pawn</summary>
    public partial class frmQueryPawnPromotionType : Form {
        private ChessBoard.ValidPawnPromotionE  m_eValidPawnPromotion;

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmQueryPawnPromotionType() {
            InitializeComponent();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="eValidPawnPromotion">  The valid pawn promotion type</param>
        //  
        //*********************************************************     
        public frmQueryPawnPromotionType(ChessBoard.ValidPawnPromotionE eValidPawnPromotion) : this() {
            m_eValidPawnPromotion = eValidPawnPromotion;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the pawn promotion type
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        //  
        //*********************************************************     
        private void frmQueryPawnPromotionType_Load(object sender, EventArgs e) {
            radioButtonQueen.Enabled    = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Queen)  != ChessBoard.ValidPawnPromotionE.None);
            radioButtonRook.Enabled     = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Rook)   != ChessBoard.ValidPawnPromotionE.None);
            radioButtonBishop.Enabled   = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Bishop) != ChessBoard.ValidPawnPromotionE.None);
            radioButtonKnight.Enabled   = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Knight) != ChessBoard.ValidPawnPromotionE.None);
            radioButtonPawn.Enabled     = ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Pawn)   != ChessBoard.ValidPawnPromotionE.None);
            if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Queen)  != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonQueen.Checked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Rook)   != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonRook.Checked  = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Bishop) != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonBishop.Checked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Knight) != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonKnight.Checked = true;
            } else if ((m_eValidPawnPromotion & ChessBoard.ValidPawnPromotionE.Pawn)   != ChessBoard.ValidPawnPromotionE.None) {
                radioButtonPawn.Checked = true;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the pawn promotion type
        /// </summary>
        //  
        //*********************************************************     
        public ChessBoard.MoveTypeE PromotionType {
            get {
                ChessBoard.MoveTypeE    eRetVal;
                
                if (radioButtonRook.Checked) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToRook;
                } else if (radioButtonBishop.Checked) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToBishop;
                } else if (radioButtonKnight.Checked) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToKnight;
                } else if (radioButtonPawn.Checked) {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToPawn;
                } else {
                    eRetVal = ChessBoard.MoveTypeE.PawnPromotionToQueen;
                }
                return(eRetVal);
            }
        }
    }
}