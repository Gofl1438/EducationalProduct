using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct.Classes
{
    public class ManagerUI
    {
        public static List<ElementUI> OpeningElement { get; } = new List<ElementUI>();

        public static void AddOpeningElement()
        {
            ElementUI rocket = new ElementUI(GameConfigUI.OpeningScene.Rocket.Sprite,
                GameConfigUI.OpeningScene.Rocket.Size,
                GameConfigUI.OpeningScene.Rocket.Point,
                GameConfigUI.OpeningScene.Rocket.RotationAngle
                );
            ElementUI background = new ElementUI(GameConfigUI.OpeningScene.Background.Sprite,
                GameConfigUI.OpeningScene.Background.Size,
                GameConfigUI.OpeningScene.Background.Point
                );
            ElementUI btnQuestion = new ElementUI(GameConfigUI.OpeningScene.BtnQuestion.Sprite,
                GameConfigUI.OpeningScene.BtnQuestion.Size,
                GameConfigUI.OpeningScene.BtnQuestion.Point
                );
            ElementUI title = new ElementUI(GameConfigUI.OpeningScene.Title.Sprite,
                GameConfigUI.OpeningScene.Title.Size,
                GameConfigUI.OpeningScene.Title.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfigUI.OpeningScene.BtnStartPlay.Sprite,
                GameConfigUI.OpeningScene.BtnStartPlay.Size,
                GameConfigUI.OpeningScene.BtnStartPlay.Point
                );
            ElementUI btnClosed = new ElementUI(GameConfigUI.OpeningScene.BtnClosed.Sprite,
                GameConfigUI.OpeningScene.BtnClosed.Size,
                GameConfigUI.OpeningScene.BtnClosed.Point
                );
            OpeningElement.Add(background);
            OpeningElement.Add(rocket);
            OpeningElement.Add(btnQuestion);
            OpeningElement.Add(title);
            OpeningElement.Add(btnStartPlay);
            OpeningElement.Add(btnClosed);
        }
    }
}
