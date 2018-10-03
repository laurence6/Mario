using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;
    internal class Goomba : GameObjectRigidBody
    {
        private const int goombaWidth = 16, goombaHeight = 16;
        private enum Status {Normal, Stomped}
        private Status status;

        public Goomba(int x, int y)
        {
            status = Status.Normal;
            location.X = x;
            location.Y = y;
            size = new Point(goombaWidth * 2, goombaHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("goomba");
            RigidBody.Mass = 0.1f;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                if (status == Status.Stomped)
                {
                    EventManager.Instance.EnqueueEvent(new GameObjectDestroyEvent(this));
                }
                if (side == CollisionSide.Top)
                {
                    status = Status.Stomped;
                    Sprite = SpriteFactory.Instance.CreateSprite("goombastomped");
                    }
                else
                {
                    
                }
            }
            else if (other is Pipe)
            {
                RigidBody.Velocity = new Vector2(0, 0);
            }
        }
    }
}
