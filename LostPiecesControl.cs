using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>UI control use to display lost pieces</summary>
    public partial class LostPiecesControl : UserControl {
        /// <summary>Associated chess control</summary>
        private ChessControl                m_chessCtl;
        /// <summary>Piece color displayed in this control</summary>
        private bool                        m_bColor;
        /// <summary>Color map from red to light background</summary>
        private ColorMap                    m_colorMapWhite;
        /// <summary>Array of color map from red to light background</summary>
        private ColorMap[]                  m_colorMapTblWhite;
        /// <summary>Remap red to dark background</summary>
        private ImageAttributes             m_imgAttrWhite;
        /// <summary>true if in design mode. In design mode, One of each possible pieces is shown and one can be selected.</summary>
        private bool                        m_bDesignMode;
        /// <summary>Piece currently selected in design mode.</summary>
        private int                         m_iSelectedPiece;

        //*********************************************************     
        //
        /// <summary>
        /// Control ctor
        /// </summary>
        //  
        //*********************************************************     
        public LostPiecesControl() {
            InitializeComponent();
            m_colorMapWhite             = new ColorMap();
            m_colorMapWhite.OldColor    = System.Drawing.Color.FromArgb(255, 255, 0, 0);
            m_colorMapWhite.NewColor    = System.Drawing.Color.FromArgb(255, System.Drawing.Color.White);
            m_colorMapTblWhite          = new ColorMap[] { m_colorMapWhite };
            m_imgAttrWhite              = new ImageAttributes();
            m_bDesignMode               = false;
            m_imgAttrWhite.SetRemapTable(m_colorMapTblWhite);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Enum the eated pieces
        /// </summary>
        /// <returns>
        /// List of eated pieces
        /// </returns>
        //  
        //*********************************************************     
        private ChessBoard.PieceE[] EnumPiece() {
            List<ChessBoard.PieceE> arrPieces;
            ChessBoard.PieceE[]     arrPossiblePiece;
            ChessBoard.PieceE       ePiece;
            int                     iEated;
            
            arrPossiblePiece = new ChessBoard.PieceE[] { ChessBoard.PieceE.King,
                                                         ChessBoard.PieceE.Queen,
                                                         ChessBoard.PieceE.Rook,
                                                         ChessBoard.PieceE.Bishop,
                                                         ChessBoard.PieceE.Knight,
                                                         ChessBoard.PieceE.Pawn };
            arrPieces = new List<ChessBoard.PieceE>(16);
            if (m_bDesignMode) {
                arrPieces.Add(ChessBoard.PieceE.None);
            }
            foreach (ChessBoard.PieceE ePossiblePiece in arrPossiblePiece) {
                if (m_bDesignMode) {
                    ePiece  = ePossiblePiece;
                    arrPieces.Add(ePiece);
                    ePiece |= ChessBoard.PieceE.Black;
                    arrPieces.Add(ePiece);
                } else {                    
                    ePiece = ePossiblePiece;
                    if (m_bColor) {
                        ePiece |= ChessBoard.PieceE.Black;
                    }
                    iEated = m_chessCtl.ChessBoard.GetEatedPieceCount(ePiece);
                    for (int iIndex = 0; iIndex < iEated; iIndex++) {
                        arrPieces.Add(ePiece);
                    }
                }
            }
            return(arrPieces.ToArray());
        }

        //*********************************************************     
        //
        /// <summary>
        /// Paint the control
        /// </summary>
        //  
        //*********************************************************     
        protected override void OnPaint(PaintEventArgs e) {
            ChessBoard.PieceE[] arrPiece;
            int                 iSquareSize;
            int                 iXPos;
            int                 iYPos;
            int                 iPiece;
            int                 iPieceIndex;
            int                 iIndex;
            Rectangle           tRectBmp;
            bool                bPieceBlack;
            
            base.OnPaint(e);
            if (m_chessCtl != null) {
                iSquareSize = Height;
                if (Width < iSquareSize) {
                    iSquareSize = Width;
                }
                iSquareSize /= 4;
                arrPiece     = EnumPiece();
                iIndex       = 0;
                foreach (ChessBoard.PieceE ePiece in arrPiece) {
                    iXPos           = iIndex & 3;
                    iYPos           = iIndex >> 2;
                    tRectBmp        = new Rectangle(iXPos * iSquareSize,
                                                    iYPos * iSquareSize,
                                                    iSquareSize,
                                                    iSquareSize);
                    if (ePiece != ChessBoard.PieceE.None) {
                        iPiece          = (int)(ePiece & ChessBoard.PieceE.PieceMask);
                        bPieceBlack     = ((ePiece & ChessBoard.PieceE.Black) != 0);
                        iPieceIndex     = (iPiece - 1) * 2 + ((bPieceBlack) ? 1 : 0);
                        e.Graphics.DrawImage(m_chessCtl.imageListPieces.Images[iPieceIndex],
                                             tRectBmp,
                                             0,
                                             0,
                                             50,
                                             50,GraphicsUnit.Pixel,
                                             m_imgAttrWhite);
                    }
                    if (iIndex == m_iSelectedPiece && m_bDesignMode) {
                        tRectBmp.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(Pens.Black, tRectBmp);
                        tRectBmp.Inflate(1, 1);
                    }                                         
                    iIndex++;                                         
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Chess control associated with this control
        /// </summary>
        //  
        //*********************************************************     
        public ChessControl ChessControl {
            get {
                return(m_chessCtl);
            }
            set {
                m_chessCtl = value;
                Invalidate();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Color being displayed. false = White, true = Black
        /// </summary>
        //  
        //*********************************************************     
        public bool Color {
            get {
                return(m_bColor);
            }
            set {
                m_bColor = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Select a piece (in design mode only)
        /// </summary>
        //  
        //*********************************************************     
        public int SelectedIndex {
            get {
                return(m_iSelectedPiece);
            }
            set {
                if (m_iSelectedPiece != value) {
                    if (value >= 0 && value < 13) {
                        m_iSelectedPiece = value;
                        Invalidate();
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the currently selected piece
        /// </summary>
        //  
        //*********************************************************
        public ChessBoard.PieceE SelectedPiece {
            get {
                ChessBoard.PieceE   eRetVal = ChessBoard.PieceE.None;
                int                 iSelectedIndex;
                
                iSelectedIndex = SelectedIndex;
                if (iSelectedIndex > 0 && iSelectedIndex < 13) {
                    iSelectedIndex--;
                    if ((iSelectedIndex & 1) != 0) {
                        eRetVal |= ChessBoard.PieceE.Black;
                    }
                    iSelectedIndex >>= 1;
                    switch(iSelectedIndex) {
                    case 0:
                        eRetVal |= ChessBoard.PieceE.King;
                        break;
                    case 1:
                        eRetVal |= ChessBoard.PieceE.Queen;
                        break;
                    case 2:
                        eRetVal |= ChessBoard.PieceE.Rook;
                        break;
                    case 3:
                        eRetVal |= ChessBoard.PieceE.Bishop;
                        break;
                    case 4:
                        eRetVal |= ChessBoard.PieceE.Knight;
                        break;
                    case 5:
                        eRetVal |= ChessBoard.PieceE.Pawn;
                        break;
                    default:
                        eRetVal = ChessBoard.PieceE.None;
                        break;
                    }
                }
                return(eRetVal);
            }
        }
        

        //*********************************************************     
        //
        /// <summary>
        /// Select the design mode
        /// </summary>
        //  
        //*********************************************************     
        public bool BoardDesignMode {
            get {
                return(m_bDesignMode);
            }
            set {
                if (m_bDesignMode != value) {
                    m_bDesignMode = value;
                    Invalidate();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Select the clicked piece in design mode
        /// </summary>
        /// <param name="e">    Event argument</param>
        //  
        //*********************************************************     
        protected override void OnMouseUp(MouseEventArgs e) {
            int     iSquareSize;
            int     iRowPos;
            int     iColPos;
            int     iPos;
            
            base.OnMouseUp(e);
            if (m_bDesignMode) {
                iSquareSize = Height;
                if (Width < iSquareSize) {
                    iSquareSize = Width;
                }
                iSquareSize /= 4;
                iRowPos      = e.Y / iSquareSize;
                iColPos      = e.X / iSquareSize;
                if (iRowPos < 4 && iColPos < 4) {
                    iPos          = (iRowPos << 2) + iColPos;
                    SelectedIndex = (iPos < 13) ? iPos : 0; 
                }
            }
        }
    }
}
