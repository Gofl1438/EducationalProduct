using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.CatchBones.Bone;
using static EducationalProduct.Classes.GameConfig.ColleсtPuzzle;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites;
using static EducationalProduct.Classes.GameConfig.DodgeMeteorites.ButtonMove;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EducationalProduct.Classes
{
    public class CashMiniGame
    {
        private static List<ButtonRepeat> _buttonRepeat;
        private static Random rand = new Random();
        private static List<Bone> _bones;
        public static List<Meteorite> _meteorites;

        public static List<ButtonRepeat> GetButtonRepeat()
        {
            if (_buttonRepeat == null)
            {
                var types = (ButtonRepeatType[])Enum.GetValues(typeof(ButtonRepeatType));
                _buttonRepeat = new List<ButtonRepeat>(types.Length);

                for (int i = 0; i < types.Length; i++)
                {
                    _buttonRepeat.Add(new ButtonRepeat(i, types[i]));
                }
            }
            return _buttonRepeat;
        }

        public static List<Bone> GetBones()
        {
            if (_bones == null)
            {
                BonesType[] bonesTypes = (BonesType[])Enum.GetValues(typeof(BonesType));
                _bones = new List<Bone>(bonesTypes.Length);
                float posOx = 0;
                float posOy = GameConfig.CanvasProduct.HeightBlockBone;
                while (_bones.Count < GameConfig.CatchBones.Bone.DefaultQuantityBone)
                {
                    int index = rand.Next(0, bonesTypes.Length);
                    posOx += GameConfig.CanvasProduct.WidthBlockBone;
                    if (posOx > GameConfig.CanvasProduct.Width)
                    {
                        posOx = GameConfig.CanvasProduct.WidthBlockBone;
                        posOy += GameConfig.CanvasProduct.HeightBlockBone;
                    }
                    PointF position = GetRandomPosition(posOx, posOy, bonesTypes[index]);
                    _bones.Add(new Bone(position, bonesTypes[index]));
                }
            }
            return _bones;
        }
        private static PointF GetRandomPosition(float posOx, float posOy, BonesType bonesType)
        {
            Size size = BonesSizeType(bonesType);
            float startPosOx = posOx - CanvasProduct.WidthBlockBone;
            float endPosOx = posOx - size.Width;
            float startPosOy = posOy - CanvasProduct.HeightBlockBone;
            float endPosOy = posOy - size.Height;

            float newPosOx = startPosOx + rand.NextSingle() * (endPosOx - startPosOx);
            float newPosOy = startPosOy + rand.NextSingle() * (endPosOy - startPosOy);

            return new PointF(newPosOx, newPosOy);
        }

        private static Size BonesSizeType(BonesType bonesType)
        {
            if (bonesType == BonesType.Orange || bonesType == BonesType.Red)
            {
                return Big.Size;
            }
            else
            {
                return Small.Size;
            }
        }
    }
}
