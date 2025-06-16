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
            OpeningScene.Rocket.Height = (int)(CanvasProduct.Height * 0.55f);
            OpeningScene.Rocket.Width = (int)(CanvasProduct.Width * 0.47f);
            OpeningScene.Rocket.PositionOx = (int)(CanvasProduct.Width * 0.53f);
            OpeningScene.Rocket.PositionOy = (int)(CanvasProduct.Height * 0.31f);

            OpeningScene.Title.Height = (int)(CanvasProduct.Height * 0.15f);
            OpeningScene.Title.Width = (int)(CanvasProduct.Width * 0.53f);
            OpeningScene.Title.PositionOx = (CanvasProduct.Width - OpeningScene.Title.Width) / 2;
            OpeningScene.Title.PositionOy = (int)(CanvasProduct.Height * 0.12f);

            OpeningScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.169f);
            OpeningScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.24f);
            OpeningScene.BtnStartPlay.PositionOx = (CanvasProduct.Width - OpeningScene.BtnStartPlay.Width) / 2;
            OpeningScene.BtnStartPlay.PositionOy = (int)(CanvasProduct.Height * 0.415f);
        }
        private static void InitializeRuleScene()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            RuleScene.Character.Width = (int)(MinValueCanvas * 0.785f);
            RuleScene.Character.Height = RuleScene.Character.Width;
            RuleScene.Character.PositionOy = CanvasProduct.Height - RuleScene.Character.Height;

            RuleScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleScene.TxtRuleScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleScene.TxtRuleScene.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleScene.TxtRuleScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleScene.TxtRuleScene.PositionOy = CanvasProduct.Height * 0.069f;
        }
        private static void InitializeEndScene()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            EndScene.Character.Width = (int)(MinValueCanvas * 0.785f);
            EndScene.Character.Height = EndScene.Character.Width;
            EndScene.Character.PositionOy = CanvasProduct.Height - RuleScene.Character.Height;

            EndScene.BtnToStart.Width = (int)(CanvasProduct.Width * 0.19f);
            EndScene.BtnToStart.Height = (int)(CanvasProduct.Height * 0.11f);
            EndScene.BtnToStart.PositionOx = CanvasProduct.Width * 0.56f;
            EndScene.BtnToStart.PositionOy = CanvasProduct.Height * 0.763f;

            EndScene.TxtEndScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            EndScene.TxtEndScene.Height = (int)(CanvasProduct.Height * 0.625f);
            EndScene.TxtEndScene.PositionOx = CanvasProduct.Width * 0.39f;
            EndScene.TxtEndScene.PositionOy = CanvasProduct.Height * 0.069f;
        }
        private static void InitializeRuleRepeatActionScene()
        {
            RuleRepeatActionScene.Character.Height = (int)(CanvasProduct.Height * 0.807);
            RuleRepeatActionScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleRepeatActionScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleRepeatActionScene.Character.Height);

            RuleRepeatActionScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleRepeatActionScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleRepeatActionScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleRepeatActionScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleRepeatActionScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleRepeatActionScene.BtnNextPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleRepeatActionScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleRepeatActionScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene1.PositionOy = CanvasProduct.Height * 0.069f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene2.PositionOy = CanvasProduct.Height * 0.069f;

            RuleRepeatActionScene.TxtRuleRepeatActionScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene3.PositionOy = CanvasProduct.Height * 0.069f;
        }
        private static void InitializeRuleCatchBonesScene()
        {
            RuleCatchBonesScene.Character.Height = (int)(CanvasProduct.Height * 0.807);
            RuleCatchBonesScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleCatchBonesScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleCatchBonesScene.Character.Height);

            RuleCatchBonesScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCatchBonesScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleCatchBonesScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCatchBonesScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleCatchBonesScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCatchBonesScene.BtnNextPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleCatchBonesScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCatchBonesScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene1.PositionOy = CanvasProduct.Height * 0.069f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene2.PositionOy = CanvasProduct.Height * 0.069f;

            RuleCatchBonesScene.TxtRuleCatchBonesScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene3.PositionOy = CanvasProduct.Height * 0.069f;
        }
        private static void InitializeRuleCollectPuzzleScene()
        {
            RuleCollectPuzzleScene.Character.Height = (int)(CanvasProduct.Height * 0.807);
            RuleCollectPuzzleScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleCollectPuzzleScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleCollectPuzzleScene.Character.Height);

            RuleCollectPuzzleScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCollectPuzzleScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleCollectPuzzleScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCollectPuzzleScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleCollectPuzzleScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleCollectPuzzleScene.BtnNextPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleCollectPuzzleScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleCollectPuzzleScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene1.PositionOy = CanvasProduct.Height * 0.069f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene2.PositionOy = CanvasProduct.Height * 0.069f;

            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene3.PositionOy = CanvasProduct.Height * 0.069f;
        }
        private static void InitializeRuleDodgeMeteoritesScene()
        {
            RuleDodgeMeteoritesScene.Character.Height = (int)(CanvasProduct.Height * 0.807);
            RuleDodgeMeteoritesScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleDodgeMeteoritesScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleDodgeMeteoritesScene.Character.Height);

            RuleDodgeMeteoritesScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleDodgeMeteoritesScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleDodgeMeteoritesScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleDodgeMeteoritesScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleDodgeMeteoritesScene.BtnNextPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleDodgeMeteoritesScene.BtnNextPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleDodgeMeteoritesScene.BtnNextPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleDodgeMeteoritesScene.BtnNextPlay.PositionOy = CanvasProduct.Height * 0.763f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene1.PositionOy = CanvasProduct.Height * 0.069f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene2.PositionOy = CanvasProduct.Height * 0.069f;

            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene3.PositionOy = CanvasProduct.Height * 0.069f;
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
            CatchBones.Bone.Big.Width = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 1.2f);
            CatchBones.Bone.Big.Height = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 1.2f);
            CatchBones.Bone.Small.Width = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 0.8f);
            CatchBones.Bone.Small.Height = (int)(MinValueCanvas / CatchBones.Bone.DefaultQuantityBone * 0.8f);
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
            NumberPointsRepeatButton.SizeResult = (int)(MinValueCanvas * 0.03f);
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
            NumberPointsDodgeMeteorites.SizeResult = (int)(MinValueCanvas * 0.03f);
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
            NumberPointsCatchBones.SizeResult = (int)(MinValueCanvas * 0.03f);
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
            public static int SizeResult { get; set; } = 20;
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
                public static readonly int DefaultQuantityBone = 1;
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
    }
}
