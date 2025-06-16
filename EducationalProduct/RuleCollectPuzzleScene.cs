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
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleCollectPuzzleElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
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
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i))
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

            if (StateExitMenu.CurrentStateMenuExitRuleCollectPuzzleScene || StateNextBtn.CurrentNextBtnExitRuleCollectPuzzleScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleCollectPuzzleScene.BtnStartPlay.PositionOx, GameConfig.RuleCollectPuzzleScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Width, GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnExitRuleCollectPuzzleScene = true;
                ColleсtPuzzle collectPuzzle = new ColleсtPuzzle();
                collectPuzzle.Opacity = 0;
                collectPuzzle.Show();
                collectPuzzle.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    collectPuzzle.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleCollectPuzzleElements.Clear();
                collectPuzzle.FormClosed += (s, args) => { this.Close(); };
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
                StateNextBtn.CurrentNextBtnExitRuleCollectPuzzleScene = true;
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                    CanvasRuleCollectPuzzleScene.Invalidate();
                }
                this.Close();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleCollectPuzzleElements.Clear();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
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
                    StateNextBtn.CurrentNextBtnExitRuleCollectPuzzleScene = false;
                }

                CanvasRuleCollectPuzzleScene.Invalidate();
            }
        }
    }
}
