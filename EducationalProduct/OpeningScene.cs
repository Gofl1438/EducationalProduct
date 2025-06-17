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
    public partial class OpeningScene : Form
    {
        Rectangle workingArea;
        public OpeningScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddOpeningElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasOpeningScene.Size.Width, CanvasOpeningScene.Size.Height));
        }

        private void OpeningScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.OpeningElements.Count; i++)
            {
                ManagerUI.OpeningElements[i].DrawSprite(g);
            }
        }

        private void OpeningScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.OpeningScene.BtnStartPlay.PositionOx, GameConfig.OpeningScene.BtnStartPlay.PositionOy),
                new Size(GameConfig.OpeningScene.BtnStartPlay.Width, GameConfig.OpeningScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                RuleScene ruleScene = new RuleScene();
                ruleScene.Opacity = 0;

                ruleScene.FormClosed += (s, args) => { this.Close(); };

                ruleScene.Show();
                ruleScene.Refresh();

                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    ruleScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
            }
        }
    }
}
