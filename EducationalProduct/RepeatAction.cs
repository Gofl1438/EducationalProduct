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
    public partial class RepeatAction : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;

        public RepeatAction()
        {
            InitializeComponent();
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
        }
        private void Update(object sender, EventArgs e)
        {
            if (StateRepeatButton.СurrentQuntitySequence < StateRepeatButton.MaxQuntitySequence && StateRepeatButton.SequenceСompleted && !StateRepeatButton.IsSceneGameOver)
            {
                StateRepeatButton.SequenceСompleted = false;
                StateRepeatButton.СurrentQuntitySequence += 1;
                ManagerButtonRepeat.NewSequence();
            }
            if (StateRepeatButton.СurrentQuntitySequence == StateRepeatButton.MaxQuntitySequence)
            {
                ManagerButtonRepeat.ButtonRepeat.Clear();
            }
            CanvasRepeatAction.Invalidate();
        }

        private void CanvasRepeatAction_MouseDown(object sender, MouseEventArgs e)
        {
            if (!StateRepeatButton.IsPlayingSequence && !StateRepeatButton.IsSceneGameOver)
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
