namespace MarioPirates
{
    internal class MarioState
    {
        private Mario mario;
        private MarioStateStar star;
        private MarioStateDirection direction;
        public MarioStateSize Size { get; set; }
        public MarioStateAction Action { get; set; }

        public MarioState(Mario mario)
        {
            this.mario = mario;
            star = new MarioStateStar(false);
            direction = new MarioStateDirection(false);
            Size = new MarioStateSmall(mario);
            Action = new MarioStateIdle(this);

            ApplySprite();
        }

        private void ApplySprite()
        {
            var s = "";
            if (IsInvincible())
                s += "star_";
            if (IsDead())
                s += Size.GetString();
            else
                s += Size.GetString() + "_" + Action.GetString() + "_" + direction.GetString();
            mario.Sprite = mario.Sprites[s];
        }

        public void Left()
        {
            direction.Left();
            ApplySprite();
        }

        public void Right()
        {
            direction.Right();
            ApplySprite();
        }

        public void Idle()
        {
            Action.Idle();
            ApplySprite();
        }

        public void Run()
        {
            Action.Run();
            ApplySprite();
        }

        public void Jump()
        {
            Action.Jump();
            ApplySprite();
        }

        public void Crouch()
        {
            Action.Crouch();
            ApplySprite();
        }

        public void Small()
        {
            Size.Small();
            ApplySprite();
        }

        public void Big()
        {
            Size.Big();
            ApplySprite();
        }

        public void Fire()
        {
            Size.Fire();
            if (IsInvincible())
                Size.Big();
            ApplySprite();
        }

        public void Dead()
        {
            Size.Dead();
            ApplySprite();
        }

        public void Star()
        {
            star.Star();
            if (Size.GetString().Equals("fire"))
                Size.Big();
            ApplySprite();
        }

        public void Unstar()
        {
            star.Unstar();
            ApplySprite();
        }

        public bool IsInvincible()
        {
            return star.IsInvincible();
        }

        public bool IsDead()
        {
            return Size.IsDead();
        }

        public bool IsJump()
        {
            return Action.GetString().Equals("jump");
        }

        public bool IsCrouch()
        {
            return Action.GetString().Equals("crouch");
        }
    }
}
