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

        public void TurnLeft()
        {
            direction.Left();
            UpdateSprite();
        }

        public void TurnRight()
        {
            direction.Right();
            UpdateSprite();
        }

        public void TurnIdle()
        {
            Action.TurnIdle();
        }

        public void TurnRun()
        {
            Action.TurnRun();
        }

        public void TurnJump()
        {
            Action.TurnJump();
        }

        public void TurnCrouch()
        {
            Action.TurnCrouch();
        }

        public void TurnSmall()
        {
            Size.TurnSmall();
        }

        public void TurnBig()
        {
            Size.TurnBig();
        }

        public void TurnFire()
        {
            if (IsInvincible)
                Size.TurnBig();
            else
                Size.TurnFire();
        }

        public void TurnDead()
        {
            mario.Dispose();
            Size.TurnDead();
        }

        public void TurnInvincible()
        {
            invincible.SetInvincible(true);
            EventManager.Ins.RaiseEvent(EventEnum.Action, this, new ActionEventArgs(CancelInvincible), Constants.MARIO_STAR_COLLISION_EVENT_DT);
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

        public void Accelerated() => accelerated.IsAccelerated = true;

        public void CancelAccelerated() => accelerated.IsAccelerated = false;

        public void Transiting() => transiting.IsTransiting = true;

        public void CancelTransiting() => transiting.IsTransiting = false;

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
