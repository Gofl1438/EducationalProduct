namespace EducationalProduct
{
    partial class DodgeMeteorites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodgeMeteorites));
            CanvasDodgeMeteorites = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasDodgeMeteorites).BeginInit();
            SuspendLayout();
            // 
            // CanvasDodgeMeteorites
            // 
            CanvasDodgeMeteorites.Dock = DockStyle.Fill;
            CanvasDodgeMeteorites.Location = new Point(0, 0);
            CanvasDodgeMeteorites.Margin = new Padding(0);
            CanvasDodgeMeteorites.Name = "CanvasDodgeMeteorites";
            CanvasDodgeMeteorites.Size = new Size(800, 450);
            CanvasDodgeMeteorites.TabIndex = 0;
            CanvasDodgeMeteorites.TabStop = false;
            CanvasDodgeMeteorites.Paint += OnRepaint;
            CanvasDodgeMeteorites.MouseDown += CanvasDodgeMeteorites_MouseDown;
            CanvasDodgeMeteorites.MouseUp += CanvasDodgeMeteorites_MouseUp;
            // 
            // DodgeMeteorites
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasDodgeMeteorites);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DodgeMeteorites";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DodgeMeteorites";
            WindowState = FormWindowState.Maximized;
            FormClosed += DodgeMeteorites_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasDodgeMeteorites).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasDodgeMeteorites;
    }
}