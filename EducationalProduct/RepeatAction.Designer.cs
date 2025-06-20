namespace EducationalProduct
{
    partial class RepeatAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepeatAction));
            CanvasRepeatAction = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)CanvasRepeatAction).BeginInit();
            SuspendLayout();
            // 
            // CanvasRepeatAction
            // 
            CanvasRepeatAction.Dock = DockStyle.Fill;
            CanvasRepeatAction.Location = new Point(0, 0);
            CanvasRepeatAction.Margin = new Padding(0);
            CanvasRepeatAction.Name = "CanvasRepeatAction";
            CanvasRepeatAction.Size = new Size(800, 450);
            CanvasRepeatAction.TabIndex = 0;
            CanvasRepeatAction.TabStop = false;
            CanvasRepeatAction.Paint += OnRepaint;
            CanvasRepeatAction.MouseDown += CanvasRepeatAction_MouseDown;
            // 
            // RepeatAction
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CanvasRepeatAction);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RepeatAction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RepeatAction";
            WindowState = FormWindowState.Maximized;
            FormClosed += RepeatAction_FormClosed;
            ((System.ComponentModel.ISupportInitialize)CanvasRepeatAction).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox CanvasRepeatAction;
    }
}