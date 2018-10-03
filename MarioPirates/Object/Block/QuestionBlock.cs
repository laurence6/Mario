namespace MarioPirates
{
    internal class QuestionBlock : Block
    {
        public QuestionBlock(int dstX, int dstY) : base(dstX, dstY)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }
    }
}
