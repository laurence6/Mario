namespace MarioPirates
{
    internal class MarioStateInvincible
    {
        public bool IsInvincible { get; private set; }

        public MarioStateInvincible(bool isInvincible = false)
        {
            IsInvincible = isInvincible;
        }

        public void SetInvincible(bool isInvincible)
        {
            IsInvincible = isInvincible;
        }

        public MarioStateEnum State => IsInvincible ? MarioStateEnum.Invincible : MarioStateEnum.Vincible;
    }
}
