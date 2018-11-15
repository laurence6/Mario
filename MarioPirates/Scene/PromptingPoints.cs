using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal sealed class PromptingPoints
    {
        public static readonly PromptingPoints Ins = new PromptingPoints();

        private PromptingPoints()
        {
        }

        private List<(ISprite, Vector2)> components = new List<(ISprite, Vector2)>();

        public void Add(int points, Vector2 pos)
        {
            components.Add((SpriteFactory.Ins.CreatePromptingPointsSprite(() => points.ToString()), pos));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
            components.ForEach(c => c.Item1.Draw(spriteBatch, c.Item2.X, c.Item2.Y));
            spriteBatch.End();
        }
    }
}
