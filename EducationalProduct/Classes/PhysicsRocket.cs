using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class PhysicsRocket
    {
        private Transform _transform;
        private float SpeedOx;
        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }
        public PhysicsRocket(Transform transform)
        {
            Transform = transform;
            SpeedOx = GameConfig.DodgeMeteorites.Rocket.SpeedOx;
        }
        public void MoveOxLeft()
        {
            Transform.Position.X -= SpeedOx;
        }
        public void MoveOxRight()
        {
            Transform.Position.X += SpeedOx;
        }
    }
}
