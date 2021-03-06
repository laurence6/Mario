﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Mario : GameObjectRigidBody, IDisposable
    {
        public readonly Dictionary<string, ISprite> Sprites;

        public MarioState State;

        private Action unsubscribe;

        public bool AllowJumpInAir { get; set; }

        private int JumpHoldCount;

        public int TransitionToBigCount { get; set; }

        public int TransitionToSmallCount { get; set; }

        private Vector2 StoredToBigLocation;
        private Vector2 StoredToSmallLocation;

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            Sprites = new Dictionary<string, ISprite>();
            new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText(Constants.DATA_FILES_PATH + Constants.MARIO_SPRITES_DATA_FILE))
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
            State.CancelAccelerated();
        }

        private void SubscribeInputMoving()
        {
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpHold, () =>
            {
                if (AllowJumpInAir)
                {
                    RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y));
                }
                else if (JumpHoldCount < Constants.MARIO_JUMP_HOLD_COUNT_LIMIT)
                {
                    RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    JumpHoldCount += 1;
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpDown, () =>
            {
                if (AllowJumpInAir || RigidBody.Grounded)
                {
                    RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    JumpHoldCount = 1;
                    AudioManager.Ins.SmallMarioJump();
                }
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDownHold, () =>
            {
                State.TurnCrouch();
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, () =>
            {
                if (!State.IsCrouch)
                    RigidBody.ApplyForce(new Vector2(-Constants.MARIO_RUN_FORCE_X * State.VelocityMultipler, 0));
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, () =>
            {
                if (!State.IsCrouch)
                    RigidBody.ApplyForce(new Vector2(Constants.MARIO_RUN_FORCE_X * State.VelocityMultipler, 0));
            });

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, () => State.TurnRight());
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, () => State.TurnLeft());

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, () =>
            {
                if (RigidBody.Velocity.X < -0)
                    State.Brake();
                else
                    State.Coast();
            });
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, () =>
            {
                if (RigidBody.Velocity.X > 0)
                    State.Brake();
                else
                    State.Coast();
            });

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpUp, () => JumpHoldCount = Constants.MARIO_JUMP_HOLD_COUNT_LIMIT);
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
                        State.TurnSmall();
                        break;
                    case Keys.U:
                        if (State.IsSmall)
                            TransitionToBigCount = 0;
                        State.TurnBig();
                        break;
                    case Keys.I:
                        if (State.IsSmall)
                            TransitionToBigCount = 0;
                        State.TurnFire();
                        break;
                    case Keys.O:
                        State.TurnDead();
                        break;
                    case Keys.P:
                        State.TurnInvincible();
                        break;
                }
            });
        }

        private void SubscribeInputX()
        {
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) => ((e as KeyDownEventArgs).key is Keys.X).Then(() => State.Accelerated()));
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUp, (s, e) => ((e as KeyUpEventArgs).key is Keys.X).Then(() => State.CancelAccelerated()));
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                if ((e as KeyDownEventArgs).key is Keys.X && State.IsFire)
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
            if (Timer.Ins.Value <= 0)
                State.TurnDead();

            if (RigidBody.Velocity.Y != 0f)
                State.TurnJump();
            else if (RigidBody.Velocity.X != 0f)
                State.TurnRun();
            else
                State.TurnIdle();
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
