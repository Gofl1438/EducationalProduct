﻿namespace EducationalProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndScene));
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
            CanvasEndScene.Size = new Size(800, 450);
            CanvasEndScene.SizeMode = PictureBoxSizeMode.StretchImage;
            CanvasEndScene.TabIndex = 4;
            CanvasEndScene.TabStop = false;
            CanvasEndScene.Paint += EndScene_Paint;
            CanvasEndScene.MouseDown += EndScene_MouseDown;
            // 
            // EndScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasEndScene);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EndScene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EndScene";
            WindowState = FormWindowState.Maximized;
            FormClosed += EndScene_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasEndScene).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasEndScene;
    }
}