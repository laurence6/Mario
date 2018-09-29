using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class GameObject
    {
        public Sprite Sprite { get; set; }
        public IRigidBody RigidBody { get; set; }

        protected Vector2 location;
        protected Point size;

        public Vector2 Location { get => location; set => location = value; }
        public Point Size { get => size; set => size = value; }

        protected GameObject()
        {
            RigidBody = new DefaultRigidBody(this);
        }

        public virtual void Update(float dt)
        {
            RigidBody?.Update(dt);
            Sprite?.Update(dt);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            Sprite?.Draw(spriteBatch, textures, new Rectangle((int)location.X, (int)location.Y, size.X, size.Y));
        }

        // Override to handle game logic
        public virtual void OnCollide(GameObject other)
        {
            // Physics simulation
            RigidBody.OnColide(other.RigidBody);
        }
    }
}
