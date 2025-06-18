using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationalProduct
{
    public partial class RepeatAction : Form
    {
        System.Windows.Forms.Timer timer;
        Bitmap _cachedBackground;
        Bitmap _cachedButtonUI;
        Rectangle workingArea;

        public RepeatAction()
        {
            InitializeComponent();
            StateRepeatButton.Init();
            StateTransitonScene.Init();
            StateRuleMenu.Init();
            StateExitMenu.Init();
            СalibrationSize();
            ManagerUI.AddRepeatActionElements();
            ManagerUI.AddTotalElements();
            ManagerButtonRepeat.AddDefaultButtonsRepeat();
            DrawElementsUI();
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
            GameConfig.Initialize(new Size(CanvasRepeatAction.Size.Width, CanvasRepeatAction.Size.Height));
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerButtonRepeat.ButtonRepeat.Count; i++)
            {
                ManagerButtonRepeat.ButtonRepeat[i].DrawSprite(g);
            }
            DrawResult(g);
            g.DrawImage(_cachedButtonUI, 0, 0);
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleElementsRepeatAction.Count; i++)
            {
                ManagerUI.RuleElementsRepeatAction[i].DrawSprite(g);
            }
        }

        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButtonUI = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.RepeatActionElements.Count; i++)
                {
                    ManagerUI.RepeatActionElements[i].DrawSprite(bgGraphics);
                }
            }
            using (var bgGraphics = Graphics.FromImage(cachedButtonUI))
            {
                for (int i = 0; i < ManagerUI.TotalElements.Count; i++)
                {
                    ManagerUI.TotalElements[i].DrawSprite(bgGraphics);
                }
            }
            _cachedBackground = cachedBackground;
            _cachedButtonUI = cachedButtonUI;
        }

        private void Update(object sender, EventArgs e)
        {
            if (StateExitMenu.СurrentStateMenuExitRepeatAction) return;

            if (StateRuleMenu.СurrentStateMenuRuleRepeatAction) return;

            if (!StateTransitonScene.IsTransitonRepeatActionAwaitOpening)
            {
                if (!StateTransitonScene.IsNotCallRepeatActionAwaitOpening)
                {
                    if (!StateRepeatButton.SingleView)
                    {
                        MenuRuleCkeck();
                        StateRepeatButton.SingleView = true;
                    }
                    AwaitOpening();
                    StateTransitonScene.IsNotCallRepeatActionAwaitOpening = true;
                }
            }
            else
            {
                if (StateRepeatButton.СurrentQuntitySequence < GameConfig.RepeatAction.MaxQuntitySequence && StateRepeatButton.SequenceСompleted && !StateRepeatButton.IsSceneGameOver && !StateRepeatButton.IsSceneWinGame
                    && !StateRepeatButton.PressButtonAnimation)
                {
                    StateRepeatButton.SequenceСompleted = false;
                    ManagerButtonRepeat.NewSequence();
                }
                if (StateRepeatButton.СurrentQuntitySequence == GameConfig.RepeatAction.MaxQuntitySequence)
                {
                    StateRepeatButton.IsSceneWinGame = true;
                    ManagerButtonRepeat.ChangeButtonConditionEnd();
                    if (!StateTransitonScene.IsNotCallRepeatActionAwait)
                    {
                        AwaitEnd();
                        StateTransitonScene.IsNotCallRepeatActionAwait = true;
                    }
                    if (StateTransitonScene.IsTransitonRepeatButtonAwait)
                    {
                        timer.Stop();
                        timer.Tick -= Update;
                        timer.Dispose();
                        RuleCatchBonesScene ruleCatchBonesScene = new RuleCatchBonesScene(); //указать нужную сцену//
                        ruleCatchBonesScene.Opacity = 0;
                        ruleCatchBonesScene.Show();
                        ruleCatchBonesScene.Refresh();
                        for (double opacity = 0; opacity <= 1; opacity += 0.1)
                        {
                            ruleCatchBonesScene.Opacity = opacity;
                            System.Threading.Thread.Sleep(16);
                        };
                        ManagerButtonRepeat.Dispose();
                        ManagerButtonRepeat.DeleteManagerButtonRepeat();
                        ManagerUI.RepeatActionElements.Clear();
                        ManagerSound.DeleteActivePlayersRepeatAction();
                        _cachedButtonUI.Dispose();
                        _cachedBackground.Dispose();
                        this.Hide();
                        this.Dispose();
                    }
                }
                CanvasRepeatAction.Invalidate();
            }
        }

        private async Task AwaitEnd()
        {
            using (var player = new SoundPlayer(Properties.Resources.RepeatButtonWin))
            {
                ManagerSound.activePlayersRepeatAction.Add(player);
                player.Play();
                await Task.Delay(3000);
            }
            StateTransitonScene.IsTransitonRepeatButtonAwait = true;
        }

        private async Task AwaitOpening()
        {
            await Task.Delay(300);
            StateTransitonScene.IsTransitonRepeatActionAwaitOpening = true;
        }

        private void DrawResult(Graphics g)
        {
            string text = $"{StateRepeatButton.СurrentQuntitySequence} из {GameConfig.RepeatAction.MaxQuntitySequence}";
            using (Font font = new Font(GameConfig.NumberPointsRepeatButton.pfc.Families[0], GameConfig.NumberPointsRepeatButton.SizeResult, GameConfig.NumberPointsRepeatButton.StyleResult))
            {
                g.DrawString(text, font, GameConfig.NumberPointsRepeatButton.shadowBrush, GameConfig.NumberPointsRepeatButton.shadowRect, GameConfig.NumberPointsRepeatButton.format);

                g.DrawString(text, font, GameConfig.NumberPointsRepeatButton.CustomBrush, GameConfig.NumberPointsRepeatButton.rectangleResult, GameConfig.NumberPointsRepeatButton.format);
            }
        }

        private void CanvasRepeatAction_MouseDown(object sender, MouseEventArgs e)
        {
            if (!StateExitMenu.СurrentStateMenuExitRepeatAction)
            {
                CheckMouseDownRule(e);
            }
            if (!StateRuleMenu.СurrentStateMenuRuleRepeatAction)
            {
                CheckMouseDownExit(e);
            }
            if (StateExitMenu.СurrentStateMenuExitRepeatAction) return;

            if (StateRuleMenu.СurrentStateMenuRuleRepeatAction) return;

            if (!StateTransitonScene.IsTransitonRepeatActionAwaitOpening) return;

            if (StateRepeatButton.СurrentStateMenuClick)
            {
                StateRepeatButton.СurrentStateMenuClick = false;
                return;
            }

            if (!StateRepeatButton.IsPlayingSequence && !StateRepeatButton.IsSceneGameOver && !StateRepeatButton.IsSceneWinGame && !StateRepeatButton.PressButtonAnimation)
            {
                for (int i = 0; i < ManagerButtonRepeat.ButtonRepeat.Count; i++)
                {
                    var button = ManagerButtonRepeat.ButtonRepeat[i];
                    if (new RectangleF(new PointF(button.Transform.Position.X, button.Transform.Position.Y),
                        new Size(GameConfig.RepeatAction.Button.Width, GameConfig.RepeatAction.Button.Height)).Contains(e.Location))
                    {
                        if (ManagerButtonRepeat.TryPressButton(button.Id))
                        {
                            button.IsActiveInSequence = true;
                            ManagerButtonRepeat.PressButton(button.Id);
                            SoundPlayer player = new SoundPlayer(Properties.Resources.RepeatButtonClick);
                            ManagerSound.activePlayersRepeatAction.Add(player);
                            player.Play();
                        }
                        else
                        {
                            StateRepeatButton.СurrentQuntitySequence = 0;
                            StateRepeatButton.SequenceСompleted = true;
                        }
                    }
                }
            }
        }

        private void CheckMouseDownRule(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnQuestion.PositionOx, GameConfig.TotalElement.BtnQuestion.PositionOy),
               new Size(GameConfig.TotalElement.BtnQuestion.Width, GameConfig.TotalElement.BtnQuestion.Height)).Contains(e.Location))
            {
                if (!StateRuleMenu.СurrentStateMenuRuleRepeatAction)
                {
                    ManagerUI.AddRuleElementsRepeatAction();
                    ManagerSound.DeleteActivePlayersRepeatAction();
                    CanvasRepeatAction.Invalidate();
                    StateRuleMenu.СurrentStateMenuRuleRepeatAction = true;
                    StateRepeatButton.СurrentStateMenuClick = true;
                    if (StateRepeatButton.IsPlayingSequence)
                    {
                        StateRepeatButton.ErorClickButton = true;
                        StateRepeatButton.cts.Cancel();
                        StateRepeatButton.cts.Dispose();
                        StateRepeatButton.cts = new CancellationTokenSource();
                    }
                }
            }

            if (!StateRuleMenu.СurrentStateMenuRuleRepeatAction) return;

            if (new RectangleF(new PointF(GameConfig.RuleInfScene.ButtonApply.PositionOx, GameConfig.RuleInfScene.ButtonApply.PositionOy),
                new Size(GameConfig.RuleInfScene.ButtonApply.Width, GameConfig.RuleInfScene.ButtonApply.Height)).Contains(e.Location))
            {
                ManagerUI.RuleElementsRepeatAction.Clear();
                StateRuleMenu.СurrentStateMenuRuleRepeatAction = false;
                StateRepeatButton.СurrentStateMenuClick = true;
                if (StateRepeatButton.ErorClickButton)
                {
                    StateRepeatButton.ErorClickButton = false;
                    ManagerButtonRepeat.PlaySequence(StateRepeatButton.cts.Token);
                }
            }
        }

        private void MenuRuleCkeck()
        {
            ManagerUI.AddRuleElementsRepeatAction();
            ManagerSound.DeleteActivePlayersRepeatAction();
            CanvasRepeatAction.Invalidate();
            StateRuleMenu.СurrentStateMenuRuleRepeatAction = true;
            StateRepeatButton.СurrentStateMenuClick = true;
            if (StateRepeatButton.IsPlayingSequence)
            {
                StateRepeatButton.ErorClickButton = true;
                StateRepeatButton.cts.Cancel();
                StateRepeatButton.cts.Dispose();
                StateRepeatButton.cts = new CancellationTokenSource();
            }
        }
        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.СurrentStateMenuExitRepeatAction)
                {
                    ManagerSound.DeleteActivePlayersRepeatAction();
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasRepeatAction.Invalidate();
                    StateExitMenu.СurrentStateMenuExitRepeatAction = true;
                    StateRepeatButton.СurrentStateMenuClick = true;
                    if (StateRepeatButton.IsPlayingSequence)
                    {
                        StateRepeatButton.ErorClickButton = true;
                        StateRepeatButton.cts.Cancel();
                        StateRepeatButton.cts.Dispose();
                        StateRepeatButton.cts = new CancellationTokenSource();
                    }
                }
            }

            if (!StateExitMenu.СurrentStateMenuExitRepeatAction) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateRepeatButton.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitRepeatAction = false;
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
                        CanvasRepeatAction.Invalidate();
                    }
                    ManagerButtonRepeat.Dispose();
                    ManagerButtonRepeat.DeleteManagerButtonRepeat();
                    ManagerUI.RepeatActionElements.Clear();
                    ManagerSound.DeleteActivePlayersRepeatAction();
                    _cachedButtonUI.Dispose();
                    _cachedBackground.Dispose();
                    this.Hide();
                    this.Dispose();
                }
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.СurrentStateMenuExitRepeatAction = false;
                StateRepeatButton.СurrentStateMenuClick = true;
                if (StateRepeatButton.ErorClickButton)
                {
                    StateRepeatButton.ErorClickButton = false;
                    ManagerButtonRepeat.PlaySequence(StateRepeatButton.cts.Token);
                }
            }
        }

        private void RepeatAction_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManagerButtonRepeat.Dispose();
            _cachedButtonUI.Dispose();
            _cachedBackground.Dispose();
            timer.Stop();
            timer.Tick -= Update;
            timer.Dispose();
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
