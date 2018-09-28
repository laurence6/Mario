namespace MarioPirates
{
    internal class QuestionBlock : BlockState
    {
        public QuestionBlock(Block block) : base(block)
        {
            block.Sprite = SpriteFactory.CreateSprite("questionblock");
        }

        public override void ChangeToQuestionBlock()
        {
        }
    }
}
