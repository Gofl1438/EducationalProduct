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
        Rectangle workingArea;
        public ColleсtPuzzle()
        {
            InitializeComponent();
            СalibrationSize();
            ManagerUI.AddColleсtPuzzleElements();
        }

        private void СalibrationSize()
        {
            workingArea = Screen.FromControl(this).WorkingArea;
            this.Height = workingArea.Height;
            this.Width = workingArea.Width;
            this.MinimumSize = new Size(workingArea.Width, workingArea.Height);
            GameConfigUI.Initialize(new Size(CanvasColleсtPuzzle.Size.Width, CanvasColleсtPuzzle.Size.Height));
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < ManagerUI.ColleсtPuzzleElements.Count; i++)
            {
                ManagerUI.ColleсtPuzzleElements[i].DrawSprite(g);
            }
        }
    }
}
