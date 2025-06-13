using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.CatchBones.Bone;


namespace EducationalProduct.Classes
{
    public static class ManagerBone
    {
        public static List<Bone> Bones = new List<Bone>();
        private static Random rand = new Random();

        public static void AddDefaultQuantityBones()
        {
            BonesType[] bonesTypes = (BonesType[])Enum.GetValues(typeof(BonesType));

            float posOx = 0;
            float posOy = GameConfig.CanvasProduct.HeightBlockBone;
            while (Bones.Count < GameConfig.CatchBones.Bone.DefaultQuantityBone)
            {
                int index = rand.Next(0, bonesTypes.Length);
                posOx += GameConfig.CanvasProduct.WidthBlockBone;
                if (posOx > GameConfig.CanvasProduct.Width)
                {
                    posOx = GameConfig.CanvasProduct.WidthBlockBone;
                    posOy += GameConfig.CanvasProduct.HeightBlockBone;
                }
                PointF position = GetRandomPosition(posOx, posOy, bonesTypes[index]);
                Bones.Add(new Bone(position, bonesTypes[index]));
            }
        } 

        public static void ApplyPhysicsMoveBone()
        {
            foreach (Bone bone in Bones)
            {
                bone.Physics.MoveBone();
            }
        }
        public static void ApplyPhysicsCollideMoveBone()
        {
            foreach (Bone bone in Bones)
            {
                bone.Physics.CollideBonesWithBorderCanvas();
            }
            foreach (Bone bone in Bones)
            {
                bone.Physics.CollideBonesWithOtherBones();
            }
        }

        public static void DeleteTouchBones()
        {
            for (int i = Bones.Count - 1; i >= 0; i--)
            {
                if (Bones[i].IsTouchedUser)
                {
                    Bones.RemoveAt(i);
                }
            }
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
