using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class Transform
    {
        public PointF Position;
        public Size Size { get; set; }
        public Transform(PointF position, Size size)
        {
            Position = position;
            Size = size;
        }
        public Transform Clone()
        {
            Position = new PointF(Position.X, Position.Y);
            Size = new Size(Size.Width, Size.Height);
            return new Transform(Position, Size);
        }
    }
}
