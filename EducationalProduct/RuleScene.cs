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
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct
{
    public partial class RuleScene : Form
    {
        Rectangle workingArea;
        Bitmap _cachedBackground;
        public RuleScene()
        {
            InitializeComponent();
            StateExitMenu.Init();
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
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleElements.Clear();
                _cachedBackground.Dispose();
                this.Hide();
                this.Dispose();
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
                if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
                {
                    mainForm.Opacity = 0;
                    mainForm.Show();
                    mainForm.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        mainForm.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                        CanvasRuleScene.Invalidate();
                    }
                    ManagerUI.TotalElementsMenuExit.Clear();
                    ManagerUI.BtnClosedElement.Clear();
                    ManagerUI.RuleElements.Clear();
                    _cachedBackground.Dispose();
                    this.Hide();
                    this.Dispose();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleScene = false;
                CanvasRuleScene.Invalidate();
            }
        }

        private void RuleScene_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cachedBackground.Dispose();
            if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
            {
                mainForm.Dispose();
            }
            Application.Exit();
        }
    }
}
