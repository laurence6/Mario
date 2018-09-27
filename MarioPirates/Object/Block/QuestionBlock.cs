namespace MarioPirates
{
    internal class QuestionBlock : BlockState
    {
        public QuestionBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }

        public override void ChangeToQuestionBlock()
        {
        }
    }
}
