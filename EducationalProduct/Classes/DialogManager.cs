using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    internal class DialogManager
    {
        public static bool UpdateNextBtn(bool startGame, int buttonIndex)
        {
            //Пропуск кнопки Начать
            if (!startGame && (buttonIndex == 1))
            {
                return true;
            }
            //Пропуск кнопки Далее
            if (startGame && (buttonIndex == 2))
            {
                return true;
            }

            return false;
        }
        public static bool UpdateDialog(int countNextbtn, int dialogIndex)
        {
            //Пропуск 2 и 3 диалога
            if ((countNextbtn == 0 && (dialogIndex == 4)) || (countNextbtn == 0 && (dialogIndex == 5)))
            {
                return true;
            }
            //Пропуск 1 и 3 диалога
            else if (((countNextbtn == 1) && (dialogIndex == 3)) || ((countNextbtn == 1) && (dialogIndex == 5)))
            {
                return true;
            }
            //Пропуск 1 и 2 диалога
            else if (((countNextbtn == 2) && (dialogIndex == 3)) || ((countNextbtn == 2) && (dialogIndex == 4)))
            {
                return true;
            }

            return false;
        }
    }
}
