using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites;

namespace EducationalProduct
{
    public partial class DodgeMeteorites : Form
    {
        RocketDodge rocket;
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        private bool IsLeftButtonPressed = false;
        private bool IsMouseOverLeftButton = false;
        private bool IsMouseOverRightButton = false;
        public DodgeMeteorites()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddDodgeMeteoritesElements();
            ManagerDodgeMeteorites.AddMeteoritesNormal();
            rocket = new RocketDodge();
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
            GameConfig.Initialize(new Size(CanvasDodgeMeteorites.Size.Width, CanvasDodgeMeteorites.Size.Height));
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.DodgeMeteoritesElements.Count; i++)
            {
                ManagerUI.DodgeMeteoritesElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
            {
                ManagerDodgeMeteorites.Meteorites[i].DrawSprite(g);
            }
            rocket.DrawSprite(g);
        }

        private void Update(object sender, EventArgs e)
        {
            for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
            {
                ManagerDodgeMeteorites.Meteorites[i].Physics.MoveOyMeteorite();
            }
            if (IsLeftButtonPressed)
            {
                if (IsMouseOverLeftButton)
                    rocket.Physics.MoveOxLeft();
                else if (IsMouseOverRightButton)
                    rocket.Physics.MoveOxRight();
            }
            CanvasDodgeMeteorites.Invalidate();
        }

        private void CanvasDodgeMeteorites_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsLeftButtonPressed = true;
                CheckMouseOverButtons(e.Location);
            }
        }

        private void CanvasDodgeMeteorites_MouseUp(object sender, MouseEventArgs e)
        {
            IsLeftButtonPressed = false;
            IsMouseOverLeftButton = false;
            IsMouseOverRightButton = false;
        }

        private void CanvasDodgeMeteorites_MouseMove(object sender, MouseEventArgs e)
        {
            if (!IsLeftButtonPressed) return;
            CheckMouseOverButtons(e.Location);
        }
        private void CheckMouseOverButtons(Point mousePos)
        {
            IsMouseOverLeftButton = new RectangleF(
                new PointF(ButtonLeft.PositionOx, ButtonLeft.PositionOy),
                new Size(ButtonLeft.Width, ButtonLeft.Height)
            ).Contains(mousePos);

            IsMouseOverRightButton = new RectangleF(
                new PointF(ButtonRight.PositionOx, ButtonRight.PositionOy),
                new Size(ButtonRight.Width, ButtonRight.Height)
            ).Contains(mousePos);
        }
    }
}
