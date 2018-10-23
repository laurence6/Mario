namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.Ins.CreateSprite("brickblock"))
        {
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (side == CollisionSide.Bottom)
            {
                if (other is Mario mario)
                {
                    if (!(mario.State.IsSmall || mario.State.IsDead))
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
                    }
                }
            }
        }
    }
}
