using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>Form use to filter the content of a PGN file</summary>
    public partial class frmPGNFilter : Form {
        
        /// <summary>Represent an ELO range in the checked list control</summary>
        private class RangeItem {
            public int      m_iRange;
            public RangeItem(int iRange) { m_iRange = iRange; }
            public override string ToString() {
                return("Range " + m_iRange.ToString() + " - " + (m_iRange + 99).ToString());
            }
        }
        
        /// <summary>Clause use to filter PGN games</summary>
        public PgnUtil.FilterClause     m_filterClause;
        /// <summary>PGN utility class</summary>
        private PgnUtil                 m_pgnUtil;
        private Stream                  m_streamInp;

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //
        //*********************************************************     
        public frmPGNFilter() {
            InitializeComponent();
            m_filterClause = new PgnUtil.FilterClause();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="pgnUtil">          PGN utility class</param>
        /// <param name="streamInp">        Input stream containing the PGN file</param>
        /// <param name="iMinELO">          Minimum ELO in the PGN file</param>
        /// <param name="iMaxELO">          Maximum ELO in the PGN file</param>
        /// <param name="arrPlayers">       List of players found in the PGN file</param>
        /// <param name="strInpFileName">   Name of the input file.</param>
        /// <param name="iGameCount">       Number of games in the PGN file</param>
        //
        //*********************************************************     
        public frmPGNFilter(PgnUtil pgnUtil, Stream streamInp, int iMinELO, int iMaxELO, string[] arrPlayers, string strInpFileName, int iGameCount) : this() {
            m_pgnUtil   = pgnUtil;
            m_streamInp = streamInp;
            iMinELO     = iMinELO / 100 * 100;
            checkedListBoxRange.Items.Clear();
            for (int iIndex = iMinELO; iIndex < iMaxELO; iIndex += 100) {
                checkedListBoxRange.Items.Add(new RangeItem(iIndex), true);
            }
            checkedListBoxPlayers.Items.Clear();
            foreach (string strPlayer in arrPlayers) {
                checkedListBoxPlayers.Items.Add(strPlayer, true);
            }
            checkedListBoxEnding.Items.Clear();
            checkedListBoxEnding.Items.Add("White win", true);
            checkedListBoxEnding.Items.Add("Black win", true);
            checkedListBoxEnding.Items.Add("Draws", true);
            checkBoxAllRanges.Checked     = true;
            checkBoxAllPlayer.Checked     = true;
            checkBoxAllEndGame.Checked    = true;
            checkedListBoxPlayers.Enabled = false;
            checkedListBoxRange.Enabled   = false;
            checkedListBoxEnding.Enabled  = false;
            labelDesc.Text                = iGameCount.ToString() + " games found in the file '" + strInpFileName + "'";
        }

        //*********************************************************     
        //
        /// <summary>
        /// Checks or unchecks all items in a checked list control
        /// </summary>
        /// <param name="checkedListBox">   Control</param>
        /// <param name="bChecked">         true to check, false to uncheck</param>
        //
        //*********************************************************     
        private void CheckAllItems(CheckedListBox checkedListBox, bool bChecked) {
            int     iCount;
            
            checkedListBox.SuspendLayout();
            iCount = checkedListBox.Items.Count;
            for (int iIndex = 0; iIndex < iCount; iIndex++) {
                checkedListBox.SetItemChecked(iIndex, bChecked);
            }
            checkedListBox.ResumeLayout();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void butSelectAllRange_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxRange, true);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void buttonClearAllRange_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxRange, false);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void buttonSelectAllPlayers_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxPlayers, true);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void buttonClearAllPlayers_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxPlayers, false);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void buttonSelectAllEndGame_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxEnding, true);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void buttonClearAllEndGame_Click(object sender, EventArgs e) {
            CheckAllItems(checkedListBoxEnding, false);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void checkBoxAllRanges_CheckedChanged(object sender, EventArgs e) {
            checkedListBoxRange.Enabled = !checkBoxAllRanges.Checked;
            buttonClearAllRange.Enabled = !checkBoxAllRanges.Checked;
            butSelectAllRange.Enabled   = !checkBoxAllRanges.Checked;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void checkBoxAllPlayer_CheckedChanged(object sender, EventArgs e) {
            checkedListBoxPlayers.Enabled  = !checkBoxAllPlayer.Checked;
            buttonClearAllPlayers.Enabled  = !checkBoxAllPlayer.Checked;
            buttonSelectAllPlayers.Enabled = !checkBoxAllPlayer.Checked;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void checkBoxAllEndGame_CheckedChanged(object sender, EventArgs e) {
            checkedListBoxEnding.Enabled   = !checkBoxAllEndGame.Checked;
            buttonClearAllEndGame.Enabled  = !checkBoxAllEndGame.Checked;
            buttonSelectAllEndGame.Enabled = !checkBoxAllEndGame.Checked;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets and validates information coming from the user
        /// </summary>
        /// <returns>
        /// true if validation is ok, false if not
        /// </returns>
        //
        //*********************************************************     
        private bool SyncInfo() {
            bool        bRetVal = true;
            
            if (checkBoxAllRanges.Checked || checkedListBoxRange.CheckedItems.Count == checkedListBoxRange.Items.Count) {
                m_filterClause.m_bAllRanges  = true;
                m_filterClause.m_hashRanges  = null;
            } else {
                m_filterClause.m_bAllEnding = false;
                if (checkedListBoxRange.CheckedItems.Count == 0 && !checkBoxIncludeUnrated.Checked) {
                    MessageBox.Show("At least one range must be selected.");
                    bRetVal = false;
                } else {
                    m_filterClause.m_hashRanges = new Dictionary<int,int>(checkedListBoxRange.CheckedItems.Count);
                    foreach (RangeItem rangeItem in checkedListBoxRange.CheckedItems) {
                        m_filterClause.m_hashRanges.Add(rangeItem.m_iRange, 0);
                    }
                }
            }
            m_filterClause.m_bIncludesUnrated = checkBoxIncludeUnrated.Checked;
            if (checkBoxAllPlayer.Checked || checkedListBoxPlayers.CheckedItems.Count == checkedListBoxPlayers.Items.Count) {
                m_filterClause.m_bAllPlayers    = true;
                m_filterClause.m_hashPlayerList = null;
            } else {
                m_filterClause.m_bAllPlayers    = false;
                if (checkedListBoxPlayers.CheckedItems.Count == 0) {
                    MessageBox.Show("At least one player must be selected.");
                    bRetVal = false;
                } else {
                    m_filterClause.m_hashPlayerList = new Dictionary<string,string>(checkedListBoxPlayers.CheckedItems.Count);
                    foreach (string strPlayer in checkedListBoxPlayers.CheckedItems) {
                        m_filterClause.m_hashPlayerList.Add(strPlayer, null);
                    }
                }
            }
            if (checkBoxAllEndGame.Checked || checkedListBoxEnding.CheckedItems.Count == checkedListBoxEnding.Items.Count) {
                m_filterClause.m_bAllEnding            = true;
                m_filterClause.m_bEndingWhiteWinning   = true;
                m_filterClause.m_bEndingBlackWinning   = true;
                m_filterClause.m_bEndingDraws          = true;
            } else {
                m_filterClause.m_bAllEnding            = false;
                if (checkedListBoxEnding.CheckedItems.Count == 0) {
                    MessageBox.Show("At least one ending must be selected.");
                    bRetVal = false;
                } else {
                    m_filterClause.m_bEndingWhiteWinning   = checkedListBoxEnding.GetItemChecked(0);
                    m_filterClause.m_bEndingBlackWinning   = checkedListBoxEnding.GetItemChecked(1);
                    m_filterClause.m_bEndingDraws          = checkedListBoxEnding.GetItemChecked(2);
                }
            }
            if (m_filterClause.m_bAllRanges &&
                m_filterClause.m_bAllPlayers &&
                m_filterClause.m_bAllEnding &&
                m_filterClause.m_bIncludesUnrated) {
                MessageBox.Show("At least one filtering option must be selected.");
                bRetVal = false;
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Clause use to filter the PGN file has defined by the user. Valid after the Ok button has been clicked.
        /// </summary>
        //
        //*********************************************************     
        public PgnUtil.FilterClause FilteringClause {
            get {
                return(m_filterClause);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the Ok button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void butOk_Click(object sender, EventArgs e) {
            if (SyncInfo()) {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the Ok button is clicked
        /// </summary>
        /// <param name="sender">           Sender object</param>
        /// <param name="e">                Event argument</param>
        //
        //*********************************************************     
        private void butTest_Click(object sender, EventArgs e) {
            int     iCount;
            
            if (SyncInfo()) {
                iCount = m_pgnUtil.FilterPGN(m_streamInp, null, FilteringClause);
                MessageBox.Show("The specified filter will result in " + iCount.ToString() + " game(s) selected.");
            }
        }
    }
}