using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class Meteorite : GameObject
    {
        public PhysicsMeteorite Physics { get; set; }
        public bool IsWasHit { get; set; }
        public Meteorite(PointF position)
        {
            Transform = new Transform(position, new Size(GameConfig.DodgeMeteorites.Meteorite.Width, GameConfig.DodgeMeteorites.Meteorite.Height));
            Sprite = GameConfig.DodgeMeteorites.Meteorite.Sprite;
            Physics = new PhysicsMeteorite(Transform);
        }
    }
}
