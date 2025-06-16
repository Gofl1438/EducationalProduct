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
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
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

            for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
            {
                ManagerUI.BtnClosedElement[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleDodgeMeteoritesElements.Count; i++)
            {
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i))
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

            if (StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene || StateNextBtn.CurrentNextBtnExitRuleDodgeMeteoritesScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOx, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Width, GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnExitRuleDodgeMeteoritesScene = true;
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
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleDodgeMeteoritesElements.Clear();
                dodgeMeteorites.FormClosed += (s, args) => { this.Close(); };
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
                StateNextBtn.CurrentNextBtnExitRuleDodgeMeteoritesScene = true;
                StateExitMenu.CurrentStateMenuExitRuleDodgeMeteoritesScene = false;
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                    CanvasRuleDodgeMeteoritesScene.Invalidate();
                }
                this.Hide();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleDodgeMeteoritesElements.Clear();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
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
                    StateNextBtn.CurrentNextBtnExitRuleDodgeMeteoritesScene = false;
                }

                CanvasRuleDodgeMeteoritesScene.Invalidate();
            }
        }
    }
}
