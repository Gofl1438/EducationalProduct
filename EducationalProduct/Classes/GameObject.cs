using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public abstract class GameObject
    {
        public Transform Transform { get; set; }
        public Bitmap Sprite { get; set; }

        public virtual void DrawSprite(Graphics g)
        {
            if (Sprite == null)
                throw new InvalidOperationException("Спрайт не задан.");

            if (Transform == null)
                throw new InvalidOperationException("Трансформация не задана.");

            g.DrawImage(Sprite, Transform.Position.X, Transform.Position.Y, Transform.Size.Width, Transform.Size.Height);
        }
    }
}
