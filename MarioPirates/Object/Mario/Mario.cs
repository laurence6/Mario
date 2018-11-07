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

        public readonly MarioState State;

        private Action unsubscribe;

        private int JumpHoldCount;

        public int TransitionToBigCount { get; set; }

        public int TransitionToSmallCount { get; set; }

        private Vector2 StoredToBigLocation;
        private Vector2 StoredToSmallLocation;

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            this.Sprites = new Dictionary<string, Sprite>();
            new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText("Content\\MarioSpritesList.json"))
                 .ForEach(s => this.Sprites.Add(s, SpriteFactory.Ins.CreateSprite(s)));

            this.RigidBody.CoR = Constants.MARIO_CO_R;

            this.State = new MarioState(this);

            this.SubscribeInput();

            this.JumpHoldCount = 0;
            this.TransitionToBigCount = Constants.MARIO_TRANSITION_COUNT_MAX;
            this.TransitionToSmallCount = Constants.MARIO_TRANSITION_COUNT_MAX;
        }

        public void SubscribeInput()
        {
            this.SubscribeInputMoving();
            this.SubscribeInputTransition();
            this.SubscribeInputX();
        }

        public void UnsubscribeInput()
        {
            this.unsubscribe();
            this.unsubscribe = null;
        }

        private void SubscribeInputMoving()
        {
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpHold, (s, e) =>
            {
                if (this.JumpHoldCount < Constants.MARIO_JUMP_HOLD_COUNT_LIMIT)
                {
                    this.RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + this.JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    this.JumpHoldCount += 1;
                }
            });
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpDown, (s, e) =>
            {
                if (this.RigidBody.Grounded)
                {
                    this.RigidBody.ApplyForce(new Vector2(0, Constants.MARIO_JUMP_FORCE_Y + this.JumpHoldCount * Constants.MARIO_JUMP_HOLD_COUNT_MULTIPLIER));
                    this.JumpHoldCount = 1;
                }
            });
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDownHold, (s, e) =>
            {
                this.State.Crouch();
            });
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, (s, e) =>
            {
                if (!this.State.IsCrouch)
                {
                    this.RigidBody.ApplyForce(new Vector2(-Constants.MARIO_RUN_FORCE_X * this.State.VelocityMultipler, 0));
                }
            });
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, (s, e) =>
            {
                if (!this.State.IsCrouch)
                {
                    this.RigidBody.ApplyForce(new Vector2(Constants.MARIO_RUN_FORCE_X * this.State.VelocityMultipler, 0));
                }
            });

            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightHold, (s, e) => this.State.Right());
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftHold, (s, e) => this.State.Left());

            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyRightDown, (s, e) =>
            {
                if (this.RigidBody.Velocity.X < -0)
                {
                    this.State.Brake();
                }
                else
                {
                    this.State.Coast();
                }
            });
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyLeftDown, (s, e) =>
            {
                if (this.RigidBody.Velocity.X > 0)
                {
                    this.State.Brake();
                }
                else
                {
                    this.State.Coast();
                }
            });

            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyUpUp, (s, e) => this.JumpHoldCount = Constants.MARIO_JUMP_HOLD_COUNT_LIMIT);
        }

        private void SubscribeInputTransition()
        {
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyDown, (s, e) =>
            {
                switch ((e as KeyDownEventArgs).key)
                {
                    case Keys.Y:
                        if (!this.State.IsSmall)
                            this.TransitionToSmallCount = 0;
                        this.State.Small();
                        break;
                    case Keys.U:
                        if (this.State.IsSmall)
                            this.TransitionToBigCount = 0;
                        this.State.Big();
                        break;
                    case Keys.I:
                        if (this.State.IsSmall)
                            this.TransitionToBigCount = 0;
                        this.State.Fire();
                        break;
                    case Keys.O:
                        this.State.Dead();
                        break;
                    case Keys.P:
                        this.State.Invincible();
                        break;
                }
            });
        }

        private void SubscribeInputX()
        {
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXDown, (s, e) => this.State.Accelerated());
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXUp, (s, e) => this.State.CancelAccelerated());
            this.unsubscribe += EventManager.Ins.Subscribe(EventEnum.KeyXDown, (s, e) =>
            {
                if (this.State.IsFire)
                {
                    var fireball = new Fireball((int)this.Location.X + (this.State.IsLeft ? -Constants.FIREBALL_WIDTH : Constants.FIREBALL_WIDTH + this.Size.X), (int)this.Location.Y + Constants.FIREBALL_HEIGHT); //16, 16, 16
                    fireball.RigidBody.Velocity = new Vector2(this.State.IsLeft ? -Constants.FIREBALL_COLLISION_VELOCITY.X : Constants.FIREBALL_COLLISION_VELOCITY.X, 0f);
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, this, new GameObjectCreateEventArgs(fireball));
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(fireball), Constants.FIRE_MARIO_FIREBALL_EVENT_DT);
                }
            });
        }

        public override void Update(float dt)
        {
            if (this.RigidBody.Velocity.Y != 0f)
                this.State.Jump();
            else if (this.RigidBody.Velocity.X != 0f)
                this.State.Run();
            else
                this.State.Idle();
            if (this.RigidBody.Velocity.X < Constants.MARIO_TRANSITION_COUNT_MAX && this.RigidBody.Velocity.X > -Constants.MARIO_TRANSITION_COUNT_MAX)
                this.State.Coast();

            if (this.TransitionToBigCount < Constants.MARIO_TRANSITION_COUNT_MAX)
            {
                if (this.TransitionToBigCount % Constants.MARIO_TRANSITION_COUNT == 0)
                {
                    this.StoredToBigLocation = new Vector2(this.Location.X, this.Location.Y + this.Size.Y);
                    var targetHeight = (int)(Constants.BIG_MARIO_HEIGHT / Constants.MARIO_TRANSITION_ZOOM[this.TransitionToBigCount / Constants.MARIO_TRANSITION_COUNT]);
                    this.Location = new Vector2(this.StoredToBigLocation.X, this.StoredToBigLocation.Y - targetHeight);
                    this.Size = new Point(Constants.BIG_MARIO_WIDTH, targetHeight);
                }
                this.TransitionToBigCount++;
            }

            if (this.TransitionToSmallCount < Constants.MARIO_TRANSITION_COUNT_MAX)
            {
                if (this.TransitionToSmallCount % Constants.MARIO_TRANSITION_COUNT == 0)
                {
                    this.StoredToSmallLocation = new Vector2(this.Location.X, this.Location.Y + this.Size.Y);
                    var targetHeight = (int)(Constants.SMALL_MARIO_HEIGHT * Constants.MARIO_TRANSITION_ZOOM[this.TransitionToSmallCount / Constants.MARIO_TRANSITION_COUNT]);
                    this.Location = new Vector2(this.StoredToSmallLocation.X, this.StoredToSmallLocation.Y - targetHeight);
                    this.Size = new Point(Constants.SMALL_MARIO_WIDTH, targetHeight);
                }

                this.TransitionToSmallCount++;
            }

            Camera.Ins.LookAt(this.Location);

            base.Update(dt);
        }

        public void Dispose()
        {
            this.UnsubscribeInput();
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, this, new KeyDownEventArgs(Keys.R), Constants.MARIO_DISPOSE_EVENT_DT);
        }
    }
}
