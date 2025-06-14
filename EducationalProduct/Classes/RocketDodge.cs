using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites.Rocket;

namespace EducationalProduct.Classes
{
    public class RocketDodge : GameObject
    {
        public PhysicsRocket Physics { get; set; }
        public bool IsVisible { get; set; }
        public RocketDodge()
        {
            Transform = new Transform(GameConfig.DodgeMeteorites.Rocket.Point, 
                new Size(Width, Height)
                );
            Sprite = GameConfig.DodgeMeteorites.Rocket.Sprite;
            Physics = new PhysicsRocket(Transform);
            IsVisible = true;
        }
    }
}
