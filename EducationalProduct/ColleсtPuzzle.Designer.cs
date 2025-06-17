namespace EducationalProduct
{
    partial class ColleсtPuzzle
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
            CanvasColleсtPuzzle = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasColleсtPuzzle).BeginInit();
            SuspendLayout();
            // 
            // CanvasColleсtPuzzle
            // 
            CanvasColleсtPuzzle.Dock = DockStyle.Fill;
            CanvasColleсtPuzzle.Location = new Point(0, 0);
            CanvasColleсtPuzzle.Margin = new Padding(0);
            CanvasColleсtPuzzle.Name = "CanvasColleсtPuzzle";
            CanvasColleсtPuzzle.Size = new Size(800, 450);
            CanvasColleсtPuzzle.TabIndex = 0;
            CanvasColleсtPuzzle.TabStop = false;
            CanvasColleсtPuzzle.Paint += OnRepaint;
            CanvasColleсtPuzzle.MouseDown += CanvasColleсtPuzzle_MouseDown;
            CanvasColleсtPuzzle.MouseMove += CanvasColleсtPuzzle_MouseMove;
            CanvasColleсtPuzzle.MouseUp += CanvasColleсtPuzzle_MouseUp;
            // 
            // ColleсtPuzzle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasColleсtPuzzle);
            DoubleBuffered = true;
            Name = "ColleсtPuzzle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ColleсtPuzzle";
            WindowState = FormWindowState.Maximized;
            FormClosed += ColleсtPuzzle_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasColleсtPuzzle).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasColleсtPuzzle;
    }
}