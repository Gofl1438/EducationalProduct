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
    public static class ManagerUI
    {
        public static List<ElementUI> TotalElements { get; } = new List<ElementUI>();
        public static List<ElementUI> BtnClosedElement { get; } = new List<ElementUI>();
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
        public static List<ElementUI> RuleElementsDodgeMeteorites { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleElementsRepeatAction { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleElementsColleсtPuzzle { get; } = new List<ElementUI>();
        public static List<ElementUI> RuleElementsCatchBones { get; } = new List<ElementUI>();

        public static void AddRuleElementsDodgeMeteorites()
        {
            RuleElementsDodgeMeteorites.Clear();
            ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            ElementUI RuleDodgeMeteorite = new ElementUI(GameConfig.RuleInfScene.RuleDodgeMeteorite.Sprite,
                GameConfig.RuleInfScene.RuleDodgeMeteorite.Size,
                GameConfig.RuleInfScene.RuleDodgeMeteorite.Point
                );
            ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
            RuleElementsDodgeMeteorites.Add(backgroundMenuExit);
            RuleElementsDodgeMeteorites.Add(RuleDodgeMeteorite);
            RuleElementsDodgeMeteorites.Add(ButtonApply);
        }
        public static void AddRuleElementsRepeatAction()
        {
            RuleElementsRepeatAction.Clear();
            ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            ElementUI RuleRepeatButton = new ElementUI(GameConfig.RuleInfScene.RuleRepeatButton.Sprite,
                GameConfig.RuleInfScene.RuleRepeatButton.Size,
                GameConfig.RuleInfScene.RuleRepeatButton.Point
                );
            ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
            RuleElementsRepeatAction.Add(backgroundMenuExit);
            RuleElementsRepeatAction.Add(RuleRepeatButton);
            RuleElementsRepeatAction.Add(ButtonApply);
        }
        public static void AddRuleElementsColleсtPuzzle()
        {
            RuleElementsColleсtPuzzle.Clear();
            ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            ElementUI RuleCollectPuzzle = new ElementUI(GameConfig.RuleInfScene.RuleCollectPuzzle.Sprite,
                GameConfig.RuleInfScene.RuleCollectPuzzle.Size,
                GameConfig.RuleInfScene.RuleCollectPuzzle.Point
                );
            ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
            RuleElementsColleсtPuzzle.Add(backgroundMenuExit);
            RuleElementsColleсtPuzzle.Add(RuleCollectPuzzle);
            RuleElementsColleсtPuzzle.Add(ButtonApply);
        }
        public static void AddRuleElementsCatchBones()
        {
            RuleElementsCatchBones.Clear();
            ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            ElementUI RuleCatchBones = new ElementUI(GameConfig.RuleInfScene.RuleCatchBones.Sprite,
                GameConfig.RuleInfScene.RuleCatchBones.Size,
                GameConfig.RuleInfScene.RuleCatchBones.Point
                );
            ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
            RuleElementsCatchBones.Add(backgroundMenuExit);
            RuleElementsCatchBones.Add(RuleCatchBones);
            RuleElementsCatchBones.Add(ButtonApply);
        }


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

        public static void AddBtnClosedElement()
        {
            BtnClosedElement.Clear();
            ElementUI btnClosed = new ElementUI(GameConfig.TotalElement.BtnClosed.Sprite,
                GameConfig.TotalElement.BtnClosed.Size,
                GameConfig.TotalElement.BtnClosed.Point
                );
            BtnClosedElement.Add(btnClosed);
        }

        public static void AddTotalElementsMenuExit()
        {
            TotalElementsMenuExit.Clear();
            ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
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
            TotalElementsMenuExit.Add(backgroundMenuExit);
            TotalElementsMenuExit.Add(menuExit);
            TotalElementsMenuExit.Add(buttonNo);
            TotalElementsMenuExit.Add(buttonYes);
        }


        public static void AddOpeningElements()
        {
            OpeningElements.Clear();
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
            RuleElements.Clear();
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
            RuleRepeatActionElements.Clear();
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
            RuleCatchBonesElements.Clear();
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
            RuleCollectPuzzleElements.Clear();
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
            RuleDodgeMeteoritesElements.Clear();
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
            CatchBonesElements.Clear();
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
            DodgeMeteoritesElementsBd.Clear();
            DodgeMeteoritesElementsBn.Clear();
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
            RepeatActionElements.Clear();
            ElementUI background = new ElementUI(GameConfig.RepeatAction.Background.Sprite,
                GameConfig.RepeatAction.Background.Size,
                GameConfig.RepeatAction.Background.Point
                );
            RepeatActionElements.Add(background);
        }

        public static void AddColleсtPuzzleElements()
        {
            ColleсtPuzzleElements.Clear();
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
