namespace SrcChess {
    partial class ChessControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            if (disposing) {
                if (m_drawingObject.m_brDarkCase != null) {
                    m_drawingObject.m_brDarkCase.Dispose();
                    m_drawingObject.m_brDarkCase = null;
                }
                if (m_drawingObject.m_brLiteCase != null) {
                    m_drawingObject.m_brLiteCase.Dispose();
                    m_drawingObject.m_brLiteCase = null;
                }
                if (m_drawingObject.m_imgAttrLiteCase != null) {
                    m_drawingObject.m_imgAttrLiteCase.Dispose();
                    m_drawingObject.m_imgAttrLiteCase = null;
                }
                if (m_drawingObject.m_imgAttrDarkCase != null) {
                    m_drawingObject.m_imgAttrDarkCase.Dispose();
                    m_drawingObject.m_imgAttrDarkCase = null;
                }
                if (m_drawingObject.m_penSelected != null) {
                    m_drawingObject.m_penSelected.Dispose();
                    m_drawingObject.m_penSelected = null;
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessControl));
            this.imageListPieces = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageListPieces
            // 
            this.imageListPieces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPieces.ImageStream")));
            this.imageListPieces.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPieces.Images.SetKeyName(0, "PawnW.bmp");
            this.imageListPieces.Images.SetKeyName(1, "PawnB.bmp");
            this.imageListPieces.Images.SetKeyName(2, "KnightW.bmp");
            this.imageListPieces.Images.SetKeyName(3, "KnightB.bmp");
            this.imageListPieces.Images.SetKeyName(4, "BishopW.bmp");
            this.imageListPieces.Images.SetKeyName(5, "BishopB.bmp");
            this.imageListPieces.Images.SetKeyName(6, "RookW.bmp");
            this.imageListPieces.Images.SetKeyName(7, "RookB.bmp");
            this.imageListPieces.Images.SetKeyName(8, "QueenW.bmp");
            this.imageListPieces.Images.SetKeyName(9, "QueenB.bmp");
            this.imageListPieces.Images.SetKeyName(10, "KingW.bmp");
            this.imageListPieces.Images.SetKeyName(11, "KingB.bmp");
            // 
            // ChessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ChessControl";
            this.Size = new System.Drawing.Size(480, 480);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>Image list for the chess pieces</summary>
        public System.Windows.Forms.ImageList imageListPieces;

    }
}
