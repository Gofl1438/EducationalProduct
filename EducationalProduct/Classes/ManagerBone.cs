using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.CatchBones;
using static EducationalProduct.Classes.GameConfig.CatchBones.Bone;


namespace EducationalProduct.Classes
{
    public static class ManagerBone
    {
        public static List<Bone> Bones = new List<Bone>();

        public static void AddDefaultQuantityBones()
        {
            Bones.Clear();
            Bones.AddRange(CashMiniGame.GetBones());
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
                    Bones[i].IsTouchedUser = false;
                    Bones.RemoveAt(i);
                }
            }
        } 
    }
}
