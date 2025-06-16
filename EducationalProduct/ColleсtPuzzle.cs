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
    public partial class ColleсtPuzzle : Form
    {
        private Puzzle currentlyDraggedPuzzle;
        private Bitmap _cachedBackground;
        private Bitmap _cachedButtonUI;
        private System.Windows.Forms.Timer timer;
        private Rectangle workingArea;

        public ColleсtPuzzle()
        {
            InitializeComponent();
            StateCollectPuzzle.Init();
            StateRuleMenu.Init();
            StateExitMenu.Init();
            СalibrationSize();
            ManagerUI.AddColleсtPuzzleElements();
            ManagerUI.AddTotalElements();
            ManagerPuzzle.AddDefaultPuzzles();
            DrawElementsUI();
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
            if (StateExitMenu.СurrentStateMenuExitCollectPuzzle) return;

            if (StateRuleMenu.СurrentStateMenuRuleCollectPuzzle) return;

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
                    ManagerSound.DeleteActivePlayersColleсtPuzzle();
                    ruleDodgeMeteoritesScene.FormClosed += (s, args) => { this.Close(); };
                }
            }
        }

        private async Task Await()
        {
            await Task.Delay(1500);
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
            g.DrawImage(_cachedButtonUI, 0, 0);
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerUI.RuleElementsColleсtPuzzle.Count; i++)
            {
                ManagerUI.RuleElementsColleсtPuzzle[i].DrawSprite(g);
            }
        }

        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButtonUI = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.ColleсtPuzzleElements.Count; i++)
                {
                    ManagerUI.ColleсtPuzzleElements[i].DrawSprite(bgGraphics);
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
        }

        private void CanvasColleсtPuzzle_MouseDown(object sender, MouseEventArgs e)
        {
            if (!StateExitMenu.СurrentStateMenuExitCollectPuzzle)
            {
                CheckMouseDownRule(e);
            }

            if (!StateRuleMenu.СurrentStateMenuRuleCollectPuzzle)
            {
                CheckMouseDownExit(e);
            }

            if (StateExitMenu.СurrentStateMenuExitCollectPuzzle) return;

            if (StateRuleMenu.СurrentStateMenuRuleCollectPuzzle) return;

            if (StateCollectPuzzle.СurrentStateMenuClick)
            {
                StateCollectPuzzle.СurrentStateMenuClick = false;
                return;
            }

            foreach (var puzzle in ManagerPuzzle.Puzzles)
            {
                if (!puzzle.Physics.IsCorrectPosition)
                {
                    if (puzzle.Physics.Bounds.Contains(e.Location))
                    {
                        currentlyDraggedPuzzle = puzzle;
                        puzzle.Physics.StartDrag(e.Location);
                        using (var player = new SoundPlayer(Properties.Resources.CollectPuzzleLet))
                        {
                            ManagerSound.activePlayersColleсtPuzzle.Add(player);
                            player.Play();
                        }
                        break;
                    }
                }
            }
        }
        private void CanvasColleсtPuzzle_MouseMove(object sender, MouseEventArgs e)
        {
            if (StateExitMenu.СurrentStateMenuExitCollectPuzzle) return;

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
            if (StateExitMenu.СurrentStateMenuExitCollectPuzzle) return;

            if (currentlyDraggedPuzzle != null)
            {
                using (var player = new SoundPlayer(Properties.Resources.CollectPuzzleTake))
                {
                    ManagerSound.activePlayersColleсtPuzzle.Add(player);
                    player.Play();
                }
                currentlyDraggedPuzzle.Physics.EndDrag();
                currentlyDraggedPuzzle = null;
            }
        }
        private void CheckMouseDownRule(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnQuestion.PositionOx, GameConfig.TotalElement.BtnQuestion.PositionOy),
               new Size(GameConfig.TotalElement.BtnQuestion.Width, GameConfig.TotalElement.BtnQuestion.Height)).Contains(e.Location))
            {
                if (!StateRuleMenu.СurrentStateMenuRuleCollectPuzzle)
                {
                    ManagerUI.AddRuleElementsColleсtPuzzle();
                    ManagerSound.DeleteActivePlayersColleсtPuzzle();
                    CanvasColleсtPuzzle.Invalidate();
                    StateRuleMenu.СurrentStateMenuRuleCollectPuzzle = true;
                    StateCollectPuzzle.СurrentStateMenuClick = true;
                }
            }

            if (!StateRuleMenu.СurrentStateMenuRuleCollectPuzzle) return;

            if (new RectangleF(new PointF(GameConfig.RuleInfScene.ButtonApply.PositionOx, GameConfig.RuleInfScene.ButtonApply.PositionOy),
                new Size(GameConfig.RuleInfScene.ButtonApply.Width, GameConfig.RuleInfScene.ButtonApply.Height)).Contains(e.Location))
            {
                ManagerUI.RuleElementsColleсtPuzzle.Clear();
                StateRuleMenu.СurrentStateMenuRuleCollectPuzzle = false;
                StateCollectPuzzle.СurrentStateMenuClick = true;
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.СurrentStateMenuExitCollectPuzzle)
                {
                    ManagerSound.DeleteActivePlayersColleсtPuzzle();
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasColleсtPuzzle.Invalidate();
                    StateExitMenu.СurrentStateMenuExitCollectPuzzle = true;
                    StateCollectPuzzle.СurrentStateMenuClick = true;
                }
            }

            if (!StateExitMenu.СurrentStateMenuExitCollectPuzzle) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateCollectPuzzle.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitCollectPuzzle = false;
                timer.Stop();
                OpeningScene OpeningScene = new OpeningScene();
                OpeningScene.Opacity = 0;
                OpeningScene.Show();
                OpeningScene.Refresh();
                for (double opacity = 0; opacity <= 1; opacity += 0.1)
                {
                    OpeningScene.Opacity = opacity;
                    System.Threading.Thread.Sleep(16);
                }
                this.Close();
                ManagerUI.ColleсtPuzzleElements.Clear();
                StateTransitonScene.IsTransitonColleсtPuzzle = false;
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerSound.DeleteActivePlayersColleсtPuzzle();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateCollectPuzzle.СurrentStateMenuClick = true;
                StateExitMenu.СurrentStateMenuExitCollectPuzzle = false;
            }
        }
    }
}
