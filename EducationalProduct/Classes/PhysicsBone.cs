using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static EducationalProduct.Classes.GameConfig;
using static EducationalProduct.Classes.GameConfig.CatchBones.Bone;

namespace EducationalProduct.Classes
{
    public class PhysicsBone
    {
        private static Random random = new Random();
        public readonly Size Size;
        private Transform _transform;
        public Vector2 Velocity { get; set; }

        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }
         
        public PhysicsBone(Transform transform, BonesType type)
        {
            Transform = transform;
            Size = BonesSizeType(type);
            float MinSpeed = GameConfig.CatchBones.Bone.MinSpeed;
            float MaxSpeed = GameConfig.CatchBones.Bone.MaxSpeed;

            int directionX = random.Next(0, 2) == 0 ? 1 : -1;
            int directionY = random.Next(0, 2) == 0 ? 1 : -1;

            float speedX = MinSpeed + (float)random.NextDouble() * (MaxSpeed - MinSpeed);
            float speedY = MinSpeed + (float)random.NextDouble() * (MaxSpeed - MinSpeed);

            Velocity = new Vector2(speedX * directionX, speedY * directionY);
        }

        public void MoveBone()
        {
            Transform.Position.X += Velocity.X;
            Transform.Position.Y += Velocity.Y;
        }

        public void CollideBonesWithBorderCanvas()
        {
            float boneWidth = Size.Width;
            float boneHeight = Size.Height;
            float canvasWidth = CanvasProduct.Width;
            float canvasHeight = CanvasProduct.Height;

            if (Transform.Position.X < 0)
            {
                Transform.Position.X = 0;
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
            else if (Transform.Position.X + boneWidth > canvasWidth)
            {
                Transform.Position.X = canvasWidth - boneWidth;
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
            if (Transform.Position.Y < 0)
            {
                Transform.Position.Y = 0;
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            }
            else if (Transform.Position.Y + boneHeight > canvasHeight)
            {
                Transform.Position.Y = canvasHeight - boneHeight;
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            }
        }

        public void CollideBonesWithOtherBones()
        {
            float diamondSize = (Size.Width + Size.Height) / 2f;

            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var otherBone = ManagerBone.Bones[i];
                if (otherBone.Physics == this) continue;

                PointF pos1 = Transform.Position;
                PointF pos2 = otherBone.Transform.Position;

                if (CheckDiamondCollision(pos1, pos2, diamondSize))
                {
                    Vector2 collisionNormal = Vector2.Normalize(new Vector2(pos1.X - pos2.X, pos1.Y - pos2.Y));

                    Vector2 temp = Velocity;
                    Velocity = otherBone.Physics.Velocity;
                    otherBone.Physics.Velocity = temp;

                    float overlap = diamondSize - (Math.Abs(pos1.X - pos2.X) + Math.Abs(pos1.Y - pos2.Y));
                    if (overlap > 0)
                    {
                        Vector2 separation = collisionNormal * overlap * 0.5f;
                        Transform.Position = new PointF(pos1.X + separation.X, pos1.Y + separation.Y);
                        otherBone.Transform.Position = new PointF(pos2.X - separation.X, pos2.Y - separation.Y);
                    }
                }
            }
        }

        public bool CheckDiamondCollision(PointF pos1, PointF pos2, float diamondSize)
        {
            float dx = Math.Abs(pos1.X - pos2.X);
            float dy = Math.Abs(pos1.Y - pos2.Y);
            return (dx + dy) < diamondSize;
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
