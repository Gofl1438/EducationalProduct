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

        public static void DeleteActivePlayersRepeatAction()
        {
            foreach (var player in activePlayersRepeatAction)
            {
                player.Stop();
                player.Dispose();
            }
            activePlayersRepeatAction.Clear();
        }
    }
}
