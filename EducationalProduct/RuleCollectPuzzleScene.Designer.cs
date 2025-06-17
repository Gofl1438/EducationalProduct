namespace EducationalProduct
{
    partial class RuleCollectPuzzleScene
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
            CanvasRuleCollectPuzzleScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRuleCollectPuzzleScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasRuleCollectPuzzleScene
            // 
            CanvasRuleCollectPuzzleScene.Dock = DockStyle.Fill;
            CanvasRuleCollectPuzzleScene.Image = Properties.Resources.Background;
            CanvasRuleCollectPuzzleScene.Location = new Point(0, 0);
            CanvasRuleCollectPuzzleScene.Margin = new Padding(0);
            CanvasRuleCollectPuzzleScene.Name = "CanvasRuleCollectPuzzleScene";
            CanvasRuleCollectPuzzleScene.Size = new Size(914, 600);
            CanvasRuleCollectPuzzleScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasRuleCollectPuzzleScene.TabIndex = 3;
            CanvasRuleCollectPuzzleScene.TabStop = false;
            CanvasRuleCollectPuzzleScene.Paint += RuleCollectPuzzleScene_Paint;
            CanvasRuleCollectPuzzleScene.MouseDown += RuleCCollectPuzzleScene_MouseDown;
            // 
            // RuleCollectPuzzleScene
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(CanvasRuleCollectPuzzleScene);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RuleCollectPuzzleScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleCollectPuzzleScene";
            WindowState = FormWindowState.Maximized;
            FormClosed += RuleCollectPuzzleScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleCollectPuzzleScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleCollectPuzzleScene;
    }
}