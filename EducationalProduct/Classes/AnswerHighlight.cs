using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct.Classes
{
    internal class AnswerHighlight
    {
        public static void Highlight(string testType)
        {
            if (testType == "TRA1")
            {
                TestRepeatAction.Answer1.Width = (int)(CanvasProduct.Width * 0.6f);
                TestRepeatAction.Answer1.Height = (int)(TestRepeatAction.Answer1.Width * 0.073f);
                TestRepeatAction.Answer1.PositionOx = CanvasProduct.Width * 0.375f;
                TestRepeatAction.Answer1.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer1.Height - CanvasProduct.Height * 0.34f;
            }
            if (testType == "TRA2")
            {
                TestRepeatAction.Answer2.Width = (int)(CanvasProduct.Width * 0.6f);
                TestRepeatAction.Answer2.Height = (int)(TestRepeatAction.Answer2.Width * 0.073f);
                TestRepeatAction.Answer2.PositionOx = CanvasProduct.Width * 0.375f;
                TestRepeatAction.Answer2.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer2.Height - CanvasProduct.Height * 0.34f;
            }
            if (testType == "TRA3")
            {
                TestRepeatAction.Answer3.Width = (int)(CanvasProduct.Width * 0.6f);
                TestRepeatAction.Answer3.Height = (int)(TestRepeatAction.Answer3.Width * 0.073f);
                TestRepeatAction.Answer3.PositionOx = CanvasProduct.Width * 0.375f;
                TestRepeatAction.Answer3.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer3.Height - CanvasProduct.Height * 0.34f;
            }
            if (testType == "TRA4")
            {
                TestRepeatAction.Answer4.Width = (int)(CanvasProduct.Width * 0.6f);
                TestRepeatAction.Answer4.Height = (int)(TestRepeatAction.Answer4.Width * 0.073f);
                TestRepeatAction.Answer4.PositionOx = CanvasProduct.Width * 0.375f;
                TestRepeatAction.Answer4.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer4.Height - CanvasProduct.Height * 0.34f;
            }
        }
    }
}
