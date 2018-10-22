using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class Block : GameObjectRigidBody
    {
        private const int blockWidth = 16, blockHeight = 16;

        private readonly Sprite usedSprite;
        private readonly Sprite normalSprite;

        private BlockState state = BlockState.Normal;
        protected virtual BlockState State
        {
            get => state;
            set
            {
                switch (value)
                {
                    case BlockState.Normal:
                        RigidBody.CollisionSideMask = CollisionSide.All;
                        Sprite = normalSprite;
                        break;
                    case BlockState.Used:
                        RigidBody.CollisionSideMask = CollisionSide.All;
                        Sprite = usedSprite;
                        break;
                    case BlockState.Hidden:
                        RigidBody.CollisionSideMask = CollisionSide.Bottom;
                        Sprite = null;
                        break;
                }
                state = value;
            }
        }

        private readonly Vector2 origLocation;

        protected Block(int dstX, int dstY, Dictionary<string, string> Params, Sprite normalSprite) : base(dstX, dstY, blockWidth * 2, blockHeight * 2)
        {
            usedSprite = SpriteFactory.Ins.CreateSprite("usedblock");
            this.normalSprite = normalSprite;

            RigidBody.ApplyForce(WorldForce.Gravity);

            Enum.TryParse(Params["State"], out BlockState state);
            State = state;

            origLocation = Location;
        }

        public override void Update(float dt)
        {
            Sprite?.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.NotNullThen(() => base.Draw(spriteBatch));
        }

        public override void Step(float dt)
        {
            if (Location.Y > origLocation.Y)
            {
                Location = origLocation;
                RigidBody.Motion = MotionEnum.Static;
            }
            base.Step(dt);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
                if (side == CollisionSide.Bottom && RigidBody.Motion == MotionEnum.Static && State != BlockState.Used)
                {
                    if (State == BlockState.Hidden)
                        State = BlockState.Normal;

                    RigidBody.Motion = MotionEnum.Keyframe;
                    RigidBody.Velocity = new Vector2(0, -150f);
                }
            base.PostCollide(other, side);
        }
    }
}
