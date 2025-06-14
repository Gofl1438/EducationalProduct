using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle.Puzzle;

namespace EducationalProduct.Classes
{
    public class PhysicsPuzzle
    {
        private Transform _transform;
        private Transform _defaultTransform;
        private PuzzlesType Type;
        public bool IsDragging;
        private PointF dragOffset;
        public bool IsCorrectPosition { get; set; }
        public RectangleF Bounds => new RectangleF(Transform.Position, Transform.Size);

        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }
        public Transform defaultTransform
        {
            get => _defaultTransform;
            set 
            {
                if (_defaultTransform == null)
                {
                    _defaultTransform = value ?? throw new ArgumentNullException(nameof(value));
                }
            }
        }
        public PhysicsPuzzle(Transform transform, GameConfig.PuzzlesType type)
        {
            Transform = transform;
            Type = type;
            defaultTransform = transform.Clone();
        }

        public void StartDrag(Point mousePos)
        {
            IsDragging = true;
            dragOffset = new PointF(mousePos.X - Transform.Position.X, mousePos.Y - Transform.Position.Y);
        }

        public void UpdateDrag(Point mousePos)
        {
            if (IsDragging)
            {
                Transform.Position = new PointF(mousePos.X - dragOffset.X, mousePos.Y - dragOffset.Y);
            }
        }
        public void EndDrag()
        {
            IsDragging = false;
        }
        public void UpdatePhysics()
        {
            if (!IsDragging)
            {
                if (Transform.Position.X < 0 || Transform.Position.X + WidthDetail > GameConfig.CanvasProduct.Width)
                {
                    Transform.Position = defaultTransform.Position;
                }
                if (Transform.Position.Y < 0 || Transform.Position.Y + HeightDetail > GameConfig.CanvasProduct.Height)
                {
                    Transform.Position = defaultTransform.Position;
                }

                RectangleF detailRect = new RectangleF(Transform.Position.X, Transform.Position.Y, WidthDetail, HeightDetail);
                RectangleF correctlyRect = SetBoneAppearance();

                float deltaX = Math.Abs(detailRect.X - correctlyRect.X);
                float deltaY = Math.Abs(detailRect.Y - correctlyRect.Y);

                float snapThreshold = GameConfig.ColleсtPuzzle.Puzzle.snapThreshold;

                if (deltaX <= snapThreshold && deltaY <= snapThreshold)
                {
                    Transform.Position = new PointF(correctlyRect.X, correctlyRect.Y);
                    IsCorrectPosition = true;
                }
            }
        }

        private RectangleF SetBoneAppearance()
        {
            float x = 0;
            float y = 0;

            switch (Type)
            {
                case GameConfig.PuzzlesType.BottomLeft:
                    x = BottomLeft.CorrectlyPosOx;
                    y = BottomLeft.CorrectlyPosOy;
                    break;
                case GameConfig.PuzzlesType.BottomRight:
                    x = BottomRight.CorrectlyPosOx;
                    y = BottomRight.CorrectlyPosOy;
                    break;
                case GameConfig.PuzzlesType.TopLeft:
                    x = TopLeft.CorrectlyPosOx;
                    y = TopLeft.CorrectlyPosOy;
                    break;
                case GameConfig.PuzzlesType.TopRight:
                    x = TopRight.CorrectlyPosOx;
                    y = TopRight.CorrectlyPosOy;
                    break;
            }

            return new RectangleF(x, y, WidthDetail, HeightDetail);
        }


    }
}
