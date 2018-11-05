using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal interface IGameObject
    {
        Vector2 Location { get; set; }
        bool IsLocationAbsolute { get; set; }
        Point Size { get; set; }

        Sprite Sprite { get; set; }

        void Update(float dt);
        void Draw(SpriteBatch spriteBatch);
    }
}
