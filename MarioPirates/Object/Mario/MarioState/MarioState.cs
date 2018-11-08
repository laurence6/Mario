namespace MarioPirates
{
    internal class MarioState
    {
        public readonly Mario mario;
        private MarioStateInvincible invincible;
        private MarioStateDirection direction;
        private MarioStateBrake brake;
        private MarioStateAccelerated accelerated;
        private MarioStateTransiting transiting;
        private MarioStateSize size;
        private MarioStateAction action;

        public MarioStateSize Size { get => size; set { size = value; UpdateSprite(); } }
        public MarioStateAction Action { get => action; set { action = value; UpdateSprite(); } }

        public MarioState(Mario mario)
        {
            this.mario = mario;
            invincible = new MarioStateInvincible();
            direction = new MarioStateDirection();
            brake = new MarioStateBrake();
            accelerated = new MarioStateAccelerated();
            transiting = new MarioStateTransiting();
            size = new MarioStateSmall(this);
            action = new MarioStateIdle(this);

            UpdateSprite();
        }

        private void UpdateSprite()
        {
            var s = Size.State.ToString().ToLower();
            if (!IsDead)
                s += Constants.MARIO_STATE_EXTEND + Action.State.ToString().ToLower() + Constants.MARIO_STATE_EXTEND + direction.State.ToString().ToLower();
            if (IsInvincible)
            {
                s += Constants.STAR_MARIO_SUFFIX;
                if (Size.State is MarioStateEnum.Fire)
                    s = MarioStateEnum.Big.ToString().ToLower() + s.Substring(4);
            }
            if (action.State is MarioStateEnum.Run && brake.State is MarioStateEnum.Brake)
                s += Constants.MARIO_BRAKE_SUFFIX;
            mario.Sprite = mario.Sprites[s];
        }

        public void Left()
        {
            direction.Left();
            UpdateSprite();
        }

        public void Right()
        {
            direction.Right();
            UpdateSprite();
        }

        public void Idle()
        {
            Action.Idle();
        }

        public void Run()
        {
            Action.Run();
        }

        public void Jump()
        {
            Action.Jump();
        }

        public void Crouch()
        {
            Action.Crouch();
        }

        public void Small()
        {
            Size.Small();
        }

        public void Big()
        {
            Size.Big();
        }

        public void Fire()
        {
            if (IsInvincible)
                Size.Big();
            else
                Size.Fire();
        }

        public void Dead()
        {
            mario.Dispose();
            Size.Dead();
        }

        public void Invincible()
        {
            invincible.SetInvincible(true);
            UpdateSprite();
        }

        public void CancelInvincible()
        {
            invincible.SetInvincible(false);
            UpdateSprite();
        }

        public void Brake()
        {
            brake.Brake();
            UpdateSprite();
        }

        public void Coast()
        {
            brake.Coast();
            UpdateSprite();
        }

        public void Accelerated()
        {
            accelerated.SetAccelerated(true);
        }

        public void CancelAccelerated()
        {
            accelerated.SetAccelerated(false);
        }

        public void Transiting()
        {
            transiting.SetTransiting(true);
        }

        public void CancelTransiting()
        {
            transiting.SetTransiting(false);
        }

        public bool IsInvincible => invincible.IsInvincible;

        public bool IsTransiting => transiting.IsTransiting;

        public bool IsDead => Size.IsDead;

        public bool IsCrouch => Action.State is MarioStateEnum.Crouch;

        public bool IsSmall => Size.State is MarioStateEnum.Small;

        public bool IsFire => Size.State is MarioStateEnum.Fire;

        public bool IsLeft => direction.State is MarioStateEnum.Left;

        public float VelocityMultipler => accelerated.VelocityMultiplier;
    }
}
