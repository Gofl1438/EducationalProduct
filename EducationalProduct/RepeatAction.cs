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
using static EducationalProduct.Classes.GameConfig.RepeatAction.NumberPoints;

namespace EducationalProduct
{
    public partial class RepeatAction : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;

        public RepeatAction()
        {
            InitializeComponent();
            StateRepeatButton.Init();
            СalibrationSize();
            ManagerUI.AddRepeatActionElements();
            ManagerButtonRepeat.AddDefaultButtonsRepeat();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }
        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasRepeatAction.Size.Width, CanvasRepeatAction.Size.Height));
        }
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.RepeatActionElements.Count; i++)
            {
                ManagerUI.RepeatActionElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerButtonRepeat.ButtonRepeat.Count; i++)
            {
                ManagerButtonRepeat.ButtonRepeat[i].DrawSprite(g);
            }
            DrawResult(g);
        }
        private void Update(object sender, EventArgs e)
        {
            if (!StateTransitonScene.IsTransitonRepeatActionAwaitOpening)
            {
                if (!StateTransitonScene.IsNotCallRepeatActionAwaitOpening)
                {
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
                    StateRepeatButton.СurrentQuntitySequence += 1;
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
                        ColleсtPuzzle ColleсtPuzzle = new ColleсtPuzzle(); //указать нужную сцену//
                        ColleсtPuzzle.Opacity = 0;
                        ColleсtPuzzle.Show();
                        ColleсtPuzzle.Refresh();
                        for (double opacity = 0; opacity <= 1; opacity += 0.1)
                        {
                            ColleсtPuzzle.Opacity = opacity;
                            System.Threading.Thread.Sleep(16);
                        }
                        this.Hide();
                        ManagerButtonRepeat.DeleteManagerButtonRepeat();
                        ManagerUI.RepeatActionElements.Clear();
                        ColleсtPuzzle.FormClosed += (s, args) => { this.Close(); };
                    }
                }
                CanvasRepeatAction.Invalidate();
            }
        }

        private async Task AwaitEnd()
        {
            await Task.Delay(2000);
            StateTransitonScene.IsTransitonRepeatButtonAwait = true;
        }

        private async Task AwaitOpening()
        {
            await Task.Delay(1000);
            StateTransitonScene.IsTransitonRepeatActionAwaitOpening = true;
        }

        private void DrawResult(Graphics g)
        {
            RectangleF rectangleResult = new RectangleF(
                PointRectangleResult,
                SizerRectangleResult
            );
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            string text = $"{((StateRepeatButton.СurrentQuntitySequence - 1) < 0 ? 0 : (StateRepeatButton.СurrentQuntitySequence - 1))} / {GameConfig.RepeatAction.MaxQuntitySequence - 1}";
            Font font = new Font(FamilyNameScore, SizeResult,
                (StateRepeatButton.СurrentQuntitySequence == GameConfig.RepeatAction.MaxQuntitySequence ? StyleResultEnd : StyleResult));

            RectangleF shadowRect = rectangleResult;
            shadowRect.Offset(3, 3);
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
            {
                g.DrawString(text, font, shadowBrush, shadowRect, format);
            }
            g.DrawString(text, font, CustomBrush, rectangleResult, format);

            font.Dispose();
        }

        private void CanvasRepeatAction_MouseDown(object sender, MouseEventArgs e)
        {
            if (!StateRepeatButton.IsPlayingSequence && !StateRepeatButton.IsSceneGameOver && !StateRepeatButton.IsSceneWinGame)
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
    }
}
