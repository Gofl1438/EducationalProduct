using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class ManagerBone
    {
        public static List<Bone> Bones = new List<Bone>();
        private static Random rand = new Random();

        public static void AddDefaultQuantityBones()
        {
            int quantityOrangeBone = 0;
            int quantityRedBone = 0;
            float posOx = 0;
            float posOy = GameConfig.CanvasProduct.HeightBlockBone;

            for (int i = 0; i < GameConfig.CatchBones.Bone.DefaultQuantityBone * 2; i++)
            {
                int typeBone;
                if (quantityOrangeBone >= GameConfig.CatchBones.Bone.DefaultQuantityBone)
                {
                    typeBone = 1;
                }
                else if (quantityRedBone >= GameConfig.CatchBones.Bone.DefaultQuantityBone)
                {
                    typeBone = 0;
                }
                else
                {
                    typeBone = rand.Next(0, 2);
                }

                posOx += GameConfig.CanvasProduct.WidthBlockBone;
                if (posOx > GameConfig.CanvasProduct.Width)
                {
                    posOx = GameConfig.CanvasProduct.WidthBlockBone;
                    posOy += GameConfig.CanvasProduct.HeightBlockBone;
                }

                PointF position = GetRandomPosition(posOx + 20, posOy + 20);
                Transform transform = new Transform(position, new Size(GameConfig.CatchBones.Bone.Width - 20, GameConfig.CatchBones.Bone.Height- 20));
                if (typeBone == 0)
                {
                    Bones.Add(new Bone(transform, GameConfig.BonesType.Orange));
                    quantityOrangeBone++;
                }
                else
                {
                    Bones.Add(new Bone(transform, GameConfig.BonesType.Red));
                    quantityRedBone++;
                }
            }
            Debug.WriteLine($"Создано: {quantityOrangeBone} оранжевых, {quantityRedBone} красных");
        }

        public static void ApplyPhysicsBone()
        {
            foreach (Bone bone in Bones)
            {
                bone.Physics.MoveBone();
                bone.Physics.CollideBonesWithBorderCanvas();
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

        private static PointF GetRandomPosition(float posOx, float posOy)
        {
            float startPosOx = posOx - GameConfig.CanvasProduct.WidthBlockBone;
            float endPosOx = posOx - GameConfig.CatchBones.Bone.Width;
            float startPosOy = posOy - GameConfig.CanvasProduct.HeightBlockBone;
            float endPosOy = posOy - GameConfig.CatchBones.Bone.Height;

            float newPosOx = startPosOx + rand.NextSingle() * (endPosOx - startPosOx);
            float newPosOy = startPosOy + rand.NextSingle() * (endPosOy - startPosOy);

            return new PointF(newPosOx, newPosOy);
        }
    }
}
