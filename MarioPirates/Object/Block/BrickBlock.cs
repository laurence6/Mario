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
                        Location = new int[2] { (int)Location.X, (int)Location.Y - Constants.BLOCK_HEIGHT * 2 }, // 32
                        Motion = MotionEnum.Dynamic,
                    }.ToGameObject();
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(powerupObj));
                    if (powerup == "Coin")
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(powerupObj), Constants.DESTROY_COIN_DELAY); //500
                    }
                    powerup = null;
                }
                else if (State == BlockState.Normal && !(mario.State.IsSmall || mario.State.IsDead))
                {
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));

                    var positions = new string[4] { "upperleft", "upperright", "lowerleft", "lowerright" };
                    var offsets = new int[4, 2] { { 0, 0 }, { Constants.BRICK_DEBRIS_WIDTH, 0 }, { 0, Constants.BRICK_DEBRIS_HEIGHT }, { Constants.BRICK_DEBRIS_WIDTH, Constants.BRICK_DEBRIS_HEIGHT } };
                    var velocities = new Vector2[] { new Vector2(-Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY, -2f * Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY),
                        new Vector2(Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY, -2f * Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY),
                        new Vector2(-Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY, 0f), new Vector2(Constants.BRICK_BLOCK_MARIO_COLLISION_VELOCITY, 0f) }; // -100, -200, 100, -200, -100, 100
                    for (var i = 0; i < positions.Length; i++)
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
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(debris), Constants.DESTORY_DEBRIS_DELAY); //500
                    }
                }
            }
        }
    }
}
