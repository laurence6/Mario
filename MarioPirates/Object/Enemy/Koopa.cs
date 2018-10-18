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
                SpriteFactory.CreateSprite("koopa_left"),
                SpriteFactory.CreateSprite("koopa_right"),
                SpriteFactory.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];
        }

        public override void Update(float dt)
        {
            Sprite = stomped ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public override void OnCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario mario)
            {
                if (!stomped)
                {
                    if(side == CollisionSide.Top || mario.State.IsInvincible)
                    {
                        stomped = true;
                    }
                }
                else
                {
                    if (side == CollisionSide.Right || side == CollisionSide.TopRight)
                    {
                        // move right
                    }
                    else
                    {
                        // move left
                    }
                }
            }
            else if (other is Pipe pipe || other is Block block || other is Goomba goomba || other is Koopa koopa)
            {
                if (side == CollisionSide.Right)
                {
                    // move left
                }
                if (side == CollisionSide.Left)
                {
                    // move right
                }
            }
            base.OnCollide(other, side);
        }
    }
}
