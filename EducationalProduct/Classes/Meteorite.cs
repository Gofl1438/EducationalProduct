using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class Meteorite : GameObject, IDisposable
    {
        public PhysicsMeteorite Physics { get; set; }
        public bool СompletedMeteorites { get; set; }
        public bool IsVisible { get; set; }
        public Meteorite(PointF position)
        {
            Transform = new Transform(position, new Size(GameConfig.DodgeMeteorites.Meteorite.Width, GameConfig.DodgeMeteorites.Meteorite.Height));
            Sprite = GameConfig.DodgeMeteorites.Meteorite.Sprite;
            Physics = new PhysicsMeteorite(Transform);
            IsVisible = true;
        }

        public void Dispose()
        {
            Sprite = null;
            Physics = null;
            Transform = null;
        }
    }
}
