namespace MarioPirates
{
    using Event;

    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.Instance.CreateSprite("brickblock"))
        {
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            base.OnCollide(other, side);
            if (side == CollisionSide.Bottom)
            {
                if (other is Mario mario)
                {
                    var state = mario.State.GetType().ToString();
                    if (state.Contains("Big") || state.Contains("Fire"))
                    {
                        EventManager.Instance.EnqueueEvent(new GameObjectDestroyEvent(this));
                    }
                }
            }
        }
    }
}
