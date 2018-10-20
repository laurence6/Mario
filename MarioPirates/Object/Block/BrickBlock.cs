namespace MarioPirates
{
    using Event;

    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.CreateSprite("brickblock"))
        {
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (side == CollisionSide.Bottom)
            {
                if (other is Mario mario)
                {
                    if (!(mario.State.IsSmall || mario.State.IsDead))
                    {
                        EventManager.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
                    }
                }
            }
            base.PostCollide(other, side);
        }
    }
}
