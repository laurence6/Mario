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

                    if (powerup != null)
                    {
                        var powerupObj = new GameObjectParam
                        {
                            TypeName = powerup,
                            Location = new int[2] { (int)Location.X, (int)Location.Y - 2 * Constants.BLOCK_HEIGHT },
                            Motion = MotionEnum.Dynamic,
                        }.ToGameObject();
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(powerupObj));
                        if (powerup == "Coin")
                        {
                            Coins.Ins.Value++;
                            Score.Ins.Value += 200;
                            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                        }
                    }
                }
        }
    }
}
