using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.OpeningScene;
using static EducationalProduct.Classes.GameConfig.RuleRepeatActionScene;
using static EducationalProduct.Classes.GameConfig.RuleScene;
using static EducationalProduct.Classes.GameConfig.TotalElement;

namespace EducationalProduct.Classes
{
    public class ManagerUI
    {
        public static List<ElementUI> TotalElements { get; } = new List<ElementUI>();
        public static List<ElementUI> TotalElementsMenuExit { get; } = new List<ElementUI>();
        public static List<ElementUI> OpeningElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleRepeatActionElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleCatchBonesElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleCollectPuzzleElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleDodgeMeteoritesElements { get; } = new List<ElementUI>();
        public static List<ElementUI> CatchBonesElements { get; } = new List<ElementUI>();
        public static List<ElementUI> ColleсtPuzzleElements { get; } = new List<ElementUI>();
        public static List<ElementUI> RepeatActionElements { get; } = new List<ElementUI>();
        public static List<ElementUI> DodgeMeteoritesElementsBd { get; } = new List<ElementUI>();
        public static List<ElementUI> DodgeMeteoritesElementsBn { get; } = new List<ElementUI>();

        public static void AddTotalElements()
        {
            TotalElements.Clear();
            ElementUI btnClosed = new ElementUI(GameConfig.TotalElement.BtnClosed.Sprite,
                GameConfig.TotalElement.BtnClosed.Size,
                GameConfig.TotalElement.BtnClosed.Point
                );
            ElementUI btnQuestion = new ElementUI(GameConfig.TotalElement.BtnQuestion.Sprite,
                GameConfig.TotalElement.BtnQuestion.Size,
                GameConfig.TotalElement.BtnQuestion.Point
                );
            TotalElements.Add(btnQuestion);
            TotalElements.Add(btnClosed);
        }

        public static void AddTotalElementsMenuExit()
        {
            TotalElementsMenuExit.Clear();
            ElementUI menuExit = new ElementUI(GameConfig.TotalElement.MenuExit.Sprite,
                GameConfig.TotalElement.MenuExit.Size,
                GameConfig.TotalElement.MenuExit.Point
                );
            ElementUI buttonNo = new ElementUI(GameConfig.TotalElement.ButtonNo.Sprite,
                GameConfig.TotalElement.ButtonNo.Size,
                GameConfig.TotalElement.ButtonNo.Point
                );
            ElementUI buttonYes = new ElementUI(GameConfig.TotalElement.ButtonYes.Sprite,
                GameConfig.TotalElement.ButtonYes.Size,
                GameConfig.TotalElement.ButtonYes.Point
                );
            TotalElementsMenuExit.Add(menuExit);
            TotalElementsMenuExit.Add(buttonNo);
            TotalElementsMenuExit.Add(buttonYes);
        }


        public static void AddOpeningElements()
        {
            ElementUI rocket = new ElementUI(GameConfig.OpeningScene.Rocket.Sprite,
                GameConfig.OpeningScene.Rocket.Size,
                GameConfig.OpeningScene.Rocket.Point,
                GameConfig.OpeningScene.Rocket.RotationAngle
                );
            ElementUI title = new ElementUI(GameConfig.OpeningScene.Title.Sprite,
                GameConfig.OpeningScene.Title.Size,
                GameConfig.OpeningScene.Title.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.OpeningScene.BtnStartPlay.Sprite,
                GameConfig.OpeningScene.BtnStartPlay.Size,
                GameConfig.OpeningScene.BtnStartPlay.Point
                );
            OpeningElements.Add(rocket);
            OpeningElements.Add(title);
            OpeningElements.Add(btnStartPlay);
        }


        public static void AddRuleElements()
        {
            ElementUI character = new ElementUI(GameConfig.RuleScene.Character.Sprite,
                GameConfig.RuleScene.Character.Size,
                GameConfig.RuleScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.RuleScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            ElementUI txtRuleScene = new ElementUI(GameConfig.RuleScene.TxtRuleScene.Sprite,
                GameConfig.RuleScene.TxtRuleScene.Size,
                GameConfig.RuleScene.TxtRuleScene.Point
                );
            RuleElements.Add(character);
            RuleElements.Add(btnStartPlay);
            RuleElements.Add(txtRuleScene);
        }

        public static void AddRuleRepeatActionElements()
        {
            ElementUI character = new ElementUI(GameConfig.RuleRepeatActionScene.Character.Sprite,
                GameConfig.RuleRepeatActionScene.Character.Size,
                GameConfig.RuleRepeatActionScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.RuleRepeatActionScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            ElementUI txtRuleRepeatActionScene = new ElementUI(GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene.Sprite,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene.Size,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene.Point
                );
            RuleRepeatActionElements.Add(character);
            RuleRepeatActionElements.Add(btnStartPlay);
            RuleRepeatActionElements.Add(txtRuleRepeatActionScene);
        }

        public static void AddRuleCatchBonesElements()
        {
            ElementUI character = new ElementUI(GameConfig.RuleCatchBonesScene.Character.Sprite,
                GameConfig.RuleCatchBonesScene.Character.Size,
                GameConfig.RuleCatchBonesScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.RuleCatchBonesScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            ElementUI txtRuleCatchBonesScene = new ElementUI(GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene.Sprite,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene.Size,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene.Point
                );
            RuleCatchBonesElements.Add(character);
            RuleCatchBonesElements.Add(btnStartPlay);
            RuleCatchBonesElements.Add(txtRuleCatchBonesScene);
        }

        public static void AddRuleCollectPuzzleElements()
        {
            ElementUI character = new ElementUI(GameConfig.RuleCollectPuzzleScene.Character.Sprite,
                GameConfig.RuleCollectPuzzleScene.Character.Size,
                GameConfig.RuleCollectPuzzleScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            ElementUI txtRuleCollectPuzzleScene = new ElementUI(GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.Sprite,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.Size,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.Point
                );
            RuleCollectPuzzleElements.Add(character);
            RuleCollectPuzzleElements.Add(btnStartPlay);
            RuleCollectPuzzleElements.Add(txtRuleCollectPuzzleScene);
        }

        public static void AddRuleDodgeMeteoritesElements()
        {
            ElementUI character = new ElementUI(GameConfig.RuleDodgeMeteoritesScene.Character.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.Character.Size,
                GameConfig.RuleDodgeMeteoritesScene.Character.Point
                );
            ElementUI btnStartPlay = new ElementUI(GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            ElementUI txtRuleDodgeMeteoritesScene = new ElementUI(GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.Size,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.Point
                );
            RuleDodgeMeteoritesElements.Add(character);
            RuleDodgeMeteoritesElements.Add(btnStartPlay);
            RuleDodgeMeteoritesElements.Add(txtRuleDodgeMeteoritesScene);
        }


        public static void AddCatchBonesElements()
        {
            ElementUI character = new ElementUI(GameConfig.CatchBones.Character.Sprite,
                GameConfig.CatchBones.Character.Size,
                GameConfig.CatchBones.Character.Point 
                );
            ElementUI background = new ElementUI(GameConfig.CatchBones.Background.Sprite,
                GameConfig.CatchBones.Background.Size,
                GameConfig.CatchBones.Background.Point
                );
            CatchBonesElements.Add(background);
            CatchBonesElements.Add(character);
        }

        public static void AddDodgeMeteoritesElements()
        {
            ElementUI background = new ElementUI(GameConfig.DodgeMeteorites.Background.Sprite,
                GameConfig.DodgeMeteorites.Background.Size,
                GameConfig.DodgeMeteorites.Background.Point
                );
            ElementUI buttonLeft = new ElementUI(GameConfig.DodgeMeteorites.ButtonMove.Left.Sprite,
                GameConfig.DodgeMeteorites.ButtonMove.Left.Size,
                GameConfig.DodgeMeteorites.ButtonMove.Left.Point
                );
            ElementUI buttonRight = new ElementUI(GameConfig.DodgeMeteorites.ButtonMove.Right.Sprite,
                GameConfig.DodgeMeteorites.ButtonMove.Right.Size,
                GameConfig.DodgeMeteorites.ButtonMove.Right.Point
                );
            DodgeMeteoritesElementsBd.Add(background);
            DodgeMeteoritesElementsBn.Add(buttonLeft);
            DodgeMeteoritesElementsBn.Add(buttonRight);
        }

        public static void AddRepeatActionElements()
        {
            ElementUI background = new ElementUI(GameConfig.RepeatAction.Background.Sprite,
                GameConfig.RepeatAction.Background.Size,
                GameConfig.RepeatAction.Background.Point
                );
            RepeatActionElements.Add(background);
        }

        public static void AddColleсtPuzzleElements()
        {
            ElementUI background = new ElementUI(GameConfig.ColleсtPuzzle.Background.Sprite,
                GameConfig.ColleсtPuzzle.Background.Size,
                GameConfig.ColleсtPuzzle.Background.Point
                );
            ElementUI shadow = new ElementUI(GameConfig.ColleсtPuzzle.Puzzle.Shadow.Sprite,
                GameConfig.ColleсtPuzzle.Puzzle.Shadow.Size,
                GameConfig.ColleсtPuzzle.Puzzle.Shadow.Point
                );
            ColleсtPuzzleElements.Add(background);
            ColleсtPuzzleElements.Add(shadow);
        }
    }
}
