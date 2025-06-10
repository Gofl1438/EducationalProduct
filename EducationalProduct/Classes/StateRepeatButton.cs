using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateRepeatButton
    {
        public static int СurrentQuntitySequence = 0;
        public static int MaxQuntitySequence = GameConfig.RepeatAction.MaxQuntitySequence;
        public static int CurrentStep = 0;
        public static bool SequenceСompleted = true;
        public static bool IsPlayingSequence = false;
        public static bool IsSceneGameOver = false;
    }
}
