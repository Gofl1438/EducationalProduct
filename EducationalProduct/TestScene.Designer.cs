namespace EducationalProduct
{
    partial class TestScene
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
            CanvasTestScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasTestScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasTestScene
            // 
            CanvasTestScene.Dock = DockStyle.Fill;
            CanvasTestScene.Image = Properties.Resources.Background;
            CanvasTestScene.Location = new Point(0, 0);
            CanvasTestScene.Margin = new Padding(0);
            CanvasTestScene.Name = "CanvasTestScene";
            CanvasTestScene.Size = new Size(800, 450);
            CanvasTestScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasTestScene.TabIndex = 4;
            CanvasTestScene.TabStop = false;
            CanvasTestScene.Paint += TestScene_Paint;
            CanvasTestScene.MouseDown += TestScene_MouseDown;
            // 
            // TestScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasTestScene);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "TestScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test";
            WindowState = FormWindowState.Maximized;
            FormClosed += TestScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasTestScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasTestScene;
    }
}