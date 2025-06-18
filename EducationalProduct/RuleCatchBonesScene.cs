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
            StateExitMenu.Init();
            StateCurrentScene.Init();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleCatchBonesElements();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
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
                if (DialogManager.UpdateNextBtn(startGame, i) || DialogManager.UpdateDialog(countNext, i))
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
                StateCurrentScene.CatchBonesScene = true;
                CatchBones catchBones = new CatchBones();
                catchBones.Opacity = 0;
                catchBones.Show();
                catchBones.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    catchBones.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                ManagerUI.BtnClosedElement.Clear();
                this.Hide();
                this.Dispose();
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
                        CanvasRuleCatchBonesScene.Invalidate();
                    }
                    ManagerUI.BtnClosedElement.Clear();
                    this.Hide();
                    this.Dispose();
                }
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

        private void RuleCatchBonesScene_FormClosed(object sender, FormClosedEventArgs e)
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
