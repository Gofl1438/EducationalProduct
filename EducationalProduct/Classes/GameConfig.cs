using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class GameConfig
    {
        public enum BonesType { Yellow, White }
        public static class CanvasPlayBones
        {
            public static int Height { get; set; }
            public static int Width { get; set; }
            public static float WidthBlockBone { get; set; }
            public static float HeightBlockBone { get; set; }
        }

        public static void Initialize(Size sizeCanvas)
        {
            CanvasPlayBones.Height = sizeCanvas.Height;
            CanvasPlayBones.Width = sizeCanvas.Width;
            CanvasPlayBones.WidthBlockBone = (float)CanvasPlayBones.Width / Bone.DefaultQuantityBone;
            CanvasPlayBones.HeightBlockBone = (float)CanvasPlayBones.Height / 2;
        }

        public static class Bone
        {
            public static readonly int DefaultQuantityBone = 8;
            public static readonly float Speed = 3f;
            public static readonly Bitmap WhiteSprite = Properties.Resources.DoodleUp;
            public static readonly Bitmap YellowSprite = Properties.Resources.RedMonster;
            public static readonly int Width = 90;
            public static readonly int Height = 90;
            public static readonly float MinSpeed = 2.0f;
            public static readonly float MaxSpeed = 7.0f;
        }
    }
}
