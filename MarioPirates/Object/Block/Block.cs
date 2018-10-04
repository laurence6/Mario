using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class Block : GameObjectRigidBody
    {
        private const int blockWidth = 16, blockHeight = 16;

        protected BlockState state = BlockState.Normal;
        protected Sprite normalStateSprite = null;

        private readonly Sprite usedSprite;

        public Block(int dstX, int dstY, string state)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(blockWidth * 2, blockHeight * 2);
            Enum.TryParse(state, out this.state);
            usedSprite = SpriteFactory.Instance.CreateSprite("brownblock");
        }

        public override void Update(float dt)
        {
            switch (state)
            {
                case BlockState.Normal:
                    Sprite = normalStateSprite;
                    break;
                case BlockState.Used:
                    Sprite = usedSprite;
                    break;
                case BlockState.Hidden:
                    Sprite = null;
                    break;
            }
            Sprite?.Update(dt);
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            if (Sprite != null)
                base.Draw(spriteBatch, textures);
        }

        public void SetHidden(bool hidden)
        {
            state = hidden ? BlockState.Hidden : BlockState.Used;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
                if (state == BlockState.Hidden && side == CollisionSide.Bottom)
                    state = BlockState.Used;
        }
    }
}
