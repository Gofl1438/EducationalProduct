﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateDodgeMeteorites
    {
        public static int CurrentСompletedMeteorites;
        public static bool IsRocketDisappear;
        public static bool IsNotCallGameOverAwait;
        public static bool RocketSoundPlayer;
        public static bool СurrentStateMenuClick;
        public static bool SingleView;

        public static void Init()
        {
            CurrentСompletedMeteorites = 0;
            IsRocketDisappear = false;
            IsNotCallGameOverAwait = false;
            RocketSoundPlayer = false;
            СurrentStateMenuClick = false;
            SingleView = false;
        }
    }

}
