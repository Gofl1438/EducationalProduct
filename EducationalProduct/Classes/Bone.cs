using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class Bone : GameObject
    {
        public GameConfig.BonesType Type { get; set; }
        public PhysicsBone Physics { get; set; }
        public bool IsCheckHit { get; set; }
        public bool IsTouchedUser { get; set; }

        public Bone(Transform transform, GameConfig.BonesType type)
        {
            Transform = transform;
            Type = type;
            SetBoneAppearance();
            Physics = new PhysicsBone(Transform);
        }

        public void SetBoneAppearance()
        {
            switch (Type)
            {
                case GameConfig.BonesType.Red:
                    Sprite = GameConfig.CatchBones.Bone.RedSprite;
                    break;
                case GameConfig.BonesType.Orange:
                    Sprite = GameConfig.CatchBones.Bone.OrangeSprite;
                    break;
            }
        }
    }
}
