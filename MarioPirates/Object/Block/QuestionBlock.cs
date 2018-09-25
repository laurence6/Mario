using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
