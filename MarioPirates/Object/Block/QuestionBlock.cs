using System.Collections.Generic;

namespace MarioPirates
{
    internal class QuestionBlock : Block
    {
        private string powerup;

        public QuestionBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("questionblock"))
        {
            powerup = Params["Powerup"];
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (other is Mario)
                if (State == BlockState.Normal && side == CollisionSide.Bottom)
                {
                    State = BlockState.Used;

                    var powerupObj = new GameObjectParam
                    {
                        TypeName = powerup,
                        Location = new int[2] { (int)Location.X + 10, (int)Location.Y - 32 },
                        Motion = MotionEnum.Dynamic,
                    }.ToGameObject();
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(powerupObj));
                    if (powerup == "Coin")
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(powerupObj), 500f);
                    }
                }
        }
    }
}
