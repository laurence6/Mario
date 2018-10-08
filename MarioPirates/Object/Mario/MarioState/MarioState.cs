namespace MarioPirates
{
    internal class MarioState
    {
        private Mario mario;
        private MarioStateInvincible invincible;
        private MarioStateDirection direction;
        public MarioStateSize Size { get; set; }
        public MarioStateAction Action { get; set; }

        public MarioState(Mario mario)
        {
            this.mario = mario;
            invincible = new MarioStateInvincible(false);
            direction = new MarioStateDirection(false);
            Size = new MarioStateSmall(mario);
            Action = new MarioStateIdle(this);

            UpdateSprite();
        }

        private void UpdateSprite()
        {
            var s = Size.GetEnum().ToString().ToLower();
            if (!IsDead)
                s += "_" + Action.GetEnum().ToString().ToLower() + "_" + direction.GetEnum().ToString().ToLower();
            if (IsInvincible)
                s += "_star";
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
            UpdateSprite();
        }

        public void Run()
        {
            Action.Run();
            UpdateSprite();
        }

        public void Jump()
        {
            Action.Jump();
            UpdateSprite();
        }

        public void Crouch()
        {
            Action.Crouch();
            UpdateSprite();
        }

        public void Small()
        {
            Size.Small();
            UpdateSprite();
        }

        public void Big()
        {
            Size.Big();
            UpdateSprite();
        }

        public void Fire()
        {
            Size.Fire();
            if (IsInvincible)
                Size.Big();
            UpdateSprite();
        }

        public void Dead()
        {
            Size.Dead();
            UpdateSprite();
            mario.RigidBody.CollideLayerMask = 0b10;
        }

        public void Invincible()
        {
            invincible.SetInvincible(true);
            if (Size.GetEnum() == MarioStateEnum.Fire)
                Size.Big();
            UpdateSprite();
        }

        public void CancelInvincible()
        {
            invincible.SetInvincible(false);
            UpdateSprite();
        }

        public bool IsInvincible => invincible.IsInvincible;

        public bool IsDead => Size.IsDead();

        public bool IsJump => Action.GetEnum() == MarioStateEnum.Jump;

        public bool IsCrouch => Action.GetEnum() == MarioStateEnum.Crouch;

        public bool IsSmall => Size.GetEnum() == MarioStateEnum.Small;
    }
}
