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
        int countNext;
        bool startGame;
        Rectangle workingArea;
        public RuleDodgeMeteoritesScene()
        {
            countNext = 0;
            startGame = false;
            InitializeComponent();
            StateExitMenu.Init();
            StateCurrentScene.Init();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleDodgeMeteoritesElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleDodgeMeteoritesScene.Size.Width, CanvasRuleDodgeMeteoritesScene.Size.Height));
        }

        private void RuleDodgeMeteoritesScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
            {
                ManagerUI.BtnClosedElement[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleDodgeMeteoritesElements.Count; i++)
            {
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i) || DialogManager.UpdateBackBtn(countNext, i))
                    continue;

                ManagerUI.RuleDodgeMeteoritesElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }

        private void RuleDodgeMeteoritesScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);
            CheckMouseDownNext(e);
            CheckMouseDownBack(e);

            if (StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene || StateNextBtn.CurrentNextBtnRuleDodgeMeteoritesScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOx, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Width, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnRuleDodgeMeteoritesScene = true;
                StateBackBtn.CurrentBackBtnRuleRepeatActionScene = true;
                StateCurrentScene.DodgeMeteoritesScene = true;
                StateAllScene.dodgeMeteorites = new DodgeMeteorites();
                StateAllScene.dodgeMeteorites.Opacity = 0;
                StateAllScene.dodgeMeteorites.Show();
                StateAllScene.dodgeMeteorites.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    StateAllScene.dodgeMeteorites.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                };
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleDodgeMeteoritesElements.Clear();
                StateAllScene.ruleDodgeMeteoritesScene.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }


        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRuleDodgeMeteoritesScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnRuleDodgeMeteoritesScene = true;
                StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene = false;
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
                        CanvasRuleDodgeMeteoritesScene.Invalidate();
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    ManagerUI.RuleDodgeMeteoritesElements.Clear();
                    StateAllScene.ruleDodgeMeteoritesScene.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene = false;
                CanvasRuleDodgeMeteoritesScene.Invalidate();
            }
        }

        private void CheckMouseDownNext(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.PositionOx, GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy),
            new Size(GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.Width, GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.Height)).Contains(e.Location))
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
                    StateNextBtn.CurrentNextBtnRuleDodgeMeteoritesScene = false;
                }

                CanvasRuleDodgeMeteoritesScene.Invalidate();
            }
        }

        private void CheckMouseDownBack(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.PositionOx, GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.PositionOy),
            new Size(GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.Width, GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.Height)).Contains(e.Location))
            {
                if (countNext > 0)
                {
                    countNext--;
                    startGame = false;

                    StateBackBtn.CurrentBackBtnRuleRepeatActionScene = false;

                    CanvasRuleDodgeMeteoritesScene.Invalidate();
                }
            }
        }

        private void RuleDodgeMeteoritesScene_FormClosed(object sender, FormClosedEventArgs e)
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
