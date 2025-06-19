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
        int countNext;
        bool startGame;
        Rectangle workingArea;
        Bitmap _cachedBackground;
        public RuleRepeatActionScene()
        {
            countNext = 0;
            startGame = false;
            InitializeComponent();
            StateExitMenu.Init();
            StateCurrentScene.Init();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleRepeatActionElements();
            DrawElementsUI();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleRepeatActionScene.Size.Width, CanvasRuleRepeatActionScene.Size.Height));
        }

        private void RuleRepeatActionScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerUI.RuleRepeatActionElements.Count; i++)
            {
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i) || DialogManager.UpdateBackBtn(countNext, i))
                    continue;

                ManagerUI.RuleRepeatActionElements[i].DrawSprite(g);
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

        private void RuleRepeatActionScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);
            CheckMouseDownNext(e);
            CheckMouseDownBack(e);

            if (StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene || StateNextBtn.CurrentNextBtnRuleRepeatActionScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOx, GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleRepeatActionScene.BtnStartPlay.Width, GameConfig.RuleRepeatActionScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnRuleRepeatActionScene = true;
                StateBackBtn.CurrentBackBtnRuleRepeatActionScene = true;
                StateCurrentScene.RepeatActionScene = true;
                StateAllScene.repeatAction = new RepeatAction();
                StateAllScene.repeatAction.Opacity = 0;
                StateAllScene.repeatAction.Show();
                StateAllScene.repeatAction.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    StateAllScene.repeatAction.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleRepeatActionElements.Clear();
                _cachedBackground.Dispose();
                StateAllScene.ruleRepeatActionScene.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRuleRepeatActionScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnRuleRepeatActionScene = true;
                StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene = false;
                if (Application.OpenForms.OfType<OpeningScene>().FirstOrDefault() is OpeningScene mainForm)
                {
                    ManagerUI.TotalElementsMenuExit.Clear();
                    mainForm.Opacity = 0;
                    mainForm.Show();
                    mainForm.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        mainForm.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                        CanvasRuleRepeatActionScene.Invalidate();
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    ManagerUI.RuleRepeatActionElements.Clear();
                    _cachedBackground.Dispose();
                    StateAllScene.ruleRepeatActionScene.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene = false;
                CanvasRuleRepeatActionScene.Invalidate();
            }
        }

        private void CheckMouseDownNext(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleRepeatActionScene.BtnNextPlay.PositionOx, GameConfig.RuleRepeatActionScene.BtnNextPlay.PositionOy),
            new Size(GameConfig.RuleRepeatActionScene.BtnNextPlay.Width, GameConfig.RuleRepeatActionScene.BtnNextPlay.Height)).Contains(e.Location))
            {
                if (!startGame)
                {
                    countNext++;

                    if (countNext == 2)
                    {
                        startGame = true;
                    }
                }
                else
                {
                    StateNextBtn.CurrentNextBtnRuleRepeatActionScene = false;
                }

                CanvasRuleRepeatActionScene.Invalidate();
            }
        }

        private void CheckMouseDownBack(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleRepeatActionScene.BtnBackPlay.PositionOx, GameConfig.RuleRepeatActionScene.BtnBackPlay.PositionOy),
            new Size(GameConfig.RuleRepeatActionScene.BtnBackPlay.Width, GameConfig.RuleRepeatActionScene.BtnBackPlay.Height)).Contains(e.Location))
            {
                if (countNext > 0)
                {
                    countNext--;
                    startGame = false;

                    StateBackBtn.CurrentBackBtnRuleRepeatActionScene = false;

                    CanvasRuleRepeatActionScene.Invalidate();
                }
            }
        }

        private void RuleRepeatActionScene_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cachedBackground.Dispose();
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
