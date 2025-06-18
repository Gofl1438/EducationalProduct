using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using static EducationalProduct.Classes.GameConfig;

namespace EducationalProduct.Classes
{
    public static class GameConfig
    {
        public enum BonesType { Red, Orange, RedSmall, OrangeSmall }
        public enum PuzzlesType { BottomLeft, BottomRight, TopLeft, TopRight }
        public enum ButtonRepeatType { Red, Blue, Yellow, Green }

        public static class CanvasProduct
        {
            public static int Height { get; set; }
            public static int Width { get; set; }
            public static float WidthBlockBone { get; set; }
            public static float HeightBlockBone { get; set; }
        }

        public static void Initialize(Size sizeCanvas)
        {
            CanvasProduct.Height = sizeCanvas.Height;
            CanvasProduct.Width = sizeCanvas.Width;
            CanvasProduct.WidthBlockBone = (float)CanvasProduct.Width / CatchBones.Bone.DefaultQuantityBone;
            CanvasProduct.HeightBlockBone = (float)CanvasProduct.Height / 2;
            InitializeTotalElement();
            InitializeColleсtPuzzle();
            InitializeRepeatAction();
            InitializeDodgeMeteorites();
            InitializeCatchBones();
            InitializeOpeningScene();
            InitializeRuleScene();
            InitializeEndScene();
            InitializeRuleRepeatActionScene();
            InitializeRuleCatchBonesScene();
            InitializeRuleCollectPuzzleScene();
            InitializeRuleDodgeMeteoritesScene();
            InitializeRuleInfScene();
            InitializeFontRepeatButton();
            InitializeFontDodgeMeteorites();
            InitializeFontCatchBones();
            InitializeTestInterface();
            InitializeTestRepeatAction();
            InitializeTestCatchBones();
            InitializeTestCollectPuzzle();
            InitializeTestDodgeMeteorites();
        }

        private static void InitializeTotalElement()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            TotalElement.MenuExit.Width = (int)(CanvasProduct.Width * 0.41f);
            TotalElement.MenuExit.Height = (int)(TotalElement.MenuExit.Width * 0.38);
            TotalElement.MenuExit.PositionOx = (CanvasProduct.Width - TotalElement.MenuExit.Width) / 2;
            TotalElement.MenuExit.PositionOy = (CanvasProduct.Height - TotalElement.MenuExit.Height) / 2;
            TotalElement.ButtonNo.Width = (int)(TotalElement.MenuExit.Width * 0.22f);
            TotalElement.ButtonNo.Height = (int)(TotalElement.MenuExit.Width * 0.22f);
            TotalElement.ButtonNo.PositionOx = TotalElement.MenuExit.PositionOx + TotalElement.MenuExit.Width - TotalElement.MenuExit.Width * 0.17f - TotalElement.ButtonNo.Width;
            TotalElement.ButtonNo.PositionOy = TotalElement.MenuExit.PositionOy + TotalElement.MenuExit.Height * 0.32f;
            TotalElement.ButtonYes.Width = (int)(TotalElement.MenuExit.Width * 0.22f);
            TotalElement.ButtonYes.Height = (int)(TotalElement.MenuExit.Width * 0.22f);
            TotalElement.ButtonYes.PositionOx = TotalElement.MenuExit.PositionOx + TotalElement.MenuExit.Width * 0.17f;
            TotalElement.ButtonYes.PositionOy = TotalElement.MenuExit.PositionOy + TotalElement.MenuExit.Height * 0.32f;
            TotalElement.BtnClosed.Height = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnClosed.Width = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnQuestion.Height = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnQuestion.Width = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnClosed.PositionOx = (int)(CanvasProduct.Width - TotalElement.BtnClosed.Width -  CanvasProduct.Width * 0.02f);
            TotalElement.BtnClosed.PositionOy = (int)(CanvasProduct.Height * 0.02f);
            TotalElement.BtnQuestion.PositionOx = (int)(CanvasProduct.Width * 0.02f);
            TotalElement.BtnQuestion.PositionOy = (int)(CanvasProduct.Height * 0.02f);
            TotalElement.BackgroundMenuExit.Height = CanvasProduct.Height;
            TotalElement.BackgroundMenuExit.Width = CanvasProduct.Width;
        }

        private static void InitializeOpeningScene()
        {
            OpeningScene.Rocket.Width = (int)(CanvasProduct.Width * 0.47f);
            OpeningScene.Rocket.Height = (int)(OpeningScene.Rocket.Width * 0.62f);
            OpeningScene.Rocket.PositionOx = (int)(CanvasProduct.Width * 0.53f);
            OpeningScene.Rocket.PositionOy = (int)(CanvasProduct.Height * 0.31f);

            OpeningScene.Title.Height = (int)(CanvasProduct.Height * 0.15f);
            OpeningScene.Title.Width = (int)(CanvasProduct.Width * 0.53f);
            OpeningScene.Title.PositionOx = (CanvasProduct.Width - OpeningScene.Title.Width) / 2;
            OpeningScene.Title.PositionOy = (int)(CanvasProduct.Height * 0.12f);

            OpeningScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.24f);
            OpeningScene.BtnStartPlay.Height = (int)(OpeningScene.BtnStartPlay.Width * 0.386f);
            OpeningScene.BtnStartPlay.PositionOx = (CanvasProduct.Width - OpeningScene.BtnStartPlay.Width) / 2;
            OpeningScene.BtnStartPlay.PositionOy = (int)(CanvasProduct.Height * 0.415f);
        }
        private static void InitializeRuleScene()
        {
            RuleScene.Character.Width = (int)(CanvasProduct.Width * 0.36f);
            RuleScene.Character.Height = (int)(RuleScene.Character.Width * 1.17f);
            RuleScene.Character.PositionOy = CanvasProduct.Height - RuleScene.Character.Height;

            RuleScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleScene.BtnStartPlay.Height = (int)(RuleScene.BtnStartPlay.Width * 0.386f);
            RuleScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleScene.TxtRuleScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleScene.TxtRuleScene.Height = (int)(RuleScene.TxtRuleScene.Width * 0.59f);
            RuleScene.TxtRuleScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleScene.TxtRuleScene.PositionOy = RuleScene.BtnStartPlay.PositionOy - RuleScene.TxtRuleScene.Height - RuleScene.BtnStartPlay.Height * 0.3f;

            RuleScene.BtnStartPlay.PositionOx = RuleScene.TxtRuleScene.PositionOx + (RuleScene.TxtRuleScene.Width - RuleScene.BtnStartPlay.Width) / 2;
        }
        private static void InitializeEndScene()
        {
            EndScene.Character.Width = (int)(CanvasProduct.Width * 0.36f);
            EndScene.Character.Height = (int)(EndScene.Character.Width * 1.17f);
            EndScene.Character.PositionOy = CanvasProduct.Height - RuleScene.Character.Height;

            EndScene.BtnToStart.Width = (int)(CanvasProduct.Width * 0.19f);
            EndScene.BtnToStart.Height = (int)(EndScene.BtnToStart.Width * 0.386f);
            EndScene.BtnToStart.PositionOy = CanvasProduct.Height * 0.8f;

            EndScene.TxtEndScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            EndScene.TxtEndScene.Height = (int)(RuleScene.TxtRuleScene.Width * 0.46f);
            EndScene.TxtEndScene.PositionOx = CanvasProduct.Width * 0.39f;
            EndScene.TxtEndScene.PositionOy = EndScene.BtnToStart.PositionOy - EndScene.TxtEndScene.Height - EndScene.BtnToStart.Height * 0.3f;

            EndScene.BtnToStart.PositionOx = EndScene.TxtEndScene.PositionOx + (EndScene.TxtEndScene.Width - EndScene.BtnToStart.Width) / 2;
        }

        private static void InitializeRuleRepeatActionScene()
        {
            RuleRepeatActionScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleRepeatActionScene.Character.Height = (int)(RuleRepeatActionScene.Character.Width * 1.08f);
            RuleRepeatActionScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleRepeatActionScene.Character.Height);

            RuleRepeatActionScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleRepeatActionScene.BtnStartPlay.Height = (int)(RuleRepeatActionScene.BtnStartPlay.Width * 0.386f);
            RuleRepeatActionScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleRepeatActionScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleRepeatActionScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleRepeatActionScene.BtnNextPlay.Height = (int)(RuleRepeatActionScene.BtnNextPlay.Width * 0.386f);
            RuleRepeatActionScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleRepeatActionScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.Height = (int)(RuleRepeatActionScene.TxtRuleRepeatActionScene1.Width * 0.53f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.PositionOy = RuleRepeatActionScene.BtnNextPlay.PositionOy - RuleRepeatActionScene.TxtRuleRepeatActionScene1.Height - RuleRepeatActionScene.BtnNextPlay.Height * 0.3f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.Height = (int)(RuleRepeatActionScene.TxtRuleRepeatActionScene2.Width * 0.609f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.PositionOy = RuleRepeatActionScene.BtnNextPlay.PositionOy - RuleRepeatActionScene.TxtRuleRepeatActionScene2.Height - RuleRepeatActionScene.BtnNextPlay.Height * 0.3f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.Height = (int)(RuleRepeatActionScene.TxtRuleRepeatActionScene3.Width * 0.445f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.PositionOy = RuleRepeatActionScene.BtnNextPlay.PositionOy - RuleRepeatActionScene.TxtRuleRepeatActionScene3.Height - RuleRepeatActionScene.BtnNextPlay.Height * 0.3f;
        }
        private static void InitializeRuleCatchBonesScene()
        {
            RuleCatchBonesScene.Character.Width = (int)(CanvasProduct.Width * 0.4);
            RuleCatchBonesScene.Character.Height = (int)(RuleCatchBonesScene.Character.Width * 0.69);   
            RuleCatchBonesScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleCatchBonesScene.Character.Height);

            RuleCatchBonesScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCatchBonesScene.BtnStartPlay.Height = (int)(RuleCatchBonesScene.BtnStartPlay.Width * 0.386f);
            RuleCatchBonesScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCatchBonesScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleCatchBonesScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCatchBonesScene.BtnNextPlay.Height = (int)(RuleCatchBonesScene.BtnNextPlay.Width * 0.386f);
            RuleCatchBonesScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCatchBonesScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.Height = (int)(RuleCatchBonesScene.TxtRuleCatchBonesScene1.Width * 0.413f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.PositionOx = CanvasProduct.Width * 0.413f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.PositionOy = RuleCatchBonesScene.BtnNextPlay.PositionOy - RuleCatchBonesScene.TxtRuleCatchBonesScene1.Height - RuleCatchBonesScene.BtnNextPlay.Height * 0.3f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.Height = (int)(RuleCatchBonesScene.TxtRuleCatchBonesScene2.Width * 0.488f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.PositionOy = RuleCatchBonesScene.BtnNextPlay.PositionOy - RuleCatchBonesScene.TxtRuleCatchBonesScene2.Height - RuleCatchBonesScene.BtnNextPlay.Height * 0.3f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.Height = (int)(RuleCatchBonesScene.TxtRuleCatchBonesScene3.Width * 0.536f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.PositionOy = RuleCatchBonesScene.BtnNextPlay.PositionOy - RuleCatchBonesScene.TxtRuleCatchBonesScene3.Height - RuleCatchBonesScene.BtnNextPlay.Height * 0.3f;
        }
        private static void InitializeRuleCollectPuzzleScene()
        {
            RuleCollectPuzzleScene.Character.Width = (int)(CanvasProduct.Width * 0.357f);
            RuleCollectPuzzleScene.Character.Height = (int)(RuleCollectPuzzleScene.Character.Width * 0.95f);
            RuleCollectPuzzleScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleCollectPuzzleScene.Character.Height);

            RuleCollectPuzzleScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCollectPuzzleScene.BtnStartPlay.Height = (int)(RuleCollectPuzzleScene.BtnStartPlay.Width * 0.386f);
            RuleCollectPuzzleScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCollectPuzzleScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleCollectPuzzleScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCollectPuzzleScene.BtnNextPlay.Height = (int)(RuleCollectPuzzleScene.BtnNextPlay.Width * 0.386f);
            RuleCollectPuzzleScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCollectPuzzleScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Height = (int)(RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Width * 0.403f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.PositionOy = RuleCollectPuzzleScene.BtnNextPlay.PositionOy - RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Height - RuleCollectPuzzleScene.BtnNextPlay.Height * 0.3f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Height = (int)(RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Width * 0.47f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.PositionOy = RuleCollectPuzzleScene.BtnNextPlay.PositionOy - RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Height - RuleCollectPuzzleScene.BtnNextPlay.Height * 0.3f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Height = (int)(RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Width * 0.28f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.PositionOy = RuleCollectPuzzleScene.BtnNextPlay.PositionOy - RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Height - RuleCollectPuzzleScene.BtnNextPlay.Height * 0.3f;
        }
        private static void InitializeRuleDodgeMeteoritesScene()
        {
            RuleDodgeMeteoritesScene.Character.Width = (int)(CanvasProduct.Width * 0.47f);
            RuleDodgeMeteoritesScene.Character.Height = (int)(RuleDodgeMeteoritesScene.Character.Width * 0.82f);
            RuleDodgeMeteoritesScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleDodgeMeteoritesScene.Character.Height);

            RuleDodgeMeteoritesScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleDodgeMeteoritesScene.BtnStartPlay.Height = (int)(RuleDodgeMeteoritesScene.BtnStartPlay.Width * 0.386f);
            RuleDodgeMeteoritesScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleDodgeMeteoritesScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleDodgeMeteoritesScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleDodgeMeteoritesScene.BtnNextPlay.Height = (int)(RuleDodgeMeteoritesScene.BtnNextPlay.Width * 0.386f);
            RuleDodgeMeteoritesScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.8f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Height = (int)(RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Width * 0.44f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.PositionOy = RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy - RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Height - RuleDodgeMeteoritesScene.BtnNextPlay.Height * 0.3f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Height = (int)(RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Width * 0.34f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.PositionOy = RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy - RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Height - RuleDodgeMeteoritesScene.BtnNextPlay.Height * 0.3f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Height = (int)(RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Width * 0.33f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.PositionOy = RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy - RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Height - RuleDodgeMeteoritesScene.BtnNextPlay.Height * 0.3f;
        }

        private static void InitializeColleсtPuzzle()
        {
            ColleсtPuzzle.Background.Width = CanvasProduct.Width;
            ColleсtPuzzle.Background.Height = CanvasProduct.Height;
            ColleсtPuzzle.Puzzle.Shadow.Height = (int)(CanvasProduct.Height * 0.7f);
            ColleсtPuzzle.Puzzle.Shadow.Width = (int)(CanvasProduct.Width * 0.6f);
            ColleсtPuzzle.Puzzle.Shadow.PositionOy = (CanvasProduct.Height - ColleсtPuzzle.Puzzle.Shadow.Height) / 2;
            ColleсtPuzzle.Puzzle.Shadow.PositionOx = (CanvasProduct.Width - ColleсtPuzzle.Puzzle.Shadow.Width) / 2;
            ColleсtPuzzle.Puzzle.HeightDetail = ColleсtPuzzle.Puzzle.Shadow.Height / 2;
            ColleсtPuzzle.Puzzle.WidthDetail = ColleсtPuzzle.Puzzle.Shadow.Width / 2;
            ColleсtPuzzle.Puzzle.BottomLeft.PositionOx = (int)(CanvasProduct.Width * 0.55f);
            ColleсtPuzzle.Puzzle.BottomLeft.PositionOy = (int)(CanvasProduct.Height * 0.005f);
            ColleсtPuzzle.Puzzle.BottomRight.PositionOx = (int)(CanvasProduct.Width * 0.025f);
            ColleсtPuzzle.Puzzle.BottomRight.PositionOy = (int)(CanvasProduct.Height * 0.7f);
            ColleсtPuzzle.Puzzle.TopLeft.PositionOx = (int)(CanvasProduct.Width * 0.63f);
            ColleсtPuzzle.Puzzle.TopLeft.PositionOy = (int)(CanvasProduct.Height * 0.53f);
            ColleсtPuzzle.Puzzle.TopRight.PositionOx = (int)(CanvasProduct.Width * 0.15f);
            ColleсtPuzzle.Puzzle.TopRight.PositionOy = (int)(CanvasProduct.Height * 0.15f);
        }
        private static void InitializeRepeatAction()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            RepeatAction.Background.Width = CanvasProduct.Width;
            RepeatAction.Background.Height = CanvasProduct.Height;
            RepeatAction.Button.Height = (int)(MinValueCanvas * 0.3f);
            RepeatAction.Button.Width = (int)(MinValueCanvas * 0.3f);
            RepeatAction.Button.Red.PositionOx = CanvasProduct.Width / 2 - MinValueCanvas * 0.05f - RepeatAction.Button.Width;
            RepeatAction.Button.Red.PositionOy = CanvasProduct.Height / 2 - MinValueCanvas * 0.05f - RepeatAction.Button.Height;
            RepeatAction.Button.Blue.PositionOx = CanvasProduct.Width / 2 + MinValueCanvas * 0.05f;
            RepeatAction.Button.Blue.PositionOy = CanvasProduct.Height / 2 - MinValueCanvas * 0.05f - RepeatAction.Button.Height;
            RepeatAction.Button.Yellow.PositionOx = CanvasProduct.Width / 2 - MinValueCanvas * 0.05f - RepeatAction.Button.Width;
            RepeatAction.Button.Yellow.PositionOy = CanvasProduct.Height / 2 + MinValueCanvas * 0.05f;
            RepeatAction.Button.Green.PositionOx = CanvasProduct.Width / 2 + MinValueCanvas * 0.05f;
            RepeatAction.Button.Green.PositionOy = CanvasProduct.Height / 2 + MinValueCanvas * 0.05f;
        }
        private static void InitializeCatchBones()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            CatchBones.Background.Width = CanvasProduct.Width;
            CatchBones.Background.Height = CanvasProduct.Height;
            CatchBones.Character.Width = (int)(CanvasProduct.Width * 0.24f);
            CatchBones.Character.Height = (int)(CanvasProduct.Height * 0.4f);
            CatchBones.Character.PositionOy = CanvasProduct.Height - CatchBones.Character.Height;
            CatchBones.Bone.Big.Width = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 1.4f);
            CatchBones.Bone.Big.Height = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 1.4f);
            CatchBones.Bone.Small.Width = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 0.9f);
            CatchBones.Bone.Small.Height = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 0.9f);
        }
        private static void InitializeDodgeMeteorites()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            DodgeMeteorites.Background.Width = CanvasProduct.Width;
            DodgeMeteorites.Background.Height = CanvasProduct.Height;
            DodgeMeteorites.Rocket.Height = (int)(MinValueCanvas * 0.35f);
            DodgeMeteorites.Rocket.HeightAntenna = (int)(DodgeMeteorites.Rocket.Height * 0.18f);
            DodgeMeteorites.Rocket.HeightWithoutFuel = (int)((DodgeMeteorites.Rocket.Height - DodgeMeteorites.Rocket.HeightAntenna) * 0.7f);
            DodgeMeteorites.Rocket.Width = (int)(MinValueCanvas * 0.17f);
            DodgeMeteorites.Rocket.WidthAntenna = (int)(DodgeMeteorites.Rocket.Width * 0.14f);
            DodgeMeteorites.ButtonMove.Height = (int)(MinValueCanvas * 0.15f);
            DodgeMeteorites.ButtonMove.Width = (int)(MinValueCanvas * 0.3f);
            DodgeMeteorites.ButtonMove.Left.PositionOx = (int)(MinValueCanvas * 0.01f);
            DodgeMeteorites.ButtonMove.Left.PositionOy = (int)(CanvasProduct.Height - DodgeMeteorites.ButtonMove.Height - MinValueCanvas * 0.01f);
            DodgeMeteorites.ButtonMove.Right.PositionOx = (int)(CanvasProduct.Width - DodgeMeteorites.ButtonMove.Width - MinValueCanvas * 0.01f);
            DodgeMeteorites.ButtonMove.Right.PositionOy = DodgeMeteorites.ButtonMove.Left.PositionOy;
            DodgeMeteorites.Rocket.PositionOx = CanvasProduct.Width / 2f;
            DodgeMeteorites.Rocket.PositionOy = DodgeMeteorites.ButtonMove.Left.PositionOy - DodgeMeteorites.Rocket.Height;
            DodgeMeteorites.Meteorite.Height = (int)(MinValueCanvas * 0.15f);
            DodgeMeteorites.Meteorite.Width = DodgeMeteorites.Meteorite.Height;
        }

        private static void InitializeRuleInfScene()
        {
            RuleInfScene.ButtonApply.Width = (int)(CanvasProduct.Width * 0.22f);
            RuleInfScene.ButtonApply.Height = (int)(RuleInfScene.ButtonApply.Width * 0.37f);
            RuleInfScene.ButtonApply.PositionOx = (CanvasProduct.Width - RuleInfScene.ButtonApply.Width) / 2;
            RuleInfScene.ButtonApply.PositionOy = (int)(CanvasProduct.Height * 0.6f); ;
            RuleInfScene.RuleRepeatButton.Width = (int)(CanvasProduct.Width * 0.77f);
            RuleInfScene.RuleRepeatButton.Height = (int)(RuleInfScene.RuleRepeatButton.Width * 0.248f);
            RuleInfScene.RuleRepeatButton.PositionOx = (CanvasProduct.Width - RuleInfScene.RuleRepeatButton.Width) / 2;
            RuleInfScene.RuleRepeatButton.PositionOy = RuleInfScene.ButtonApply.PositionOy - RuleInfScene.RuleRepeatButton.Height - (int)(CanvasProduct.Height * 0.03f);
            RuleInfScene.RuleCatchBones.Width = (int)(CanvasProduct.Width * 0.778f);
            RuleInfScene.RuleCatchBones.Height = (int)(RuleInfScene.RuleCatchBones.Width * 0.147f);
            RuleInfScene.RuleCatchBones.PositionOx = (CanvasProduct.Width - RuleInfScene.RuleCatchBones.Width) / 2;
            RuleInfScene.RuleCatchBones.PositionOy = RuleInfScene.ButtonApply.PositionOy - RuleInfScene.RuleCatchBones.Height - (int)(CanvasProduct.Height * 0.03f);
            RuleInfScene.RuleCollectPuzzle.Width = (int)(CanvasProduct.Width * 0.778f);
            RuleInfScene.RuleCollectPuzzle.Height = (int)(RuleInfScene.RuleCollectPuzzle.Width * 0.215f);
            RuleInfScene.RuleCollectPuzzle.PositionOx = (CanvasProduct.Width - RuleInfScene.RuleCollectPuzzle.Width) / 2;
            RuleInfScene.RuleCollectPuzzle.PositionOy = RuleInfScene.ButtonApply.PositionOy - RuleInfScene.RuleCollectPuzzle.Height - (int)(CanvasProduct.Height * 0.03f);
            RuleInfScene.RuleDodgeMeteorite.Width = (int)(CanvasProduct.Width * 0.778f);
            RuleInfScene.RuleDodgeMeteorite.Height = (int)(RuleInfScene.RuleDodgeMeteorite.Width * 0.252f);
            RuleInfScene.RuleDodgeMeteorite.PositionOx = (CanvasProduct.Width - RuleInfScene.RuleDodgeMeteorite.Width) / 2;
            RuleInfScene.RuleDodgeMeteorite.PositionOy = RuleInfScene.ButtonApply.PositionOy - RuleInfScene.RuleDodgeMeteorite.Height - (int)(CanvasProduct.Height * 0.03f);

        }

        public static void InitializeFontRepeatButton()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            NumberPointsRepeatButton.WidthRectangleResult = CanvasProduct.Width;
            NumberPointsRepeatButton.HeightRectangleResult = (int)(CanvasProduct.Height * 0.25f);
            NumberPointsRepeatButton.SizeResult = (int)(TotalElement.BtnQuestion.Height * 0.3f);
            IntPtr fontPtr = Marshal.AllocCoTaskMem(NumberPointsRepeatButton.FamilyNameScore.Length);
            Marshal.Copy(NumberPointsRepeatButton.FamilyNameScore, 0, fontPtr, NumberPointsRepeatButton.FamilyNameScore.Length);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(fontPtr, NumberPointsRepeatButton.FamilyNameScore.Length);
            RectangleF shadowRect = NumberPointsRepeatButton.rectangleResult;
            shadowRect.Offset(3, 3);
            NumberPointsRepeatButton.fontPtr = fontPtr;
            NumberPointsRepeatButton.pfc = pfc;
            NumberPointsRepeatButton.shadowRect = shadowRect;
        }
        public static void InitializeFontDodgeMeteorites()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            NumberPointsDodgeMeteorites.WidthRectangleResult = CanvasProduct.Width;
            NumberPointsDodgeMeteorites.HeightRectangleResult = (int)(CanvasProduct.Height * 0.10f);
            NumberPointsDodgeMeteorites.SizeResult = (int)(TotalElement.BtnQuestion.Height * 0.3f);
            IntPtr fontPtr = Marshal.AllocCoTaskMem(NumberPointsDodgeMeteorites.FamilyNameScore.Length);
            Marshal.Copy(NumberPointsDodgeMeteorites.FamilyNameScore, 0, fontPtr, NumberPointsDodgeMeteorites.FamilyNameScore.Length);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(fontPtr, NumberPointsDodgeMeteorites.FamilyNameScore.Length);
            RectangleF shadowRect = NumberPointsDodgeMeteorites.rectangleResult;
            shadowRect.Offset(3, 3);
            NumberPointsDodgeMeteorites.fontPtr = fontPtr;
            NumberPointsDodgeMeteorites.pfc = pfc;
            NumberPointsDodgeMeteorites.shadowRect = shadowRect;
        }
        public static void InitializeFontCatchBones()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            NumberPointsCatchBones.WidthRectangleResult = CanvasProduct.Width;
            NumberPointsCatchBones.HeightRectangleResult = (int)(CanvasProduct.Height * 0.1f);
            NumberPointsCatchBones.SizeResult = (int)(TotalElement.BtnQuestion.Height * 0.3f);
            IntPtr fontPtr = Marshal.AllocCoTaskMem(NumberPointsCatchBones.FamilyNameScore.Length);
            Marshal.Copy(NumberPointsCatchBones.FamilyNameScore, 0, fontPtr, NumberPointsCatchBones.FamilyNameScore.Length);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(fontPtr, NumberPointsCatchBones.FamilyNameScore.Length);
            RectangleF shadowRect = NumberPointsCatchBones.rectangleResult;
            shadowRect.Offset(3, 3);
            NumberPointsCatchBones.fontPtr = fontPtr;
            NumberPointsCatchBones.pfc = pfc;
            NumberPointsCatchBones.shadowRect = shadowRect;
        }

        private static void InitializeTestInterface()
        {
            TestInterface.Character.Width = (int)(CanvasProduct.Width * 0.36f);
            TestInterface.Character.Height = (int)(TestInterface.Character.Width * 1.17f);
            TestInterface.Character.PositionOy = CanvasProduct.Height - TestInterface.Character.Height;

            TestInterface.BtnAnswer.Width = (int)(CanvasProduct.Width * 0.15f);
            TestInterface.BtnAnswer.Height = (int)(TestInterface.BtnAnswer.Width * 0.346f);
            TestInterface.BtnAnswer.PositionOx = CanvasProduct.Width * 0.8f;
            TestInterface.BtnAnswer.PositionOy = CanvasProduct.Height * 0.85f;

            TestInterface.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.15f);
            TestInterface.BtnNextPlay.Height = (int)(TestInterface.BtnAnswer.Width * 0.346f);
            TestInterface.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.8f;
            TestInterface.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.85f;

            TestInterface.BackgroundTest.Width = (int)(CanvasProduct.Width * 0.6f);
            TestInterface.BackgroundTest.Height = (int)(TestInterface.BackgroundTest.Width * 0.4f);
            TestInterface.BackgroundTest.PositionOx = CanvasProduct.Width * 0.35f;
            TestInterface.BackgroundTest.PositionOy = CanvasProduct.Height - TestInterface.BackgroundTest.Height - CanvasProduct.Height * 0.3f;

            TestInterface.Success.Width = (int)(CanvasProduct.Width * 0.3f);
            TestInterface.Success.Height = (int)(TestInterface.Success.Width * 0.095f);
            TestInterface.Success.PositionOx = CanvasProduct.Width * 0.4f;
            TestInterface.Success.PositionOy = CanvasProduct.Height * 0.85f;
        }
        private static void InitializeTestRepeatAction()
        {
            TestRepeatAction.Question.Width = (int)(CanvasProduct.Width * 0.3f);
            TestRepeatAction.Question.Height = (int)(TestRepeatAction.Question.Width * 0.18f);
            TestRepeatAction.Question.PositionOx = CanvasProduct.Width * 0.5f;
            TestRepeatAction.Question.PositionOy = CanvasProduct.Height - TestRepeatAction.Question.Height - CanvasProduct.Height * 0.8f;

            TestRepeatAction.Tip.Width = (int)(CanvasProduct.Width * 0.4f);
            TestRepeatAction.Tip.Height = (int)(TestRepeatAction.Tip.Width * 0.134f);
            TestRepeatAction.Tip.PositionOx = CanvasProduct.Width * 0.37f;
            TestRepeatAction.Tip.PositionOy = CanvasProduct.Height * 0.85f;

            TestRepeatAction.Answer1.Width = (int)(CanvasProduct.Width * 0.55f);
            TestRepeatAction.Answer1.Height = (int)(TestRepeatAction.Answer1.Width * 0.062f);
            TestRepeatAction.Answer1.PositionOx = CanvasProduct.Width * 0.375f;
            TestRepeatAction.Answer1.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer1.Height - CanvasProduct.Height * 0.64f;

            TestRepeatAction.Answer2.Width = (int)(CanvasProduct.Width * 0.55f);
            TestRepeatAction.Answer2.Height = (int)(TestRepeatAction.Answer2.Width * 0.062f);
            TestRepeatAction.Answer2.PositionOx = CanvasProduct.Width * 0.375f;
            TestRepeatAction.Answer2.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer2.Height - CanvasProduct.Height * 0.54f;

            TestRepeatAction.Answer3.Width = (int)(CanvasProduct.Width * 0.55f);
            TestRepeatAction.Answer3.Height = (int)(TestRepeatAction.Answer3.Width * 0.062f);
            TestRepeatAction.Answer3.PositionOx = CanvasProduct.Width * 0.375f;
            TestRepeatAction.Answer3.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer3.Height - CanvasProduct.Height * 0.44f;

            TestRepeatAction.Answer4.Width = (int)(CanvasProduct.Width * 0.55f);
            TestRepeatAction.Answer4.Height = (int)(TestRepeatAction.Answer4.Width * 0.062f);
            TestRepeatAction.Answer4.PositionOx = CanvasProduct.Width * 0.375f;
            TestRepeatAction.Answer4.PositionOy = CanvasProduct.Height - TestRepeatAction.Answer4.Height - CanvasProduct.Height * 0.34f;
        }
        private static void InitializeTestCatchBones()
        {
            TestCatchBones.Question.Width = (int)(CanvasProduct.Width * 0.3f);
            TestCatchBones.Question.Height = (int)(TestCatchBones.Question.Width * 0.18f);
            TestCatchBones.Question.PositionOx = CanvasProduct.Width * 0.5f;
            TestCatchBones.Question.PositionOy = CanvasProduct.Height - TestCatchBones.Question.Height - CanvasProduct.Height * 0.8f;

            TestCatchBones.Tip.Width = (int)(CanvasProduct.Width * 0.4f);
            TestCatchBones.Tip.Height = (int)(TestCatchBones.Tip.Width * 0.134f);
            TestCatchBones.Tip.PositionOx = CanvasProduct.Width * 0.37f;
            TestCatchBones.Tip.PositionOy = CanvasProduct.Height * 0.85f;

            TestCatchBones.Answer1.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCatchBones.Answer1.Height = (int)(TestCatchBones.Answer1.Width * 0.062f);
            TestCatchBones.Answer1.PositionOx = CanvasProduct.Width * 0.375f;
            TestCatchBones.Answer1.PositionOy = CanvasProduct.Height - TestCatchBones.Answer1.Height - CanvasProduct.Height * 0.64f;

            TestCatchBones.Answer2.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCatchBones.Answer2.Height = (int)(TestCatchBones.Answer2.Width * 0.062f);
            TestCatchBones.Answer2.PositionOx = CanvasProduct.Width * 0.375f;
            TestCatchBones.Answer2.PositionOy = CanvasProduct.Height - TestCatchBones.Answer2.Height - CanvasProduct.Height * 0.54f;

            TestCatchBones.Answer3.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCatchBones.Answer3.Height = (int)(TestCatchBones.Answer3.Width * 0.062f);
            TestCatchBones.Answer3.PositionOx = CanvasProduct.Width * 0.375f;
            TestCatchBones.Answer3.PositionOy = CanvasProduct.Height - TestCatchBones.Answer3.Height - CanvasProduct.Height * 0.44f;

            TestCatchBones.Answer4.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCatchBones.Answer4.Height = (int)(TestCatchBones.Answer4.Width * 0.062f);
            TestCatchBones.Answer4.PositionOx = CanvasProduct.Width * 0.375f;
            TestCatchBones.Answer4.PositionOy = CanvasProduct.Height - TestCatchBones.Answer4.Height - CanvasProduct.Height * 0.34f;
        }
        private static void InitializeTestCollectPuzzle()
        {
            TestCollectPuzzle.Question.Width = (int)(CanvasProduct.Width * 0.3f);
            TestCollectPuzzle.Question.Height = (int)(TestCollectPuzzle.Question.Width * 0.18f);
            TestCollectPuzzle.Question.PositionOx = CanvasProduct.Width * 0.5f;
            TestCollectPuzzle.Question.PositionOy = CanvasProduct.Height - TestCollectPuzzle.Question.Height - CanvasProduct.Height * 0.8f;

            TestCollectPuzzle.Tip.Width = (int)(CanvasProduct.Width * 0.4f);
            TestCollectPuzzle.Tip.Height = (int)(TestCollectPuzzle.Tip.Width * 0.134f);
            TestCollectPuzzle.Tip.PositionOx = CanvasProduct.Width * 0.37f;
            TestCollectPuzzle.Tip.PositionOy = CanvasProduct.Height * 0.85f;

            TestCollectPuzzle.Answer1.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCollectPuzzle.Answer1.Height = (int)(TestCollectPuzzle.Answer1.Width * 0.062f);
            TestCollectPuzzle.Answer1.PositionOx = CanvasProduct.Width * 0.375f;
            TestCollectPuzzle.Answer1.PositionOy = CanvasProduct.Height - TestCollectPuzzle.Answer1.Height - CanvasProduct.Height * 0.64f;

            TestCollectPuzzle.Answer2.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCollectPuzzle.Answer2.Height = (int)(TestCollectPuzzle.Answer2.Width * 0.062f);
            TestCollectPuzzle.Answer2.PositionOx = CanvasProduct.Width * 0.375f;
            TestCollectPuzzle.Answer2.PositionOy = CanvasProduct.Height - TestCollectPuzzle.Answer2.Height - CanvasProduct.Height * 0.54f;

            TestCollectPuzzle.Answer3.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCollectPuzzle.Answer3.Height = (int)(TestCollectPuzzle.Answer3.Width * 0.062f);
            TestCollectPuzzle.Answer3.PositionOx = CanvasProduct.Width * 0.375f;
            TestCollectPuzzle.Answer3.PositionOy = CanvasProduct.Height - TestCollectPuzzle.Answer3.Height - CanvasProduct.Height * 0.44f;

            TestCollectPuzzle.Answer4.Width = (int)(CanvasProduct.Width * 0.55f);
            TestCollectPuzzle.Answer4.Height = (int)(TestCollectPuzzle.Answer4.Width * 0.062f);
            TestCollectPuzzle.Answer4.PositionOx = CanvasProduct.Width * 0.375f;
            TestCollectPuzzle.Answer4.PositionOy = CanvasProduct.Height - TestCollectPuzzle.Answer4.Height - CanvasProduct.Height * 0.34f;
        }
        private static void InitializeTestDodgeMeteorites()
        {
            TestDodgeMeteorites.Question.Width = (int)(CanvasProduct.Width * 0.3f);
            TestDodgeMeteorites.Question.Height = (int)(TestDodgeMeteorites.Question.Width * 0.18f);
            TestDodgeMeteorites.Question.PositionOx = CanvasProduct.Width * 0.5f;
            TestDodgeMeteorites.Question.PositionOy = CanvasProduct.Height - TestDodgeMeteorites.Question.Height - CanvasProduct.Height * 0.8f;

            TestDodgeMeteorites.Tip.Width = (int)(CanvasProduct.Width * 0.4f);
            TestDodgeMeteorites.Tip.Height = (int)(TestDodgeMeteorites.Tip.Width * 0.134f);
            TestDodgeMeteorites.Tip.PositionOx = CanvasProduct.Width * 0.37f;
            TestDodgeMeteorites.Tip.PositionOy = CanvasProduct.Height * 0.85f;

            TestDodgeMeteorites.Answer1.Width = (int)(CanvasProduct.Width * 0.55f);
            TestDodgeMeteorites.Answer1.Height = (int)(TestDodgeMeteorites.Answer1.Width * 0.062f);
            TestDodgeMeteorites.Answer1.PositionOx = CanvasProduct.Width * 0.375f;
            TestDodgeMeteorites.Answer1.PositionOy = CanvasProduct.Height - TestDodgeMeteorites.Answer1.Height - CanvasProduct.Height * 0.64f;

            TestDodgeMeteorites.Answer2.Width = (int)(CanvasProduct.Width * 0.55f);
            TestDodgeMeteorites.Answer2.Height = (int)(TestDodgeMeteorites.Answer2.Width * 0.062f);
            TestDodgeMeteorites.Answer2.PositionOx = CanvasProduct.Width * 0.375f;
            TestDodgeMeteorites.Answer2.PositionOy = CanvasProduct.Height - TestDodgeMeteorites.Answer2.Height - CanvasProduct.Height * 0.54f;

            TestDodgeMeteorites.Answer3.Width = (int)(CanvasProduct.Width * 0.55f);
            TestDodgeMeteorites.Answer3.Height = (int)(TestDodgeMeteorites.Answer3.Width * 0.062f);
            TestDodgeMeteorites.Answer3.PositionOx = CanvasProduct.Width * 0.375f;
            TestDodgeMeteorites.Answer3.PositionOy = CanvasProduct.Height - TestDodgeMeteorites.Answer3.Height - CanvasProduct.Height * 0.44f;

            TestDodgeMeteorites.Answer4.Width = (int)(CanvasProduct.Width * 0.55f);
            TestDodgeMeteorites.Answer4.Height = (int)(TestDodgeMeteorites.Answer4.Width * 0.062f);
            TestDodgeMeteorites.Answer4.PositionOx = CanvasProduct.Width * 0.375f;
            TestDodgeMeteorites.Answer4.PositionOy = CanvasProduct.Height - TestDodgeMeteorites.Answer4.Height - CanvasProduct.Height * 0.34f;
        }

        public static class NumberPointsCatchBones
        {
            public static byte[] FamilyNameScore = Properties.Resources.PressStart2P_Regular;
            public static int SizeResult { get; set; }
            public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
            public static readonly Brush shadowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            public static readonly FontStyle StyleResult = FontStyle.Bold;
            public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
            public static int WidthRectangleResult { get; set; }
            public static int HeightRectangleResult { get; set; }
            public static float posOxRectangleResult { get; set; }
            public static float posOyRectangleResult { get; set; }
            public static PointF PointRectangleResult => new PointF(posOxRectangleResult, posOyRectangleResult);
            public static Size SizerRectangleResult => new Size(WidthRectangleResult, HeightRectangleResult);
            public static RectangleF rectangleResult => new RectangleF(PointRectangleResult, SizerRectangleResult);
            public static StringFormat format => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            public static IntPtr fontPtr { get; set; }
            public static PrivateFontCollection pfc { get; set; }
            public static RectangleF shadowRect { get; set; }
        }

        public static class NumberPointsRepeatButton
        {
            public static byte[] FamilyNameScore = Properties.Resources.PressStart2P_Regular;
            public static int SizeResult { get; set; }
            public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(118, 66, 138));
            public static readonly Brush shadowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            public static readonly FontStyle StyleResult = FontStyle.Bold;
            public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
            public static int WidthRectangleResult { get; set; }
            public static int HeightRectangleResult { get; set; }
            public static float PosOxRectangleResult { get; set; }
            public static float PosOyRectangleResult { get; set; }
            public static PointF PointRectangleResult => new PointF(PosOxRectangleResult, PosOyRectangleResult);
            public static Size SizerRectangleResult => new Size(WidthRectangleResult, HeightRectangleResult);
            public static RectangleF rectangleResult => new RectangleF(PointRectangleResult, SizerRectangleResult);
            public static StringFormat format => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            public static IntPtr fontPtr { get; set; }
            public static PrivateFontCollection pfc { get; set; }
            public static RectangleF shadowRect { get; set; }
        }
        public static class NumberPointsDodgeMeteorites
        {
            public static byte[] FamilyNameScore = Properties.Resources.PressStart2P_Regular;
            public static int SizeResult { get; set; }
            public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
            public static readonly Brush shadowBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            public static readonly FontStyle StyleResult = FontStyle.Bold;
            public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
            public static int WidthRectangleResult { get; set; } 
            public static int HeightRectangleResult { get; set; }
            public static float posOxRectangleResult { get; set; }
            public static float posOyRectangleResult { get; set; }
            public static PointF PointRectangleResult => new PointF(posOxRectangleResult, posOyRectangleResult);
            public static Size SizerRectangleResult => new Size(WidthRectangleResult, HeightRectangleResult);
            public static RectangleF rectangleResult => new RectangleF(PointRectangleResult, SizerRectangleResult);
            public static StringFormat format => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            public static IntPtr fontPtr { get; set; }
            public static PrivateFontCollection pfc { get; set; }
            public static RectangleF shadowRect { get; set; }
        }

        public static class RuleInfScene
        {
            public static class ButtonApply
            {
                public static readonly Bitmap Sprite = GameResources.ApplyButton;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class RuleDodgeMeteorite
            {
                public static readonly Bitmap Sprite = GameResources.RuleDodgeMeteorite;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class RuleCatchBones
            {
                public static readonly Bitmap Sprite = GameResources.RuleCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class RuleCollectPuzzle
            {
                public static readonly Bitmap Sprite = GameResources.RuleCollectPuzzle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class RuleRepeatButton
            {
                public static readonly Bitmap Sprite = GameResources.RuleRepeatButton;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class TotalElement
        {
            public static class BackgroundMenuExit
            {
                public static readonly Bitmap Sprite = GameResources.backgroundExitMenu;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnClosed
            {
                public static readonly Bitmap Sprite = GameResources.btnClosedOpening;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnQuestion
            {
                public static readonly Bitmap Sprite = GameResources.btnQuestion;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class MenuExit
            {
                public static readonly Bitmap Sprite = GameResources.MenuExit;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class ButtonNo
            {
                public static readonly Bitmap Sprite = GameResources.NoExit;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class ButtonYes
            {
                public static readonly Bitmap Sprite = GameResources.YesExit;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }

        public static class OpeningScene
        {
            public static class Rocket
            {
                public static readonly Bitmap Sprite = GameResources.OpeningRocket;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static readonly float RotationAngle = -20f;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Title
            {
                public static readonly Bitmap Sprite = GameResources.OpeningTitle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnStartPlayOpening;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class RuleScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.СharacterRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleScene
            {
                public static readonly Bitmap Sprite = GameResources.txtRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class EndScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.СharacterRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnToStart
            {
                public static readonly Bitmap Sprite = GameResources.btnToStart;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtEndScene
            {
                public static readonly Bitmap Sprite = GameResources.txtEnd;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }

        public static class RuleRepeatActionScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.CharacterRuleRepeatActionScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnNextPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnNextPlay;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleRepeatActionScene1
            {
                public static readonly Bitmap Sprite = GameResources.txtRepeatAction1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleRepeatActionScene2
            {
                public static readonly Bitmap Sprite = GameResources.txtRepeatAction2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleRepeatActionScene3
            {
                public static readonly Bitmap Sprite = GameResources.txtRepeatAction3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class RuleCatchBonesScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.CharacterRuleCatchBonesScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnNextPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnNextPlay;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCatchBonesScene1
            {
                public static readonly Bitmap Sprite = GameResources.txtCatchBones1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCatchBonesScene2
            {
                public static readonly Bitmap Sprite = GameResources.txtCatchBones2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCatchBonesScene3
            {
                public static readonly Bitmap Sprite = GameResources.txtCatchBones3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class RuleCollectPuzzleScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.CharacterRuleCollectPuzzleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnNextPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnNextPlay;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCollectPuzzleScene1
            {
                public static readonly Bitmap Sprite = GameResources.txtCollectPuzzle1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCollectPuzzleScene2
            {
                public static readonly Bitmap Sprite = GameResources.txtCollectPuzzle2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCollectPuzzleScene3
            {
                public static readonly Bitmap Sprite = GameResources.txtCollectPuzzle3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class RuleDodgeMeteoritesScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.CharacterRuleDodgeMeteoritesScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnNextPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnNextPlay;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleDodgeMeteoritesScene1
            {
                public static readonly Bitmap Sprite = GameResources.txtDodgeMeteorites1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleDodgeMeteoritesScene2
            {
                public static readonly Bitmap Sprite = GameResources.txtDodgeMeteorites2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleDodgeMeteoritesScene3
            {
                public static readonly Bitmap Sprite = GameResources.txtDodgeMeteorites3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }

        public static class CatchBones
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.CharacterCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Background
            {
                public static readonly Bitmap Sprite = GameResources.BackgroundCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Bone
            {
                public static readonly int DefaultQuantityBone = 2;
                public static readonly float MinSpeed = 2.0f;
                public static readonly float MaxSpeed = 8.0f;
                public static class Big
                {
                    public static readonly Bitmap RedSprite = GameResources.RedBone;
                    public static readonly Bitmap OrangeSprite = GameResources.OrangeBone;
                    public static int Width { get; set; }
                    public static int Height { get; set; }
                    public static Size Size => new Size(Width, Height);
                }
                public static class Small
                {
                    public static readonly Bitmap RedSprite = GameResources.RedBoneSmall;
                    public static readonly Bitmap OrangeSprite = GameResources.OrangeBoneSmall;
                    public static int Width { get; set; }
                    public static int Height { get; set; }
                    public static Size Size => new Size(Width, Height);
                }
            }
        }
        public static class ColleсtPuzzle
        {
            public static class Background
            {
                public static readonly Bitmap Sprite = GameResources.BackgroundColleсtPuzzle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Puzzle
            {
                public static int HeightDetail { get; set; }
                public static int WidthDetail { get; set; }
                public static readonly float snapThreshold = 30f;
                public static class Shadow
                {
                    public static readonly Bitmap Sprite = GameResources.ShadowPuzzle;
                    public static int Height { get; set; }
                    public static int Width { get; set; }
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class SolidRocket
                {
                    public static readonly Bitmap Sprite = GameResources.SolidRocket;
                    public static readonly float SpeedOx = 0.8f;
                    public static readonly float Acceleration = 0.3f;
                    public static int Height { get; set; } = Shadow.Height;
                    public static int Width { get; set; } = Shadow.Width;
                    public static float PositionOx { get; set; } = Shadow.PositionOx;
                    public static float PositionOy { get; set; } = Shadow.PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class BottomLeft
                {
                    public static readonly Bitmap Sprite = GameResources.PuzzleBottomLeft;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class BottomRight
                {
                    public static readonly Bitmap Sprite = GameResources.PuzzleBottomRight;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy + HeightDetail;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopLeft
                {
                    public static readonly Bitmap Sprite = GameResources.PuzzleTopLeft;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx + WidthDetail;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopRight
                {
                    public static readonly Bitmap Sprite = GameResources.PuzzleTopRight;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx + WidthDetail;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy + HeightDetail;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
            }
        }
        public static class DodgeMeteorites
        {
            public static class Background
            {
                public static readonly Bitmap Sprite = GameResources.BackgroundDodgeMeteorites;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Rocket
            {
                public static readonly Bitmap Sprite = GameResources.RocketDodge;
                public static readonly float SpeedOx = 35f;
                public static readonly float SpeedOy = 0.1f;
                public static readonly float Acceleration = 0.05f;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static int HeightWithoutFuel { get; set; }
                public static int HeightAntenna { get; set; }
                public static int WidthAntenna { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }

            public static class Meteorite
            {
                public static readonly Bitmap Sprite = GameResources.Meteorite;
                public static readonly float SpeedOy = 8.0f;
                public static readonly int DefaultQuantityMeteorites = 5;
                public static int Height { get; set; }
                public static int Width { get; set; }

                public static Size Size => new Size(Width, Height);
            }

            public static class ButtonMove
            {
                public static int Height { get; set; }
                public static int Width { get; set; }

                public static class Left
                {
                    public static readonly Bitmap Sprite = GameResources.LeftButtonDodge;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Right
                {
                    public static readonly Bitmap Sprite = GameResources.RightButtonDodge;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
            }
        }
        public static class RepeatAction
        {
            public static readonly int FrequencyGameOver = 13;
            public static readonly int MaxQuntitySequence = 1;
            public static class Background
            {
                public static readonly Bitmap Sprite = GameResources.BackgroundRepeatAction;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Button
            {
                public static int Height { get; set; }
                public static int Width { get; set; }

                public static class Red
                {
                    public static readonly Bitmap SpriteLight = GameResources.RedButtonLight;
                    public static readonly Bitmap SpriteGray = GameResources.RedButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Blue
                {
                    public static readonly Bitmap SpriteLight = GameResources.BlueButtonLight;
                    public static readonly Bitmap SpriteGray = GameResources.BlueButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Yellow
                {
                    public static readonly Bitmap SpriteLight = GameResources.YellowButtonLight;
                    public static readonly Bitmap SpriteGray = GameResources.YellowButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Green
                {
                    public static readonly Bitmap SpriteLight = GameResources.GreenButtonLight;
                    public static readonly Bitmap SpriteGray = GameResources.GreenButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
            }
        }

        public static class TestInterface
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = GameResources.СharacterRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnAnswer
            {
                public static readonly Bitmap Sprite = GameResources.btnAnswer;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BackgroundTest
            {
                public static readonly Bitmap Sprite = GameResources.BackgroundTest;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnNextPlay
            {
                public static readonly Bitmap Sprite = GameResources.btnNextPlay;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Success
            {
                public static readonly Bitmap Sprite = GameResources.Success;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class TestRepeatAction
        {
            public static class Question
            {
                public static readonly Bitmap Sprite = GameResources.txtTestQuestionRepeatAction;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer1
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerRepeatAction1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer2
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerRepeatAction2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer3
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerRepeatAction3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer4
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerRepeatAction4;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Tip
            {
                public static readonly Bitmap Sprite = GameResources.txtTestTipRepeatAction;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class TestCatchBones
        {
            public static class Question
            {
                public static readonly Bitmap Sprite = GameResources.txtTestQuestionCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer1
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCatchBones1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer2
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCatchBones2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer3
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCatchBones3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer4
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCatchBones4;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Tip
            {
                public static readonly Bitmap Sprite = GameResources.txtTestTipCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class TestCollectPuzzle
        {
            public static class Question
            {
                public static readonly Bitmap Sprite = GameResources.txtTestQuestionCollectPuzzle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer1
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCollectPuzzle1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer2
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCollectPuzzle2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer3
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCollectPuzzle3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer4
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerCollectPuzzle4;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Tip
            {
                public static readonly Bitmap Sprite = GameResources.txtTestTipCollectPuzzle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class TestDodgeMeteorites
        {
            public static class Question
            {
                public static readonly Bitmap Sprite = GameResources.txtTestQuestionDodgeMeteorites;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer1
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerDodgeMeteorites1;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer2
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerDodgeMeteorites2;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer3
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerDodgeMeteorites3;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Answer4
            {
                public static readonly Bitmap Sprite = GameResources.txtTestAnswerDodgeMeteorites4;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Tip
            {
                public static readonly Bitmap Sprite = GameResources.txtTestTipDodgeMeteorites;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
    }
}
