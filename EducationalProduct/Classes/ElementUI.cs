using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class ElementUI : GameObject 
    {
        public float RotationAngle { get; set; }

        public  ElementUI(Bitmap sprite, Size sizeObject, PointF pointObject, float rotationAngle = 0)
        {
            Sprite = sprite;
            Transform = new Transform(pointObject, sizeObject);
            RotationAngle = rotationAngle;
        }

        public override void DrawSprite(Graphics g)
        {
            if (Sprite == null)
                throw new InvalidOperationException("Спрайт не задан.");

            if (Transform == null)
                throw new InvalidOperationException("Трансформация не задана.");

            GraphicsState state = g.Save();

            g.TranslateTransform(
                Transform.Position.X + Transform.Size.Width / 2,
                Transform.Position.Y + Transform.Size.Height / 2);

            g.RotateTransform(RotationAngle);

            g.DrawImage(Sprite,
                       -Transform.Size.Width / 2,
                       -Transform.Size.Height / 2,
                       Transform.Size.Width,
                       Transform.Size.Height);

            g.Restore(state);
        }
    }
}
