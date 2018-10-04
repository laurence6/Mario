namespace MarioPirates
{
    using Event;

    internal class QuestionBlock : Block
    {
        public QuestionBlock(int dstX, int dstY, string state) : base(dstX, dstY, state)
        {
            normalStateSprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
                if (side == CollisionSide.Bottom && state == BlockState.Normal)
                {
                    state = BlockState.Used;

                    EventManager.Instance.TriggerEvent(new GameObjectCreateEvent(
                        new GameObjectParam
                        {
                            TypeName = "Coin",
                            Location = new int[2] { (int)location.X + 10, (int)location.Y - 32 },
                        }
                    ));
                }

            base.OnCollide(other, side);
        }
    }
}
