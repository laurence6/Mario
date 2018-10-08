namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public BrickBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.CreateSprite("brickblock"))
        {
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            base.OnCollide(other, side);
            if (side == CollisionSide.Bottom)
            {
                if (other is Mario)
                {
                    // FIXME
                }
            }
        }
    }
}
