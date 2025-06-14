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
    public partial class RuleDodgeMeteoritesScene : Form
    {
        Rectangle workingArea;
        public RuleDodgeMeteoritesScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddTotalElements();
            ManagerUI.AddRuleDodgeMeteoritesElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleDodgeMeteoritesScene.Size.Width, CanvasRuleDodgeMeteoritesScene.Size.Height));
        }

        private void RuleDodgeMeteoritesScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
            {
                ManagerUI.TotalElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleDodgeMeteoritesElements.Count; i++)
            {
                ManagerUI.RuleDodgeMeteoritesElements[i].DrawSprite(g);
            }
        }

        private void RuleDodgeMeteoritesScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOx, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Width, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                DodgeMeteorites dodgeMeteorites = new DodgeMeteorites();
                dodgeMeteorites.Opacity = 0;
                dodgeMeteorites.Show();
                dodgeMeteorites.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    dodgeMeteorites.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                dodgeMeteorites.FormClosed += (s, args) => { this.Close(); };
            }
        }
    }
}
