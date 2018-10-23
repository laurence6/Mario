﻿using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody
    {
        private const int koopaWidth = 16, koopaHeight = 23;

        private bool stomped;
        private readonly Sprite[] sprites;

        public Koopa(int x, int y) : base(x, y, koopaWidth * 2, koopaHeight * 2)
        {
            RigidBody.Mass = 0.1f;

            stomped = false;
            sprites = new Sprite[3] {
                SpriteFactory.Ins.CreateSprite("koopa_left"),
                SpriteFactory.Ins.CreateSprite("koopa_right"),
                SpriteFactory.Ins.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];

            RigidBody.Velocity = new Vector2(-25f, 0f);
        }

        public override void Update(float dt)
        {
            Sprite = stomped ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario mario)
            {
                if (side == CollisionSide.Top || mario.State.IsInvincible)
                {
                    if (side == CollisionSide.Top)
                        if (stomped)
                            RigidBody.Velocity = mario.RigidBody.Bound.Center.X > RigidBody.Bound.Center.X ? new Vector2(-250f, 0f) : new Vector2(250f, 0f);
                    stomped = true;
                }
            }
            base.PostCollide(other, side);
        }
    }
}
