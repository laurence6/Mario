namespace MarioPirates
{
    internal class QuestionBlockStar : Block
    {
        public QuestionBlockStar(int dstX, int dstY, string state)
            : base(dstX, dstY, state, SpriteFactory.CreateSprite("questionblock"))
        {
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (other is Mario)
                if (State == BlockState.Normal && side == CollisionSide.Bottom)
                {
                    State = BlockState.Used;

                    EventManager.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(new GameObjectParam
                    {
                        TypeName = "Star",
                        Location = new int[2] { (int)Location.X + 10, (int)Location.Y - 32 },
                        Motion = MotionEnum.Dynamic,
                    }));
                }
        }
    }
}
