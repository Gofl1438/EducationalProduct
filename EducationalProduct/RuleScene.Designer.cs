namespace EducationalProduct
{
    partial class RuleScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleScene));
            CanvasRuleScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRuleScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasRuleScene
            // 
            CanvasRuleScene.Dock = DockStyle.Fill;
            CanvasRuleScene.Image = Properties.Resources.BackgroundCharacter;
            CanvasRuleScene.Location = new Point(0, 0);
            CanvasRuleScene.Margin = new Padding(0);
            CanvasRuleScene.Name = "CanvasRuleScene";
            CanvasRuleScene.Size = new Size(1201, 539);
            CanvasRuleScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasRuleScene.TabIndex = 0;
            CanvasRuleScene.TabStop = false;
            CanvasRuleScene.Paint += RuleScene_Paint;
            CanvasRuleScene.MouseDown += RuleScene_MouseDown;
            // 
            // RuleScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 539);
            Controls.Add(CanvasRuleScene);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RuleScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleScene";
            WindowState = FormWindowState.Maximized;
            FormClosed += RuleScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleScene;
    }
}