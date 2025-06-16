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
        Bitmap _cachedBackground;
        public RuleScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleElements();
            DrawElementsUI();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleScene.Size.Width, CanvasRuleScene.Size.Height));
        }

        private void RuleScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerUI.RuleElements.Count; i++)
            {
                ManagerUI.RuleElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }
        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
                {
                    ManagerUI.BtnClosedElement[i].DrawSprite(bgGraphics);
                }
            }
            _cachedBackground = cachedBackground;
        }
        private void RuleScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);

            if (StateExitMenu.CurrentStateMenuExitRuleScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleScene.BtnStartPlay.PositionOx, GameConfig.RuleScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleScene.BtnStartPlay.Width, GameConfig.RuleScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                RuleRepeatActionScene ruleRepeatActionScene = new RuleRepeatActionScene();
                ruleRepeatActionScene.Opacity = 0;
                ruleRepeatActionScene.Show();
                ruleRepeatActionScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    ruleRepeatActionScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleElements.Clear();
                ruleRepeatActionScene.FormClosed += (s, args) => { this.Close(); };
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitRuleScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRuleScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitRuleScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitRuleScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateExitMenu.CurrentStateMenuExitRuleScene = false;
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                    CanvasRuleScene.Invalidate();
                }
                this.Hide();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleElements.Clear();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleScene = false;
                CanvasRuleScene.Invalidate();
            }
        }
    }
}
