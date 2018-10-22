using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Mario : GameObjectRigidBody
    {
        private const int JumpHoldCountLimit = 20;

        public readonly Dictionary<string, Sprite> Sprites;

        public readonly MarioState State;

        private int JumpHoldCount;

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            Sprites = new Dictionary<string, Sprite>();
            new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText("Content\\MarioSpritesList.json"))
                 .ForEach(s => Sprites.Add(s, SpriteFactory.CreateSprite(s)));

            RigidBody.CoR = 0.5f;

            State = new MarioState(this);

            SubscribeInputMoving();
            SubscribeInputTransition();

            JumpHoldCount = 0;
        }

        private void SubscribeInputMoving()
        {
            EventManager.Subscribe(EventEnum.KeyUpHold, (s, e) =>
            {
                if (!State.IsDead && JumpHoldCount < JumpHoldCountLimit)
                {
                    RigidBody.ApplyForce(new Vector2(0, -2500 + JumpHoldCount * 50));
                    JumpHoldCount += 1;
                }
            });
            EventManager.Subscribe(EventEnum.KeyUpDown, (s, e) =>
            {
                if (!State.IsDead && JumpHoldCount < JumpHoldCountLimit)
                {
                    RigidBody.ApplyForce(new Vector2(0, -2500 + JumpHoldCount * 50));
                    JumpHoldCount += 1;
                }
            });
            EventManager.Subscribe(EventEnum.KeyDownHold, (s, e) =>
            {
                if (!State.IsDead)
                {
                    State.Crouch();
                }
            });
            EventManager.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
            {
                if (!State.IsDead && !State.IsCrouch)
                {
                    RigidBody.ApplyForce(new Vector2(-2000, 0));
                }
            });
            EventManager.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (!State.IsDead && !State.IsCrouch)
                {
                    RigidBody.ApplyForce(new Vector2(2000, 0));
                }
            });

            EventManager.Subscribe(EventEnum.KeyRightHold, (s, e) => State.Right());
            EventManager.Subscribe(EventEnum.KeyLeftHold, (s, e) => State.Left());

            EventManager.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (RigidBody.Velocity.X < 0)
                {
                    State.Brake();
                }
                else
                {
                    State.Coast();
                }
            });
            EventManager.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
            {
                if (RigidBody.Velocity.X > 0)
                {
                    State.Brake();
                }
                else
                {
                    State.Coast();
                }
            });

            EventManager.Subscribe(EventEnum.KeyUpUp, (s, e) => JumpHoldCount = JumpHoldCountLimit);

            EventManager.Subscribe(EventEnum.KeyUpDown, (s, e) =>
            {
                if (RigidBody.Grounded)
                {
                    JumpHoldCount = 0;
                }
            });
        }

        private void SubscribeInputTransition()
        {
            EventManager.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                switch ((e as KeyDownEventArgs).key)
                {
                    case Keys.Y:
                        State.Small();
                        break;
                    case Keys.U:
                        State.Big();
                        break;
                    case Keys.I:
                        State.Fire();
                        break;
                    case Keys.O:
                        State.Dead();
                        break;
                    case Keys.P:
                        State.Invincible();
                        break;
                }
            });
        }

        public override void Update(float dt)
        {
            if (RigidBody.Velocity.Y != 0f)
                State.Jump();
            else if (RigidBody.Velocity.X != 0f)
                State.Run();
            else
                State.Idle();

            base.Update(dt);
        }

        public override void PostCollide(GameObjectRigidBody other, CollisionSide side)
        {
            // Response to collision with items.
            if (other is Coin)
            {
                // Score up
            }
            else if (other is Flower)
            {
                State.Fire();
            }
            else if (other is GreenMushroom)
            {
                // Life up
            }
            else if (other is PipeTop && side == CollisionSide.Bottom)
            {
                // Get in the pipe
            }
            else if (other is RedMushroom)
            {
                State.Big();
            }
            else if (other is Star)
            {
                State.Invincible();
            }

            // Response to collsion with enemies
            if (other is Goomba || other is Koopa)
            {
                if (side != CollisionSide.Bottom && !State.IsInvincible)
                {
                    if (State.IsSmall)
                    {
                        RigidBody.Velocity = new Vector2(0f, -200f);
                        State.Dead();
                        EventManager.RaiseEvent(EventEnum.KeyDown, this, new KeyDownEventArgs(Keys.R), 5000f);
                    }
                    else
                    {
                        State.Small();
                    }
                }
                else
                {
                    RigidBody.Velocity = new Vector2(0f, -200f);
                }
            }

            base.PostCollide(other, side);
        }
    }
}
