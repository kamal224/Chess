using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SrcChess {
    /// <summary>Chess Control. This UI control implements the chess board interface.</summary>
    public partial class ChessControl : UserControl, SearchEngine.ITrace {
        
        /// <summary>
        /// Interface implemented by the UI which show the move list.
        /// This interface is called by the chess control each time a move has to be updated.
        /// </summary>
        public interface IMoveListUI {
            /// <summary>Removes all move</summary>
            void        Reset(ChessBoard chessBoard);
            /// <summary>Append a move</summary>
            /// <param name="iPermCount">Permutation analyzed</param>
            /// <param name="iDepth">Depth of the search</param>
            /// <param name="iCacheHit">Nb of permutation found in cache</param>
            void        NewMoveDone(int iPermCount, int iDepth, int iCacheHit);
            /// <summary>Called when the position in the redo buffer has changed</summary>
            void        RedoPosChanged();
        }

        /// <summary>Color of elements use to draw the control</summary>
        public struct ChessControlColorInfo {
            /// <summary>Color of the lighter case</summary>
            public Color                    m_colLiteCase;
            /// <summary>Color of the darker case</summary>
            public Color                    m_colDarkCase;
            /// <summary>Color use to draw the white piece</summary>
            public Color                    m_colWhitePiece;
            /// <summary>Color use to draw the black piece</summary>
            public Color                    m_colBlackPiece;
        }
        
        /// <summary>Brush/map/pen use to draw the board</summary>
        private struct BoardDrawingObject {
            /// <summary>Black brush</summary>
            public Brush                        m_brBlack;
            /// <summary>Brush use to draw the lite case</summary>
            public Brush                        m_brLiteCase;
            /// <summary>Brush use to draw the dark case</summary>
            public Brush                        m_brDarkCase;
            /// <summary>Pen to draw a rectangle around the selected case</summary>
            public  Pen                         m_penSelected;
            /// <summary>Color map from white to light case</summary>
            public  ColorMap                    m_colorMapWhiteToLiteCase;
            /// <summary>Color map from white to dark case</summary>
            public  ColorMap                    m_colorMapWhiteToDarkCase;
            /// <summary>Color map from red to white of piece</summary>
            public  ColorMap                    m_colorMapRedToWhitePiece;
            /// <summary>Color map from black to black of piece</summary>
            public  ColorMap                    m_colorMapBlackToBlackPiece;
            /// <summary>Array of color map from red to dark background</summary>
            public  ColorMap[]                  m_colorMapTblLiteCase;
            /// <summary>Array of color map from red to light background</summary>
            public  ColorMap[]                  m_colorMapTblDarkCase;
            /// <summary>Remap red to dark background</summary>
            public  ImageAttributes             m_imgAttrLiteCase;
            /// <summary>Remap red to light background</summary>
            public  ImageAttributes             m_imgAttrDarkCase;
        }
        
        /// <summary>
        /// Interface implemented by the UI which show the lost pieces.
        /// This interface is called each time the chess board need an update on the lost pieces UI.
        /// </summary>
        public interface IUpdateCmd {
            /// <summary>Update the lost pieces</summary>
            void        Update();
        }
        
        /// <summary>Event argument for the MoveSelected event</summary>
        public class MoveSelectedEventArgs : System.EventArgs {
            /// <summary>Move position</summary>
            public ChessBoard.MovePosS  Move;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="move">     Move position</param>
            public                      MoveSelectedEventArgs(ChessBoard.MovePosS move) { Move = move; }
        }
        /// <summary>Delegate for the MoveSelected event</summary>
        public delegate void                    MoveSelectedEventHandler(object sender, MoveSelectedEventArgs e);
        
        /// <summary>Called when a user select a valid move to be done</summary>
        public event MoveSelectedEventHandler   MoveSelected;

        /// <summary>Event argument for the QueryPiece event</summary>
        public class QueryPieceEventArgs : System.EventArgs {
            /// <summary>Position of the square</summary>
            public int                  Pos;
            /// <summary>Piece</summary>
            public ChessBoard.PieceE    Piece;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="iPos">     Position of the square</param>
            /// <param name="ePiece">   Piece</param>
            public                      QueryPieceEventArgs(int iPos, ChessBoard.PieceE ePiece) { Pos = iPos; Piece = ePiece; }
        }

        /// <summary>Delegate for the QueryPiece event</summary>
        public delegate void                    QueryPieceEventHandler(object sender, QueryPieceEventArgs e);
        
        /// <summary>Called when chess control in design mode need to know which piece to insert in the board</summary>
        public event QueryPieceEventHandler     QueryPiece;

        /// <summary>Event argument for the QueryPawnPromotionType event</summary>
        public class QueryPawnPromotionTypeEventArgs : System.EventArgs {
            /// <summary>Promotion type (Queen, Rook, Bishop, Knight or Pawn)</summary>
            public ChessBoard.MoveTypeE             PawnPromotionType;
            /// <summary>Possible pawn promotions in the current context</summary>
            public ChessBoard.ValidPawnPromotionE   ValidPawnPromotion;
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="eValidPawnPromotion">  Possible pawn promotions in the current context</param>
            public                                  QueryPawnPromotionTypeEventArgs(ChessBoard.ValidPawnPromotionE eValidPawnPromotion) { ValidPawnPromotion = eValidPawnPromotion; PawnPromotionType = ChessBoard.MoveTypeE.Normal; }
        }

        /// <summary>Delegate for the QueryPawnPromotionType event</summary>
        public delegate void                            QueryPawnPromotionTypeEventHandler(object sender, QueryPawnPromotionTypeEventArgs e);
        
        /// <summary>Called when chess control needs to know which type of pawn promotion must be done</summary>
        public event QueryPawnPromotionTypeEventHandler QueryPawnPromotionType;

        /// <summary>Called to refreshed the command state (menu, toolbar etc.)</summary>
        public event System.EventHandler                UpdateCmdState;
        

        /// <summary>Array of metafile, one for each piece</summary>
        static private Metafile[]           m_arrMetafilePiece;
        
        /// <summary>Chess board attached to the control.</summary>
        private ChessBoard                  m_board;
        /// <summary>true to have white in the bottom of the screen, false to have black</summary>
        private bool                        m_bWhiteInBottom = true;
        /// <summary>Font use to draw coordinate on the side of the control</summary>
        private Font                        m_fontCoord;
        /// <summary>Currently selected case</summary>
        private Point                       m_ptSelectedCase;
        /// <summary>true to enable auto-selection</summary>
        private bool                        m_bAutoSelection;
        /// <summary>User interface used to display the move list</summary>
        private IMoveListUI                 m_moveListUI;
        /// <summary>Time the last search was started</summary>
        private DateTime                    m_dateTimeStartSearching;
        /// <summary>Elapse time of the last search</summary>
        private TimeSpan                    m_timeSpanLastSearch;
        /// <summary>Timer for both player</summary>
        private GameTimer                   m_gameTimer;
        /// <summary>Object use to draw the board</summary>
        private BoardDrawingObject          m_drawingObject;
        /// <summary>Color use to draw the board</summary>
        private ChessControlColorInfo       m_colorInfo;
        /// <summary>Name of the player playing white piece</summary>
        private string                      m_strWhitePlayerName;
        /// <summary>Name of the player playing black piece</summary>
        private string                      m_strBlackPlayerName;
        /// <summary>Type of player playing white piece</summary>
        private PgnParser.PlayerTypeE       m_eWhitePlayerType;
        /// <summary>Type of player playing black piece</summary>
        private PgnParser.PlayerTypeE       m_eBlackPlayerType;

        //*********************************************************     
        //
        /// <summary>
        /// Static Class Constructor
        /// </summary>
        //  
        //*********************************************************     
        static ChessControl() {
            LoadPieceSet();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load an EMF image (Extended MetaFile)
        /// </summary>
        /// <param name="assem">        Assembly from which the resource must be found</param>
        /// <param name="strName">      Partial name of the resource</param>
        /// <returns>
        /// EMF Image
        /// </returns>
        //  
        //*********************************************************     
        static private Metafile LoadMetaImage(System.Reflection.Assembly assem, string strName) {
            System.Drawing.Imaging.Metafile retVal;
            System.IO.Stream                stream;
            
            stream  = assem.GetManifestResourceStream(assem.GetName().Name + "." + strName);
            retVal  = new System.Drawing.Imaging.Metafile(stream);
            stream.Close();
            return(retVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load the set of pieces in Extended Metafile Format
        /// </summary>
        //  
        //*********************************************************     
        private static void LoadPieceSet() {
            System.Reflection.Assembly  assemThis;
            
            m_arrMetafilePiece                                                              = new Metafile[16];
            assemThis                                                                       = typeof(ChessControl).Assembly;
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.King   | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_klt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.King   | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_kdt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Queen  | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_qlt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Queen  | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_qdt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Rook   | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_rlt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Rook   | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_rdt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Bishop | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_blt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Bishop | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_bdt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Knight | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_nlt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Knight | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_ndt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Pawn   | ChessBoard.PieceE.White)]   = LoadMetaImage(assemThis, "Chess_plt45.emf");
            m_arrMetafilePiece[(int)(ChessBoard.PieceE.Pawn   | ChessBoard.PieceE.Black)]   = LoadMetaImage(assemThis, "Chess_pdt45.emf");
        }

        //*********************************************************     
        //
        /// <summary>
        /// Class constructor
        /// </summary>
        //  
        //*********************************************************     
        public ChessControl() {
            m_board                     = new ChessBoard(this);
            m_board.ReadBook("book.bin");
            m_ptSelectedCase.X          = -1;
            m_ptSelectedCase.Y          = -1;
            m_bAutoSelection            = true;
            m_colorInfo.m_colLiteCase   = Color.DarkGray;
            m_colorInfo.m_colDarkCase   = Color.DarkRed;
            m_colorInfo.m_colBlackPiece = Color.Black;
            m_colorInfo.m_colWhitePiece = Color.FromArgb(235, 235, 235);
            InitializeComponent();
            m_gameTimer                 = new GameTimer();
            m_gameTimer.Enabled         = false;
            m_gameTimer.Reset(m_board.NextMoveColor);
            m_strWhitePlayerName        = "Player 1";
            m_strBlackPlayerName        = "Player 2";
            m_eWhitePlayerType          = PgnParser.PlayerTypeE.Human;
            m_eBlackPlayerType          = PgnParser.PlayerTypeE.Human;
            CreateDrawingObjects();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Creates the drawing object using the current color info
        /// </summary>
        //  
        //*********************************************************     
        private void CreateDrawingObjects() {
            
            m_drawingObject.m_colorMapWhiteToLiteCase           = new ColorMap();
            m_drawingObject.m_colorMapWhiteToDarkCase           = new ColorMap();
            m_drawingObject.m_colorMapRedToWhitePiece           = new ColorMap();
            m_drawingObject.m_colorMapBlackToBlackPiece         = new ColorMap();
            m_drawingObject.m_colorMapWhiteToLiteCase.OldColor  = Color.FromArgb(255, 255, 255, 255);
            m_drawingObject.m_colorMapWhiteToLiteCase.NewColor  = m_colorInfo.m_colLiteCase;
            m_drawingObject.m_colorMapWhiteToDarkCase.OldColor  = Color.FromArgb(255, 255, 255, 255);
            m_drawingObject.m_colorMapWhiteToDarkCase.NewColor  = m_colorInfo.m_colDarkCase;
            m_drawingObject.m_colorMapRedToWhitePiece.OldColor  = Color.FromArgb(255, Color.Red);
            m_drawingObject.m_colorMapRedToWhitePiece.NewColor  = m_colorInfo.m_colWhitePiece;
            m_drawingObject.m_colorMapBlackToBlackPiece.OldColor= Color.Black;
            m_drawingObject.m_colorMapBlackToBlackPiece.NewColor= m_colorInfo.m_colBlackPiece;
            m_drawingObject.m_colorMapTblLiteCase               = new ColorMap[] { m_drawingObject.m_colorMapRedToWhitePiece, m_drawingObject.m_colorMapBlackToBlackPiece, m_drawingObject.m_colorMapWhiteToLiteCase };
            m_drawingObject.m_colorMapTblDarkCase               = new ColorMap[] { m_drawingObject.m_colorMapRedToWhitePiece, m_drawingObject.m_colorMapBlackToBlackPiece, m_drawingObject.m_colorMapWhiteToDarkCase };
            m_drawingObject.m_imgAttrLiteCase                   = new ImageAttributes();
            m_drawingObject.m_imgAttrDarkCase                   = new ImageAttributes();
            m_drawingObject.m_imgAttrLiteCase.SetRemapTable(m_drawingObject.m_colorMapTblLiteCase);
            m_drawingObject.m_imgAttrDarkCase.SetRemapTable(m_drawingObject.m_colorMapTblDarkCase);
            m_drawingObject.m_brBlack                           = new SolidBrush(Color.Black);
            m_drawingObject.m_brLiteCase                        = new SolidBrush(m_colorInfo.m_colLiteCase);
            m_drawingObject.m_brDarkCase                        = new SolidBrush(m_colorInfo.m_colDarkCase);
            m_drawingObject.m_penSelected                       = new Pen(m_drawingObject.m_brBlack, 4);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Reset the board to the initial condition
        /// </summary>
        //  
        //*********************************************************     
        public void ResetBoard() {
            m_board.ResetBoard();
            m_ptSelectedCase.X  = -1;
            m_ptSelectedCase.Y  = -1;
            if (m_moveListUI != null) {
                m_moveListUI.Reset(m_board);
            }
            OnUpdateCmdState(System.EventArgs.Empty);
            m_gameTimer.Reset(m_board.NextMoveColor);
            m_gameTimer.Enabled = false;
            Invalidate();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Color use to draw the board
        /// </summary>
        //  
        //*********************************************************     
        public ChessControlColorInfo ColorInfo {
            get {
                return(m_colorInfo);
            }
            set {
                m_colorInfo = value;
                CreateDrawingObjects();
                Invalidate();
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// User interface responsible to display move list.
        /// </summary>
        //  
        //*********************************************************     
        public IMoveListUI MoveListUI {
            get {
                return(m_moveListUI);
            }
            set {
                m_moveListUI = value;
                if (value != null) {
                    value.Reset(m_board);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Name of the player playing white piece
        /// </summary>
        //  
        //*********************************************************     
        public string WhitePlayerName {
            get {
                return(m_strWhitePlayerName);
            }
            set {
                m_strWhitePlayerName = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Name of the player playing black piece
        /// </summary>
        //  
        //*********************************************************     
        public string BlackPlayerName {
            get {
                return(m_strBlackPlayerName);
            }
            set {
                m_strBlackPlayerName = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Type of player playing white piece
        /// </summary>
        //  
        //*********************************************************     
        public PgnParser.PlayerTypeE WhitePlayerType {
            get {
                return(m_eWhitePlayerType);
            }
            set {
                m_eWhitePlayerType = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Type of player playing black piece
        /// </summary>
        //  
        //*********************************************************     
        public PgnParser.PlayerTypeE BlackPlayerType {
            get {
                return(m_eBlackPlayerType);
            }
            set {
                m_eBlackPlayerType = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Trigger the UpdateCmdState event. Called when command state need to be reevaluated.
        /// </summary>
        /// <param name="e">    Event argument</param>
        //  
        //*********************************************************     
        protected void OnUpdateCmdState(System.EventArgs e) {
            if (UpdateCmdState != null) {
                UpdateCmdState(this, e);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Save the current game into a file
        /// </summary>
        /// <param name="writer">   Binary writer</param>
        //  
        //*********************************************************     
        public virtual void SaveGame(BinaryWriter writer) {
            string                  strVersion;
            
            strVersion = "SRCBC095";
            writer.Write(strVersion);
            m_board.SaveBoard(writer);
            writer.Write(m_strWhitePlayerName);
            writer.Write(m_strBlackPlayerName);
            writer.Write(m_gameTimer.WhitePlayTime.Ticks);
            writer.Write(m_gameTimer.BlackPlayTime.Ticks);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load a game from a stream
        /// </summary>
        /// <param name="reader">   Binary reader</param>
        //  
        //*********************************************************     
        public virtual bool LoadGame(BinaryReader reader) {
            bool                        bRetVal;
            string                      strVersion;
            long                        lWhiteTicks;
            long                        lBlackTicks;
            
            strVersion = reader.ReadString();
            if (strVersion != "SRCBC095") {
                bRetVal = false;
            } else {
                bRetVal = m_board.LoadBoard(reader);
                if (bRetVal) {
                    if (m_moveListUI != null) {
                        m_moveListUI.Reset(m_board);
                    }
                    OnUpdateCmdState(System.EventArgs.Empty);
                    Invalidate();
                    m_strWhitePlayerName    = reader.ReadString();
                    m_strBlackPlayerName    = reader.ReadString();
                    lWhiteTicks             = reader.ReadInt64();
                    lBlackTicks             = reader.ReadInt64();
                    m_gameTimer.ResetTo(m_board.NextMoveColor, lWhiteTicks, lBlackTicks);
                    m_gameTimer.Enabled = true;
                }
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Load a board from a file selected by the user.
        /// </summary>
        /// <returns>
        /// true if a new board has been read
        /// </returns>
        //  
        //*********************************************************
         public bool LoadFromFile() {
            bool                    bRetVal = false;
            OpenFileDialog          openDlg;
            Stream                  stream;
            BinaryReader            reader;
            frmPGNGamePicker        frmPicker;
            int                     iIndex;
            
            using(openDlg = new OpenFileDialog()) {
                openDlg.AddExtension        = true;
                openDlg.CheckFileExists     = true;
                openDlg.CheckPathExists     = true;
                openDlg.DefaultExt          = "che";
                openDlg.Filter              = "Chess Files (*.che, *.pgn)|*.che;*.pgn";
                openDlg.Multiselect         = false;
                if (openDlg.ShowDialog() == DialogResult.OK) {
                    iIndex = openDlg.FileName.LastIndexOf('.');
                    if (iIndex == -1 || openDlg.FileName.Substring(iIndex).ToLower() != ".pgn") {
                        try {
                            stream = openDlg.OpenFile();
                        } catch(System.Exception) {
                            MessageBox.Show("Unable to open the file - " + openDlg.FileName);
                            stream = null;
                        }
                        if (stream != null) {
                            try {
                                using (reader = new BinaryReader(stream)) {
                                    if (!LoadGame(reader)) {
                                        MessageBox.Show("Bad file version - " + openDlg.FileName);
                                    } else {
                                        bRetVal = true;
                                    }
                                }
                            } catch(SystemException) {
                                MessageBox.Show("The file '" + openDlg.FileName + "' seems to be corrupted.");
                                ResetBoard();
                            }
                            stream.Dispose();
                            OnUpdateCmdState(System.EventArgs.Empty);
                        }
                    } else {
                        frmPicker = new frmPGNGamePicker();
                        using(frmPicker) {
                            if (frmPicker.InitForm(openDlg.FileName)) {
                                if (frmPicker.ShowDialog() == DialogResult.OK) {
                                    CreateGameFromMove(frmPicker.StartingChessBoard,
                                                       frmPicker.MoveList,
                                                       frmPicker.StartingColor,
                                                       frmPicker.WhitePlayerName,
                                                       frmPicker.BlackPlayerName,
                                                       frmPicker.WhitePlayerType,
                                                       frmPicker.BlackPlayerType,
                                                       frmPicker.WhiteTimer,
                                                       frmPicker.BlackTimer);
                                    bRetVal = true;
                                }
                            }
                        }
                    }
                }
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Save a board to a file selected by the user
        /// </summary>
        //  
        //*********************************************************
        public void SaveToFile() {
            SaveFileDialog  saveDlg;
            Stream          stream;
            
            using(saveDlg = new SaveFileDialog()) {
                saveDlg.AddExtension        = true;
                saveDlg.CheckPathExists     = true;
                saveDlg.DefaultExt          = "che";
                saveDlg.Filter              = "Chess Files (*.che)|*.che";
                saveDlg.OverwritePrompt     = true;
                if (saveDlg.ShowDialog() == DialogResult.OK) {
                    try {
                        stream = saveDlg.OpenFile();
                    } catch(System.Exception) {
                        MessageBox.Show("Unable to open the file - " + saveDlg.FileName);
                        stream = null;
                    }
                    if (stream != null) {
                        try {
                            SaveGame(new BinaryWriter(stream));
                        } catch(SystemException) {
                            MessageBox.Show("Unable to write to the file '" + saveDlg.FileName + "'.");
                        }
                        stream.Dispose();
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Save the board to a file selected by the user in PGN format
        /// </summary>
        //  
        //*********************************************************
        public void SavePGNToFile() {
            SaveFileDialog  saveDlg;
            Stream          stream;
            StreamWriter    writer;
            DialogResult    eResult;
            
            using(saveDlg = new SaveFileDialog()) {
                saveDlg.AddExtension        = true;
                saveDlg.CheckPathExists     = true;
                saveDlg.DefaultExt          = "pgn";
                saveDlg.Filter              = "PGN Chess Files (*.pgn)|*.pgn";
                saveDlg.OverwritePrompt     = true;
                if (saveDlg.ShowDialog() == DialogResult.OK) {
                    if (ChessBoard.MovePosStack.PositionInList + 1 != ChessBoard.MovePosStack.List.Count) {
                        eResult = MessageBox.Show("Do you want to save the undone moves?", "Saving to PGN File", MessageBoxButtons.YesNoCancel);
                    } else {
                        eResult = DialogResult.Yes;
                    }
                    if (eResult != DialogResult.Cancel) {
                        try {
                            stream = saveDlg.OpenFile();
                        } catch(System.Exception) {
                            MessageBox.Show("Unable to open the file - " + saveDlg.FileName);
                            stream = null;
                        }
                        if (stream != null) {
                            try {
                                using (writer = new StreamWriter(stream)) {
                                    writer.Write(SaveGameToPGNText(eResult == DialogResult.Yes));
                                }
                            } catch(SystemException) {
                                MessageBox.Show("Unable to write to the file '" + saveDlg.FileName + "'.");
                            }
                            stream.Dispose();
                        }
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Create a new game using the specified list of moves
        /// </summary>
        /// <param name="chessBoardStarting">   Starting board or null if standard board</param>
        /// <param name="listMove">             List of moves</param>
        /// <param name="eNextMoveColor">       Color starting to play</param>
        /// <param name="strWhitePlayerName">   Name of the player playing white pieces</param>
        /// <param name="strBlackPlayerName">   Name of the player playing black pieces</param>
        /// <param name="eWhitePlayerType">     Type of player playing white pieces</param>
        /// <param name="eBlackPlayerType">     Type of player playing black pieces</param>
        /// <param name="spanPlayerWhite">      Timer for white</param>
        /// <param name="spanPlayerBlack">      Timer for black</param>
        //  
        //*********************************************************     
        public virtual void CreateGameFromMove(ChessBoard                   chessBoardStarting,
                                               List<ChessBoard.MovePosS>    listMove,
                                               ChessBoard.PlayerColorE      eNextMoveColor,
                                               string                       strWhitePlayerName,
                                               string                       strBlackPlayerName,
                                               PgnParser.PlayerTypeE        eWhitePlayerType,
                                               PgnParser.PlayerTypeE        eBlackPlayerType,
                                               TimeSpan                     spanPlayerWhite,
                                               TimeSpan                     spanPlayerBlack) {
            m_board.CreateGameFromMove(chessBoardStarting,
                                       listMove,
                                       eNextMoveColor);
            if (m_moveListUI != null) {
                m_moveListUI.Reset(m_board);
            }
            WhitePlayerName = strWhitePlayerName;
            BlackPlayerName = strBlackPlayerName;
            WhitePlayerType = eWhitePlayerType;
            BlackPlayerType = eBlackPlayerType;
            OnUpdateCmdState(System.EventArgs.Empty);
            m_gameTimer.ResetTo(m_board.NextMoveColor,
                                spanPlayerWhite.Ticks,
                                spanPlayerBlack.Ticks);
            m_gameTimer.Enabled = true;
            Invalidate();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Creates a game from a PGN text paste by the user
        /// </summary>
        /// <returns>
        /// true if a new board has been loaded
        /// </returns>
        //  
        //*********************************************************
         public bool CreateFromPGNText() {
            bool                bRetVal = false;
            frmCreatePGNGame    frm;
            
            frm = new frmCreatePGNGame();
            using(frm) {
                if (frm.ShowDialog() == DialogResult.OK) {
                    CreateGameFromMove(frm.StartingChessBoard,
                                       frm.MoveList,
                                       frm.StartingColor,
                                       frm.WhitePlayerName,
                                       frm.BlackPlayerName,
                                       frm.WhitePlayerType,
                                       frm.BlackPlayerType,
                                       frm.WhiteTimer,
                                       frm.BlackTimer);
                    bRetVal = true;
                }
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Creates a game from a PGN text paste by the user
        /// </summary>
        /// <returns>
        /// true if a new board has been loaded
        /// </returns>
        //  
        //*********************************************************
         public string SaveGameToPGNText(bool bIncludeRedoMove) {
            string  strRetVal;
            
            strRetVal = PgnUtil.GetPGNFromBoard(m_board,
                                                bIncludeRedoMove,
                                                "SrcChess Game",
                                                "SrcChess Location",
                                                DateTime.Now.ToString("yyyy.MM.dd"),
                                                "1",
                                                WhitePlayerName,
                                                BlackPlayerName,
                                                WhitePlayerType,
                                                BlackPlayerType,
                                                m_gameTimer.WhitePlayTime,
                                                m_gameTimer.BlackPlayTime);
            return(strRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Create a book from files selected by the user
        /// </summary>
        //  
        //*********************************************************
         public void CreateBookFromFiles() {
            OpenFileDialog          openDlg;
            SaveFileDialog          saveDlg;
            PgnParser               parser;
            Stream                  stream;
            TextReader              reader;
            Book                    book;
            string                  strText;
            List<int[]>             arrMoveList;
            int                     iSkip;
            int                     iTruncated;
            int                     iTotalSkip = 0;
            int                     iTotalTruncated = 0;
            int                     iTotalFiles = 0;
            int                     iBookEntries;
            bool                    bAbort = false;
            
            arrMoveList = new List<int[]>(8192);
            book        = new Book();
            using(openDlg = new OpenFileDialog()) {
                openDlg.AddExtension        = true;
                openDlg.CheckFileExists     = true;
                openDlg.CheckPathExists     = true;
                openDlg.DefaultExt          = "pgn";
                openDlg.Filter              = "Chess PGN Files (*.pgn)|*.pgn";
                openDlg.Multiselect         = true;
                if (openDlg.ShowDialog() == DialogResult.OK) {
                    foreach (string strFileName in openDlg.FileNames) {
                        try {
                            stream = File.OpenRead(strFileName);
                        } catch(System.Exception) {
                            MessageBox.Show("Unable to open the file - " + strFileName);
                            stream = null;
                        }
                        if (stream != null) {
                            reader  = new StreamReader(stream);
                            strText = reader.ReadToEnd();
                            parser  = new PgnParser(false);
                            try {
                                parser.Parse(strText, arrMoveList, out iSkip, out iTruncated);
                                iTotalSkip      += iSkip;
                                iTotalTruncated += iTruncated;
                                iTotalFiles++;
                            } catch(PgnParserException exc) {
                                MessageBox.Show("Error processing file '" + strFileName + "'\r\n" + exc.Message + "\r\n" + exc.CodeInError);
                                bAbort =  true;
                            }
                            stream.Close();
                        }
                        if (bAbort) {
                            break;
                        }
                    }
                    if (!bAbort) {
                        iBookEntries = book.CreateBookList(arrMoveList, 30, 10);
                        MessageBox.Show(iTotalFiles.ToString() + " PNG file(s) read. " + arrMoveList.Count.ToString() + " games processed. " + iTotalTruncated.ToString() + " truncated. " + iTotalSkip.ToString() + " skipped. " + iBookEntries.ToString() + " book entries defined.");
                        using(saveDlg = new SaveFileDialog()) {
                            saveDlg.AddExtension        = true;
                            saveDlg.CheckPathExists     = true;
                            saveDlg.DefaultExt          = "bin";
                            saveDlg.Filter              = "Chess Opening Book (*.bin)|*.bin";
                            saveDlg.OverwritePrompt     = true;
                            if (saveDlg.ShowDialog() == DialogResult.OK) {
                                try {
                                    book.SaveBookToFile(saveDlg.FileName);
                                } catch (System.Exception ex) {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Trace a permutation. Can be used for debugging.
        /// </summary>
        /// <param name="iDepth">       Current depth of the search</param>
        /// <param name="ePlayerColor"> Color who play</param>
        /// <param name="move">         Move</param>
        /// <param name="iPts">         Points for this move</param>
        //  
        //*********************************************************     
        public virtual void TraceSearch(int iDepth, ChessBoard.PlayerColorE ePlayerColor, ChessBoard.MovePosS move, int iPts) {
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the chess board associated with the control
        /// </summary>
        //  
        //*********************************************************     
        public ChessBoard ChessBoard {
            get {
                return(m_board);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Determine if the White are in the top or bottom of the draw board
        /// </summary>
        //  
        //*********************************************************     
        public bool WhiteInBottom {
            get {
                return(m_bWhiteInBottom);
            }
            set {
                if (value != m_bWhiteInBottom) {
                    m_bWhiteInBottom = value;
                    Invalidate();
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Trigger the MoveSelected event
        /// </summary>
        /// <param name="e">    Event arguments</param>
        //  
        //*********************************************************     
        protected virtual void OnMoveSelected(MoveSelectedEventArgs e) {
            if (MoveSelected != null) {
                MoveSelected(this, e);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// OnQueryPiece:       Trigger the QueryPiece event
        /// </summary>
        /// <param name="e">    Event arguments</param>
        //  
        //*********************************************************     
        protected virtual void OnQueryPiece(QueryPieceEventArgs e) {
            if (QueryPiece != null) {
                QueryPiece(this, e);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// OnQweryPawnPromotionType:   Trigger the QueryPawnPromotionType event
        /// </summary>
        /// <param name="e">            Event arguments</param>
        //  
        //*********************************************************     
        protected virtual void OnQueryPawnPromotionType(QueryPawnPromotionTypeEventArgs e) {
            if (QueryPawnPromotionType != null) {
                QueryPawnPromotionType(this, e);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Returns the size of one case in pixel
        /// </summary>
        //  
        //*********************************************************     
        private int CaseSize {
            get {
                int     iSize;
                
                iSize = Size.Width;
                if (Size.Height < iSize) {
                    iSize = Size.Height;                
                }
                return(iSize / 9);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Enable or disable the auto selection mode
        /// </summary>
        //  
        //*********************************************************     
        public bool AutoSelection {
            get {
                return(m_bAutoSelection);
            }
            set {
                m_bAutoSelection = value;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Determine the board design mode
        /// </summary>
        //  
        //*********************************************************     
        public bool BoardDesignMode {
            get {
                return(m_board.DesignMode);
            }
            set {
                DialogResult            eRes;
                ChessBoard.PlayerColorE eNextMoveColor;
                
                if (m_board.DesignMode != value) {
                    if (value) {
                        m_board.OpenDesignMode();
                        m_board.MovePosStack.Clear();
                        if (m_moveListUI != null) {
                            m_moveListUI.Reset(m_board);
                        }
                        m_gameTimer.Enabled = false;
                        OnUpdateCmdState(System.EventArgs.Empty);
                    } else {
                        eRes = MessageBox.Show("Is the next move to the white?", "SrcChess", MessageBoxButtons.YesNo);
                        eNextMoveColor = (eRes == DialogResult.Yes) ? ChessBoard.PlayerColorE.White : ChessBoard.PlayerColorE.Black;
                        if (m_board.CloseDesignMode(eNextMoveColor, (ChessBoard.BoardStateMaskE)0, 0)) {
                            if (m_moveListUI != null) {
                                m_moveListUI.Reset(m_board);
                            }
                            m_gameTimer.Reset(m_board.NextMoveColor);
                            m_gameTimer.Enabled = true;
                        }
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Set the piece in a case. Can only be used in design mode.
        /// </summary>
        //  
        //*********************************************************     
        public void SetCaseValue(int iPos, ChessBoard.PieceE ePiece) {
            Graphics    gr;
            int         iY;
            int         iX;
            
            if (BoardDesignMode) {
                iY = iPos >> 3;
                iX = iPos & 7;
                m_board[iPos] = ePiece;
                using(gr = CreateGraphics()) {
                    DrawCase(gr, iY, iX, false);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Draw a case and its content
        /// </summary>
        /// <param name="gr">       Graphic object</param>
        /// <param name="iY">       Y position of the piece (0-7)</param>
        /// <param name="iX">       X position of the piece (0-7)</param>
        /// <param name="bRevert">  true to revert the background color</param>
        //  
        //*********************************************************     
        private void DrawCase(Graphics gr, int iY, int iX, bool bRevert) {
            Rectangle           tRectCase;
            Rectangle           tRectBmp;
            ChessBoard.PieceE   ePiece;
            Metafile            metaFile;
            int                 iPiece;
            int                 iDrawXPos;
            int                 iDrawYPos;
            int                 iOfs;
            int                 iCaseSize;
            int                 iAroundSize;
            bool                bPieceBlack;
            bool                bLiteCase;
            
            iCaseSize   = CaseSize;
            iAroundSize = iCaseSize / 6;
            iOfs        = iCaseSize / 2;
            if (m_bWhiteInBottom) {
                iDrawYPos = 7 - iY;
                iDrawXPos = 7 - iX;
            } else {
                iDrawYPos = iY;
                iDrawXPos = iX;
            }
            bLiteCase = (((iX + (iY & 1)) & 1) == 0);
            if (bRevert) {
                bLiteCase = !bLiteCase;
            }
            tRectCase = new Rectangle(iDrawXPos * iCaseSize + iOfs, iDrawYPos * iCaseSize + iOfs, iCaseSize, iCaseSize);
            tRectBmp  = new Rectangle(iDrawXPos * iCaseSize + iAroundSize / 2 + iOfs, iDrawYPos * iCaseSize + iAroundSize / 2 + iOfs, iCaseSize - iAroundSize, iCaseSize - iAroundSize);
            ePiece    = m_board[(iY << 3) + iX];
            gr.FillRectangle(bLiteCase ? m_drawingObject.m_brLiteCase : m_drawingObject.m_brDarkCase, tRectCase);
            if (ePiece != ChessBoard.PieceE.None) {
                iPiece          = (int)ePiece;
                bPieceBlack     = ((ePiece & ChessBoard.PieceE.Black) != 0);
                metaFile        = m_arrMetafilePiece[iPiece];
                gr.DrawImage(metaFile, tRectBmp, 0, 0, metaFile.Width, metaFile.Height, GraphicsUnit.Pixel,  bLiteCase ? m_drawingObject.m_imgAttrLiteCase : m_drawingObject.m_imgAttrDarkCase);
            }
            if (m_ptSelectedCase.X == iX &&
                m_ptSelectedCase.Y == iY) {
                tRectCase.Inflate(-2, -2);
                gr.DrawRectangle(m_drawingObject.m_penSelected, tRectCase);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Draw the coordinate around the board
        /// </summary>
        /// <param name="gr">       Graphic object</param>
        /// <param name="iPos">     Coordinate position (0-7)</param>
        //  
        //*********************************************************     
        private void DrawCoord(Graphics gr, int iPos) {
            string          strCoord;
            RectangleF      tRect;
            int             iVal;
            int             iCaseSize;
            int             iHalf;
            int             iQuart;
            StringFormat    fmt = new StringFormat();
            
            iCaseSize           = CaseSize;
            iHalf               = iCaseSize / 2;
            iQuart              = iCaseSize / 4;
            fmt.Alignment       = StringAlignment.Center;
            fmt.LineAlignment   = StringAlignment.Center;
            iVal                = (m_bWhiteInBottom) ? 8 - iPos : iPos + 1;
            strCoord            = ((Char)(48+iVal)).ToString();
            tRect               = new RectangleF(0, iPos * iCaseSize + iQuart * 3, iHalf, iHalf);
            gr.DrawString(strCoord, m_fontCoord, m_drawingObject.m_brBlack, tRect, fmt);
            tRect               = new RectangleF(iCaseSize * 8 + iHalf, iPos * iCaseSize + iQuart * 3, iHalf, iHalf);
            gr.DrawString(strCoord, m_fontCoord, m_drawingObject.m_brBlack, tRect, fmt);
            iVal                = (m_bWhiteInBottom) ? iPos : 7 - iPos;
            strCoord            = ((Char)(97+iVal)).ToString();
            tRect               = new RectangleF(iPos * iCaseSize + iQuart * 3, 0, iHalf, iHalf);
            gr.DrawString(strCoord, m_fontCoord, m_drawingObject.m_brBlack, tRect, fmt);
            tRect               = new RectangleF(iPos * iCaseSize + iQuart * 3, iCaseSize * 8 + iHalf, iHalf, iHalf);
            gr.DrawString(strCoord, m_fontCoord, m_drawingObject.m_brBlack, tRect, fmt);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get the case coordinate from a client coordinate.
        /// </summary>
        /// <returns>
        /// Case corrdinate or -1 if out of bound. (0,0) = Upper left corner (white size)
        /// </returns>
        //  
        //*********************************************************     
        public Point GetCaseFromPoint(Point ptCoord) {
            Point   ptRetVal;
            int     iCaseSize;
            int     iOfs;
            
            iCaseSize  = CaseSize;
            iOfs       = iCaseSize / 2;
            ptRetVal   = new Point((ptCoord.X - iOfs) / iCaseSize, (ptCoord.Y - iOfs) / iCaseSize);
            if (ptRetVal.X < 0 ||
                ptRetVal.X > 7 ||
                ptRetVal.Y < 0 ||
                ptRetVal.Y > 7) {
                ptRetVal.X = -1;
                ptRetVal.Y = -1;
            } else if (m_bWhiteInBottom) {
                ptRetVal.X = 7 - ptRetVal.X;
                ptRetVal.Y = 7 - ptRetVal.Y;
            }
            return(ptRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Select a case
        /// </summary>
        //  
        //*********************************************************     
        public Point SelectedCase {
            get {
                return(m_ptSelectedCase);
            }
            set {
                Graphics    gr;
                Point       pt;
                
                using(gr = CreateGraphics()) {
                    if (m_ptSelectedCase.X != value.X ||
                        m_ptSelectedCase.Y != value.Y) {
                        if (m_ptSelectedCase.X != -1) {
                            pt                 = m_ptSelectedCase;
                            m_ptSelectedCase.X = -1;
                            m_ptSelectedCase.Y = -1;
                            DrawCase(gr,  pt.Y, pt.X, false);
                        }
                        m_ptSelectedCase = value;
                        if (m_ptSelectedCase.X != -1) {
                            DrawCase(gr, m_ptSelectedCase.Y, m_ptSelectedCase.X, false);
                        }
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Called when the mouse is clicked down
        /// </summary>
        /// <param name="e">        Event argument</param>
        //  
        //*********************************************************     
        protected override void OnMouseDown(MouseEventArgs e) {            
            Point                           pt;
            ChessBoard.MovePosS             tMove;
            ChessBoard.ValidPawnPromotionE  eValidPawnPromotion;
            QueryPieceEventArgs             eQueryPieceEventArgs;
            int                             iPos;
            Graphics                        gr;
            QueryPawnPromotionTypeEventArgs eventArg;
            
            base.OnMouseDown(e);
            if (BoardDesignMode) {
                pt = GetCaseFromPoint(new Point(e.X, e.Y));
                if (pt.X != -1) {
                    iPos                 = pt.X + (pt.Y << 3);
                    eQueryPieceEventArgs = new QueryPieceEventArgs(iPos, ChessBoard[iPos]);
                    OnQueryPiece(eQueryPieceEventArgs);
                    ChessBoard[iPos] = eQueryPieceEventArgs.Piece;
                    using(gr = CreateGraphics()) {
                        DrawCase(gr, pt.Y, pt.X, false);
                    }
                }
            } else if (AutoSelection) {
                pt = GetCaseFromPoint(new Point(e.X, e.Y));
                if (pt.X == -1) {
                    SelectedCase = pt;
                } else {
                    if (SelectedCase.X == -1) {
                        SelectedCase = pt;
                    } else {
                        if (SelectedCase.X == pt.X  &&
                            SelectedCase.Y == pt.Y) {
                            pt.X         = -1;
                            pt.Y         = -1;
                            SelectedCase = pt;
                        } else {
                            tMove = ChessBoard.FindIfValid(m_board.NextMoveColor,
                                                           SelectedCase.X + (SelectedCase.Y << 3),
                                                           pt.X + (pt.Y << 3));
                            if (tMove.StartPos != 255) {                                                           
                                eValidPawnPromotion = ChessBoard.FindValidPawnPromotion(m_board.NextMoveColor, 
                                                                                        SelectedCase.X + (SelectedCase.Y << 3),
                                                                                        pt.X + (pt.Y << 3));
                                if (eValidPawnPromotion != ChessBoard.ValidPawnPromotionE.None) {
                                    eventArg = new QueryPawnPromotionTypeEventArgs(eValidPawnPromotion);
                                    OnQueryPawnPromotionType(eventArg);
                                    if (eventArg.PawnPromotionType == ChessBoard.MoveTypeE.Normal) {
                                        tMove.StartPos = 255;
                                    } else {
                                        tMove.Type &= ~ChessBoard.MoveTypeE.MoveTypeMask;
                                        tMove.Type |= eventArg.PawnPromotionType;
                                    }
                                }
                            }
                            pt.X = -1;
                            pt.Y = -1;
                            SelectedCase = pt;
                            if (tMove.StartPos == 255) {
                                System.Console.Beep();
                            } else {
                                OnMoveSelected(new MoveSelectedEventArgs(tMove));
                            }
                        }
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Paint the control
        /// </summary>
        /// <param name="e">        Event argument</param>
        //  
        //*********************************************************     
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            for (int iY = 0; iY < 8; iY++) {
                DrawCoord(e.Graphics, iY);
                for (int iX = 0; iX < 8; iX++) {
                    DrawCase(e.Graphics, iY, iX, false);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Paint the control
        /// </summary>
        /// <param name="e">        Event argument</param>
        //  
        //*********************************************************     
        protected override void  OnResize(EventArgs e) {
            int     iFontSize;
            
            base.OnResize(e);
            iFontSize = CaseSize / 5;
            if (iFontSize < 4) {
                iFontSize = 4;
            }
            if (m_fontCoord != null) {
                m_fontCoord.Dispose();
            }
            m_fontCoord = new Font("Verdana", iFontSize);
            Invalidate();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Flash a case
        /// </summary>
        /// <param name="gr">       Graphic object</param>
        /// <param name="iPos">     Position to flah (0-63)</param>
        //  
        //*********************************************************     
        private void FlashPos(Graphics gr, int iPos) {
            int         iY;
            int         iX;
            bool        bRevert;
            
            iY = iPos >> 3;
            iX = iPos & 7;
            bRevert = true;
            for (int iIndex  = 0; iIndex < 4; iIndex++) {
                DrawCase(gr, iY, iX, bRevert);
                System.Threading.Thread.Sleep(200);
                bRevert = !bRevert;
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Get additional position to update when doing or undoing a special move
        /// </summary>
        /// <param name="movePos">      Position of the move</param>
        /// <returns>
        /// Array of position to undo
        /// </returns>
        //  
        //*********************************************************     
        private int[] GetPosToUpdate(ChessBoard.MovePosS movePos) {
            List<int>       arrRetVal = new List<int>(2);

            if ((movePos.Type & ChessBoard.MoveTypeE.MoveTypeMask) == ChessBoard.MoveTypeE.Castle) {
                switch(movePos.EndPos) {
                case 1:
                    arrRetVal.Add(0);
                    arrRetVal.Add(2);
                    break;
                case 5:
                    arrRetVal.Add(7);
                    arrRetVal.Add(4);
                    break;
                case 57:
                    arrRetVal.Add(56);
                    arrRetVal.Add(58);
                    break;
                case 61:
                    arrRetVal.Add(63);
                    arrRetVal.Add(60);
                    break;
                default:
                    MessageBox.Show("Oops!");
                    break;
                }
            } else if ((movePos.Type & ChessBoard.MoveTypeE.MoveTypeMask) == ChessBoard.MoveTypeE.EnPassant) {
                arrRetVal.Add((movePos.StartPos & 56) + (movePos.EndPos & 7));
            }
            return(arrRetVal.ToArray());
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show before move is done
        /// </summary>
        /// <param name="movePos">      Position of the move</param>
        /// <param name="bFlash">       true to flash the from and destination pieces</param>
        //  
        //*********************************************************     
        private void ShowBeforeMove(ChessBoard.MovePosS movePos, bool bFlash) {
            Graphics    gr;

            using(gr = CreateGraphics()) {
                if (bFlash) {
                    FlashPos(gr, movePos.StartPos);
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Show after move is done
        /// </summary>
        /// <param name="movePos">      Position of the move</param>
        /// <param name="bFlash">       true to flash the from and destination pieces</param>
        //  
        //*********************************************************     
        private void ShowAfterMove(ChessBoard.MovePosS movePos, bool bFlash) {
            Graphics    gr;
            int[]       arrPosToUpdate;

            using(gr = CreateGraphics()) {
                DrawCase(gr, movePos.StartPos >> 3, movePos.StartPos & 7, false);
                if (bFlash) {
                    FlashPos(gr, movePos.EndPos);
                } else {
                    DrawCase(gr, movePos.EndPos >> 3, movePos.EndPos & 7, false);
                }
                arrPosToUpdate = GetPosToUpdate(movePos);
                foreach (int iPos in arrPosToUpdate) {
                    if (bFlash) {
                        FlashPos(gr, iPos);
                    } else {
                        DrawCase(gr, iPos >> 3, iPos & 7, false);
                    }
                }
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Play the specified move
        /// </summary>
        /// <param name="movePos">      Position of the move</param>
        /// <param name="bFlash">       true to flash the from and destination pieces</param>
        /// <param name="iPermCount">   Permutation count</param>
        /// <param name="iDepth">       Maximum depth use to find the move</param>
        /// <param name="iCacheHit">    Number of permutation found in cache</param>
        /// <returns>
        /// NoRepeat, FiftyRuleRepeat, ThreeFoldRepeat, Tie, Check, Mate
        /// </returns>
        //  
        //*********************************************************     
        public ChessBoard.MoveResultE DoMove(ChessBoard.MovePosS movePos, bool bFlash, int iPermCount, int iDepth, int iCacheHit) {
            ChessBoard.MoveResultE eRetVal;
            
            ShowBeforeMove(movePos, bFlash);
            eRetVal = m_board.DoMove(movePos);
            ShowAfterMove(movePos, bFlash);
            if (m_moveListUI != null) {
                m_moveListUI.NewMoveDone(iPermCount, iDepth, iCacheHit);
            }
            OnUpdateCmdState(System.EventArgs.Empty);
            m_gameTimer.PlayerColor = m_board.NextMoveColor;
            m_gameTimer.Enabled = (eRetVal == ChessBoard.MoveResultE.NoRepeat || eRetVal == ChessBoard.MoveResultE.Check);
            return(eRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Undo the last move
        /// </summary>
        /// <param name="bFlash">   true to flash the from and destination pieces</param>
        //  
        //*********************************************************     
        public void UndoMove(bool bFlash) {
            ChessBoard.MovePosS movePos;
            Graphics            gr;
            int[]               arrPosToUpdate;

            movePos = m_board.MovePosStack.CurrentMove;
            using(gr = CreateGraphics()) {
                if (bFlash) {
                    FlashPos(gr, movePos.EndPos);
                }
                m_board.UndoMove();
                DrawCase(gr, movePos.EndPos >> 3, movePos.EndPos & 7, false);
                if (bFlash) {
                    FlashPos(gr, movePos.StartPos);
                } else {
                    DrawCase(gr, movePos.StartPos >> 3, movePos.StartPos & 7, false);
                }
                arrPosToUpdate = GetPosToUpdate(movePos);
                Array.Reverse(arrPosToUpdate);
                foreach (int iPos in arrPosToUpdate) {
                    if (bFlash) {
                        FlashPos(gr, iPos);
                    } else {
                        DrawCase(gr, iPos >> 3, iPos & 7, false);
                    }
                }
            }
            if (m_moveListUI != null) {
                m_moveListUI.RedoPosChanged();
            }
            OnUpdateCmdState(System.EventArgs.Empty);
            m_gameTimer.PlayerColor = m_board.NextMoveColor;
            m_gameTimer.Enabled = true;
        }

        //*********************************************************     
        //
        /// <summary>
        /// Redo the most recently undone move
        /// </summary>
        /// <param name="bFlash">   true to flash</param>
        /// <returns>
        /// NoRepeat, FiftyRuleRepeat, ThreeFoldRepeat, Check, Mate
        /// </returns>
        //  
        //*********************************************************     
        public ChessBoard.MoveResultE RedoMove(bool bFlash) {
            ChessBoard.MoveResultE  eRetVal;
            ChessBoard.MovePosS     movePos;
            
            movePos = m_board.MovePosStack.NextMove;
            ShowBeforeMove(movePos, bFlash);
            eRetVal = m_board.RedoMove();
            ShowAfterMove(movePos, bFlash);
            if (m_moveListUI != null) {
                m_moveListUI.RedoPosChanged();
            }
            OnUpdateCmdState(System.EventArgs.Empty);
            m_gameTimer.PlayerColor = m_board.NextMoveColor;
            m_gameTimer.Enabled = (eRetVal == ChessBoard.MoveResultE.NoRepeat || eRetVal == ChessBoard.MoveResultE.Check);
            return(eRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// ShowHintMove:                   Show a hint on the next move to do
        /// </summary>
        /// <param name="movePos">          Move position</param>
        //  
        //*********************************************************     
        public void ShowHintMove(ChessBoard.MovePosS movePos) {
            ShowBeforeMove(movePos, true);
            m_board.DoMoveNoLog(movePos);
            ShowAfterMove(movePos, true);
            m_board.UndoMoveNoLog(movePos);
            ShowAfterMove(movePos, false);
        }

        //*********************************************************     
        //
        /// <summary>
        /// ShowHint:                       Find and show a hint on the next move to do
        /// </summary>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="movePos">          Move position found</param>
        /// <param name="iPermCount">       Permutation count</param>
        /// <param name="iCacheHit">        Cache hit</param>
        /// <returns>
        /// true if a hint has been shown
        /// </returns>
        //  
        //*********************************************************     
        public bool ShowHint(SearchEngine.SearchMode searchMode, out ChessBoard.MovePosS movePos, out int iPermCount, out int iCacheHit) {
            bool    bRetVal;
            int     iMaxDepth;
            
            if (FindBestMove(searchMode, null, out movePos, out iPermCount, out iCacheHit, out iMaxDepth)) {
                ShowHintMove(movePos);
                bRetVal = true;
            } else {
                bRetVal = false;
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the number of move which can be undone
        /// </summary>
        //  
        //*********************************************************     
        public int UndoCount {
            get {
                return(m_board.MovePosStack.PositionInList + 1);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Select a move by index using undo/redo buffer to move
        /// </summary>
        /// <param name="iIndex">   Index of the move. Can be -1</param>
        /// <param name="bSucceed"> true if index in range</param>
        /// <returns>
        /// Repeat result
        /// </returns>
        //  
        //*********************************************************     
        public ChessBoard.MoveResultE SelectMove(int iIndex, out bool bSucceed) {
            ChessBoard.MoveResultE  eRetVal = ChessBoard.MoveResultE.NoRepeat;
            int                         iCurPos;
            int                         iCount;
            
            iCurPos = m_board.MovePosStack.PositionInList;
            iCount  = m_board.MovePosStack.Count;
            if (iIndex >= -1 && iIndex < iCount) {
                bSucceed = true;
                if (iCurPos < iIndex) {
                    while (iCurPos != iIndex) {
                        eRetVal = RedoMove(false);
                        iCurPos++;
                    }
                } else if (iCurPos > iIndex) {
                    while (iCurPos != iIndex) {
                        UndoMove(false);
                        iCurPos--;
                    }
                }
            } else {
                bSucceed = false;
            }
            return(eRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the number of move which can be redone
        /// </summary>
        //  
        //*********************************************************     
        public int RedoCount {
            get {
                int iCurPos;
                int iCount;
                
                iCurPos = m_board.MovePosStack.PositionInList;
                iCount  = m_board.MovePosStack.Count;
                return(iCount - iCurPos - 1);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Current color to play
        /// </summary>
        //  
        //*********************************************************     
        public ChessBoard.PlayerColorE NextMoveColor {
            get {
                return(m_board.NextMoveColor);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// List of played moves
        /// </summary>
        //  
        //*********************************************************     
        private ChessBoard.MovePosS[] MoveList {
            get {
                ChessBoard.MovePosS[]   arrMoveList;
                int                     iMoveCount;
                
                iMoveCount  = m_board.MovePosStack.PositionInList + 1;
                arrMoveList = new ChessBoard.MovePosS[iMoveCount];
                if (iMoveCount != 0) {
                    m_board.MovePosStack.List.CopyTo(0, arrMoveList, 0, iMoveCount);
                }
                return(arrMoveList);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Find a move from the opening book
        /// </summary>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="move">             Found move</param>
        /// <returns>
        /// true if succeed, false if no move found in book
        /// </returns>
        //  
        //*********************************************************     
        public bool FindBookMove(SearchEngine.SearchMode searchMode, out ChessBoard.MovePosS move) {
            bool                    bRetVal;
            ChessBoard.MovePosS[]   arrMoves;
            
            if (!m_board.StandardInitialBoard) {
                move.OriginalPiece  = ChessBoard.PieceE.None;
                move.StartPos       = 255;
                move.EndPos         = 255;
                move.Type           = ChessBoard.MoveTypeE.Normal;
                bRetVal             = false;
            } else {
                arrMoves = MoveList;
                bRetVal  = m_board.FindBookMove(searchMode, m_board.NextMoveColor, arrMoves, out move);
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Find the best move for a player using alpha-beta pruning or minmax search
        /// </summary>
        /// <param name="searchMode">       Search mode</param>
        /// <param name="chessBoard">       Chess board to use. Null to use the base one</param>
        /// <param name="moveBest">         Best move found</param>
        /// <param name="iPermCount">       Total permutation evaluated</param>
        /// <param name="iCacheHit">        Number of moves found in the translation table cache</param>
        /// <param name="iMaxDepth">        Maximum depth evaluated</param>
        /// <returns>
        /// true if a move has been found
        /// </returns>
        //  
        //*********************************************************     
        public bool FindBestMove(SearchEngine.SearchMode searchMode, ChessBoard chessBoard, out ChessBoard.MovePosS moveBest, out int iPermCount, out int iCacheHit, out int iMaxDepth) {
            bool    bRetVal;
            bool    bUseBook;
            
            bUseBook = ((searchMode.m_eOption & SearchEngine.SearchMode.OptionE.UseBook) != 0);
            if (bUseBook && FindBookMove(searchMode, out moveBest)) {
                iPermCount = -1;
                iCacheHit  = -1;
                iMaxDepth  = 0;
                bRetVal    = true;
            } else {
                if (chessBoard == null) {
                    chessBoard = m_board;
                }
                m_dateTimeStartSearching = DateTime.Now;
                bRetVal                  = chessBoard.FindBestMove(searchMode, m_board.NextMoveColor, out moveBest, out iPermCount, out iCacheHit, out iMaxDepth);
                m_timeSpanLastSearch     = DateTime.Now - m_dateTimeStartSearching;
            }
            return(bRetVal);
        }

        //*********************************************************     
        //
        /// <summary>
        /// Cancel search
        /// </summary>
        //  
        //*********************************************************     
        public void CancelSearch() {
            m_board.CancelSearch();
        }

        //*********************************************************     
        //
        /// <summary>
        /// Time use to find the last best move
        /// </summary>
        //  
        //*********************************************************     
        public TimeSpan LastFindBestMoveTimeSpan {
            get {
                return(m_timeSpanLastSearch);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Game timer
        /// </summary>
        //  
        //*********************************************************     
        public GameTimer GameTimer {
            get {
                return(m_gameTimer);
            }
        }

        //*********************************************************     
        //
        /// <summary>
        /// Gets the position express in a human form
        /// </summary>
        /// <param name="ptStart">      Starting Position</param>
        /// <param name="ptEnd">        Ending position</param>
        /// <returns>
        /// Human form position
        /// </returns>
        //  
        //*********************************************************     
        static public string GetHumanPos(Point ptStart, Point ptEnd) {
            return(ChessBoard.GetHumanPos(ptStart.X + (ptStart.Y << 3)) + "-" + ChessBoard.GetHumanPos(ptEnd.X + (ptEnd.Y << 3)));
        }
    }
}
