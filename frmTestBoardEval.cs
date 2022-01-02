using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>Enter parameters for testing the board evaluation functions</summary>
    public partial class frmTestBoardEval : Form {
        /// <summary>Board evaluation utility</summary>
        BoardEvaluationUtil     m_boardEvalUtil;
        /// <summary>Resulting search mode</summary>
        SearchEngine.SearchMode m_searchMode;

        //*********************************************************     
        //
        /// <summary>
        /// Form constructor
        /// </summary>
        //  
        //*********************************************************     
        public frmTestBoardEval() {
            InitializeComponent();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Form constructor
        /// </summary>
        /// <param name="boardEvalUtil">        Board evaluation utility class</param>
        /// <param name="searchModeTemplate">   Search mode template</param>
        //  
        //*********************************************************     
        public frmTestBoardEval(BoardEvaluationUtil boardEvalUtil, SearchEngine.SearchMode searchModeTemplate) : this() {
            m_searchMode        = new SearchEngine.SearchMode(boardEvalUtil.BoardEvaluators[0],
                                                              boardEvalUtil.BoardEvaluators[0],
                                                              SearchEngine.SearchMode.OptionE.UseAlphaBeta,
                                                              searchModeTemplate.m_eThreadingMode,
                                                              4,
                                                              0,
                                                              searchModeTemplate.m_eRandomMode);
            foreach (IBoardEvaluation boardEval in boardEvalUtil.BoardEvaluators) {
                comboBoxWhiteBEval.Items.Add(boardEval.Name);
                comboBoxBlackBEval.Items.Add(boardEval.Name);
            }
            comboBoxWhiteBEval.SelectedIndex = 0;
            comboBoxBlackBEval.SelectedIndex = (comboBoxBlackBEval.Items.Count == 0) ? 0 : 1;
            m_boardEvalUtil     = boardEvalUtil;
            SetButtonState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the search mode
        /// </summary>
        //  
        //*********************************************************     
        public SearchEngine.SearchMode SearchMode {
            get {
                IBoardEvaluation    boardEval;
                
                boardEval = m_boardEvalUtil.FindBoardEvaluator(comboBoxWhiteBEval.SelectedItem.ToString());
                if (boardEval == null) {
                    boardEval = m_boardEvalUtil.BoardEvaluators[0];
                }
                m_searchMode.m_boardEvaluationWhite = boardEval;
                boardEval = m_boardEvalUtil.FindBoardEvaluator(comboBoxBlackBEval.SelectedItem.ToString());
                if (boardEval == null) {
                    boardEval = m_boardEvalUtil.BoardEvaluators[0];
                }
                m_searchMode.m_boardEvaluationBlack = boardEval;
                m_searchMode.m_iSearchDepth         = (int)plyCount.Value;
                return(m_searchMode);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the number of games to test
        /// </summary>
        //  
        //*********************************************************     
        public int GameCount {
            get {
                return((int)gameCount.Value);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Set the state of the buttons
        /// </summary>
        //  
        //*********************************************************     
        private void SetButtonState() {
            SearchEngine.SearchMode   searchMode;
            
            if (m_boardEvalUtil != null) {
                searchMode    = SearchMode;
                butOk.Enabled = true ; //(searchMode.m_boardEvaluationWhite != m_searchMode.m_boardEvaluationBlack);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the combo box selection is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void comboBoxWhiteBEval_SelectedIndexChanged(object sender, EventArgs e) {
            SetButtonState();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the combo box selection is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        //  
        //*********************************************************     
        private void comboBoxBlackBEval_SelectedIndexChanged(object sender, EventArgs e) {
            SetButtonState();
        }
    }
}