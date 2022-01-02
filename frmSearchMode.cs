using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>
    /// Enter the search mode
    /// </summary>
    public partial class frmSearchMode : Form {
        /// <summary>Source search mode object</summary>
        private SearchEngine.SearchMode m_searchMode;
        /// <summary>Board evaluation utility class</summary>
        private BoardEvaluationUtil     m_boardEvalUtil;

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmSearchMode() {
            InitializeComponent();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        internal frmSearchMode(SearchEngine.SearchMode searchMode, BoardEvaluationUtil boardEvalUtil) : this() {
            int     iPos;
            
            m_searchMode    = searchMode;
            m_boardEvalUtil = boardEvalUtil;
            foreach (IBoardEvaluation boardEval in m_boardEvalUtil.BoardEvaluators) {
                iPos = comboBoxWhiteBEval.Items.Add(boardEval.Name);
                if (searchMode.m_boardEvaluationWhite == boardEval) {
                    comboBoxWhiteBEval.SelectedIndex = iPos;
                }
                iPos = comboBoxBlackBEval.Items.Add(boardEval.Name);
                if (searchMode.m_boardEvaluationBlack == boardEval) {
                    comboBoxBlackBEval.SelectedIndex = iPos;
                }
            }
            checkBoxTransTable.Checked = ((searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseTransTable) != 0);
            if (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch) {
                radioButtonOnePerProc.Checked   = true;
            } else if (searchMode.m_eThreadingMode == SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch) {
                radioButtonOneForUI.Checked     = true;
            } else {
                radioButtonNoThread.Checked     = true;
            }
            checkBoxBookOpening.Checked     = ((searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseBook) != 0);
            if ((searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseAlphaBeta) != 0) {
                radioButtonAlphaBeta.Checked    = true;
            } else {
                radioButtonMinMax.Checked       = true;
                checkBoxTransTable.Enabled      = false;
            }
            if (searchMode.m_iSearchDepth == 0) {
                radioButtonAvgTime.Checked = true;
                textBoxTimeInSec.Text      = searchMode.m_iTimeOutInSec.ToString();
                plyCount.Value             = 6;
            } else {
                if ((searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch) == SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch) {
                    radioButtonFixDepthIterative.Checked = true;
                } else {
                    radioButtonFixDepth.Checked = true;
                }
                plyCount.Value              = searchMode.m_iSearchDepth;
                textBoxTimeInSec.Text       = "15";
            }
            switch(searchMode.m_eRandomMode) {
            case SearchEngine.SearchMode.RandomModeE.Off:
                radioButtonRndOff.Checked   = true;
                break;
            case SearchEngine.SearchMode.RandomModeE.OnRepetitive:
                radioButtonRndOnRep.Checked = true;
                break;
            default:
                radioButtonRndOn.Checked    = true;
                break;
            }
            textBoxTransSize.Text = (TransTable.TranslationTableSize / 1000000 * 32).ToString();    // Roughly 32 bytes / entry
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when radioButtonAlphaBeta checked state has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void radioButtonAlphaBeta_CheckedChanged(object sender, EventArgs e) {
            checkBoxTransTable.Enabled = radioButtonAlphaBeta.Checked;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Set the plyCount/avgTime control state
        /// </summary>
        //  
        //*********************************************************     
        private void SetPlyAvgTimeState() {
            if (radioButtonAvgTime.Checked) {
                plyCount.Enabled           = false;
                labelNumberOfPly.Enabled   = false;
                textBoxTimeInSec.Enabled   = true;
                labelAvgTime.Enabled       = true;
            } else {
                plyCount.Enabled           = true;
                labelNumberOfPly.Enabled   = true;
                textBoxTimeInSec.Enabled   = false;
                labelAvgTime.Enabled       = false;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when radioButtonFixDepth checked state has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void radioButtonFixDepth_CheckedChanged(object sender, EventArgs e) {
            SetPlyAvgTimeState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when radioButtonFixDepthIterative checked state has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void radioButtonFixDepthIterative_CheckedChanged(object sender, EventArgs e) {
            SetPlyAvgTimeState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the time in second textbox changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void textBoxTimeInSec_TextChanged(object sender, EventArgs e) {
            int iVal;
            
            butOk.Enabled = (Int32.TryParse(textBoxTimeInSec.Text, out iVal) &&
                             iVal > 0 &&
                             iVal < 999);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the transposition table size is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void textBoxTransSize_TextChanged(object sender, EventArgs e) {
            int iVal;
            
            butOk.Enabled = (Int32.TryParse(textBoxTransSize.Text, out iVal) &&
                             iVal > 4 &&
                             iVal < 256);
        }

        //*********************************************************
        //
        /// <summary>
        /// Update the SearchMode object
        /// </summary>
        //  
        //*********************************************************
        public void UpdateSearchMode() {
            Properties.Settings settings = Properties.Settings.Default;
            int                 iTransTableSize;
            IBoardEvaluation    boardEval;
            
            settings.UseAlphaBeta           = radioButtonAlphaBeta.Checked;
            settings.UseBook                = checkBoxBookOpening.Checked;
            settings.UseTransTable          = checkBoxTransTable.Checked;
            settings.PlyCount               = (int)plyCount.Value;
            settings.AverageTime            = Int32.Parse(textBoxTimeInSec.Text);
            settings.UsePlyCount            = radioButtonFixDepth.Checked;
            settings.UsePlyCountIterative   = radioButtonFixDepthIterative.Checked;
            m_searchMode.m_eOption          = (radioButtonAlphaBeta.Checked) ? SearchEngine.SearchMode.OptionE.UseAlphaBeta :
                                                                               SearchEngine.SearchMode.OptionE.UseMinMax;
            if (checkBoxBookOpening.Checked) {
                m_searchMode.m_eOption |= SearchEngine.SearchMode.OptionE.UseBook;
            }
            if (checkBoxTransTable.Checked) {
                m_searchMode.m_eOption |= SearchEngine.SearchMode.OptionE.UseTransTable;
            }
            if (radioButtonOnePerProc.Checked) {
                m_searchMode.m_eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.OnePerProcessorForSearch;
                settings.UseThread            = 2;
            } else if (radioButtonOneForUI.Checked) {
                m_searchMode.m_eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.DifferentThreadForSearch;
                settings.UseThread            = 1;
            } else {
                m_searchMode.m_eThreadingMode = SearchEngine.SearchMode.ThreadingModeE.Off;
                settings.UseThread            = 0;
            }
            if (radioButtonAvgTime.Checked) {
                m_searchMode.m_iSearchDepth     = 0;
                m_searchMode.m_iTimeOutInSec    = Int32.Parse(textBoxTimeInSec.Text);
            } else {
                m_searchMode.m_iSearchDepth     = (int)plyCount.Value;
                m_searchMode.m_iTimeOutInSec    = 0;
                if (radioButtonFixDepthIterative.Checked) {
                    m_searchMode.m_eOption |= SearchEngine.SearchMode.OptionE.UseIterativeDepthSearch;
                }
            }
            if (radioButtonRndOff.Checked) {
                m_searchMode.m_eRandomMode  = SearchEngine.SearchMode.RandomModeE.Off;
            } else if (radioButtonRndOnRep.Checked) {
                m_searchMode.m_eRandomMode  = SearchEngine.SearchMode.RandomModeE.OnRepetitive;
            } else {
                m_searchMode.m_eRandomMode = SearchEngine.SearchMode.RandomModeE.On;
            }
            settings.RandomMode             = (int)m_searchMode.m_eRandomMode;
            iTransTableSize                 = Int32.Parse(textBoxTransSize.Text);
            settings.TransTableSize         = iTransTableSize;
            TransTable.TranslationTableSize = iTransTableSize / 32 * 1000000;
            
            boardEval = m_boardEvalUtil.FindBoardEvaluator(comboBoxWhiteBEval.SelectedItem.ToString());
            if (boardEval == null) {
                boardEval = m_boardEvalUtil.BoardEvaluators[0];
            }
            m_searchMode.m_boardEvaluationWhite = boardEval;
            settings.WhiteBoardEval             = boardEval.Name;
            boardEval = m_boardEvalUtil.FindBoardEvaluator(comboBoxBlackBEval.SelectedItem.ToString());
            if (boardEval == null) {
                boardEval = m_boardEvalUtil.BoardEvaluators[0];
            }
            m_searchMode.m_boardEvaluationBlack = boardEval;
            settings.BlackBoardEval             = boardEval.Name;
            
            settings.Save();
        }
    }
}