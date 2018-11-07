namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        public Flower(int dstX, int dstY) : base(dstX, dstY, Constants.FLOWER_WIDTH * 2, Constants.FLOWER_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flower");
            RigidBody.CollisionLayerMask = CollisionLayer.Flower;
            RigidBody.Motion = MotionEnum.Keyframe;
        }
    }
}
