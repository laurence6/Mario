namespace MarioPirates
{
    internal class QuestionBlock : Block
    {
        public QuestionBlock(int dstX, int dstY, string state) : base(dstX, dstY, state)
        {
            normalStateSprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
                if (side == CollisionSide.Bottom)
                    state = BlockState.Used;
            base.OnCollide(other, side);
        }
    }
}
