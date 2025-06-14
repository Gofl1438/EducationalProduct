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
    public partial class RuleRepeatActionScene : Form
    {
        Rectangle workingArea;
        Bitmap _cachedBackground;
        public RuleRepeatActionScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddBtnClosedElement();
            ManagerUI.AddRuleRepeatActionElements();
            DrawElementsUI();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
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

            if (StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene) return;

            if (new RectangleF(new PointF(GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOx, GameConfig.RuleRepeatActionScene.BtnStartPlay.PositionOy),
            new Size(GameConfig.RuleRepeatActionScene.BtnStartPlay.Width, GameConfig.RuleRepeatActionScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                RepeatAction repeatAction = new RepeatAction();
                repeatAction.Opacity = 0;
                repeatAction.Show();
                repeatAction.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    repeatAction.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleRepeatActionElements.Clear();
                repeatAction.FormClosed += (s, args) => { this.Close(); };
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
                StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene = false;
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                    CanvasRuleRepeatActionScene.Invalidate();
                }
                this.Hide();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerUI.BtnClosedElement.Clear();
                ManagerUI.RuleRepeatActionElements.Clear();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.CurrentStateMenuExitRuleRepeatActionScene = false;
                CanvasRuleRepeatActionScene.Invalidate();
            }
        }
    }
}
