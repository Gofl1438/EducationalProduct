using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle.Puzzle.SolidRocket;

namespace EducationalProduct.Classes
{
    public class SolidRocketPuzzle : GameObject
    {
        private float SpeedOx;
        private float Acceleration;

        public SolidRocketPuzzle()
        {
            Sprite = Properties.Resources.SolidRocket;
            Transform = new Transform(new PointF(PositionOx, PositionOy), new Size(Width, Height));
            SpeedOx = GameConfig.ColleсtPuzzle.Puzzle.SolidRocket.SpeedOx;
            Acceleration = GameConfig.ColleсtPuzzle.Puzzle.SolidRocket.Acceleration;
        }

        public void MoveOxRight()
        {
            Transform.Position.X += SpeedOx;
            SpeedOx += Acceleration;
        }
    }
}
