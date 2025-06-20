using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalProduct
{
    public partial class OpeningScene : Form
    {
        bool DevInfoMenuOpen;
        Rectangle workingArea;
        public OpeningScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddOpeningElements();
            DevInfoMenuOpen = false;
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasOpeningScene.Size.Width, CanvasOpeningScene.Size.Height));
        }

        private void OpeningScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.OpeningElements.Count; i++)
            {
                ManagerUI.OpeningElements[i].DrawSprite(g);
            }

            for (int i = 0; i < ManagerUI.TotalElementsMenuExitOpeningScene.Count; i++)
            {
                ManagerUI.TotalElementsMenuExitOpeningScene[i].DrawSprite(g);
            }

            for (int i = 0; i < ManagerUI.DevInfoMenuElements.Count; i++)
            {
                ManagerUI.DevInfoMenuElements[i].DrawSprite(g);
            }
        }

        private void OpeningScene_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);
            CheckMouseDownDevInfoMenu(e);

            if (StateExitMenu.CurrentStateMenuExitOpeningScene || DevInfoMenuOpen) return;

            if (StateOpeningScene.СurrentStateMenuClick)
            {
                StateOpeningScene.СurrentStateMenuClick = false;
                return;
            }

            if (new RectangleF(new PointF(GameConfig.OpeningScene.BtnStartPlay.PositionOx, GameConfig.OpeningScene.BtnStartPlay.PositionOy),
                new Size(GameConfig.OpeningScene.BtnStartPlay.Width, GameConfig.OpeningScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                StateAllScene.ruleScene = new RuleScene();
                StateAllScene.ruleScene.Opacity = 0;

                StateAllScene.ruleScene.Show();
                StateAllScene.ruleScene.Refresh();

                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    StateAllScene.ruleScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.CurrentStateMenuExitOpeningScene && !DevInfoMenuOpen)
                {
                    ManagerUI.AddTotalElementsMenuExitOpeningScene();
                    CanvasOpeningScene.Invalidate();
                    StateExitMenu.CurrentStateMenuExitOpeningScene = true;
                    StateOpeningScene.СurrentStateMenuClick = true;
                }
            }

            if (!StateExitMenu.CurrentStateMenuExitOpeningScene) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                this.Close();
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExitOpeningScene.Clear();
                StateExitMenu.CurrentStateMenuExitOpeningScene = false;
                CanvasOpeningScene.Invalidate();
                StateOpeningScene.СurrentStateMenuClick = true;
            }
        }

        private void CheckMouseDownDevInfoMenu(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.OpeningScene.BtnDevInfo.PositionOx, GameConfig.OpeningScene.BtnDevInfo.PositionOy),
               new Size(GameConfig.OpeningScene.BtnDevInfo.Width, GameConfig.OpeningScene.BtnDevInfo.Height)).Contains(e.Location))
            {
                if (!DevInfoMenuOpen && !StateExitMenu.CurrentStateMenuExitOpeningScene)
                {
                    MenuRuleCheck();
                }
            }

            if (!DevInfoMenuOpen) return;

            if (new RectangleF(new PointF(GameConfig.DevInfoMenu.ButtonApply.PositionOx, GameConfig.DevInfoMenu.ButtonApply.PositionOy),
                new Size(GameConfig.DevInfoMenu.ButtonApply.Width, GameConfig.DevInfoMenu.ButtonApply.Height)).Contains(e.Location))
            {
                ManagerUI.DevInfoMenuElements.Clear();
                CanvasOpeningScene.Invalidate();
                DevInfoMenuOpen = false;
            }
        }

        private void MenuRuleCheck()
        {
            ManagerUI.AddDevInfoMenuElements();
            CanvasOpeningScene.Invalidate();
            DevInfoMenuOpen = true;
        }
    }
}
