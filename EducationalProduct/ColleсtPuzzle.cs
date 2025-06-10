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
    public partial class ColleсtPuzzle : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        public ColleсtPuzzle()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddColleсtPuzzleElements();
            ManagerPuzzle.AddDefaultPuzzles();
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
            GameConfig.Initialize(new Size(CanvasColleсtPuzzle.Size.Width, CanvasColleсtPuzzle.Size.Height));
        }
        private void Update(object sender, EventArgs e)
        {
            ManagerPuzzle.ApplyPhysics();
            if (!ManagerPuzzle.CheckCorrectPoisiton())
            {
                /*
                RuleScene ruleScene = new RuleScene();
                ruleScene.Opacity = 0;
                ruleScene.Show();
                ruleScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    ruleScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Hide();
                ruleScene.FormClosed += (s, args) => { this.Close(); };
                */
            }
            CanvasColleсtPuzzle.Invalidate();
        }
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.ColleсtPuzzleElements.Count; i++)
            {
                ManagerUI.ColleсtPuzzleElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerPuzzle.Puzzles.Count; i++)
            {
                ManagerPuzzle.Puzzles[i].DrawSprite(g);
            }
        }
        private Puzzle currentlyDraggedPuzzle;
        private void CanvasColleсtPuzzle_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var puzzle in ManagerPuzzle.Puzzles)
            {
                if (!puzzle.Physics.IsCorrectPosition)
                {
                    if (puzzle.Physics.Bounds.Contains(e.Location))
                    {
                        currentlyDraggedPuzzle = puzzle;
                        puzzle.Physics.StartDrag(e.Location);
                        break;
                    }
                }
            }
        }

        private void CanvasColleсtPuzzle_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentlyDraggedPuzzle != null)
            {
                currentlyDraggedPuzzle.Physics.UpdateDrag(e.Location);
                if (ManagerPuzzle.Puzzles.Remove(currentlyDraggedPuzzle))
                {
                    ManagerPuzzle.Puzzles.Add(currentlyDraggedPuzzle);
                }
                CanvasColleсtPuzzle.Invalidate();
            }
        }

        private void CanvasColleсtPuzzle_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentlyDraggedPuzzle != null)
            {
                currentlyDraggedPuzzle.Physics.EndDrag();
                currentlyDraggedPuzzle = null;
            }
        }
    }
}
