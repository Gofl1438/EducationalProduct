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
        public CatchBones()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerBone.AddDefaultQuantityBones();
            ManagerUI.AddCatchBonesElements();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            ManagerBone.ApplyPhysicsBone();
            ManagerBone.DeleteTouchBones();
            if(StateCatchBones.СurrentQuntityBones == StateCatchBones.MaxQuntityBones)
            {
                Await();
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
            CanvasCatchBones.Invalidate();
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
            for (int i = 0; i < ManagerUI.CatchBonesElements.Count; i++)
            {
                ManagerUI.CatchBonesElements[i].DrawSprite(g);
            }
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                ManagerBone.Bones[i].DrawSprite(g);
            }
            DrawResult(g);
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
            g.DrawString(
                $"{StateCatchBones.СurrentQuntityBones} / {StateCatchBones.MaxQuntityBones}",
                new Font(FamilyNameScore, SizeResult, (StateCatchBones.СurrentQuntityBones == StateCatchBones.MaxQuntityBones ? StyleResultEnd : StyleResult)),
                CustomBrush,
                rectangleResult,
                format
                );
        }

        private void CatchBones_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var bone = ManagerBone.Bones[i];
                if (new RectangleF(new PointF(bone.Transform.Position.X, bone.Transform.Position.Y), 
                    new Size(GameConfig.CatchBones.Bone.Width, GameConfig.CatchBones.Bone.Height)).Contains(e.Location))
                {
                    ManagerBone.Bones[i].IsTouchedUser = true;
                    StateCatchBones.СurrentQuntityBones += 1;
                }
            }
        }
    }
}
