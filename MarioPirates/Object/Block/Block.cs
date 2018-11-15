using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class Block : GameObjectRigidBody
    {
        private readonly ISprite usedSprite;
        private readonly ISprite normalSprite;

        private BlockState state = BlockState.Normal;

        public BlockState State
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

        public virtual bool IsUsed => State == BlockState.Used;

        private readonly Vector2 origLocation;

        protected Block(int dstX, int dstY, Dictionary<string, string> Params, ISprite normalSprite) : base(dstX, dstY, Constants.BLOCK_WIDTH * 2, Constants.BLOCK_HEIGHT * 2)
        {
            usedSprite = SpriteFactory.Ins.CreateSprite(Constants.USED_BLOCK_SPRITE);
            this.normalSprite = normalSprite;

            RigidBody.ApplyForce(WorldForce.Gravity);

            Enum.TryParse(Params[Constants.STATE_PARAM], out BlockState state);
            State = state;

            origLocation = Location;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Sprite.NotNullThen(() => base.Draw(spriteBatch));
        }

        public override void Step(float dt)
        {
            base.Step(dt);
            if (Location.Y > origLocation.Y)
            {
                Location = origLocation;
                RigidBody.Motion = MotionEnum.Static;
            }
        }
    }
}
