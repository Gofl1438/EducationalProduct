using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            RuleCatchBonesScene.Character.PositionOy = CanvasProduct.Height - RuleCatchBonesScene.Character.Height + 150;
            RuleCollectPuzzleScene.Character.PositionOy = CanvasProduct.Height - RuleCollectPuzzleScene.Character.Height;
            RuleDodgeMeteoritesScene.Character.PositionOy = CanvasProduct.Height - RuleDodgeMeteoritesScene.Character.Height;
            InitializeTotalElement();
            InitializeColleсtPuzzle();
            InitializeRepeatAction();
            InitializeDodgeMeteorites();
            InitializeCatchBones();
            InitializeOpeningScene();
            InitializeRuleScene();
            InitializeRuleRepeatActionScene();
            InitializeRuleCatchBonesScene();
            InitializeRuleCollectPuzzleScene();
            InitializeRuleDodgeMeteoritesScene();
        }

        private static void InitializeTotalElement()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            TotalElement.MenuExit.Height = (int)(CanvasProduct.Height * 0.1f);
            TotalElement.MenuExit.Width = (int)(CanvasProduct.Height * 0.4f);
            TotalElement.MenuExit.PositionOx = (CanvasProduct.Width - TotalElement.MenuExit.Width) / 2;
            TotalElement.MenuExit.PositionOy = (CanvasProduct.Height - TotalElement.MenuExit.Height) / 2;
            TotalElement.ButtonNo.PositionOx = TotalElement.MenuExit.PositionOx + TotalElement.MenuExit.Width * 0.6f;
            TotalElement.ButtonNo.PositionOy = TotalElement.MenuExit.PositionOy + TotalElement.MenuExit.Height * 0.7f;
            TotalElement.ButtonNo.Width = (int)(TotalElement.MenuExit.Width * 0.3f);
            TotalElement.ButtonNo.Height = (int)(TotalElement.MenuExit.Height * 0.2f);
            TotalElement.ButtonYes.PositionOx = TotalElement.MenuExit.PositionOx + TotalElement.MenuExit.Width * 0.1f;
            TotalElement.ButtonYes.PositionOy = TotalElement.MenuExit.PositionOy + TotalElement.MenuExit.Height * 0.7f;
            TotalElement.ButtonYes.Width = (int)(TotalElement.MenuExit.Width * 0.3f);
            TotalElement.ButtonYes.Height = (int)(TotalElement.MenuExit.Height * 0.2f);
            TotalElement.BtnClosed.Height = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnClosed.Width = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnQuestion.Height = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnQuestion.Width = (int)(MinValueCanvas * 0.1f);
            TotalElement.BtnClosed.PositionOx = (int)(CanvasProduct.Width - TotalElement.BtnClosed.Width -  CanvasProduct.Width * 0.02f);
            TotalElement.BtnClosed.PositionOy = (int)(CanvasProduct.Height * 0.02f);
            TotalElement.BtnQuestion.PositionOx = (int)(CanvasProduct.Width * 0.02f);
            TotalElement.BtnQuestion.PositionOy = (int)(CanvasProduct.Height * 0.02f);
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
        private static void InitializeRuleRepeatActionScene()
        {
            RuleRepeatActionScene.Character.Height = (int)(CanvasProduct.Height * 0.807);
            RuleRepeatActionScene.Character.Width = (int)(CanvasProduct.Width * 0.357);
            RuleRepeatActionScene.Character.PositionOy = (int)(CanvasProduct.Height - RuleRepeatActionScene.Character.Height);
            RuleRepeatActionScene.BtnStartPlay.Width = (int)(CanvasProduct.Width * 0.19f);
            RuleRepeatActionScene.BtnStartPlay.Height = (int)(CanvasProduct.Height * 0.11f);
            RuleRepeatActionScene.BtnStartPlay.PositionOx = CanvasProduct.Width * 0.56f;
            RuleRepeatActionScene.BtnStartPlay.PositionOy = CanvasProduct.Height * 0.763f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleRepeatActionScene.TxtRuleRepeatActionScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleRepeatActionScene.TxtRuleRepeatActionScene.PositionOy = CanvasProduct.Height * 0.069f;
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
            RuleCatchBonesScene.TxtRuleCatchBonesScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCatchBonesScene.TxtRuleCatchBonesScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCatchBonesScene.TxtRuleCatchBonesScene.PositionOy = CanvasProduct.Height * 0.069f;
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
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleCollectPuzzleScene.TxtRuleCollectPuzzleScene.PositionOy = CanvasProduct.Height * 0.069f;
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
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.Width = (int)(CanvasProduct.Width * 0.5468f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.Height = (int)(CanvasProduct.Height * 0.625f);
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.PositionOx = CanvasProduct.Width * 0.39f;
            RuleDodgeMeteoritesScene.TxtRuleDodgeMeteoritesScene.PositionOy = CanvasProduct.Height * 0.069f;
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
            RepeatAction.NumberPoints.WidthRectangleResult = CanvasProduct.Width;
            RepeatAction.NumberPoints.HeightRectangleResult = (int)(CanvasProduct.Height * 0.25f);
            RepeatAction.NumberPoints.SizeResult = (int)(MinValueCanvas * 0.04f);
        }
        private static void InitializeCatchBones()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            CatchBones.Background.Width = CanvasProduct.Width;
            CatchBones.Background.Height = CanvasProduct.Height;
            CatchBones.NumberPoints.WidthRectangleResult = CanvasProduct.Width;
            CatchBones.NumberPoints.HeightRectangleResult = (int)(CanvasProduct.Height * 0.1f);
            CatchBones.NumberPoints.SizeResult = (int)(MinValueCanvas * 0.04f);
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
            DodgeMeteorites.NumberPoints.widthRectangleResult = CanvasProduct.Width;
            DodgeMeteorites.NumberPoints.heightRectangleResult = (int)(CanvasProduct.Height * 0.10f);
            DodgeMeteorites.NumberPoints.SizeResult = (int)(MinValueCanvas * 0.04f);
        }

        public static class TotalElement
        {
            public static class BtnClosed
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnClosedOpening;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnQuestion
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnQuestion;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class MenuExit
            {
                public static readonly Bitmap Sprite = Properties.Resources.MenuExit;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class ButtonNo
            {
                public static readonly Bitmap Sprite = Properties.Resources.NoExit;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class ButtonYes
            {
                public static readonly Bitmap Sprite = Properties.Resources.YesExit;
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
                public static readonly Bitmap Sprite = Properties.Resources.OpeningRocket;
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
                public static readonly Bitmap Sprite = Properties.Resources.OpeningTitle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnStartPlayOpening;
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
                public static readonly Bitmap Sprite = Properties.Resources.СharacterRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleScene
            {
                public static readonly Bitmap Sprite = Properties.Resources.txtRuleScene;
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
                public static readonly Bitmap Sprite = Properties.Resources.CharacterRuleRepeatActionScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleRepeatActionScene
            {
                public static readonly Bitmap Sprite = Properties.Resources.MT;
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
                public static readonly Bitmap Sprite = Properties.Resources.CharacterRuleCatchBonesScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCatchBonesScene
            {
                public static readonly Bitmap Sprite = Properties.Resources.BS;
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
                public static readonly Bitmap Sprite = Properties.Resources.CharacterRuleCollectPuzzleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleCollectPuzzleScene
            {
                public static readonly Bitmap Sprite = Properties.Resources.txtKorolev;
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
                public static readonly Bitmap Sprite = Properties.Resources.CharacterRuleDodgeMeteoritesScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class TxtRuleDodgeMeteoritesScene
            {
                public static readonly Bitmap Sprite = Properties.Resources.txtGagarin;
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
                public static readonly Bitmap Sprite = Properties.Resources.CharacterCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class NumberPoints
            {
                public const string FamilyNameScore = "Mistral";
                public static int SizeResult { get; set; }
                public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
                public static readonly FontStyle StyleResult = FontStyle.Bold;
                public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
                public static int WidthRectangleResult { get; set; }
                public static int HeightRectangleResult { get; set; }
                public static float PosOxRectangleResult { get; set; }
                public static float PosOyRectangleResult { get; set; }
                public static PointF PointRectangleResult => new PointF(PosOxRectangleResult, PosOyRectangleResult);
                public static Size SizerRectangleResult => new Size(WidthRectangleResult, HeightRectangleResult);
            }
            public static class Bone
            {
                public static readonly int DefaultQuantityBone = 12;
                public static readonly float MinSpeed = 2.0f;
                public static readonly float MaxSpeed = 8.0f;
                public static class Big
                {
                    public static readonly Bitmap RedSprite = Properties.Resources.RedBone;
                    public static readonly Bitmap OrangeSprite = Properties.Resources.OrangeBone;
                    public static int Width { get; set; }
                    public static int Height { get; set; }
                    public static Size Size => new Size(Width, Height);
                }
                public static class Small
                {
                    public static readonly Bitmap RedSprite = Properties.Resources.RedBoneSmall;
                    public static readonly Bitmap OrangeSprite = Properties.Resources.OrangeBoneSmall;
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
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundColleсtPuzzle;
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
                    public static readonly Bitmap Sprite = Properties.Resources.ShadowPuzzle;
                    public static int Height { get; set; }
                    public static int Width { get; set; }
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class SolidRocket
                {
                    public static readonly Bitmap Sprite = Properties.Resources.SolidRocket;
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
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleBottomLeft;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class BottomRight
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleBottomRight;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy + HeightDetail;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopLeft
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleTopLeft;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static float CorrectlyPosOx { get; set; } = Shadow.PositionOx + WidthDetail;
                    public static float CorrectlyPosOy { get; set; } = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopRight
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleTopRight;
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
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundDodgeMeteorites;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class NumberPoints
            {
                public const string FamilyNameScore = "Mistral";
                public static int SizeResult { get; set; }
                public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
                public static readonly FontStyle StyleResult = FontStyle.Bold;
                public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
                public static int widthRectangleResult { get; set; }
                public static int heightRectangleResult { get; set; }
                public static float posOxRectangleResult { get; set; }
                public static float posOyRectangleResult { get; set; }
                public static PointF PointRectangleResult => new PointF(posOxRectangleResult, posOyRectangleResult);
                public static Size SizerRectangleResult => new Size(widthRectangleResult, heightRectangleResult);
            }
            public static class Rocket
            {
                public static readonly Bitmap Sprite = Properties.Resources.RocketDodge;
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
                public static readonly Bitmap Sprite = Properties.Resources.Meteorite;
                public static readonly float SpeedOy = 8.0f;
                public static readonly int DefaultQuantityMeteorites = 20;
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
                    public static readonly Bitmap Sprite = Properties.Resources.LeftButtonDodge;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Right
                {
                    public static readonly Bitmap Sprite = Properties.Resources.RightButtonDodge;
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
            public static readonly int MaxQuntitySequence = 5;
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundRepeatAction;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx { get; set; }
                public static float PositionOy { get; set; }
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class NumberPoints
            {
                
                public const string FamilyNameScore = "Mistral";
                public static int SizeResult { get; set; }
                public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(118, 66, 138));
                public static readonly FontStyle StyleResult = FontStyle.Bold;
                public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
                public static int WidthRectangleResult { get; set; }
                public static int HeightRectangleResult { get; set; }
                public static float PosOxRectangleResult { get; set; }
                public static float PosOyRectangleResult { get; set; }
                public static PointF PointRectangleResult => new PointF(PosOxRectangleResult, PosOyRectangleResult);
                public static Size SizerRectangleResult => new Size(WidthRectangleResult, HeightRectangleResult);
            }
            public static class Button
            {
                public static int Height { get; set; }
                public static int Width { get; set; }

                public static class Red
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.RedButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.RedButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Blue
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.BlueButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.BlueButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Yellow
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.YellowButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.YellowButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Green
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.GreenButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.GreenButtonGray;
                    public static float PositionOx { get; set; }
                    public static float PositionOy { get; set; }
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
            }
        }
    }
}
