﻿using Microsoft.Xna.Framework;
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

            State = new MarioState(this);

            RigidBody.Mass = 1f;
            RigidBody.ApplyForce(WorldForce.Friction);

            SubscribeInputMoving();
            SubscribeInputTransition();
        }

        private void SubscribeInputMoving()
        {
            EventManager.Subscribe(e =>
            {
                if (!State.IsDead)
                {
                    State.Jump();
                    RigidBody.ApplyForce(new Vector2(0, -2000));
                }
            }, EventEnum.KeyUpHold);
            EventManager.Subscribe(e =>
            {
                if (!State.IsDead)
                {
                    State.Crouch();
                    RigidBody.ApplyForce(new Vector2(0, 2000));
                }
            }, EventEnum.KeyDownHold);
            EventManager.Subscribe(e =>
            {
                if (!State.IsDead)
                {
                    State.Left();
                    RigidBody.ApplyForce(new Vector2(-2000, 0));
                }
            }, EventEnum.KeyLeftHold);
            EventManager.Subscribe(e =>
            {
                if (!State.IsDead)
                {
                    State.Right();
                    RigidBody.ApplyForce(new Vector2(2000, 0));
                }
            }, EventEnum.KeyRightHold);

            EventManager.Subscribe(e => State.Idle(), EventEnum.KeyUpUp, EventEnum.KeyDownUp);
        }

        private void SubscribeInputTransition()
        {
            EventManager.Subscribe(e =>
            {
                switch ((e as KeyDownEvent).key)
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
            }, EventEnum.KeyDown);
        }

        public override void Update(float dt)
        {
            if (RigidBody.Velocity.X == 0f)
                State.Idle();
            else
                State.Run();
            base.Update(dt);
        }

        public override void OnCollide(GameObject obj, CollisionSide side)
        {
            // Response to collision with items.
            if (obj is Coin)
            {
                // Score up
            }
            else if (obj is Flower)
            {
                State.Fire();
            }
            else if (obj is GreenMushroom)
            {
                // Life up
            }
            else if (obj is Pipe && side == CollisionSide.Bottom)
            {
                // Get in the pipe
            }
            else if (obj is RedMushroom)
            {
                State.Big();
            }
            else if (obj is Star)
            {
                State.Invincible();
            }

            // Response to collsion with enemies
            if (obj is Goomba || obj is Koopa)
            {
                if (!(side == CollisionSide.Bottom || State.IsInvincible))
                {
                    if (State.IsSmall)
                    {
                        State.Dead();
                    }
                    else
                    {
                        State.Small();
                    }
                }
            }
        }
    }
}
