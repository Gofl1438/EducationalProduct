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
    public partial class RuleCatchBonesScene : Form
    {
        int countNext;
        bool startGame;
        Rectangle workingArea;
        public RuleCatchBonesScene()
        {
            countNext = 0;
            startGame = false;
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleCatchBonesElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRuleCatchBonesScene.Size.Width, CanvasRuleCatchBonesScene.Size.Height));
        }

        private void RuleCatchBonesScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.BtnClosedElement.Count; i++)
            {
                ManagerUI.BtnClosedElement[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleCatchBonesElements.Count; i++)
            {
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext,i))
                    continue;

                ManagerUI.RuleCatchBonesElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }

        private void RuleCatchBonesScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);
            CheckMouseDownNext(e);

            if (StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene || StateNextBtn.CurrentNextBtnExitRuleCatchBonesScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleCatchBonesScene.BtnStartPlay.PositionOx, GameConfig.RuleCatchBonesScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleCatchBonesScene.BtnStartPlay.Width, GameConfig.RuleCatchBonesScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnExitRuleCatchBonesScene = true;
                CatchBones catchBones = new CatchBones();
                catchBones.Opacity = 0;
                catchBones.Show();
                catchBones.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    catchBones.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ManagerUI.BtnClosedElement.Clear();
                catchBones.FormClosed += (s, args) => { this.Close(); };
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene)
                {
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRuleCatchBonesScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateNextBtn.CurrentNextBtnExitRuleCatchBonesScene = true;
                StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene = false;
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                    CanvasRuleCatchBonesScene.Invalidate();
                }
                this.Hide();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleCatchBonesScene = false;
                CanvasRuleCatchBonesScene.Invalidate();
            }
        }

        private void CheckMouseDownNext(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.RuleCatchBonesScene.BtnNextPlay.PositionOx, GameConfig.RuleCatchBonesScene.BtnNextPlay.PositionOy),
            new Size(GameConfig.RuleCatchBonesScene.BtnNextPlay.Width, GameConfig.RuleCatchBonesScene.BtnNextPlay.Height)).Contains(e.Location))
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
                    StateNextBtn.CurrentNextBtnExitRuleCatchBonesScene = false;
                }

                CanvasRuleCatchBonesScene.Invalidate();
            }
        }
    }
}
