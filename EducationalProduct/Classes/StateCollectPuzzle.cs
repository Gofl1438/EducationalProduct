using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateCollectPuzzle
    {
        public static int countFreePuzzles;
        public static bool rocketLaunch;
        public static bool СurrentStateMenuClick;

        public static void Init()
        {
            countFreePuzzles = 0;
            rocketLaunch = false;
            СurrentStateMenuClick = false;
        }
    }
}
