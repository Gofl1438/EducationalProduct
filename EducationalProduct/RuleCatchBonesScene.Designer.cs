namespace EducationalProduct
{
    partial class RuleCatchBonesScene
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
            CanvasRuleCatchBonesScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRuleCatchBonesScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasRuleCatchBonesScene
            // 
            CanvasRuleCatchBonesScene.BackgroundImage = Properties.Resources.Background;
            CanvasRuleCatchBonesScene.Dock = DockStyle.Fill;
            CanvasRuleCatchBonesScene.Location = new Point(0, 0);
            CanvasRuleCatchBonesScene.Margin = new Padding(0);
            CanvasRuleCatchBonesScene.Name = "CanvasRuleCatchBonesScene";
            CanvasRuleCatchBonesScene.Size = new Size(800, 450);
            CanvasRuleCatchBonesScene.TabIndex = 2;
            CanvasRuleCatchBonesScene.TabStop = false;
            CanvasRuleCatchBonesScene.Paint += RuleCatchBonesScene_Paint;
            CanvasRuleCatchBonesScene.MouseDown += RuleCatchBonesScene_MouseDown;
            // 
            // RuleCatchBonesScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasRuleCatchBonesScene);
            Name = "RuleCatchBonesScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleCatchBonesScene";
            WindowState = FormWindowState.Maximized;
            FormClosed += RuleCatchBonesScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleCatchBonesScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleCatchBonesScene;
    }
}