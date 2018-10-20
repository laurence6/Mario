namespace MarioPirates
{
    using Event;

    internal class QuestionBlock : Block
    {
        public QuestionBlock(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.CreateSprite("questionblock"))
        {
        }

        public override void OnCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
                if (State == BlockState.Normal && side == CollisionSide.Bottom)
                {
                    State = BlockState.Used;

                    EventManager.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(new GameObjectParam
                    {
                        TypeName = "Coin",
                        Location = new int[2] { (int)Location.X + 10, (int)Location.Y - 32 },
                        Motion = MotionEnum.Dynamic,
                    }));
                }
            base.OnCollide(other, side);
        }
    }
}
