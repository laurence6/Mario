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

        protected BlockState State { get; private set; } = BlockState.Normal;

        protected Block(int dstX, int dstY, string stateName, Sprite normalSprite) : base(dstX, dstY, blockWidth * 2, blockHeight * 2)
        {
            usedSprite = SpriteFactory.Instance.CreateSprite("brownblock");
            this.normalSprite = normalSprite;
            Enum.TryParse(stateName, out BlockState state);
            SetState(state);
        }

        public override void Update(float dt)
        {
            Sprite?.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            if (Sprite != null)
                base.Draw(spriteBatch, textures);
        }

        public void SetState(BlockState state)
        {
            switch (state)
            {
                case BlockState.Normal:
                    RigidBody.CollideSideMask = CollisionSide.All;
                    Sprite = normalSprite;
                    break;
                case BlockState.Used:
                    RigidBody.CollideSideMask = CollisionSide.All;
                    Sprite = usedSprite;
                    break;
                case BlockState.Hidden:
                    RigidBody.CollideSideMask = CollisionSide.Bottom;
                    Sprite = null;
                    break;
            }
            State = state;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
                if (State == BlockState.Hidden && side == CollisionSide.Bottom)
                    SetState(BlockState.Normal);
        }
    }
}
