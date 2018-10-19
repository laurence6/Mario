using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    using Event;

    internal class Mario : GameObjectRigidBody
    {
        public readonly Dictionary<string, Sprite> Sprites;

        public readonly MarioState State;

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            Sprites = new Dictionary<string, Sprite>();
            new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText("Content\\MarioSpritesList.json"))
                 .ForEach(s => Sprites.Add(s, SpriteFactory.CreateSprite(s)));

            RigidBody.CoR = 0.5f;

            State = new MarioState(this);

            SubscribeInputMoving();
            SubscribeInputTransition();
        }

        private void SubscribeInputMoving()
        {
            EventManager.Subscribe(EventEnum.KeyUpHold, (s, e) =>
            {
                if (!State.IsDead)
                {
                    State.Jump();
                    RigidBody.ApplyForce(new Vector2(0, -2000));
                }
            });
            EventManager.Subscribe(EventEnum.KeyDownHold, (s, e) =>
            {
                if (!State.IsDead)
                {
                    State.Crouch();
                    RigidBody.ApplyForce(new Vector2(0, 2000));
                }
            });
            EventManager.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
            {
                if (!State.IsDead)
                {
                    State.Left();
                    RigidBody.ApplyForce(new Vector2(-2000, 0));
                }
            });
            EventManager.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (!State.IsDead)
                {
                    State.Right();
                    RigidBody.ApplyForce(new Vector2(2000, 0));
                }
            });

            EventManager.Subscribe(EventEnum.KeyUpUp, (s, e) => State.Idle());
            EventManager.Subscribe(EventEnum.KeyDownUp, (s, e) => State.Idle());
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
            if (RigidBody.Velocity.X == 0f)
                State.Idle();
            else
                State.Run();
            base.Update(dt);
        }

        public override void OnCollide(GameObjectRigidBody other, CollisionSide side)
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
            else if (other is Pipe && side == CollisionSide.Bottom)
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
                if (!(side == CollisionSide.Bottom || State.IsInvincible))
                {
                    if (State.IsSmall)
                        State.Dead();
                    else
                        State.Small();
                }
            }

            base.OnCollide(other, side);
        }
    }
}
