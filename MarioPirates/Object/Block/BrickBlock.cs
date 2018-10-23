using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        private string powerup;

        public BrickBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("brickblock"))
        {
            if (Params.ContainsKey("Powerup"))
                powerup = Params["Powerup"];
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            base.PostCollide(other, side);
            if (other is Mario mario && side == CollisionSide.Bottom)
            {
                if (State == BlockState.Normal)
                {
                    State = BlockState.Used;

                    if (powerup != null)
                    {
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
                else if (State == BlockState.Used && !(mario.State.IsSmall || mario.State.IsDead))
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
        }
    }
}
