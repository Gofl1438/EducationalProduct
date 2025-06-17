namespace EducationalProduct
{
    partial class RuleRepeatActionScene
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
            CanvasRuleRepeatActionScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRuleRepeatActionScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasRuleRepeatActionScene
            // 
            CanvasRuleRepeatActionScene.Dock = DockStyle.Fill;
            CanvasRuleRepeatActionScene.Image = Properties.Resources.Background;
            CanvasRuleRepeatActionScene.Location = new Point(0, 0);
            CanvasRuleRepeatActionScene.Margin = new Padding(0);
            CanvasRuleRepeatActionScene.Name = "CanvasRuleRepeatActionScene";
            CanvasRuleRepeatActionScene.Size = new Size(1359, 667);
            CanvasRuleRepeatActionScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasRuleRepeatActionScene.TabIndex = 1;
            CanvasRuleRepeatActionScene.TabStop = false;
            CanvasRuleRepeatActionScene.Paint += RuleRepeatActionScene_Paint;
            CanvasRuleRepeatActionScene.MouseDown += RuleRepeatActionScene_MouseDown;
            // 
            // RuleRepeatActionScene
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 667);
            Controls.Add(CanvasRuleRepeatActionScene);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RuleRepeatActionScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleRepeatAction";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleRepeatActionScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleRepeatActionScene;
    }
}