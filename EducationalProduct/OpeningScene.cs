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
    public partial class OpeningScene : Form
    {
        Rectangle workingArea;
        public OpeningScene()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddOpeningElement();
            this.Invalidate();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfigUI.Initialize(new Size(this.Size.Width, this.Size.Height));
        }

        private void OpeningScene_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < ManagerUI.OpeningElement.Count; i++)
            {
                ManagerUI.OpeningElement[i].DrawSprite(g);
            }
        }

        private void OpeningScene_MouseDown(object sender, MouseEventArgs e)
        {
            if (new RectangleF(new PointF(GameConfigUI.OpeningScene.BtnStartPlay.PositionOx, GameConfigUI.OpeningScene.BtnStartPlay.PositionOy),
                new Size(GameConfigUI.OpeningScene.BtnStartPlay.Width, GameConfigUI.OpeningScene.BtnStartPlay.Height)).Contains(e.Location))
            {
                this.Hide();
                using (CatchBones catchBones = new CatchBones())
                {
                    catchBones.ShowDialog();
                }
                this.Close();
            }
        }
    }
}
