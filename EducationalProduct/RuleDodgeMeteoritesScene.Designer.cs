namespace EducationalProduct
{
    partial class RuleDodgeMeteoritesScene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleDodgeMeteoritesScene));
            CanvasRuleDodgeMeteoritesScene = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRuleDodgeMeteoritesScene).BeginInit();
            SuspendLayout();
            // 
            // CanvasRuleDodgeMeteoritesScene
            // 
            CanvasRuleDodgeMeteoritesScene.Dock = DockStyle.Fill;
            CanvasRuleDodgeMeteoritesScene.Image = Properties.Resources.BackgroundCharacter;
            CanvasRuleDodgeMeteoritesScene.Location = new Point(0, 0);
            CanvasRuleDodgeMeteoritesScene.Margin = new Padding(0);
            CanvasRuleDodgeMeteoritesScene.Name = "CanvasRuleDodgeMeteoritesScene";
            CanvasRuleDodgeMeteoritesScene.Size = new Size(800, 450);
            CanvasRuleDodgeMeteoritesScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasRuleDodgeMeteoritesScene.TabIndex = 4;
            CanvasRuleDodgeMeteoritesScene.TabStop = false;
            CanvasRuleDodgeMeteoritesScene.Paint += RuleDodgeMeteoritesScene_Paint;
            CanvasRuleDodgeMeteoritesScene.MouseDown += RuleDodgeMeteoritesScene_MouseDown;
            // 
            // RuleDodgeMeteoritesScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasRuleDodgeMeteoritesScene);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RuleDodgeMeteoritesScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RuleDodgeMeteoritesScene";
            WindowState = FormWindowState.Maximized;
            FormClosed += RuleDodgeMeteoritesScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRuleDodgeMeteoritesScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRuleDodgeMeteoritesScene;
    }
}