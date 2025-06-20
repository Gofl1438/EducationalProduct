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
            CanvasRuleRepeatActionScene.Image = Properties.Resources.BackgroundCharacter;
            CanvasRuleRepeatActionScene.Location = new Point(0, 0);
            CanvasRuleRepeatActionScene.Margin = new Padding(0);
            CanvasRuleRepeatActionScene.Name = "CanvasRuleRepeatActionScene";
            CanvasRuleRepeatActionScene.Size = new Size(1189, 500);
            CanvasRuleRepeatActionScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasRuleRepeatActionScene.TabIndex = 1;
            CanvasRuleRepeatActionScene.TabStop = false;
            CanvasRuleRepeatActionScene.Paint += RuleRepeatActionScene_Paint;
            CanvasRuleRepeatActionScene.MouseDown += RuleRepeatActionScene_MouseDown;
            // 
            // RuleRepeatActionScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 500);
            Controls.Add(CanvasRuleRepeatActionScene);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RuleRepeatActionScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleRepeatAction";
            WindowState = FormWindowState.Maximized;
            FormClosed += RuleRepeatActionScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleRepeatActionScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleRepeatActionScene;
    }
}