using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class PhysicsMeteorite
    {
        private static Random random = new Random();
        private Transform _transform;
        private float SpeedOy;

        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PhysicsMeteorite(Transform transform)
        {
            Transform = transform;
            SpeedOy = GameConfig.DodgeMeteorites.Meteorite.SpeedOy;
        }
        public void MoveOyMeteorite()
        {
            Transform.Position.Y += SpeedOy;
        }
    }
}
