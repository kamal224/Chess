namespace SrcChess {
    partial class LostPiecesControl {
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
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LostPiecesControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "PawnW.bmp");
            this.imageList1.Images.SetKeyName(1, "PawnB.bmp");
            this.imageList1.Images.SetKeyName(2, "KnightW.bmp");
            this.imageList1.Images.SetKeyName(3, "KnightB.bmp");
            this.imageList1.Images.SetKeyName(4, "BishopW.bmp");
            this.imageList1.Images.SetKeyName(5, "BishopB.bmp");
            this.imageList1.Images.SetKeyName(6, "RookW.bmp");
            this.imageList1.Images.SetKeyName(7, "RookB.bmp");
            this.imageList1.Images.SetKeyName(8, "QueenW.bmp");
            this.imageList1.Images.SetKeyName(9, "QueenB.bmp");
            this.imageList1.Images.SetKeyName(10, "KingW.bmp");
            this.imageList1.Images.SetKeyName(11, "KingB.bmp");
            // 
            // LostPiecesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LostPiecesControl";
            this.Size = new System.Drawing.Size(316, 295);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
    }
}
