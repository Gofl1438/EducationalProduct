using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateExitMenu
    {
        public static bool СurrentStateMenuExitCatchBones;
        public static bool СurrentStateMenuExitCollectPuzzle;
        public static bool СurrentStateMenuExitDodgeMeteorites;
        public static bool СurrentStateMenuExitRepeatAction;
        public static bool CurrentStateMenuExitRuleCatchBonesScene;
        public static bool CurrentStateMenuExitRuleCollectPuzzleScene;
        public static bool CurrentStateMenuExitRuleDodgeMeteoritesScene;
        public static bool CurrentStateMenuExitRuleRepeatActionScene;
        public static bool CurrentStateMenuExitRuleScene;
        public static bool CurrentStateMenuExitTestScene;
        public static bool CurrentStateMenuExitOpeningScene;

        public static void Init()
        {
            СurrentStateMenuExitCatchBones = false;
            СurrentStateMenuExitCollectPuzzle = false;
            СurrentStateMenuExitDodgeMeteorites = false;
            СurrentStateMenuExitRepeatAction = false;
            CurrentStateMenuExitRuleCatchBonesScene = false;
            CurrentStateMenuExitRuleCollectPuzzleScene = false;
            CurrentStateMenuExitRuleDodgeMeteoritesScene = false;
            CurrentStateMenuExitRuleRepeatActionScene = false;
            CurrentStateMenuExitRuleScene = false;
            CurrentStateMenuExitTestScene = false;
            CurrentStateMenuExitOpeningScene = false;
        }
    }
}
