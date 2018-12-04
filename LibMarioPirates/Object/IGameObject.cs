using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal interface IGameObject
    {
        Vector2 Location { get; set; }
        Vector2 RelLocation { get; }
        bool IsLocationAbsolute { get; set; }

        Point Size { get; set; }

        ISprite Sprite { get; set; }

        void Update(float dt);
        void Draw(SpriteBatch spriteBatch);
    }
}
