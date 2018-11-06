using Microsoft.Xna.Framework;
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
                if (powerup != null)
                {
                    State = BlockState.Used;

                    var powerupObj = new GameObjectParam
                    {
                        TypeName = powerup,
                        Location = new int[2] { (int)Location.X, (int)Location.Y - Constants.BLOCK_HEIGHT * 2 },
                        Motion = MotionEnum.Dynamic,
                    }.ToGameObject();
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(powerupObj));
                    if (powerup == "Coin")
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                    }
                    powerup = null;
                }
                else if (State == BlockState.Normal && !(mario.State.IsSmall || mario.State.IsDead))
                {
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));

                    for (var i = 0; i < Constants.BRICK_BLOCK_COLLISION_POSITIONS.Length; i++)
                    {
                        var debris = new GameObjectParam
                        {
                            TypeName = "BrickDebris",
                            Location = new int[] { (int)Location.X + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 0], (int)Location.Y + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 1] },
                            Motion = MotionEnum.Dynamic,
                            Params = new Dictionary<string, string> { { "Position", Constants.BRICK_BLOCK_COLLISION_POSITIONS[i] } },
                        }.ToGameObject();
                        (debris as GameObjectRigidBody).RigidBody.Velocity = Constants.BRICK_BLOCK_COLLISION_VELOCITIES[i];
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(debris));
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(debris), Constants.BLOCK_COLLISION_EVENT_DT);
                    }
                }
            }
        }
    }
}
