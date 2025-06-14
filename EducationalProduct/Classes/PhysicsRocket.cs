using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class PhysicsRocket
    {
        public bool IsWasHit { get; set; }
        private Transform _transform;
        private float SpeedOx;
        private float SpeedOy;
        private float Acceleration;
        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }
        public PhysicsRocket(Transform transform)
        {
            Transform = transform;
            SpeedOx = GameConfig.DodgeMeteorites.Rocket.SpeedOx;
            SpeedOy = GameConfig.DodgeMeteorites.Rocket.SpeedOy;
            Acceleration = GameConfig.DodgeMeteorites.Rocket.Acceleration;
        }
        public void MoveOxLeft()
        {
            Transform.Position.X -= SpeedOx;
            if (Transform.Position.X < 0)
            {
                Transform.Position.X = 0;
            }
        }
        public void MoveOxRight()
        {
            Transform.Position.X += SpeedOx;
            if (Transform.Position.X + GameConfig.DodgeMeteorites.Rocket.Width > GameConfig.CanvasProduct.Width)
            {
                Transform.Position.X = GameConfig.CanvasProduct.Width - GameConfig.DodgeMeteorites.Rocket.Width;
            }
        }
        
        public void MoveDisappear()
        {
            Transform.Position.Y -= SpeedOy;
            SpeedOy += Acceleration;
        }
        public void CheckCollideWithMeteorites()
        {
            for (int i = 0; i < ManagerDodgeMeteorites.Meteorites.Count; i++)
            {
                var meteorite = ManagerDodgeMeteorites.Meteorites[i];

                // Основной корпус ракеты
                var rocketRect = new RectangleF(
                    Transform.Position.X,
                    Transform.Position.Y + GameConfig.DodgeMeteorites.Rocket.HeightAntenna,
                    Transform.Size.Width,
                    GameConfig.DodgeMeteorites.Rocket.HeightWithoutFuel
                );

                // Антенна ракеты
                var antennaRect = new RectangleF(
                    Transform.Position.X + (Transform.Size.Width - GameConfig.DodgeMeteorites.Rocket.WidthAntenna) / 2,
                    Transform.Position.Y,
                    GameConfig.DodgeMeteorites.Rocket.WidthAntenna,
                    GameConfig.DodgeMeteorites.Rocket.HeightAntenna
                );

                // Метеорит
                var meteoriteRect = new RectangleF(
                    meteorite.Transform.Position.X,
                    meteorite.Transform.Position.Y,
                    meteorite.Transform.Size.Width,
                    meteorite.Transform.Size.Height
                );

                // Проверяем столкновение метеорита с корпусом или антенной
                if (meteoriteRect.IntersectsWith(rocketRect) ||
                    meteoriteRect.IntersectsWith(antennaRect))
                {
                    IsWasHit = true;
                    break;
                }
            }
        }
    }
}
