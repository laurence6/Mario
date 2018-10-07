using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateStar
    {
        private bool star;

        public MarioStateStar(bool isStar = false)
        {
            star = isStar;
        }

        public void Star()
        {
            star = true;
        }

        public void Unstar()
        {
            star = false;
        }

        public bool IsInvincible()
        {
            return star;
        }
    }
}
