using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class Block : GameObjectRigidBody
    {
        private readonly Sprite usedSprite;
        private readonly Sprite normalSprite;

        private BlockState state = BlockState.Normal;

        public BlockState State
        {
            get => this.state;
            set
            {
                switch (value)
                {
                    case BlockState.Normal:
                        this.RigidBody.CollisionSideMask = CollisionSide.All;
                        this.Sprite = this.normalSprite;
                        break;
                    case BlockState.Used:
                        this.RigidBody.CollisionSideMask = CollisionSide.All;
                        this.Sprite = this.usedSprite;
                        break;
                    case BlockState.Hidden:
                        this.RigidBody.CollisionSideMask = CollisionSide.Bottom;
                        this.Sprite = null;
                        break;
                }
                this.state = value;
            }
        }

        public virtual bool IsUsed => this.State == BlockState.Used;

        private readonly Vector2 origLocation;

        protected Block(int dstX, int dstY, Dictionary<string, string> Params, Sprite normalSprite) : base(dstX, dstY, Constants.BLOCK_WIDTH * 2, Constants.BLOCK_HEIGHT * 2)
        {
            this.usedSprite = SpriteFactory.Ins.CreateSprite("usedblock");
            this.normalSprite = normalSprite;

            this.RigidBody.ApplyForce(WorldForce.Gravity);

            Enum.TryParse(Params["State"], out BlockState state);
            this.State = state;

            this.origLocation = this.Location;
        }

        public override void Update(float dt)
        {
            this.Sprite?.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Sprite.NotNullThen(() => base.Draw(spriteBatch));
        }

        public override void Step(float dt)
        {
            base.Step(dt);
            if (this.Location.Y > this.origLocation.Y)
            {
                this.Location = this.origLocation;
                this.RigidBody.Motion = MotionEnum.Static;
            }
        }
    }
}
