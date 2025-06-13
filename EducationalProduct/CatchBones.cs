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
using static EducationalProduct.Classes.GameConfig.CatchBones.NumberPoints;

namespace EducationalProduct
{
    public partial class CatchBones : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        Bitmap _cachedBackground;
        public CatchBones()
        {
            InitializeComponent();
            StateCatchBones.Init();
            СalibrationSize();
            ManagerBone.AddDefaultQuantityBones();
            ManagerUI.AddCatchBonesElements();
            _cachedBackground = DrawElementsUI();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
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
                    DodgeMeteorites DodgeMeteorites = new DodgeMeteorites(); //указать нужную сцену//
                    DodgeMeteorites.Opacity = 0;
                    DodgeMeteorites.Show();
                    DodgeMeteorites.Refresh();
                    for (double opacity = 0; opacity <= 1; opacity += 0.1)
                    {
                        DodgeMeteorites.Opacity = opacity;
                        System.Threading.Thread.Sleep(16);
                    }
                    this.Hide();
                    ManagerUI.CatchBonesElements.Clear();
                    DodgeMeteorites.FormClosed += (s, args) => { this.Close(); };
                }
            }
        }

        private async Task Await()
        {
            await Task.Delay(1000);
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
        }

        private Bitmap DrawElementsUI()
        {
            Bitmap _cachedBackground;
            _cachedBackground = new Bitmap(GameConfig.CanvasProduct.Width, GameConfig.CanvasProduct.Height);
            using (var bgGraphics = Graphics.FromImage(_cachedBackground))
            {
                for (int i = 0; i < ManagerUI.CatchBonesElements.Count; i++)
                {
                    ManagerUI.CatchBonesElements[i].DrawSprite(bgGraphics);
                }
            }
            return _cachedBackground;
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
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var bone = ManagerBone.Bones[i];
                Size size = ManagerBone.Bones[i].Physics.Size;
                if (new RectangleF(new PointF(bone.Transform.Position.X, bone.Transform.Position.Y),
                    size).Contains(e.Location))
                {
                    ManagerBone.Bones[i].IsTouchedUser = true;
                    StateCatchBones.СurrentQuntityBones += 1;
                }
            }
        }
    }
}
