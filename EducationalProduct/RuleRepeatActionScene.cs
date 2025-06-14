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
    public partial class RuleRepeatActionScene : Form
    {
        Rectangle workingArea;
        public RuleRepeatActionScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddOpeningElements();
            ManagerUI.AddRuleRepeatActionElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleRepeatActionScene.Size.Width, CanvasRuleRepeatActionScene.Size.Height));
        }

        private void RuleRepeatActionScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
            {
                ManagerUI.TotalElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleRepeatActionElements.Count; i++)
            {
                ManagerUI.RuleRepeatActionElements[i].DrawSprite(g);
            }
        }

        private void RuleRepeatActionScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOx, GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleRepeatActionScene.BtnStartPlay.Width, GameConfig.RuleRepeatActionScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                RepeatAction repeatAction = new RepeatAction();
                repeatAction.Opacity = 0;
                repeatAction.Show();
                repeatAction.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    repeatAction.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                repeatAction.FormClosed += (s, args) => { this.Close(); };
            }
        }
    }
}
