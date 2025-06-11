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

        public enum BonesType { Red, Orange }
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
            TotalElement.Background.Width = CanvasProduct.Width;
            TotalElement.Background.Height = CanvasProduct.Height;
            TotalElement.BtnClosed.PositionOx = CanvasProduct.Width - TotalElement.BtnClosed.Width - TotalElement.BtnClosed.Height;
            RuleScene.Character.PositionOy = CanvasProduct.Height - RuleScene.Character.Height;
            DodgeMeteorites.Background.Width = CanvasProduct.Width;
            DodgeMeteorites.Background.Height = CanvasProduct.Height;
            CanvasProduct.WidthBlockBone = (float)CanvasProduct.Width / CatchBones.Bone.DefaultQuantityBone;
            CanvasProduct.HeightBlockBone = (float)CanvasProduct.Height / 2;
            InitializeColleсtPuzzle();
            InitializeRepeatAction();
            InitializeDodgeMeteorites();
            InitializeCatchBones();
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
            RepeatAction.NumberPoints.widthRectangleResult = CanvasProduct.Width;
            RepeatAction.NumberPoints.heightRectangleResult = (int)(CanvasProduct.Height * 0.25f);
            RepeatAction.NumberPoints.SizeResult = (int)(MinValueCanvas * 0.04f);
        }


        private static void InitializeCatchBones()
        {
            int MinValueCanvas = Math.Min(CanvasProduct.Height, CanvasProduct.Width);
            CatchBones.Background.Width = CanvasProduct.Width;
            CatchBones.Background.Height = CanvasProduct.Height;
            CatchBones.NumberPoints.widthRectangleResult = CanvasProduct.Width;
            CatchBones.NumberPoints.heightRectangleResult = (int)(CanvasProduct.Height * 0.1f);
            CatchBones.NumberPoints.SizeResult = (int)(MinValueCanvas * 0.04f);
            CatchBones.Character.Width = (int)(CanvasProduct.Width * 0.24f);
            CatchBones.Character.Height = (int)(CanvasProduct.Height * 0.4f);
            CatchBones.Character.PositionOy = CanvasProduct.Height - CatchBones.Character.Height;
            CatchBones.Bone.Width = (int)(CanvasProduct.Width / CatchBones.Bone.DefaultQuantityBone * 0.8f);
            CatchBones.Bone.Height = (int)(CanvasProduct.Width / CatchBones.Bone.DefaultQuantityBone * 0.8f);
        }

        private static void InitializeDodgeMeteorites()
        {
            DodgeMeteorites.Background.Width = CanvasProduct.Width;
            DodgeMeteorites.Background.Height = CanvasProduct.Height;
        }



        public static class TotalElement
        {
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.Background;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx => 0;
                public static float PositionOy => 0;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnClosed
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnClosedOpening;
                public static int Height { get; set; } = 100;
                public static int Width { get; set; } = 100;
                public static float PositionOx;
                public static float PositionOy = 50;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnBackArrow
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnBackArrow;
                public static int Height { get; set; } = 100;
                public static int Width { get; set; } = 100;
                public static float PositionOx = 50;
                public static float PositionOy = 50;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class OpeningScene
        {
            public static class Rocket
            {
                public static readonly Bitmap Sprite = Properties.Resources.OpeningRocket;
                public static int Height { get; set; } = 600;
                public static int Width { get; set; } = 920;
                public static float PositionOx { get; set; } = 1020;
                public static float PositionOy { get; set; } = 340;
                public static readonly float RotationAngle = -20f;
                public static Size Size = new Size(Width, Height);
                public static PointF Point = new PointF(PositionOx, PositionOy);
            }

            public static class BtnQuestion
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnQuestion;
                public static int Height { get; set; } = 100;
                public static int Width { get; set; } = 100;
                public static float PositionOx = 50;
                public static float PositionOy = 50;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Title
            {
                public static readonly Bitmap Sprite = Properties.Resources.OpeningTitle;
                public static int Height { get; set; } = 168;
                public static int Width { get; set; } = 1021;
                public static float PositionOx = 450;
                public static float PositionOy = 131;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnStartPlayOpening;
                public static int Height { get; set; } = 183;
                public static int Width { get; set; } = 463;
                public static float PositionOx = 729;
                public static float PositionOy = 449;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
        }
        public static class RuleScene
        {
            public static class Character
            {
                public static readonly Bitmap Sprite = Properties.Resources.СharacterRuleScene;
                public static int Height { get; set; } = 847;
                public static int Width { get; set; } = 847;
                public static float PositionOx = 0;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class BtnStartPlay
            {
                public static readonly Bitmap Sprite = Properties.Resources.btnPlayStartRuleScene;
                public static int Height { get; set; } = 188;
                public static int Width { get; set; } = 530;
                public static float PositionOx = 1200;
                public static float PositionOy = 700;
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
                public static float PositionOx;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundCatchBones;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class NumberPoints
            {
                public const string FamilyNameScore = "Mistral";
                public static int SizeResult;
                public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
                public static readonly FontStyle StyleResult = FontStyle.Bold;
                public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
                public static int widthRectangleResult;
                public static int heightRectangleResult;
                public static float posOxRectangleResult;
                public static float posOyRectangleResult;
                public static PointF PointRectangleResult => new PointF(posOxRectangleResult, posOyRectangleResult);
                public static Size SizerRectangleResult => new Size(widthRectangleResult, heightRectangleResult);
            }
            public static class Bone
            {
                public static readonly int DefaultQuantityBone = 8;
                public static readonly float Speed = 3f;
                public static readonly Bitmap RedSprite = Properties.Resources.RedBone;
                public static readonly Bitmap OrangeSprite = Properties.Resources.OrangeBone;
                public static int Width = 130;
                public static int Height = 130;
                public static readonly float MinSpeed = 2.0f;
                public static readonly float MaxSpeed = 8.0f;
            }
        }
        public static class ColleсtPuzzle
        {
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundColleсtPuzzle;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class Puzzle
            {
                public static int HeightDetail;
                public static int WidthDetail;
                public static class Shadow
                {
                    public static readonly Bitmap Sprite = Properties.Resources.ShadowPuzzle;
                    public static int Height;
                    public static int Width;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class SolidRocket
                {
                    public static readonly Bitmap Sprite = Properties.Resources.SolidRocket;
                    public static readonly float SpeedOx = 12f;
                    public static readonly float Acceleration = 3f;
                    public static int Height = Shadow.Height;
                    public static int Width = Shadow.Width;
                    public static float PositionOx = Shadow.PositionOx;
                    public static float PositionOy = Shadow.PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class BottomLeft
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleBottomLeft;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static float CorrectlyPosOx = Shadow.PositionOx;
                    public static float CorrectlyPosOy = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class BottomRight
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleBottomRight;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static float CorrectlyPosOx = Shadow.PositionOx;
                    public static float CorrectlyPosOy = Shadow.PositionOy + HeightDetail;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopLeft
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleTopLeft;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static float CorrectlyPosOx = Shadow.PositionOx + WidthDetail;
                    public static float CorrectlyPosOy = Shadow.PositionOy;
                    public static Size Size => new Size(WidthDetail, HeightDetail);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class TopRight
                {
                    public static readonly Bitmap Sprite = Properties.Resources.PuzzleTopRight;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static float CorrectlyPosOx = Shadow.PositionOx + WidthDetail;
                    public static float CorrectlyPosOy = Shadow.PositionOy + HeightDetail;
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
                public static float PositionOx;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }

            public static class Rocket
            {
                public static readonly Bitmap Sprite = Properties.Resources.RocketDodge;
                public static int Height { get; set; } = 350;
                public static int Width { get; set; } = 250;
                public static float PositionOx { get; set; } = 102;
                public static float PositionOy { get; set; } = 400;
                public static float SpeedOx = 35f;
                public static Size Size = new Size(Width, Height);
                public static PointF Point = new PointF(PositionOx, PositionOy);
            }

            public static class Meteorite
            {
                public static readonly Bitmap Sprite = Properties.Resources.Meteorite;
                public static readonly float MinSpeedOy = 3.0f;
                public static readonly float MaxSpeedOy = 7.0f;
                public static readonly int normalQuantity = 5;
                public static int Height { get; set; } = 300;
                public static int Width { get; set; } = 300;

                public static Size Size = new Size(Width, Height);
            }

            public static class ButtonLeft
            {
                public static readonly Bitmap Sprite = Properties.Resources.LeftButtonDodge;
                public static int Height { get; set; } = 200;
                public static int Width { get; set; } = 350;
                public static float PositionOx { get; set; } = 60;
                public static float PositionOy { get; set; } = 750;
                public static Size Size = new Size(Width, Height);
                public static PointF Point = new PointF(PositionOx, PositionOy);
            }
            public static class ButtonRight
            {
                public static readonly Bitmap Sprite = Properties.Resources.RightButtonDodge;
                public static int Height { get; set; } = 200;
                public static int Width { get; set; } = 350;
                public static float PositionOx { get; set; } = 1500;
                public static float PositionOy { get; set; } = 750;
                public static Size Size = new Size(Width, Height);
                public static PointF Point = new PointF(PositionOx, PositionOy);
            }
        }
        public static class RepeatAction
        {
            public static readonly int FrequencyGameOver = 5;
            public static readonly int MaxQuntitySequence = 6;
            public static class Background
            {
                public static readonly Bitmap Sprite = Properties.Resources.BackgroundRepeatAction;
                public static int Height { get; set; }
                public static int Width { get; set; }
                public static float PositionOx;
                public static float PositionOy;
                public static Size Size => new Size(Width, Height);
                public static PointF Point => new PointF(PositionOx, PositionOy);
            }
            public static class NumberPoints
            {
                
                public const string FamilyNameScore = "Mistral";
                public static int SizeResult;
                public static readonly SolidBrush CustomBrush = new SolidBrush(Color.FromArgb(118, 66, 138));
                public static readonly FontStyle StyleResult = FontStyle.Bold;
                public static readonly FontStyle StyleResultEnd = FontStyle.Strikeout;
                public static int widthRectangleResult;
                public static int heightRectangleResult;
                public static float posOxRectangleResult;
                public static float posOyRectangleResult;
                public static PointF PointRectangleResult => new PointF(posOxRectangleResult, posOyRectangleResult);
                public static Size SizerRectangleResult => new Size(widthRectangleResult, heightRectangleResult);
            }
            public static class Button
            {
                public static int Height;
                public static int Width;

                public static class Red
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.RedButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.RedButtonGray;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Blue
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.BlueButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.BlueButtonGray;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Yellow
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.YellowButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.YellowButtonGray;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
                public static class Green
                {
                    public static readonly Bitmap SpriteLight = Properties.Resources.GreenButtonLight;
                    public static readonly Bitmap SpriteGray = Properties.Resources.GreenButtonGray;
                    public static float PositionOx;
                    public static float PositionOy;
                    public static Size Size => new Size(Width, Height);
                    public static PointF Point => new PointF(PositionOx, PositionOy);
                }
            }
        }
    }

}
