using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDead : MarioStateSize
    {
        protected const int marioWidth = 30, marioHeight = 28;

        public MarioStateDead(Mario mario) : base(mario)
        {
            mario.Size = new Point(marioWidth, marioHeight);
            mario.Sprite = SpriteFactory.CreateSprite("dead");
        }

        public override void Dead()
        {
        }

        public override bool IsDead => true;

        public override MarioStateEnum State => MarioStateEnum.Dead;
    }
}
