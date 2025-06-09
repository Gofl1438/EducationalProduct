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
    public partial class CatchBones : Form
    {
        System.Windows.Forms.Timer timer;
        Rectangle workingArea;
        public CatchBones()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerBone.AddDefaultQuantityBones();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 14;
            timer.Tick += Update;
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            ManagerBone.ApplyPhysicsBone();
            ManagerBone.DeleteTouchBones();
            catchBonesCanvas.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfig.Initialize(new Size(catchBonesCanvas.Size.Width, catchBonesCanvas.Size.Height));
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                ManagerBone.Bones[i].DrawSprite(g);
            }
        }

        private void CatchBones_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var bone = ManagerBone.Bones[i];
                if (new RectangleF(new PointF(bone.Transform.Position.X, bone.Transform.Position.Y), 
                    new Size(GameConfig.Bone.Width, GameConfig.Bone.Height)).Contains(e.Location))
                {
                    ManagerBone.Bones[i].IsTouchedUser = true;
                }
            }
        }
    }
}
