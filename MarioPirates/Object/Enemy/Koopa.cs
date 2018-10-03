using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Koopa : GameObjectRigidBody
    {
        private const int koopaWidth = 16, koopaHeight = 23;
        private enum Status { Normal, Stomped, Shell}
        private Status status;
        public Koopa(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(koopaWidth * 2, koopaHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("koopaleft");
            RigidBody.Mass = 0.1f;
            status = Status.Normal;
        }
        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if(other is Mario)
            {
                if (status == Status.Stomped)
                {
                    status = Status.Shell;
                    Sprite = SpriteFactory.Instance.CreateSprite("koopashell");
                }
                
                else if(side== CollisionSide.Top)
                {
                    status = Status.Stomped;
                    Sprite = SpriteFactory.Instance.CreateSprite("koopastomped");
                }
            }
            else if(other is Pipe)
            {
                RigidBody.Velocity *= -1;
                if (status == Status.Normal)
                {
                    Sprite = SpriteFactory.Instance.CreateSprite("kooparight");
                }
            }
        }
    }
}
