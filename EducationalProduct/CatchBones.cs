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
using static EducationalProduct.Classes.GameConfig.CatchBones.NumberPoints;

namespace EducationalProduct
{
    public partial class CatchBones : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        Bitmap _cachedBackground;
        Bitmap _cachedButtonUI;
        public CatchBones()
        {
            InitializeComponent();
            StateCatchBones.Init();
            СalibrationSize();
            ManagerBone.AddDefaultQuantityBones();
            ManagerUI.AddCatchBonesElements();
            ManagerUI.AddTotalElements();
            DrawElementsUI();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            if (StateExitMenu.СurrentStateMenuExitCatchBones) return;

            foreach (Bone bone in ManagerBone.Bones)
            {
                bone.Physics.MoveBone();
                CanvasCatchBones.Invalidate();
            }
            ManagerBone.ApplyPhysicsCollideMoveBone();
            ManagerBone.DeleteTouchBones();
            if (StateCatchBones.СurrentQuntityBones == GameConfig.CatchBones.Bone.DefaultQuantityBone)
            {
                if (!StateTransitonScene.IsNotCallCatchBonesAwait)
                {
                    Await();
                    StateTransitonScene.IsNotCallCatchBonesAwait = true;
                }
                if (StateTransitonScene.IsTransitonCatchBonesAwait)
                {
                    timer.Stop();
                    RuleCollectPuzzleScene ruleCollectPuzzleScene = new RuleCollectPuzzleScene(); //указать нужную сцену//
                    ruleCollectPuzzleScene.Opacity = 0;
                    ruleCollectPuzzleScene.Show();
                    ruleCollectPuzzleScene.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        ruleCollectPuzzleScene.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    this.Hide();
                    ManagerUI.CatchBonesElements.Clear();
                    ManagerSound.DeleteActivePlayersCatchBones();
                    ruleCollectPuzzleScene.FormClosed += (s, args) => { this.Close(); };
                }
            }
        }

        private async Task Await()
        {
            await Task.Delay(1200);
            StateTransitonScene.IsTransitonCatchBonesAwait = true;
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(CanvasCatchBones.Size.Width, CanvasCatchBones.Size.Height));
        }
        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_cachedBackground, 0, 0);
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                ManagerBone.Bones[i].DrawSprite(g);
            }
            DrawResult(g);
            g.DrawImage(_cachedButtonUI, 0, 0);
            for (int i = 0; i < ManagerUI.TotalElementsMenuExit.Count; i++)
            {
                ManagerUI.TotalElementsMenuExit[i].DrawSprite(g);
            }
        }

        private void DrawElementsUI()
        {
            Bitmap cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            Bitmap cachedButtonUI = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(cachedBackground))
            {
                for (int i = 0; i < ManagerUI.CatchBonesElements.Count; i++)
                {
                    ManagerUI.CatchBonesElements[i].DrawSprite(bgGraphics);
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

            string text = $"{StateCatchBones.СurrentQuntityBones} / {GameConfig.CatchBones.Bone.DefaultQuantityBone}";
            Font font = new Font(FamilyNameScore, SizeResult,
                (StateCatchBones.СurrentQuntityBones == GameConfig.CatchBones.Bone.DefaultQuantityBone ?
                 StyleResultEnd : StyleResult));

            RectangleF shadowRect = rectangleResult;
            shadowRect.Offset(3, 3);
            using (Brush shadowBrush = new SolidBrush(Color.FromArgb(100, Color.Black)))
            {
                g.DrawString(text, font, shadowBrush, shadowRect, format);
            }
            g.DrawString(text, font, CustomBrush, rectangleResult, format);

            font.Dispose();
        }

        private void CatchBones_MouseDown(object sender, MouseEventArgs e)
        {
            CheckMouseDownExit(e);

            if (StateExitMenu.СurrentStateMenuExitCatchBones) return;

            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var bone = ManagerBone.Bones[i];
                Size size = ManagerBone.Bones[i].Physics.Size;
                if (new RectangleF(new PointF(bone.Transform.Position.X, bone.Transform.Position.Y),
                    size).Contains(e.Location))
                {
                    ManagerBone.Bones[i].IsTouchedUser = true;
                    using (var player = new SoundPlayer(Properties.Resources.CatchBonesClickBones))
                    {
                        ManagerSound.activePlayersCatchBones.Add(player);
                        player.Play();
                    }
                    StateCatchBones.СurrentQuntityBones += 1;
                }
            }
        }

        private void CheckMouseDownExit(MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfig.TotalElement.BtnClosed.PositionOx, GameConfig.TotalElement.BtnClosed.PositionOy),
                new Size(GameConfig.TotalElement.BtnClosed.Width, GameConfig.TotalElement.BtnClosed.Height)).Contains(e.Location))
            {
                if (!StateExitMenu.СurrentStateMenuExitCatchBones)
                {
                    ManagerSound.DeleteActivePlayersCatchBones();
                    ManagerUI.AddTotalElementsMenuExit();
                    CanvasCatchBones.Invalidate();
                    StateExitMenu.СurrentStateMenuExitCatchBones = true;
                }
            }

            if (!StateExitMenu.СurrentStateMenuExitCatchBones) return;

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonYes.PositionOx, GameConfig.TotalElement.ButtonYes.PositionOy),
                new Size(GameConfig.TotalElement.ButtonYes.Width, GameConfig.TotalElement.ButtonYes.Height)).Contains(e.Location))
            {
                StateExitMenu.СurrentStateMenuExitCatchBones = false;
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
                this.Hide();
                ManagerUI.CatchBonesElements.Clear();
                ManagerUI.TotalElementsMenuExit.Clear();
                ManagerSound.DeleteActivePlayersCatchBones();
                OpeningScene.FormClosed += (s, args) => { this.Close(); };
            }

            if (new RectangleF(new PointF(GameConfig.TotalElement.ButtonNo.PositionOx, GameConfig.TotalElement.ButtonNo.PositionOy),
                new Size(GameConfig.TotalElement.ButtonNo.Width, GameConfig.TotalElement.ButtonNo.Height)).Contains(e.Location))
            {
                ManagerUI.TotalElementsMenuExit.Clear();
                StateExitMenu.СurrentStateMenuExitCatchBones = false;
            }
        }
    }

}
