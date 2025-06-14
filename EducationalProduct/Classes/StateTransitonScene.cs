using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateTransitonScene
    {
        public static bool IsTransitonColleсtPuzzle = false;

        public static bool IsTransitonCatchBonesAwait = false;
        public static bool IsTransitonRepeatButtonAwait = false;
        public static bool IsTransitonColleсtPuzzleAwait = false;

        public static bool IsNotCallColleсtPuzzleAwait = false;


        public static bool IsNotCallCatchBonesAwait = false;

        public static bool IsTransitonRepeatActionAwaitOpening = false;
        public static bool IsNotCallRepeatActionAwaitOpening = false;

        public static bool IsNotCallRepeatActionAwait = false;

        public static bool IsNotCallDodgeMeteoritesAwait = false;
        public static bool IsTransitonDodgeMeteoritesAwait = false;

        public static void Init()
        {
            IsTransitonColleсtPuzzle = false;
            IsTransitonCatchBonesAwait = false;
            IsTransitonRepeatButtonAwait = false;
            IsTransitonColleсtPuzzleAwait = false;
            IsNotCallColleсtPuzzleAwait = false;
            IsNotCallCatchBonesAwait = false;
            IsTransitonRepeatActionAwaitOpening = false;
            IsNotCallRepeatActionAwaitOpening = false;
            IsNotCallRepeatActionAwait = false;
            IsNotCallDodgeMeteoritesAwait = false;
            IsTransitonDodgeMeteoritesAwait = false;
    }
    }
}