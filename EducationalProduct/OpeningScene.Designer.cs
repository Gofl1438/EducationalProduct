namespace EducationalProduct
{
    partial class OpeningScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpeningScene));
            CanvasOpeningScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasOpeningScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasOpeningScene
            // 
            CanvasOpeningScene.Dock = DockStyle.Fill;
            CanvasOpeningScene.Image = Properties.Resources.Background;
            CanvasOpeningScene.Location = new Point(0, 0);
            CanvasOpeningScene.Margin = new Padding(0);
            CanvasOpeningScene.Name = "CanvasOpeningScene";
            CanvasOpeningScene.Size = new Size(1279, 571);
            CanvasOpeningScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasOpeningScene.TabIndex = 0;
            CanvasOpeningScene.TabStop = false;
            CanvasOpeningScene.Paint += OpeningScene_Paint;
            CanvasOpeningScene.MouseDown += OpeningScene_MouseDown;
            // 
            // OpeningScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1279, 571);
            Controls.Add(CanvasOpeningScene);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "OpeningScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpeningScene";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)CanvasOpeningScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasOpeningScene;
    }
}