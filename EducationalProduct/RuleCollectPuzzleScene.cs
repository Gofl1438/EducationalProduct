﻿using EducationalProduct.Classes;
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
    public partial class RuleCollectPuzzleScene : Form
    {
        int countNext;
        bool startGame;
        Rectangle workingArea;
        public RuleCollectPuzzleScene()
        {
            countNext = 0;
            startGame = false;
            InitializeComponent();
            StateExitMenu.Init();
            StateCurrentScene.Init();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleCollectPuzzleElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleCollectPuzzleScene.Size.Width, CanvasRuleCollectPuzzleScene.Size.Height));
        }

        private void RuleCollectPuzzleScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
            {
                ManagerUI.BtnClosedElement[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleCollectPuzzleElements.Count; i++)
            {
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i) || DialogManager.UpdateBackBtn(countNext, i))
                    continue;

                ManagerUI.RuleCollectPuzzleElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }

        private void RuleCCollectPuzzleScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);
            CheckMouseDownNext(e);
            CheckMouseDownBack(e);

            if (StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene || StateNextBtn.CurrentNextBtnRuleCollectPuzzleScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleCollectPuzzleScene.BtnStartPlay.PositionOx, GameConfig.RuleCollectPuzzleScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Width, GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnRuleCollectPuzzleScene = true;
                StateCurrentScene.CollectPuzzleScene = true;
                StateAllScene.colleсtPuzzle = new ColleсtPuzzle();
                StateAllScene.colleсtPuzzle.Opacity = 0;
                StateAllScene.colleсtPuzzle.Show();
                StateAllScene.colleсtPuzzle.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    StateAllScene.colleсtPuzzle.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleCollectPuzzleElements.Clear();
                StateAllScene.ruleCollectPuzzleScene.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRuleCollectPuzzleScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene = false;
                StateNextBtn.CurrentNextBtnRuleCollectPuzzleScene = true;
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
                        CanvasRuleCollectPuzzleScene.Invalidate();
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    ManagerUI.RuleCollectPuzzleElements.Clear();
                    StateAllScene.ruleCollectPuzzleScene.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene = false;
                CanvasRuleCollectPuzzleScene.Invalidate();
            }
        }
        private void CheckMouseDownNext(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleCollectPuzzleScene.BtnNextPlay.PositionOx, GameConfig.RuleCollectPuzzleScene.BtnNextPlay.PositionOy),
            new Size(GameConfig.RuleCollectPuzzleScene.BtnNextPlay.Width, GameConfig.RuleCollectPuzzleScene.BtnNextPlay.Height)).Contains(e.Location))
            {
                if (!startGame && !StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene)
                {
                    StateNextBtn.CurrentNextBtnRuleCollectPuzzleScene = true;
                    countNext++;

                    if (countNext == 2)
                    {
                        startGame = true;
                    }
                }
                else
                {
                    StateNextBtn.CurrentNextBtnRuleCollectPuzzleScene = false;
                }

                CanvasRuleCollectPuzzleScene.Invalidate();
            }
        }
        private void CheckMouseDownBack(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleCollectPuzzleScene.BtnBackPlay.PositionOx, GameConfig.RuleCollectPuzzleScene.BtnBackPlay.PositionOy),
            new Size(GameConfig.RuleCollectPuzzleScene.BtnBackPlay.Width, GameConfig.RuleCollectPuzzleScene.BtnBackPlay.Height)).Contains(e.Location))
            {
                if (countNext > 0 && !StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene)
                {
                    countNext--;
                    startGame = false;

                    StateBackBtn.CurrentBackBtnRuleRepeatActionScene = false;

                    CanvasRuleCollectPuzzleScene.Invalidate();
                }
            }
        }

        private void RuleCollectPuzzleScene_FormClosed(object sender, FormClosedEventArgs e)
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
