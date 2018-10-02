namespace MarioPirates
{
    internal abstract class MarioState
    {
        protected Mario mario;

        protected MarioState(Mario mario)
        {
            this.mario = mario;
        }

        public abstract void Left();

        public abstract void Right();

        public abstract void Jump();

        public abstract void Crouch();

        public abstract void Small();

        public abstract void Big();

        public abstract void Fire();

        public abstract void Star();

        public abstract void Dead();
    }
}
