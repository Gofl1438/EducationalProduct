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
    public partial class RuleScene : Form
    {
        Rectangle workingArea;
        public RuleScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddOpeningElements();
            ManagerUI.AddRuleElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfigUI.Initialize(new Size(CanvasRuleScene.Size.Width, CanvasRuleScene.Size.Height));
        }

        private void RuleScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
            {
                ManagerUI.TotalElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleElements.Count; i++)
            {
                ManagerUI.RuleElements[i].DrawSprite(g);
            }
        }

        private void RuleScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfigUI.RuleScene.BtnStartPlay.PositionOx, GameConfigUI.RuleScene.BtnStartPlay.PositionOy),
                new Size(GameConfigUI.RuleScene.BtnStartPlay.Width, GameConfigUI.RuleScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                RuleScene ruleScene = new RuleScene();
                ruleScene.Opacity = 0;
                ruleScene.Show();
                ruleScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    ruleScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ruleScene.FormClosed += (s, args) => { this.Close(); };
            }
        }
    }
}
