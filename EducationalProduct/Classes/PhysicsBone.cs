using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public class PhysicsBone
    {
        private static Random random = new Random();
        private Transform _transform;
        public Vector2 Velocity { get; set; }

        public Transform Transform
        {
            get => _transform;
            set => _transform = value ?? throw new ArgumentNullException(nameof(value));
        }

        public PhysicsBone(Transform transform)
        {
            Transform = transform;
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
            float boneWidth = GameConfig.CatchBones.Bone.Width;
            float boneHeight = GameConfig.CatchBones.Bone.Height;
            float canvasWidth = GameConfig.CanvasProduct.Width;
            float canvasHeight = GameConfig.CanvasProduct.Height;

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
            float boneWidth = GameConfig.CatchBones.Bone.Width;
            float boneHeight = GameConfig.CatchBones.Bone.Height;

            for (int i = 0; i < ManagerBone.Bones.Count; i++)
            {
                var otherBone = ManagerBone.Bones[i];
                if (otherBone.Physics == this) continue;

                Vector2 pos1 = new Vector2(Transform.Position.X, Transform.Position.Y);
                Vector2 pos2 = new Vector2(otherBone.Transform.Position.X, otherBone.Transform.Position.Y);

                if (Math.Abs(pos1.X - pos2.X) < boneWidth &&
                    Math.Abs(pos1.Y - pos2.Y) < boneHeight)
                {
                    Vector2 collisionNormal = Vector2.Normalize(pos1 - pos2);

                    Vector2 temp = Velocity;
                    Velocity = otherBone.Physics.Velocity;
                    otherBone.Physics.Velocity = temp;

                    float overlap = (boneWidth + boneHeight) / 2 - Vector2.Distance(pos1, pos2);
                    if (overlap > 0)
                    {
                        Vector2 separation = collisionNormal * overlap * 0.5f;
                        Transform.Position = new PointF(Transform.Position.X + separation.X, Transform.Position.Y + separation.Y);
                        otherBone.Transform.Position = new PointF(otherBone.Transform.Position.X - separation.X, otherBone.Transform.Position.Y - separation.Y);
                    }
                }
            }
        }
    }
}
