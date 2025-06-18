using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.CashElementUI;
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
        public static List<ElementUI> EndElements { get; } = new List<ElementUI>();
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
        public static List<ElementUI> TestInterfaceElements { get; } = new List<ElementUI>();
        public static List<ElementUI> TestRepeatActionElements { get; } = new List<ElementUI>();
        public static List<ElementUI> TestCatchBonesElements { get; } = new List<ElementUI>();
        public static List<ElementUI> TestCollectPuzzleElements { get; } = new List<ElementUI>();
        public static List<ElementUI> TestDodgeMeteoritesElements { get; } = new List<ElementUI>();


        public static void AddRuleElementsDodgeMeteorites()
        {
            RuleElementsDodgeMeteorites.Clear();
            RuleElementsDodgeMeteorites.Add(CashElementUI.RuleElementsDodgeMeteorites.backgroundMenuExit);
            RuleElementsDodgeMeteorites.Add(CashElementUI.RuleElementsDodgeMeteorites.RuleDodgeMeteorite);
            RuleElementsDodgeMeteorites.Add(CashElementUI.RuleElementsDodgeMeteorites.ButtonApply);
        }
        public static void AddRuleElementsRepeatAction()
        {
            RuleElementsRepeatAction.Clear();
            RuleElementsRepeatAction.Add(CashElementUI.RuleElementsRepeatAction.backgroundMenuExit);
            RuleElementsRepeatAction.Add(CashElementUI.RuleElementsRepeatAction.RuleRepeatButton);
            RuleElementsRepeatAction.Add(CashElementUI.RuleElementsRepeatAction.ButtonApply);
        }
        public static void AddRuleElementsColleсtPuzzle()
        {
            RuleElementsColleсtPuzzle.Clear();
            RuleElementsColleсtPuzzle.Add(CashElementUI.RuleElementsColleсtPuzzle.backgroundMenuExit);
            RuleElementsColleсtPuzzle.Add(CashElementUI.RuleElementsColleсtPuzzle.RuleCollectPuzzle);
            RuleElementsColleсtPuzzle.Add(CashElementUI.RuleElementsColleсtPuzzle.ButtonApply);
        }
        public static void AddRuleElementsCatchBones()
        {
            RuleElementsCatchBones.Clear();
            RuleElementsCatchBones.Add(CashElementUI.RuleElementsCatchBones.backgroundMenuExit);
            RuleElementsCatchBones.Add(CashElementUI.RuleElementsCatchBones.RuleCatchBones);
            RuleElementsCatchBones.Add(CashElementUI.RuleElementsCatchBones.ButtonApply);
        }


        public static void AddTotalElements()
        {
            TotalElements.Clear();
            TotalElements.Add(CashElementUI.TotalElements.btnQuestion);
            TotalElements.Add(CashElementUI.TotalElements.btnClosed);
        }
        public static void AddBtnClosedElement()
        {
            BtnClosedElement.Clear();
            BtnClosedElement.Add(CashElementUI.BtnClosedElement.btnClosed);
        }
        public static void AddTotalElementsMenuExit()
        {
            TotalElementsMenuExit.Clear();
            TotalElementsMenuExit.Add(CashElementUI.TotalElementsMenuExit.backgroundMenuExit);
            TotalElementsMenuExit.Add(CashElementUI.TotalElementsMenuExit.menuExit);
            TotalElementsMenuExit.Add(CashElementUI.TotalElementsMenuExit.buttonNo);
            TotalElementsMenuExit.Add(CashElementUI.TotalElementsMenuExit.buttonYes);
        }


        public static void AddOpeningElements()
        {
            OpeningElements.Clear();
            OpeningElements.Add(CashElementUI.OpeningElements.rocket);
            OpeningElements.Add(CashElementUI.OpeningElements.title);
            OpeningElements.Add(CashElementUI.OpeningElements.btnStartPlay);
        }
        public static void AddRuleElements()
        {
            RuleElements.Clear();
            RuleElements.Add(CashElementUI.RuleElements.character);
            RuleElements.Add(CashElementUI.RuleElements.btnStartPlay);
            RuleElements.Add(CashElementUI.RuleElements.txtRuleScene);
        }
        public static void AddEndElements()
        {
            EndElements.Clear();
            EndElements.Add(CashElementUI.EndElements.character);
            EndElements.Add(CashElementUI.EndElements.btnToStart);
            EndElements.Add(CashElementUI.EndElements.txtEndScene);
        }


        public static void AddRuleRepeatActionElements()
        {
            RuleRepeatActionElements.Clear();
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.character);
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.btnStartPlay);
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.btnNextPlay);
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.txtRuleRepeatActionScene1);
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.txtRuleRepeatActionScene2);
            RuleRepeatActionElements.Add(CashElementUI.RuleRepeatActionElements.txtRuleRepeatActionScene3);
        }
        public static void AddRuleCatchBonesElements()
        {
            RuleCatchBonesElements.Clear();
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.character);
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.btnStartPlay);
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.btnNextPlay);
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.txtRuleCatchBonesScene1);
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.txtRuleCatchBonesScene2);
            RuleCatchBonesElements.Add(CashElementUI.RuleCatchBonesElements.txtRuleCatchBonesScene3);
        }
        public static void AddRuleCollectPuzzleElements()
        {
            RuleCollectPuzzleElements.Clear();
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.character);
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.btnStartPlay);
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.btnNextPlay);
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.txtRuleCollectPuzzleScene1);
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.txtRuleCollectPuzzleScene2);
            RuleCollectPuzzleElements.Add(CashElementUI.RuleCollectPuzzleElements.txtRuleCollectPuzzleScene3);
        }
        public static void AddRuleDodgeMeteoritesElements()
        {
            RuleDodgeMeteoritesElements.Clear();
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.character);
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.btnStartPlay);
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.btnNextPlay);
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.txtRuleDodgeMeteoritesScene1);
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.txtRuleDodgeMeteoritesScene2);
            RuleDodgeMeteoritesElements.Add(CashElementUI.RuleDodgeMeteoritesElements.txtRuleDodgeMeteoritesScene3);
        }


        public static void AddCatchBonesElements()
        {
            CatchBonesElements.Clear();
            CatchBonesElements.Add(CashElementUI.CatchBonesElements.background);
            CatchBonesElements.Add(CashElementUI.CatchBonesElements.character);
        }
        public static void AddDodgeMeteoritesElements()
        {
            DodgeMeteoritesElementsBd.Clear();
            DodgeMeteoritesElementsBn.Clear();
            DodgeMeteoritesElementsBd.Add(CashElementUI.DodgeMeteoritesElements.background);
            DodgeMeteoritesElementsBn.Add(CashElementUI.DodgeMeteoritesElements.buttonLeft);
            DodgeMeteoritesElementsBn.Add(CashElementUI.DodgeMeteoritesElements.buttonRight);
        }
        public static void AddRepeatActionElements()
        {
            RepeatActionElements.Clear();
            RepeatActionElements.Add(CashElementUI.RepeatActionElements.background);
        }
        public static void AddColleсtPuzzleElements()
        {
            ColleсtPuzzleElements.Clear();
            ColleсtPuzzleElements.Add(CashElementUI.ColleсtPuzzleElements.background);
            ColleсtPuzzleElements.Add(CashElementUI.ColleсtPuzzleElements.shadow);
        }


        public static void AddTestInterfaceElements()
        {
            TestInterfaceElements.Clear();
            TestInterfaceElements.Add(CashElementUI.TestInterfaceElements.character);
            TestInterfaceElements.Add(CashElementUI.TestInterfaceElements.btnAnswer);
            TestInterfaceElements.Add(CashElementUI.TestInterfaceElements.btnNextPlay);
            TestInterfaceElements.Add(CashElementUI.TestInterfaceElements.backgroundTest);
            TestInterfaceElements.Add(CashElementUI.TestInterfaceElements.success);
        }
        public static void AddTestRepeatAction()
        {
            TestRepeatActionElements.Clear();
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.question);
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.tip);
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.answer1);
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.answer2);
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.answer3);
            TestRepeatActionElements.Add(CashElementUI.TestRepeatActionElements.answer4);
        }
        public static void AddTestCatchBones()
        {
            TestCatchBonesElements.Clear();
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.question);
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.tip);
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.answer1);
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.answer2);
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.answer3);
            TestCatchBonesElements.Add(CashElementUI.TestCatchBonesElements.answer4);
        }
        public static void AddTestCollectPuzzle()
        {
            TestCollectPuzzleElements.Clear();
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.question);
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.tip);
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.answer1);
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.answer2);
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.answer3);
            TestCollectPuzzleElements.Add(CashElementUI.TestCollectPuzzleElements.answer4);
        }
        public static void AddTestDodgeMeteorites()
        {
            TestDodgeMeteoritesElements.Clear();
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.question);
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.tip);
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.answer1);
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.answer2);
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.answer3);
            TestDodgeMeteoritesElements.Add(CashElementUI.TestDodgeMeteoritesElements.answer4);
        }
    }
}
