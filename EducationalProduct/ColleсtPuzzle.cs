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
        private Puzzle currentlyDraggedPuzzle;
        private Bitmap _cachedBackground;
        private System.Windows.Forms.Timer timer;
        private Rectangle workingArea;

        public ColleсtPuzzle()
        {
            InitializeComponent();
            StateCollectPuzzle.Init();
            СalibrationSize();
            ManagerUI.AddColleсtPuzzleElements();
            ManagerPuzzle.AddDefaultPuzzles();
            _cachedBackground = DrawElementsUI();
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
            if (!StateTransitonScene.IsTransitonColleсtPuzzle)
            {
                ManagerPuzzle.ApplyPhysics();
                CanvasColleсtPuzzle.Invalidate();
            }
            else
            {
                if (!StateTransitonScene.IsNotCallColleсtPuzzleAwait)
                {
                    Await();
                    StateTransitonScene.IsNotCallColleсtPuzzleAwait = true;
                }
                if (StateTransitonScene.IsTransitonColleсtPuzzleAwait) //указать нужную сцену//
                {
                    timer.Stop();
                    RuleDodgeMeteoritesScene ruleDodgeMeteoritesScene = new RuleDodgeMeteoritesScene();
                    ruleDodgeMeteoritesScene.Opacity = 0;
                    ruleDodgeMeteoritesScene.Show();
                    ruleDodgeMeteoritesScene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        ruleDodgeMeteoritesScene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    this.Hide();
                    ManagerUI.ColleсtPuzzleElements.Clear();
                    StateTransitonScene.IsTransitonColleсtPuzzle = false;
                    ruleDodgeMeteoritesScene.FormClosed += (s, args) => { this.Close(); };
                }
            }
        }

        private async Task Await()
        {
            await Task.Delay(1000);
            StateTransitonScene.IsTransitonColleсtPuzzleAwait = true;
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerPuzzle.Puzzles.Count; i++)
            {
                ManagerPuzzle.Puzzles[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerPuzzle.SolidRocketPuzzles.Count; i++)
            {
                ManagerPuzzle.SolidRocketPuzzles[i].DrawSprite(g);
            }
        }

        private Bitmap DrawElementsUI()
        {
            Bitmap _cachedBackground;
            _cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(_cachedBackground))
            {
                for (int i = 0; i < ManagerUI.ColleсtPuzzleElements.Count; i++)
                {
                    ManagerUI.ColleсtPuzzleElements[i].DrawSprite(bgGraphics);
                }
            }
            return _cachedBackground;
        }

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
