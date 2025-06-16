using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateRepeatButton
    {
        public static int СurrentQuntitySequence;
        public static int CurrentStep;
        public static bool SequenceСompleted;
        public static bool IsPlayingSequence;
        public static bool IsSceneGameOver;
        public static bool IsSceneWinGame;
        public static bool PressButtonAnimation;
        public static bool СurrentStateMenuClick;
        public static bool ErorClickButton;
        public static CancellationTokenSource cts;

        public static void Init()
        { 
            СurrentQuntitySequence = 0;
            CurrentStep = 0;
            SequenceСompleted = true;
            IsPlayingSequence = false;
            IsSceneGameOver = false;
            IsSceneWinGame = false;
            PressButtonAnimation = false;
            СurrentStateMenuClick = false;
            ErorClickButton = false;
            cts = new CancellationTokenSource();
        }
    }
}
