using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites.Meteorite;

namespace EducationalProduct.Classes
{
    public static class ManagerDodgeMeteorites
    {
        private static Random random = new Random();
        public static List<Meteorite> Meteorites = new List<Meteorite>();
        
        public static void Dispose()
        {
            foreach (var met in Meteorites)
            {
                met.Dispose();
            }
        }
        public static void AddMeteoritesNormal()
        {
            Meteorites.Clear();
            for (int i = 0; i < DefaultQuantityMeteorites; i++)
            {
                PointF position = new PointF();
                if (Meteorites.Count == 0)
                {
                    position.Y = -Height;
                }
                else
                {
                    float maxPosOy = Meteorites[Meteorites.Count - 1].Transform.Position.Y - GameConfig.DodgeMeteorites.Rocket.Height;
                    float minPosOy = maxPosOy - Height;
                    position.Y = minPosOy + (float)random.NextDouble() * (maxPosOy - minPosOy);
                }
                position.X = (float)random.NextDouble() * (GameConfig.CanvasProduct.Width - Width);

                Meteorites.Add(new Meteorite(position));
            }
        }

        public static void DeleteMeteorites()
        {
            for (int i = Meteorites.Count - 1; i >= 0; i--)
            {
                if (Meteorites[i].Transform.Position.Y > GameConfig.CanvasProduct.Height)
                {
                    Meteorites.RemoveAt(i);
                }
            }
        }
    }
}
