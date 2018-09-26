namespace MarioPirates
{
    public class QuestionBlock : BlockState
    {
        public QuestionBlock(Block block) : base(block)
        {
            block.sprite = SpriteFactory.Instance.CreateSprite("questionblock");
        }

        public override void ChangeToQuestionBlock()
        {
        }
    }

}
