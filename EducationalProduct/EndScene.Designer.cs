namespace EducationalProduct
{
    partial class EndScene
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
            CanvasEndScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasEndScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasEndScene
            // 
            CanvasEndScene.Dock = DockStyle.Fill;
            CanvasEndScene.Image = Properties.Resources.BackgroundEnd;
            CanvasEndScene.Location = new Point(0, 0);
            CanvasEndScene.Margin = new Padding(0);
            CanvasEndScene.Name = "CanvasEndScene";
            CanvasEndScene.Size = new Size(914, 600);
            CanvasEndScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasEndScene.TabIndex = 4;
            CanvasEndScene.TabStop = false;
            CanvasEndScene.Paint += EndScene_Paint;
            CanvasEndScene.MouseDown += EndScene_MouseDown;
            // 
            // EndScene
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(CanvasEndScene);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EndScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EndScene";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)CanvasEndScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasEndScene;
    }
}