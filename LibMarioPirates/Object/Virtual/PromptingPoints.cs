using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class PromptingPoints : GameObjectRigidBody
    {
        public PromptingPoints(float locX, float locY, int value) : base(locX, locY, 0, 0)
        {
            Sprite = SpriteFactory.Ins.CreatePromptingPointsSprite(() => value.ToString());
            RigidBody.Motion = MotionEnum.Keyframe;
            RigidBody.Velocity = new Vector2(0f, -25f);
            RigidBody.CollisionLayerMask = CollisionLayer.None;
            RigidBody.ApplyForce(WorldForce.None);
            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this), Constants.RESET_EVENT_DT);
        }
    }
}
