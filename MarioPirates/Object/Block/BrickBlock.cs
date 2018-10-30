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
                        Location = new int[2] { (int)Location.X, (int)Location.Y - 32 },
                        Motion = MotionEnum.Dynamic,
                    }.ToGameObject();
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(powerupObj));
                    if (powerup == "Coin")
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(powerupObj), 500f);
                    }
                    powerup = null;
                }
                else if (State == BlockState.Normal && !(mario.State.IsSmall || mario.State.IsDead))
                {
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));

                    var positions = new string[4] { "upperleft", "upperright", "lowerleft", "lowerright" };
                    var offsets = new int[4, 2] { { 0, 0 }, { BrickDebris.debrisWidth, 0 }, { 0, BrickDebris.debrisHeight }, { BrickDebris.debrisWidth, BrickDebris.debrisHeight } };
                    var velocities = new Vector2[] { new Vector2(-100f, -200f), new Vector2(100f, -200f), new Vector2(-100f, 0f), new Vector2(100f, 0f) };
                    for (var i = 0; i < 4; i++)
                    {
                        var debris = new GameObjectParam
                        {
                            TypeName = "BrickDebris",
                            Location = new int[] { (int)Location.X + offsets[i, 0], (int)Location.Y + offsets[i, 1] },
                            Motion = MotionEnum.Dynamic,
                            Params = new Dictionary<string, string> { { "Position", positions[i] } },
                        }.ToGameObject();
                        (debris as GameObjectRigidBody).RigidBody.Velocity = velocities[i];
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(debris));
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(debris), 500f);
                    }
                }
            }
        }
    }
}
