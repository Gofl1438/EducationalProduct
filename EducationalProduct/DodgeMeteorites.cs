﻿using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites;

namespace EducationalProduct
{
    public partial class DodgeMeteorites : Form
    {
        RocketDodge rocket;
        Bitmap _cachedBackground;
        Bitmap _cachedButton;
        Bitmap _cachedButtonUI;
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        private bool IsButtonPressed = false;
        private bool IsMouseOverLeftButton = false;
        private bool IsMouseOverRightButton = false;
        private bool _touchActive;
        private Point _lastTouchPos;

        public DodgeMeteorites()
        {
            InitializeComponent();
            StateDodgeMeteorites.Init();
            StateRuleMenu.Init();
            StateExitMenu.Init();
            СalibrationSize();
            ManagerUI.AddDodgeMeteoritesElements();
            ManagerUI.AddTotalElements();
            DrawElementsUI();
            ManagerDodgeMeteorites.AddMeteoritesNormal();
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            rocket = new RocketDodge();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }
        private void СalibrationSize()
        {
            workingArea = Screen.PrimaryScreen.Bounds;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasDodgeMeteorites.Size.Width, CanvasDodgeMeteorites.Size.Height));
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
            {
                if (ManagerDodgeMeteorites.Meteorites[i].IsVisible)
                {
                    ManagerDodgeMeteorites.Meteorites[i].DrawSprite(g);
                }
            }
            if (rocket.IsVisible)
            {
                rocket.DrawSprite(g);
            }
            DrawResult(g);
            g.DrawImage(_cachedButton, 0, 0);
            g.DrawImage(_cachedButtonUI, 0, 0);
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleElementsDodgeMeteorites.Count; i++)
            {
                ManagerUI.RuleElementsDodgeMeteorites[i].DrawSprite(g);
            }
        }

        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButton = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButtonUI = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.DodgeMeteoritesElementsBd.Count; i++)
                {
                    ManagerUI.DodgeMeteoritesElementsBd[i].DrawSprite(bgGraphics);
                }
            }
            using (var bgGraphics = Graphics.FromImage(cachedButton))
            {
                for (int i = 0; i < ManagerUI.DodgeMeteoritesElementsBn.Count; i++)
                {
                    ManagerUI.DodgeMeteoritesElementsBn[i].DrawSprite(bgGraphics);
                }
            }
            using (var bgGraphics = Graphics.FromImage(cachedButtonUI))
            {
                for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
                {
                    ManagerUI.TotalElements[i].DrawSprite(bgGraphics);
                }
            }
            _cachedButtonUI = cachedButtonUI;
            _cachedBackground = cachedBackground;
            _cachedButton = cachedButton;
        }

        private void Update(object sender, EventArgs e)
        {
            if (StateExitMenu.СurrentStateMenuExitDodgeMeteorites) return;

            if (StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites) return;

            rocket.Physics.CheckCollideWithMeteorites();

            if (!StateDodgeMeteorites.SingleView)
            {
                MenuRuleCheck();
                StateDodgeMeteorites.SingleView = true;
            }

            if (rocket.Physics.IsWasHit)
            {
                if (!StateDodgeMeteorites.IsNotCallGameOverAwait)
                {
                    GameOver();
                    StateDodgeMeteorites.IsNotCallGameOverAwait = true;
                }
            }
            else
            {
                for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
                {
                    ManagerDodgeMeteorites.Meteorites[i].Physics.MoveOyMeteorite();
                }
                if (IsMouseOverLeftButton)
                    rocket.Physics.MoveOxLeft();
                else if (IsMouseOverRightButton)
                    rocket.Physics.MoveOxRight();
                ManagerDodgeMeteorites.DeleteMeteorites();
                СompletedMeteorites();
                CanvasDodgeMeteorites.Invalidate();
                if (StateDodgeMeteorites.CurrentСompletedMeteorites == GameConfig.DodgeMeteorites.Meteorite.DefaultQuantityMeteorites)
                {
                    if (!StateDodgeMeteorites.RocketSoundPlayer)
                    {
                        using (var player = new SoundPlayer(Properties.Resources.CollectPuzzleSingleRocketTakeoff))
                        {
                            ManagerSound.activePlayersDodgeMeteorite.Add(player);
                            player.Play();
                        }
                        StateDodgeMeteorites.RocketSoundPlayer = true;
                    }
                    if (!StateDodgeMeteorites.IsRocketDisappear)
                    {
                        rocket.Physics.MoveDisappear();
                        if (rocket.Transform.Position.Y + Rocket.Size.Height < 0)
                        {
                            StateDodgeMeteorites.IsRocketDisappear = true;
                        }
                    }
                    else
                    {
                        if (!StateTransitonScene.IsNotCallDodgeMeteoritesAwait)
                        {
                            Await();
                            StateTransitonScene.IsNotCallDodgeMeteoritesAwait = true;
                        }
                        if (StateTransitonScene.IsTransitonDodgeMeteoritesAwait)
                        {
                            timer.Stop();
                            timer.Tick -= Update;
                            timer.Dispose();
                            StateAllScene.testScene = new TestScene(); //указать нужную сцену//
                            StateAllScene.testScene.Opacity = 0;
                            StateAllScene.testScene.Show();
                            StateAllScene.testScene.Refresh();
                            for (double opacity = 0; opacity <= 1; opacity += 0.1)
                            {
                                StateAllScene.testScene.Opacity = opacity;
                                System.Threading.Thread.Sleep(16);
                            }
                            rocket.Dispose();
                            ManagerDodgeMeteorites.Dispose();
                            ManagerUI.DodgeMeteoritesElementsBd.Clear();
                            ManagerUI.DodgeMeteoritesElementsBn.Clear();
                            ManagerSound.DeleteActivePlayersDodgeMeteorites();
                            _cachedBackground.Dispose();
                            _cachedButton.Dispose();
                            _cachedButtonUI.Dispose();
                            StateAllScene.dodgeMeteorites.Dispose();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }
                }
            }
            if (_touchActive || SystemInformation.MouseButtonsSwapped)
            {
                CheckTouchControls();
            }
        }

        private void CheckTouchControls()
        {
            var currentPos = CanvasDodgeMeteorites.PointToClient(Cursor.Position);

            if (currentPos != _lastTouchPos)
            {
                _lastTouchPos = currentPos;
                CheckMouseOverButtons(currentPos);
            }
        }

        private void CanvasDodgeMeteorites_MouseDown(object sender, MouseEventArgs e)
        {
            _touchActive = true;
            _lastTouchPos = e.Location;

            if (!StateExitMenu.СurrentStateMenuExitDodgeMeteorites)
            {
                CheckMouseDownRule(e);
            }

            if (!StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites)
            {
                CheckMouseDownExit(e);
            }

            if (StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites) return;

            if (StateExitMenu.СurrentStateMenuExitDodgeMeteorites) return;

            if (StateDodgeMeteorites.СurrentStateMenuClick)
            {
                StateDodgeMeteorites.СurrentStateMenuClick = false;
                return;
            }
            CheckMouseOverButtons(e.Location);
        }

        private void CanvasDodgeMeteorites_MouseUp(object sender, MouseEventArgs e)
        {
            _touchActive = false;

            if (StateExitMenu.СurrentStateMenuExitDodgeMeteorites) return;

            IsMouseOverLeftButton = false;
            IsMouseOverRightButton = false;
        }


        private void CheckMouseOverButtons(Point mousePos)
        {
            IsMouseOverLeftButton = new RectangleF(
                new PointF(ButtonMove.Left.PositionOx, ButtonMove.Left.PositionOy),
                new Size(ButtonMove.Width, ButtonMove.Height)
            ).Contains(mousePos);
            IsMouseOverRightButton = new RectangleF(
                new PointF(ButtonMove.Right.PositionOx, ButtonMove.Right.PositionOy),
                new Size(ButtonMove.Width, ButtonMove.Height)
            ).Contains(mousePos);
        }

        private async Task Await()
        {
            await Task.Delay(1500);
            StateTransitonScene.IsTransitonDodgeMeteoritesAwait = true;
        }

        private async Task GameOver()
        {
            int blinkCount = 5;
            int blinkDelay = 100;
            using (var player = new SoundPlayer(Properties.Resources.DodgeMeteoriteCrashRocket))
            {
                ManagerSound.activePlayersDodgeMeteorite.Add(player);
                player.Play();
            }
            for (int i = 0; i < blinkCount; i++)
            {
                bool visible = (i % 2 == 0);

                for (int j = 0; j < ManagerDodgeMeteorites.Meteorites.Count; j++)
                {
                    ManagerDodgeMeteorites.Meteorites[j].IsVisible = visible;
                }
                rocket.IsVisible = visible;
                CanvasDodgeMeteorites.Invalidate();
                await Task.Delay(blinkDelay);
            }
            ManagerDodgeMeteorites.AddMeteoritesNormal();
            StateDodgeMeteorites.CurrentСompletedMeteorites = 0;
            rocket = new RocketDodge();
            StateDodgeMeteorites.IsNotCallGameOverAwait = false;
            using (var player = new SoundPlayer(Properties.Resources.DodgeMeteoriteSoundLight))
            {
                ManagerSound.activePlayersDodgeMeteorite.Add(player);
                player.PlayLooping();
            }
        }

        private void DrawResult(Graphics g)
        {
            string text = $"{StateDodgeMeteorites.CurrentСompletedMeteorites} из {GameConfig.DodgeMeteorites.Meteorite.DefaultQuantityMeteorites}";
            using (Font font = new Font(GameConfig.NumberPointsDodgeMeteorites.pfc.Families[0], GameConfig.NumberPointsDodgeMeteorites.SizeResult, GameConfig.NumberPointsDodgeMeteorites.StyleResult))
            {
                g.DrawString(text, font, GameConfig.NumberPointsDodgeMeteorites.shadowBrush, GameConfig.NumberPointsDodgeMeteorites.shadowRect, GameConfig.NumberPointsDodgeMeteorites.format);

                g.DrawString(text, font, GameConfig.NumberPointsDodgeMeteorites.CustomBrush, GameConfig.NumberPointsDodgeMeteorites.rectangleResult, GameConfig.NumberPointsDodgeMeteorites.format);
            }
        }

        private void СompletedMeteorites()
        {
            for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
            {
                var meteorites = ManagerDodgeMeteorites.Meteorites[i];
                if (meteorites.Transform.Position.Y > rocket.Transform.Position.Y + Rocket.Height
                    && !meteorites.СompletedMeteorites)
                {
                    StateDodgeMeteorites.CurrentСompletedMeteorites++;
                    ManagerDodgeMeteorites.Meteorites[i].СompletedMeteorites = true;
                }
            }
        }

        private void CheckMouseDownRule(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnQuestion.PositionOx, GameConfig.TotalElement.BtnQuestion.PositionOy),
               new Size(GameConfig.TotalElement.BtnQuestion.Width, GameConfig.TotalElement.BtnQuestion.Height)).Contains(e.Location))
            {
                if (!StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites)
                {
                    ManagerUI.AddRuleElementsDodgeMeteorites();
                    ManagerSound.DeleteActivePlayersDodgeMeteorites();
                    CanvasDodgeMeteorites.Invalidate();
                    StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites = true;
                    StateDodgeMeteorites.СurrentStateMenuClick = true;
                }
            }

            if (!StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites) return;

            if (new RectangleF(new PointF(GameConfig.RuleInfScene.ButtonApply.PositionOx, GameConfig.RuleInfScene.ButtonApply.PositionOy),
                new Size(GameConfig.RuleInfScene.ButtonApply.Width, GameConfig.RuleInfScene.ButtonApply.Height)).Contains(e.Location))
            {
                ManagerUI.RuleElementsDodgeMeteorites.Clear();
                StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites = false;
                StateDodgeMeteorites.СurrentStateMenuClick = true;
                using (var player = new SoundPlayer(Properties.Resources.DodgeMeteoriteSoundLight))
                {
                    ManagerSound.activePlayersDodgeMeteorite.Add(player);
                    player.PlayLooping();
                }
            }
        }

        private void MenuRuleCheck()
        {
            ManagerUI.AddRuleElementsDodgeMeteorites();
            ManagerSound.DeleteActivePlayersDodgeMeteorites();
            CanvasDodgeMeteorites.Invalidate();
            StateRuleMenu.СurrentStateMenuRuleDodgeMeteorites = true;
            StateDodgeMeteorites.СurrentStateMenuClick = true;
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.СurrentStateMenuExitDodgeMeteorites)
                {
                    ManagerSound.DeleteActivePlayersDodgeMeteorites();
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasDodgeMeteorites.Invalidate();
                    StateDodgeMeteorites.СurrentStateMenuClick = true;
                    StateExitMenu.СurrentStateMenuExitDodgeMeteorites = true;
                }
            }

            if (!StateExitMenu.СurrentStateMenuExitDodgeMeteorites) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateDodgeMeteorites.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitDodgeMeteorites = false;
                timer.Stop();
                timer.Tick -= Update;
                timer.Dispose();
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
                        CanvasDodgeMeteorites.Invalidate();
                    }
                    rocket.Dispose();
                    ManagerDodgeMeteorites.Dispose();
                    ManagerUI.DodgeMeteoritesElementsBd.Clear();
                    ManagerUI.DodgeMeteoritesElementsBn.Clear();
                    ManagerSound.DeleteActivePlayersDodgeMeteorites();
                    _cachedBackground.Dispose();
                    _cachedButton.Dispose();
                    _cachedButtonUI.Dispose();
                    StateAllScene.dodgeMeteorites.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateDodgeMeteorites.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitDodgeMeteorites = false;
                using (var player = new SoundPlayer(Properties.Resources.DodgeMeteoriteSoundLight))
                {
                    ManagerSound.activePlayersDodgeMeteorite.Add(player);
                    player.PlayLooping();
                }
            }
        }

        private void DodgeMeteorites_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagerDodgeMeteorites.Dispose();
            rocket.Dispose();
            timer.Stop();
            timer.Tick -= Update;
            timer.Dispose();
            _cachedBackground.Dispose();
            _cachedButton.Dispose();
            _cachedButtonUI.Dispose();
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
