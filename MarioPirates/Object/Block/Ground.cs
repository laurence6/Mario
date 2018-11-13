using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class Ground : GameObjectRigidBody
    {
        private List<Block> blocks = new List<Block>();

        public Ground(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, 0, 0)
        {
            var blockType = Params["BlockType"];
            var count = int.Parse(Params["Count"]);
            var param = new GameObjectParam
            {
                TypeName = blockType,
                Location = new int[] { dstX, dstY },
                Motion = MotionEnum.Static,
                Params = new Dictionary<string, string> { { "State", "Normal" } },
            };
            for (var i = 0; i < count; i++)
            {
                var blockInstance = param.ToGameObject();
                param.Location[0] += blockInstance.Size.X;
                if (blockInstance is Block block)
                    blocks.Add(block);
            }
            Size = new Point(param.Location[0] - dstX, Constants.BLOCK_HEIGHT);
        }

        public override void Update(float dt)
        {
            blocks.ForEach(o => o.Update(dt));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            blocks.ForEach(o => o.Draw(spriteBatch));
        }
    }
}
