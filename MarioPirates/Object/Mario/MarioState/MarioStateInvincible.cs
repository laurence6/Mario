namespace MarioPirates
{
    internal class MarioStateInvincible
    {
        public bool IsInvincible { get; private set; }

        public MarioStateInvincible(bool isInvincible = false)
        {
            IsInvincible = isInvincible;
        }

        public void SetInvincible(bool inInvincible)
        {
            IsInvincible = inInvincible;
        }

        public MarioStateEnum GetEnum()
        {
            if (IsInvincible)
            {
                return MarioStateEnum.Invincible;
            }
            else
            {
                return MarioStateEnum.Vincible;
            }
        }
    }
}
