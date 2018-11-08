using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Mario : GameObjectRigidBody, IDisposable
    {
        public readonly Dictionary<string, Sprite> Sprites;

        public MarioState State;

        private Action unsubscribe;

        private int JumpHoldCount;

        public int TransitionToBigCount { get; set; }

        public int TransitionToSmallCount { get; set; }

        private Vector2 StoredToBigLocation;
        private Vector2 StoredToSmallLocation;

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            Sprites = new Dictionary<string, Sprite>();
            new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText(Constants.CONTENT_PATH_ROOT + Constants.MARIO_SPRITES_LIST_FILE))
                 .ForEach(s => Sprites.Add(s, SpriteFactory.Ins.CreateSprite(s)));

            RigidBody.CoR = Constants.MARIO_CO_R;

            Reset();

            SubscribeInput();
        }

        public void Reset()
        {
            RigidBody.CollisionLayerMask = CollisionLayer.All;
            RigidBody.Velocity = Vector2.Zero;
            JumpHoldCount = 0;
            TransitionToBigCount = Constants.MARIO_TRANSITION_COUNT_MAX;
            TransitionToSmallCount = Constants.MARIO_TRANSITION_COUNT_MAX;
            State = new MarioState(this);
        }

        public void SubscribeInput()
        {
            SubscribeInputMoving();
            SubscribeInputTransition();
            SubscribeInputX();
        }

        public void UnsubscribeInput()
        {
            unsubscribe();
            unsubscribe = null;
        }

        private void SubscribeInputMoving()
        {
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpHold, (s, e) =>
            {
                if (JumpHoldCount < Constants.MARIO_JUMP_HOLD_COUNT_LIMIT)
                {
                    RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    JumpHoldCount += 1;
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpDown, (s, e) =>
            {
                if (RigidBody.Grounded)
                {
                    RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    JumpHoldCount = 1;
                    AudioManager.Ins.SmallMarioJump();
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDownHold, (s, e) =>
            {
                State.Crouch();
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
            {
                if (!State.IsCrouch)
                {
                    RigidBody.ApplyForce(new Vector2(-Constants.MARIO_RUN_FORCE_X * State.VelocityMultipler, 0));
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (!State.IsCrouch)
                {
                    RigidBody.ApplyForce(new Vector2(Constants.MARIO_RUN_FORCE_X * State.VelocityMultipler, 0));
                }
            });

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, (s, e) => State.Right());
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, (s, e) => State.Left());

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (RigidBody.Velocity.X < -0)
                {
                    State.Brake();
                }
                else
                {
                    State.Coast();
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
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

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpUp, (s, e) => JumpHoldCount = Constants.MARIO_JUMP_HOLD_COUNT_LIMIT);
        }

        private void SubscribeInputTransition()
        {
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                switch ((e as KeyDownEventArgs).key)
                {
                    case Keys.Y:
                        if (!State.IsSmall)
                            TransitionToSmallCount = 0;
                        State.Small();
                        break;
                    case Keys.U:
                        if (State.IsSmall)
                            TransitionToBigCount = 0;
                        State.Big();
                        break;
                    case Keys.I:
                        if (State.IsSmall)
                            TransitionToBigCount = 0;
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

        private void SubscribeInputX()
        {
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXDown, (s, e) => State.Accelerated());
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXUp, (s, e) => State.CancelAccelerated());
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXDown, (s, e) =>
            {
                if (State.IsFire)
                {
                    var fireball = new Fireball((int)Location.X + (State.IsLeft ? -Constants.FIREBALL_WIDTH : Constants.FIREBALL_WIDTH + Size.X), (int)Location.Y + Constants.FIREBALL_HEIGHT); //16, 16, 16
                    fireball.RigidBody.Velocity = new Vector2(State.IsLeft ? -Constants.FIREBALL_COLLISION_VELOCITY.X : Constants.FIREBALL_COLLISION_VELOCITY.X, 0f);
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(fireball));
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(fireball), Constants.FIRE_MARIO_FIREBALL_EVENT_DT);
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
            if (RigidBody.Velocity.X < Constants.MARIO_TRANSITION_COUNT_MAX && RigidBody.Velocity.X > -Constants.MARIO_TRANSITION_COUNT_MAX)
                State.Coast();

            if (TransitionToBigCount < Constants.MARIO_TRANSITION_COUNT_MAX)
            {
                if (TransitionToBigCount % Constants.MARIO_TRANSITION_COUNT == 0)
                {
                    StoredToBigLocation = new Vector2(Location.X, Location.Y + Size.Y);
                    var targetHeight = (int)(Constants.BIG_MARIO_HEIGHT / Constants.MARIO_TRANSITION_ZOOM[TransitionToBigCount / Constants.MARIO_TRANSITION_COUNT]);
                    Location = new Vector2(StoredToBigLocation.X, StoredToBigLocation.Y - targetHeight);
                    Size = new Point(Constants.BIG_MARIO_WIDTH, targetHeight);
                }
                TransitionToBigCount++;
            }

            if (TransitionToSmallCount < Constants.MARIO_TRANSITION_COUNT_MAX)
            {
                if (TransitionToSmallCount % Constants.MARIO_TRANSITION_COUNT == 0)
                {
                    StoredToSmallLocation = new Vector2(Location.X, Location.Y + Size.Y);
                    var targetHeight = (int)(Constants.SMALL_MARIO_HEIGHT * Constants.MARIO_TRANSITION_ZOOM[TransitionToSmallCount / Constants.MARIO_TRANSITION_COUNT]);
                    Location = new Vector2(StoredToSmallLocation.X, StoredToSmallLocation.Y - targetHeight);
                    Size = new Point(Constants.SMALL_MARIO_WIDTH, targetHeight);
                }

                TransitionToSmallCount++;
            }

            Camera.Ins.LookAt(Location);

            base.Update(dt);
        }

        public void Dispose()
        {
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, this, new KeyDownEventArgs(Keys.R), Constants.RESET_EVENT_DT);
        }
    }
}
