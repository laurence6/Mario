namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        private const int starWidth = 14, starHeight = 16;

        public Star(int dstX, int dstY) : base(dstX, dstY, starWidth * 2, starHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("stars");
            RigidBody.Mass = 0.05f;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
