using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    internal class StateCurrentScene
    {
        public static bool RepeatActionScene;
        public static bool CatchBonesScene;
        public static bool CollectPuzzleScene;
        public static bool DodgeMeteoritesScene;

        public static void Init()
        {
            RepeatActionScene = false;
            CatchBonesScene = false;
            CollectPuzzleScene = false;
            DodgeMeteoritesScene = false;
        }
    }
}
