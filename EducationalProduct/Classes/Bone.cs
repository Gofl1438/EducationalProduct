using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig.CatchBones.Bone;

namespace EducationalProduct.Classes
{
    public class Bone : GameObject
    {
        public GameConfig.BonesType Type { get; set; }
        public PhysicsBone Physics { get; set; }
        public bool IsCheckHit { get; set; }
        public bool IsTouchedUser { get; set; }

        public Bone(PointF position, GameConfig.BonesType type)
        {
            Type = type;
            SetBoneAppearance(position);
            Physics = new PhysicsBone(Transform, type);
        }

        public void SetBoneAppearance(PointF position)
        {
            switch (Type)
            {
                case GameConfig.BonesType.Red:
                    Sprite = GameConfig.CatchBones.Bone.Big.RedSprite;
                    Transform = new Transform(position, new Size(Big.Width, Big.Height));
                    break;
                case GameConfig.BonesType.Orange:
                    Sprite = GameConfig.CatchBones.Bone.Big.OrangeSprite;
                    Transform = new Transform(position, new Size(Big.Width, Big.Height));
                    break;
                case GameConfig.BonesType.RedSmall:
                    Sprite = GameConfig.CatchBones.Bone.Small.RedSprite;
                    Transform = new Transform(position, new Size(Small.Width, Small.Height));
                    break;
                case GameConfig.BonesType.OrangeSmall:
                    Sprite = GameConfig.CatchBones.Bone.Small.OrangeSprite;
                    Transform = new Transform(position, new Size(Small.Width, Small.Height));
                    break;

            }
        }
    }
}
