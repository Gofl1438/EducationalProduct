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
                case GameConfig.BonesType.White:
                    Sprite = GameConfig.Bone.WhiteSprite;
                    break;
                case GameConfig.BonesType.Yellow:
                    Sprite = GameConfig.Bone.YellowSprite;
                    break;
            }
        }
    }
}
