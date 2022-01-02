using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>Pickup the colors use to draw the chess control</summary>
    public partial class frmPickupColor : Form {
        private ChessControl                        m_chessCtl;
        private ChessControl.ChessControlColorInfo  m_colorInfo;

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmPickupColor() {
            InitializeComponent();
            m_chessCtl                          = new ChessControl();
            m_chessCtl.Location                 = new Point(0, 0);
            m_chessCtl.Size                     = panel1.Size;
            panel1.Controls.Add(m_chessCtl);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="colorInfo">    Color info</param>
        //  
        //*********************************************************     
        public frmPickupColor(ChessControl.ChessControlColorInfo colorInfo) {
            InitializeComponent();
            m_chessCtl                          = new ChessControl();
            m_chessCtl.Location                 = new Point(0, 0);
            m_chessCtl.Size                     = panel1.Size;
            m_chessCtl.ColorInfo                = colorInfo;
            m_colorInfo                         = colorInfo;
            panel1.Controls.Add(m_chessCtl);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Chess control color information
        /// </summary>
        //  
        //*********************************************************     
        public ChessControl.ChessControlColorInfo ColorInfo {
            get {
                return(m_colorInfo);
            }
            set {
                m_colorInfo = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when form is loaded
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void frmPickupColor_Load(object sender, EventArgs e) {
            butWhitePieceColor.BackColor = m_colorInfo.m_colWhitePiece;
            butBlackPieceColor.BackColor = m_colorInfo.m_colBlackPiece;
            butLiteSquareColor.BackColor = m_colorInfo.m_colLiteCase;
            butDarkSquareColor.BackColor = m_colorInfo.m_colDarkCase;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the white piece color button is pressed.
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void butWhitePieceColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = m_colorInfo.m_colWhitePiece;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK) {
                m_colorInfo.m_colWhitePiece     = colorDialog1.Color;
                butWhitePieceColor.BackColor    = colorDialog1.Color;
                m_chessCtl.ColorInfo            = m_colorInfo;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the black piece color button is pressed.
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void butBlackPieceColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = m_colorInfo.m_colBlackPiece;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK) {
                m_colorInfo.m_colBlackPiece     = colorDialog1.Color;
                butBlackPieceColor.BackColor    = colorDialog1.Color;
                m_chessCtl.ColorInfo            = m_colorInfo;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the lite square color button is pressed.
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void butLiteSquareColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = m_colorInfo.m_colLiteCase;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK) {
                m_colorInfo.m_colLiteCase       = colorDialog1.Color;
                butLiteSquareColor.BackColor    = colorDialog1.Color;
                m_chessCtl.ColorInfo            = m_colorInfo;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the dark square color button is pressed.
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void butDarkSquareColor_Click(object sender, EventArgs e) {
            colorDialog1.Color = m_colorInfo.m_colDarkCase;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK) {
                m_colorInfo.m_colDarkCase       = colorDialog1.Color;
                butDarkSquareColor.BackColor    = colorDialog1.Color;
                m_chessCtl.ColorInfo            = m_colorInfo;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the reset to default button is pressed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event handler</param>
        //  
        //*********************************************************     
        private void butResetToDefault_Click(object sender, EventArgs e) {
            m_colorInfo.m_colLiteCase       = Color.DarkGray;
            butLiteSquareColor.BackColor    = Color.DarkGray;
            m_colorInfo.m_colDarkCase       = Color.DarkRed;
            butDarkSquareColor.BackColor    = Color.DarkRed;
            m_colorInfo.m_colBlackPiece     = Color.Black;
            butBlackPieceColor.BackColor    = Color.Black;
            m_colorInfo.m_colWhitePiece     = Color.FromArgb(235, 235, 235);
            butWhitePieceColor.BackColor    = Color.FromArgb(235, 235, 235);
            m_chessCtl.ColorInfo            = m_colorInfo;
        }
    }
}