using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle.Puzzle;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EducationalProduct.Classes
{
    public class Puzzle : GameObject
    {
        public GameConfig.PuzzlesType Type { get; set; }
        public PhysicsPuzzle Physics { get; set; }
        public bool IsCorrectPosition { get; set; }

        public Puzzle(GameConfig.PuzzlesType type)
        {
            Type = type;
            SetBoneAppearance();
            Physics = new PhysicsPuzzle(Transform, type);
        }

        private void SetBoneAppearance()
        {
            switch (Type)
            {
                case GameConfig.PuzzlesType.BottomLeft:
                    ConfigureBottomLeftPuzzle();
                    break;
                case GameConfig.PuzzlesType.BottomRight:
                    ConfigureBottomRightPuzzle();
                    break;
                case GameConfig.PuzzlesType.TopLeft:
                    ConfigureTopLeftPuzzle();
                    break;
                case GameConfig.PuzzlesType.TopRight:
                    ConfigureTopRightPuzzle();
                    break;
            }
        }

        private void ConfigureBottomLeftPuzzle()
        {
            Sprite = BottomLeft.Sprite;
            Transform = new Transform(new PointF (BottomLeft.PositionOx, BottomLeft.PositionOy), 
                new Size(WidthDetail, HeightDetail)
                );
        }
        private void ConfigureBottomRightPuzzle()
        {
            Sprite = BottomRight.Sprite;
            Transform = new Transform(new PointF(BottomRight.PositionOx, BottomRight.PositionOy),
                new Size(WidthDetail, HeightDetail)
                );
        }
        private void ConfigureTopLeftPuzzle()
        {
            Sprite = TopLeft.Sprite;
            Transform = new Transform(new PointF(TopLeft.PositionOx, TopLeft.PositionOy),
                new Size(WidthDetail, HeightDetail)
                );
        }
        private void ConfigureTopRightPuzzle()
        {
            Sprite = TopRight.Sprite;
            Transform = new Transform(new PointF(TopRight.PositionOx, TopRight.PositionOy),
                new Size(WidthDetail, HeightDetail)
                );
        }
    }
}
