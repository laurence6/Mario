using System;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody, IDisposable
    {
        public bool Stomped { get; set; } = false;

        private readonly Sprite[] sprites;

        public Koopa(int x, int y) : base(x, y, Constants.KOOPA_WIDTH * 2, Constants.KOOPA_HEIGHT * 2)
        {
            sprites = new Sprite[3] {
                SpriteFactory.Ins.CreateSprite("koopa_left"),
                SpriteFactory.Ins.CreateSprite("koopa_right"),
                SpriteFactory.Ins.CreateSprite("koopa_stomped"),
            };
            Sprite = sprites[0];

            RigidBody.Mass = Constants.KOOPA_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy;
            RigidBody.Velocity = Constants.KOOPA_INITIAL_VELOCITY;
        }

        public override void Update(float dt)
        {
            Sprite = Stomped ? sprites[2] : RigidBody.Velocity.X < 0 ? sprites[0] : sprites[1];
            base.Update(dt);
        }

        public void Dispose()
        {
            Score.Ins.Value += Stomped ? Constants.KOOPA_POINTS : 2 * Constants.KOOPA_POINTS;
        }
    }
}
