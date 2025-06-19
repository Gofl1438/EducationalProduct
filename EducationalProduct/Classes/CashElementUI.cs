using EducationalProduct.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct.Classes
{
    public static class CashElementUI
    {
        public static class RuleElementsDodgeMeteorites
        {
            public static readonly ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI RuleDodgeMeteorite = new ElementUI(GameConfig.RuleInfScene.RuleDodgeMeteorite.Sprite,
                GameConfig.RuleInfScene.RuleDodgeMeteorite.Size,
                GameConfig.RuleInfScene.RuleDodgeMeteorite.Point
                );
            public static readonly ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
        }
        public static class RuleElementsRepeatAction
        {
            public static readonly ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI RuleRepeatButton = new ElementUI(GameConfig.RuleInfScene.RuleRepeatButton.Sprite,
                GameConfig.RuleInfScene.RuleRepeatButton.Size,
                GameConfig.RuleInfScene.RuleRepeatButton.Point
                );
            public static readonly ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
        }
        public static class RuleElementsColleсtPuzzle
        {
            public static readonly ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI RuleCollectPuzzle = new ElementUI(GameConfig.RuleInfScene.RuleCollectPuzzle.Sprite,
                GameConfig.RuleInfScene.RuleCollectPuzzle.Size,
                GameConfig.RuleInfScene.RuleCollectPuzzle.Point
                );
            public static readonly ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
        }
        public static class RuleElementsCatchBones
        {
            public static readonly ElementUI backgroundMenuExit = new ElementUI(GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI RuleCatchBones = new ElementUI(GameConfig.RuleInfScene.RuleCatchBones.Sprite,
                GameConfig.RuleInfScene.RuleCatchBones.Size,
                GameConfig.RuleInfScene.RuleCatchBones.Point
                );
            public static readonly ElementUI ButtonApply = new ElementUI(GameConfig.RuleInfScene.ButtonApply.Sprite,
                GameConfig.RuleInfScene.ButtonApply.Size,
                GameConfig.RuleInfScene.ButtonApply.Point
                );
        }

        public static class TotalElements
        {
            public static readonly ElementUI btnClosed = new ElementUI(
                GameConfig.TotalElement.BtnClosed.Sprite,
                GameConfig.TotalElement.BtnClosed.Size,
                GameConfig.TotalElement.BtnClosed.Point
                );
            public static readonly ElementUI btnQuestion = new ElementUI(
                GameConfig.TotalElement.BtnQuestion.Sprite,
                GameConfig.TotalElement.BtnQuestion.Size,
                GameConfig.TotalElement.BtnQuestion.Point
                );
        }

        public static class BtnClosedElement
        {
            public static readonly ElementUI btnClosed = new ElementUI(GameConfig.TotalElement.BtnClosed.Sprite,
                GameConfig.TotalElement.BtnClosed.Size,
                GameConfig.TotalElement.BtnClosed.Point
                );
        }

        public static class TotalElementsMenuExit
        {
            public static readonly  ElementUI backgroundMenuExit = new ElementUI(
                GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI menuExit = new ElementUI(
                GameConfig.TotalElement.MenuExit.Sprite,
                GameConfig.TotalElement.MenuExit.Size,
                GameConfig.TotalElement.MenuExit.Point
                );
            public static readonly ElementUI buttonNo = new ElementUI(
                GameConfig.TotalElement.ButtonNo.Sprite,
                GameConfig.TotalElement.ButtonNo.Size,
                GameConfig.TotalElement.ButtonNo.Point
                );
            public static readonly ElementUI buttonYes = new ElementUI(
                GameConfig.TotalElement.ButtonYes.Sprite,
                GameConfig.TotalElement.ButtonYes.Size,
                GameConfig.TotalElement.ButtonYes.Point
                );
        }

        public static class TotalElementsMenuExitOpeningScene
        {
            public static readonly ElementUI backgroundMenuExit = new ElementUI(
                GameConfig.TotalElement.BackgroundMenuExit.Sprite,
                GameConfig.TotalElement.BackgroundMenuExit.Size,
                GameConfig.TotalElement.BackgroundMenuExit.Point
                );
            public static readonly ElementUI menuExit = new ElementUI(
                GameConfig.OpeningScene.MenuExit.Sprite,
                GameConfig.OpeningScene.MenuExit.Size,
                GameConfig.OpeningScene.MenuExit.Point
                );
            public static readonly ElementUI buttonNo = new ElementUI(
                GameConfig.TotalElement.ButtonNo.Sprite,
                GameConfig.TotalElement.ButtonNo.Size,
                GameConfig.TotalElement.ButtonNo.Point
                );
            public static readonly ElementUI buttonYes = new ElementUI(
                GameConfig.TotalElement.ButtonYes.Sprite,
                GameConfig.TotalElement.ButtonYes.Size,
                GameConfig.TotalElement.ButtonYes.Point
                );
        }

        public static class OpeningElements
        {
            public static readonly ElementUI rocket = new ElementUI(
                GameConfig.OpeningScene.Rocket.Sprite,
                GameConfig.OpeningScene.Rocket.Size,
                GameConfig.OpeningScene.Rocket.Point,
                GameConfig.OpeningScene.Rocket.RotationAngle
                );
            public static readonly ElementUI title = new ElementUI(
                GameConfig.OpeningScene.Title.Sprite,
                GameConfig.OpeningScene.Title.Size,
                GameConfig.OpeningScene.Title.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.OpeningScene.BtnStartPlay.Sprite,
                GameConfig.OpeningScene.BtnStartPlay.Size,
                GameConfig.OpeningScene.BtnStartPlay.Point
                );
            public static readonly ElementUI btnClosed = new ElementUI(
                GameConfig.OpeningScene.BtnClosed.Sprite,
                GameConfig.OpeningScene.BtnClosed.Size,
                GameConfig.OpeningScene.BtnClosed.Point
                );
        }


        public static class RuleElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.RuleScene.Character.Sprite,
                GameConfig.RuleScene.Character.Size,
                GameConfig.RuleScene.Character.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.RuleScene.BtnStartPlay.Sprite,
                GameConfig.RuleScene.BtnStartPlay.Size,
                GameConfig.RuleScene.BtnStartPlay.Point
                );
            public static readonly ElementUI txtRuleScene = new ElementUI(
                GameConfig.RuleScene.TxtRuleScene.Sprite,
                GameConfig.RuleScene.TxtRuleScene.Size,
                GameConfig.RuleScene.TxtRuleScene.Point
                );
        }
      
        public static class EndElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.EndScene.Character.Sprite,
                GameConfig.EndScene.Character.Size,
                GameConfig.EndScene.Character.Point
                );
            public static readonly ElementUI btnToStart = new ElementUI(
                GameConfig.EndScene.BtnToStart.Sprite,
                GameConfig.EndScene.BtnToStart.Size,
                GameConfig.EndScene.BtnToStart.Point
                );
            public static readonly ElementUI txtEndScene = new ElementUI(
                GameConfig.EndScene.TxtEndScene.Sprite,
                GameConfig.EndScene.TxtEndScene.Size,
                GameConfig.EndScene.TxtEndScene.Point
                );
        }

        public static class RuleRepeatActionElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.RuleRepeatActionScene.Character.Sprite,
                GameConfig.RuleRepeatActionScene.Character.Size,
                GameConfig.RuleRepeatActionScene.Character.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.RuleRepeatActionScene.BtnStartPlay.Sprite,
                GameConfig.RuleRepeatActionScene.BtnStartPlay.Size,
                GameConfig.RuleRepeatActionScene.BtnStartPlay.Point
                );
            public static readonly ElementUI btnNextPlay = new ElementUI(
                GameConfig.RuleRepeatActionScene.BtnNextPlay.Sprite,
                GameConfig.RuleRepeatActionScene.BtnNextPlay.Size,
                GameConfig.RuleRepeatActionScene.BtnNextPlay.Point
                );
            public static readonly ElementUI btnBackPlay = new ElementUI(
                GameConfig.RuleRepeatActionScene.BtnBackPlay.Sprite,
                GameConfig.RuleRepeatActionScene.BtnBackPlay.Size,
                GameConfig.RuleRepeatActionScene.BtnBackPlay.Point
                );
            public static readonly ElementUI txtRuleRepeatActionScene1 = new ElementUI(
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene1.Sprite,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene1.Size,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene1.Point
                );
            public static readonly ElementUI txtRuleRepeatActionScene2 = new ElementUI(
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene2.Sprite,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene2.Size,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene2.Point
                );
            public static readonly ElementUI txtRuleRepeatActionScene3 = new ElementUI(
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene3.Sprite,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene3.Size,
                GameConfig.RuleRepeatActionScene.TxtRuleRepeatActionScene3.Point
                );
        }

        public static class RuleCatchBonesElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.RuleCatchBonesScene.Character.Sprite,
                GameConfig.RuleCatchBonesScene.Character.Size,
                GameConfig.RuleCatchBonesScene.Character.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.RuleCatchBonesScene.BtnStartPlay.Sprite,
                GameConfig.RuleCatchBonesScene.BtnStartPlay.Size,
                GameConfig.RuleCatchBonesScene.BtnStartPlay.Point
                );
            public static readonly ElementUI btnNextPlay = new ElementUI(
                GameConfig.RuleCatchBonesScene.BtnNextPlay.Sprite,
                GameConfig.RuleCatchBonesScene.BtnNextPlay.Size,
                GameConfig.RuleCatchBonesScene.BtnNextPlay.Point
                );
            public static readonly ElementUI btnBackPlay = new ElementUI(
                GameConfig.RuleCatchBonesScene.BtnBackPlay.Sprite,
                GameConfig.RuleCatchBonesScene.BtnBackPlay.Size,
                GameConfig.RuleCatchBonesScene.BtnBackPlay.Point
                );
            public static readonly ElementUI txtRuleCatchBonesScene1 = new ElementUI(
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene1.Sprite,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene1.Size,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene1.Point
                );
            public static readonly ElementUI txtRuleCatchBonesScene2 = new ElementUI(
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene2.Sprite,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene2.Size,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene2.Point
                );
            public static readonly ElementUI txtRuleCatchBonesScene3 = new ElementUI(
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene3.Sprite,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene3.Size,
                GameConfig.RuleCatchBonesScene.TxtRuleCatchBonesScene3.Point
                );
        }

        public static class RuleCollectPuzzleElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.Character.Sprite,
                GameConfig.RuleCollectPuzzleScene.Character.Size,
                GameConfig.RuleCollectPuzzleScene.Character.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Sprite,
                GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Size,
                GameConfig.RuleCollectPuzzleScene.BtnStartPlay.Point
                );
            public static readonly ElementUI btnNextPlay = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.BtnNextPlay.Sprite,
                GameConfig.RuleCollectPuzzleScene.BtnNextPlay.Size,
                GameConfig.RuleCollectPuzzleScene.BtnNextPlay.Point
                );
            public static readonly ElementUI btnBackPlay = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.BtnBackPlay.Sprite,
                GameConfig.RuleCollectPuzzleScene.BtnBackPlay.Size,
                GameConfig.RuleCollectPuzzleScene.BtnBackPlay.Point
                );
            public static readonly ElementUI txtRuleCollectPuzzleScene1 = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Sprite,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Size,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Point
                );
            public static readonly ElementUI txtRuleCollectPuzzleScene2 = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Sprite,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Size,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Point
                );
            public static readonly ElementUI txtRuleCollectPuzzleScene3 = new ElementUI(
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Sprite,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Size,
                GameConfig.RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Point
                );
        }

        public static class RuleDodgeMeteoritesElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.Character.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.Character.Size,
                GameConfig.RuleDodgeMeteoritesScene.Character.Point
                );
            public static readonly ElementUI btnStartPlay = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Size,
                GameConfig.RuleDodgeMeteoritesScene.BtnStartPlay.Point
                );
            public static readonly ElementUI btnNextPlay = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.Size,
                GameConfig.RuleDodgeMeteoritesScene.BtnNextPlay.Point
                );
            public static readonly ElementUI btnBackPlay = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.Size,
                GameConfig.RuleDodgeMeteoritesScene.BtnBackPlay.Point
                );
            public static readonly ElementUI txtRuleDodgeMeteoritesScene1 = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Size,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Point
                );
            public static readonly ElementUI txtRuleDodgeMeteoritesScene2 = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Size,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Point
                );
            public static readonly ElementUI txtRuleDodgeMeteoritesScene3 = new ElementUI(
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Sprite,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Size,
                GameConfig.RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Point
                );
        }

        public static class CatchBonesElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.CatchBones.Character.Sprite,
                GameConfig.CatchBones.Character.Size,
                GameConfig.CatchBones.Character.Point
                );
            public static readonly ElementUI background = new ElementUI(
                GameConfig.CatchBones.Background.Sprite,
                GameConfig.CatchBones.Background.Size,
                GameConfig.CatchBones.Background.Point
                );
        }

        public static class DodgeMeteoritesElements
        {
           public static readonly ElementUI background = new ElementUI(
                GameConfig.DodgeMeteorites.Background.Sprite,
                GameConfig.DodgeMeteorites.Background.Size,
                GameConfig.DodgeMeteorites.Background.Point
                );
            public static readonly ElementUI buttonLeft = new ElementUI(
                GameConfig.DodgeMeteorites.ButtonMove.Left.Sprite,
                GameConfig.DodgeMeteorites.ButtonMove.Left.Size,
                GameConfig.DodgeMeteorites.ButtonMove.Left.Point
                );
            public static readonly ElementUI buttonRight = new ElementUI(
                GameConfig.DodgeMeteorites.ButtonMove.Right.Sprite,
                GameConfig.DodgeMeteorites.ButtonMove.Right.Size,
                GameConfig.DodgeMeteorites.ButtonMove.Right.Point
                );
        }

        public static class RepeatActionElements
        {
            public static readonly ElementUI background = new ElementUI(
                GameConfig.RepeatAction.Background.Sprite,
                GameConfig.RepeatAction.Background.Size,
                GameConfig.RepeatAction.Background.Point
                );
        }

        public static class ColleсtPuzzleElements
        {
            public static readonly ElementUI background = new ElementUI(
                GameConfig.ColleсtPuzzle.Background.Sprite,
                GameConfig.ColleсtPuzzle.Background.Size,
                GameConfig.ColleсtPuzzle.Background.Point
                );
            public static readonly ElementUI shadow = new ElementUI(
                GameConfig.ColleсtPuzzle.Puzzle.Shadow.Sprite,
                GameConfig.ColleсtPuzzle.Puzzle.Shadow.Size,
                GameConfig.ColleсtPuzzle.Puzzle.Shadow.Point
                );
        }

        public static class TestInterfaceElements
        {
            public static readonly ElementUI character = new ElementUI(
                GameConfig.TestInterface.Character.Sprite,
                GameConfig.TestInterface.Character.Size,
                GameConfig.TestInterface.Character.Point
                );
            public static readonly ElementUI btnAnswer = new ElementUI(
                GameConfig.TestInterface.BtnAnswer.Sprite,
                GameConfig.TestInterface.BtnAnswer.Size,
                GameConfig.TestInterface.BtnAnswer.Point
                );
            public static readonly ElementUI btnNextPlay = new ElementUI(
                GameConfig.TestInterface.BtnNextPlay.Sprite,
                GameConfig.TestInterface.BtnNextPlay.Size,
                GameConfig.TestInterface.BtnNextPlay.Point
                );
            public static readonly ElementUI backgroundTest = new ElementUI(
                GameConfig.TestInterface.BackgroundTest.Sprite,
                GameConfig.TestInterface.BackgroundTest.Size,
                GameConfig.TestInterface.BackgroundTest.Point
                );
            public static readonly ElementUI success = new ElementUI(
                GameConfig.TestInterface.Success.Sprite,
                GameConfig.TestInterface.Success.Size,
                GameConfig.TestInterface.Success.Point
                );

        }
        public static class TestRepeatActionElements
        {
            public static readonly ElementUI question = new ElementUI(
                GameConfig.TestRepeatAction.Question.Sprite,
                GameConfig.TestRepeatAction.Question.Size,
                GameConfig.TestRepeatAction.Question.Point
                );
            public static readonly ElementUI tip = new ElementUI(
                GameConfig.TestRepeatAction.Tip.Sprite,
                GameConfig.TestRepeatAction.Tip.Size,
                GameConfig.TestRepeatAction.Tip.Point
                );
            public static readonly ElementUI answer1 = new ElementUI(
                GameConfig.TestRepeatAction.Answer1.Sprite,
                GameConfig.TestRepeatAction.Answer1.Size,
                GameConfig.TestRepeatAction.Answer1.Point
                );
            public static readonly ElementUI answer2 = new ElementUI(
                GameConfig.TestRepeatAction.Answer2.Sprite,
                GameConfig.TestRepeatAction.Answer2.Size,
                GameConfig.TestRepeatAction.Answer2.Point
                );
            public static readonly ElementUI answer3 = new ElementUI(
                GameConfig.TestRepeatAction.Answer3.Sprite,
                GameConfig.TestRepeatAction.Answer3.Size,
                GameConfig.TestRepeatAction.Answer3.Point
                );
            public static readonly ElementUI answer4 = new ElementUI(
                GameConfig.TestRepeatAction.Answer4.Sprite,
                GameConfig.TestRepeatAction.Answer4.Size,
                GameConfig.TestRepeatAction.Answer4.Point
                );
        }
        public static class TestCatchBonesElements
        {
            public static readonly ElementUI question = new ElementUI(
                GameConfig.TestCatchBones.Question.Sprite,
                GameConfig.TestCatchBones.Question.Size,
                GameConfig.TestCatchBones.Question.Point
                );
            public static readonly ElementUI tip = new ElementUI(
                GameConfig.TestCatchBones.Tip.Sprite,
                GameConfig.TestCatchBones.Tip.Size,
                GameConfig.TestCatchBones.Tip.Point
                );
            public static readonly ElementUI answer1 = new ElementUI(
                GameConfig.TestCatchBones.Answer1.Sprite,
                GameConfig.TestCatchBones.Answer1.Size,
                GameConfig.TestCatchBones.Answer1.Point
                );
            public static readonly ElementUI answer2 = new ElementUI(
                GameConfig.TestCatchBones.Answer2.Sprite,
                GameConfig.TestCatchBones.Answer2.Size,
                GameConfig.TestCatchBones.Answer2.Point
                );
            public static readonly ElementUI answer3 = new ElementUI(
                GameConfig.TestCatchBones.Answer3.Sprite,
                GameConfig.TestCatchBones.Answer3.Size,
                GameConfig.TestCatchBones.Answer3.Point
                );
            public static readonly ElementUI answer4 = new ElementUI(
                GameConfig.TestCatchBones.Answer4.Sprite,
                GameConfig.TestCatchBones.Answer4.Size,
                GameConfig.TestCatchBones.Answer4.Point
                );
        }
        public static class TestCollectPuzzleElements
        {
            public static readonly ElementUI question = new ElementUI(
                GameConfig.TestCollectPuzzle.Question.Sprite,
                GameConfig.TestCollectPuzzle.Question.Size,
                GameConfig.TestCollectPuzzle.Question.Point
                );
            public static readonly ElementUI tip = new ElementUI(
                GameConfig.TestCollectPuzzle.Tip.Sprite,
                GameConfig.TestCollectPuzzle.Tip.Size,
                GameConfig.TestCollectPuzzle.Tip.Point
                );
            public static readonly ElementUI answer1 = new ElementUI(
                GameConfig.TestCollectPuzzle.Answer1.Sprite,
                GameConfig.TestCollectPuzzle.Answer1.Size,
                GameConfig.TestCollectPuzzle.Answer1.Point
                );
            public static readonly ElementUI answer2 = new ElementUI(
                GameConfig.TestCollectPuzzle.Answer2.Sprite,
                GameConfig.TestCollectPuzzle.Answer2.Size,
                GameConfig.TestCollectPuzzle.Answer2.Point
                );
            public static readonly ElementUI answer3 = new ElementUI(
                GameConfig.TestCollectPuzzle.Answer3.Sprite,
                GameConfig.TestCollectPuzzle.Answer3.Size,
                GameConfig.TestCollectPuzzle.Answer3.Point
                );
            public static readonly ElementUI answer4 = new ElementUI(
                GameConfig.TestCollectPuzzle.Answer4.Sprite,
                GameConfig.TestCollectPuzzle.Answer4.Size,
                GameConfig.TestCollectPuzzle.Answer4.Point
                );
        }
        public static class TestDodgeMeteoritesElements
        {
            public static readonly ElementUI question = new ElementUI(
                GameConfig.TestDodgeMeteorites.Question.Sprite,
                GameConfig.TestDodgeMeteorites.Question.Size,
                GameConfig.TestDodgeMeteorites.Question.Point
                );
            public static readonly ElementUI tip = new ElementUI(
                GameConfig.TestDodgeMeteorites.Tip.Sprite,
                GameConfig.TestDodgeMeteorites.Tip.Size,
                GameConfig.TestDodgeMeteorites.Tip.Point
                );
            public static readonly ElementUI answer1 = new ElementUI(
                GameConfig.TestDodgeMeteorites.Answer1.Sprite,
                GameConfig.TestDodgeMeteorites.Answer1.Size,
                GameConfig.TestDodgeMeteorites.Answer1.Point
                );
            public static readonly ElementUI answer2 = new ElementUI(
                GameConfig.TestDodgeMeteorites.Answer2.Sprite,
                GameConfig.TestDodgeMeteorites.Answer2.Size,
                GameConfig.TestDodgeMeteorites.Answer2.Point
                );
            public static readonly ElementUI answer3 = new ElementUI(
                GameConfig.TestDodgeMeteorites.Answer3.Sprite,
                GameConfig.TestDodgeMeteorites.Answer3.Size,
                GameConfig.TestDodgeMeteorites.Answer3.Point
                );
            public static readonly ElementUI answer4 = new ElementUI(
                GameConfig.TestDodgeMeteorites.Answer4.Sprite,
                GameConfig.TestDodgeMeteorites.Answer4.Size,
                GameConfig.TestDodgeMeteorites.Answer4.Point
                );
        }
    }
}
