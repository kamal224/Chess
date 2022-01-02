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
    /// Select the game parameters
    /// </summary>
    //
    //*********************************************************     
    public partial class frmGameParameter : Form {
        private frmChessBoard   m_frmFather;

        //*********************************************************     
        //
        /// <summary>
        /// Default constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmGameParameter() {
            InitializeComponent();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="frmFather">    Father form</param>
        //  
        //*********************************************************     
        private frmGameParameter(frmChessBoard frmFather) : this() {
            m_frmFather = frmFather;
            switch(m_frmFather.PlayingMode) {
            case frmChessBoard.PlayingModeE.DesignMode:
                throw new System.ApplicationException("Must not be called in design mode.");
            case frmChessBoard.PlayingModeE.PlayerAgainstComputer:
                radioButtonPlayerAgainstComputer.Checked = true;
                break;
            case frmChessBoard.PlayingModeE.PlayerAgainstPlayer:
                radioButtonPlayerAgainstPlayer.Checked = true;
                break;
            case frmChessBoard.PlayingModeE.ComputerAgainstComputer:
                radioButtonComputerAgainstComputer.Checked = true;
                break;
            }
            switch(m_frmFather.m_eComputerPlayingColor) {
            case ChessBoard.PlayerColorE.Black:
                radioButtonComputerPlayBlack.Checked = true;
                break;
            case ChessBoard.PlayerColorE.White:
                radioButtonComputerPlayWhite.Checked = true;
                break;
            }
            CheckState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Check the state of the group box
        /// </summary>
        //  
        //*********************************************************     
        private void CheckState() {
            groupBoxComputerPlay.Enabled = radioButtonPlayerAgainstComputer.Checked;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called to accept the form
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        private void butOk_Click(object sender, EventArgs e) {
            if (radioButtonPlayerAgainstComputer.Checked) {
                m_frmFather.PlayingMode = frmChessBoard.PlayingModeE.PlayerAgainstComputer;
            } else if (radioButtonPlayerAgainstPlayer.Checked) {
                m_frmFather.PlayingMode = frmChessBoard.PlayingModeE.PlayerAgainstPlayer;
            } else if (radioButtonComputerAgainstComputer.Checked) {
                m_frmFather.PlayingMode = frmChessBoard.PlayingModeE.ComputerAgainstComputer;
            }
            m_frmFather.m_eComputerPlayingColor = (radioButtonComputerPlayBlack.Checked) ? ChessBoard.PlayerColorE.Black : ChessBoard.PlayerColorE.White;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the radio button value is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        private void radioButtonPlayerAgainstComputer_CheckedChanged(object sender, EventArgs e) {
            CheckState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the radio button value is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        private void radioButtonPlayerAgainstPlayer_CheckedChanged(object sender, EventArgs e) {
            CheckState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the radio button value is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        //  
        //*********************************************************     
        private void radioButtonComputerAgainstComputer_CheckedChanged(object sender, EventArgs e) {
            CheckState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Ask for the game parameter
        /// </summary>
        /// <param name="frmFather">        Father form</param>
        /// <returns>
        /// true if succeed
        /// </returns>
        //  
        //*********************************************************     
        public static bool AskGameParameter(frmChessBoard frmFather) {
            bool                bRetVal;
            frmGameParameter    frm;
            
            frm = new frmGameParameter(frmFather);
            using(frm) {
                bRetVal = (frm.ShowDialog() == DialogResult.OK);
            }
            return(bRetVal);
        }
    }
}