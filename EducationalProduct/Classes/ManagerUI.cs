using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfigUI;
using static EducationalProduct.Classes.GameConfigUI.OpeningScene;

namespace EducationalProduct.Classes
{
    public class ManagerUI
    {
        public static List<ElementUI> TotalElements { get; } = new List<ElementUI>();
        public static List<ElementUI> OpeningElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleElements { get; } = new List<ElementUI>();
        public static List<ElementUI> CatchBonesElements { get; } = new List<ElementUI>();

        public static void AddTotalElements()
        {
            ElementUI btnClosed = new ElementUI(GameConfigUI.TotalElement.BtnClosed.Sprite,
                GameConfigUI.TotalElement.BtnClosed.Size,
                GameConfigUI.TotalElement.BtnClosed.Point
                );
            ElementUI btnBackArrow = new ElementUI(GameConfigUI.TotalElement.BtnBackArrow.Sprite,
                GameConfigUI.TotalElement.BtnBackArrow.Size,
                GameConfigUI.TotalElement.BtnBackArrow.Point
                );
            TotalElements.Add(btnClosed);
            TotalElements.Add(btnBackArrow);
        }

        public static void AddOpeningElements()
        {
            ElementUI rocket = new ElementUI(GameConfigUI.OpeningScene.Rocket.Sprite,
                GameConfigUI.OpeningScene.Rocket.Size,
                GameConfigUI.OpeningScene.Rocket.Point,
                GameConfigUI.OpeningScene.Rocket.RotationAngle
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
            ElementUI btnClosed = new ElementUI(GameConfigUI.TotalElement.BtnClosed.Sprite,
                GameConfigUI.TotalElement.BtnClosed.Size,
                GameConfigUI.TotalElement.BtnClosed.Point
                );
            OpeningElements.Add(rocket);
            OpeningElements.Add(btnQuestion);
            OpeningElements.Add(title);
            OpeningElements.Add(btnStartPlay);
            OpeningElements.Add(btnClosed);
        }

        public static void AddRuleElements()
        {
            ElementUI character = new ElementUI(GameConfigUI.RuleScene.Character.Sprite,
                GameConfigUI.RuleScene.Character.Size,
                GameConfigUI.RuleScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfigUI.RuleScene.BtnStartPlay.Sprite,
                GameConfigUI.RuleScene.BtnStartPlay.Size,
                GameConfigUI.RuleScene.BtnStartPlay.Point
                );
            RuleElements.Add(character);
            RuleElements.Add(btnStartPlay);
        }
        public static void AddCatchBonesElements()
        {
            ElementUI character = new ElementUI(GameConfigUI.CatchBones.Character.Sprite,
                GameConfigUI.CatchBones.Character.Size,
                GameConfigUI.CatchBones.Character.Point
                );
            CatchBonesElements.Add(character);
        }
    }
}
