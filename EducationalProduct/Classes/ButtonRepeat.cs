using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.RepeatAction.Button;

namespace EducationalProduct.Classes
{
    public class ButtonRepeat : GameObject
    {
        public GameConfig.ButtonRepeatType Type { get; set; }
        public Bitmap SpritePressed;
        public int Id { get; }
        public bool IsActiveInSequence { get; set; }
        public ButtonRepeat(int id, GameConfig.ButtonRepeatType type)
        {
            Id = id;
            Type = type;
            SetButtonActionAppearance();
        }

        private void SetButtonActionAppearance()
        {
            switch (Type)
            {
                case GameConfig.ButtonRepeatType.Red:
                    ConfigureRedButtonRepeat();
                    break;
                case GameConfig.ButtonRepeatType.Blue:
                    ConfigureBlueButtonRepeat();
                    break;
                case GameConfig.ButtonRepeatType.Yellow:
                    ConfigureYellowButtonRepeat();
                    break;
                case GameConfig.ButtonRepeatType.Green:
                    ConfigureGreenButtonRepeat();
                    break;
            }
        }

        private void ConfigureRedButtonRepeat()
        {
            Sprite = Red.SpriteGray;
            SpritePressed = Red.SpriteLight;
            Transform = new Transform(new PointF(Red.PositionOx, Red.PositionOy),
                new Size(Width, Height)
                );
        }
        private void ConfigureBlueButtonRepeat()
        {
            Sprite = Blue.SpriteGray;
            SpritePressed = Blue.SpriteLight;
            Transform = new Transform(new PointF(Blue.PositionOx, Blue.PositionOy),
                new Size(Width, Height)
                );
        }
        private void ConfigureYellowButtonRepeat()
        {
            Sprite = Yellow.SpriteGray;
            SpritePressed = Yellow.SpriteLight;
            Transform = new Transform(new PointF(Yellow.PositionOx, Yellow.PositionOy),
                new Size(Width, Height)
                );
        }
        private void ConfigureGreenButtonRepeat()
        {
            Sprite = Green.SpriteGray;
            SpritePressed = Green.SpriteLight;
            Transform = new Transform(new PointF(Green.PositionOx, Green.PositionOy),
                new Size(Width, Height)
                );
        }

        public override void DrawSprite(Graphics g)
        {
            if (Sprite == null)
                throw new InvalidOperationException("Спрайт не задан.");

            if (Transform == null)
                throw new InvalidOperationException("Трансформация не задана.");

            Bitmap currentSprite = IsActiveInSequence ? SpritePressed : Sprite;
            g.DrawImage(currentSprite, Transform.Position.X, Transform.Position.Y, Transform.Size.Width, Transform.Size.Height);
        }
    }
}
