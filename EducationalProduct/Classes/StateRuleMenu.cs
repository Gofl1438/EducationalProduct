using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateRuleMenu
    {
        public static bool СurrentStateMenuRuleCatchBones = false;
        public static bool СurrentStateMenuRuleCollectPuzzle = false;
        public static bool СurrentStateMenuRuleDodgeMeteorites = false;
        public static bool СurrentStateMenuRuleRepeatAction = false;

        public static void Init()
        {
            СurrentStateMenuRuleCatchBones = false;
            СurrentStateMenuRuleCollectPuzzle = false;
            СurrentStateMenuRuleDodgeMeteorites = false;
            СurrentStateMenuRuleRepeatAction = false;
        }
    }
}
