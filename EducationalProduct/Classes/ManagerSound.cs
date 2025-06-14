using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class ManagerSound
    {
        public static List<SoundPlayer> activePlayersRepeatAction = new List<SoundPlayer>();
        public static List<SoundPlayer> activePlayersColleсtPuzzle = new List<SoundPlayer>();
        public static List<SoundPlayer> activePlayersCatchBones = new List<SoundPlayer>();
        public static List<SoundPlayer> activePlayersDodgeMeteorite = new List<SoundPlayer>();
        public static void DeleteActivePlayersRepeatAction()
        {
            foreach (var player in activePlayersRepeatAction)
            {
                player.Stop();
                player.Dispose();
            }
            activePlayersRepeatAction.Clear();
        }

        public static void DeleteActivePlayersColleсtPuzzle()
        {
            foreach (var player in activePlayersColleсtPuzzle)
            {
                player.Stop();
                player.Dispose();
            }
            activePlayersColleсtPuzzle.Clear();
        }
        public static void DeleteActivePlayersCatchBones()
        {
            foreach (var player in activePlayersCatchBones)
            {
                player.Stop();
                player.Dispose();
            }
            activePlayersCatchBones.Clear();
        }

        public static void DeleteActivePlayersDodgeMeteorite()
        {
            foreach (var player in activePlayersDodgeMeteorite)
            {
                player.Stop();
                player.Dispose();
            }
            activePlayersDodgeMeteorite.Clear();
        }
    }
}
