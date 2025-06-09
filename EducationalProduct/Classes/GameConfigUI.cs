using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfigUI;

namespace EducationalProduct.Classes
{
    public static class GameConfigUI
    {
        public static int Height { get; set; }
        public static int Width { get; set; }

        public static void Initialize(Size sizeCanvas)
        {
            Height = sizeCanvas.Height;
            Width = sizeCanvas.Width;
            OpeningScene.Background.Width = Width;
            OpeningScene.Background.Height = Height;
            OpeningScene.BtnClosed.PositionOx = Width - OpeningScene.BtnClosed.Width - OpeningScene.BtnClosed.Height;
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
        }
    }

}
