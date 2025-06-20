namespace EducationalProduct
{
    partial class CatchBones
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatchBones));
            CanvasCatchBones = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasCatchBones).BeginInit();
            SuspendLayout();
            // 
            // CanvasCatchBones
            // 
            CanvasCatchBones.Dock = DockStyle.Fill;
            CanvasCatchBones.Location = new Point(0, 0);
            CanvasCatchBones.Margin = new Padding(0);
            CanvasCatchBones.Name = "CanvasCatchBones";
            CanvasCatchBones.Size = new Size(982, 393);
            CanvasCatchBones.TabIndex = 0;
            CanvasCatchBones.TabStop = false;
            CanvasCatchBones.Paint += OnRepaint;
            CanvasCatchBones.MouseDown += CatchBones_MouseDown;
            // 
            // CatchBones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(982, 393);
            Controls.Add(CanvasCatchBones);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CatchBones";
            Text = "CatchBones";
            WindowState = FormWindowState.Maximized;
            FormClosed += CatchBones_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasCatchBones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasCatchBones;
    }
}