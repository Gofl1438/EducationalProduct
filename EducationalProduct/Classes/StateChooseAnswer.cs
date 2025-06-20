using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    internal class StateChooseAnswer
    {
        public static bool trueAnswer;
        public static bool showTip;
        public static bool showSuccess;
        public static bool chooseAnswer;
        public static bool goNext;
        public static bool answerIsGiven;
        public static bool currentStateMenuClick;

        public static void Init()
        {
            trueAnswer = false;
            showTip = false;
            showSuccess = false;
            chooseAnswer = false;
            goNext = false;
            answerIsGiven = false;
            currentStateMenuClick = false;
        }
    }
}
