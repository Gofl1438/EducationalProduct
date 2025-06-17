using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalProduct
{
    public partial class EndScene : Form
    {
        Rectangle workingArea;
        public EndScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddEndElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasEndScene.Size.Width, CanvasEndScene.Size.Height));
        }

        private void EndScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.EndElements.Count; i++)
            {
                ManagerUI.EndElements[i].DrawSprite(g);
            }
        }

        private void EndScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.EndScene.BtnToStart.PositionOx, GameConfig.EndScene.BtnToStart.PositionOy),
                new Size(GameConfig.EndScene.BtnToStart.Width, GameConfig.EndScene.BtnToStart.Height)).Contains(e.Location))
            {
                if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
                {
                    mainForm.Opacity = 0;
                    mainForm.Show();
                    mainForm.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        mainForm.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                        CanvasEndScene.Invalidate();
                    }
                    ManagerUI.EndElements.Clear();
                    this.Hide();
                    this.Dispose();
                }
            }
        }

        private void EndScene_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
            if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
            {
                mainForm.Dispose();
            }
            Application.Exit();
        }
    }
}
