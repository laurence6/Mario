namespace MarioPirates
{
    internal class QuestionBlock : Block
    {
        public QuestionBlock(int dstX, int dstY, string state) : base(dstX, dstY, state)
        {
            normalStateSprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }
    }
}
