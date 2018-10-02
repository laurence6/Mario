using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class Goomba : GameObject
    {
        private const int goombaWidth = 16, goombaHeight = 16;
        public Goomba(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size = new Point(goombaWidth * 2, goombaHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("goomba");
            RigidBody.Mass = 0.1f;
        }
        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if(other is Mario)
            {
                if (side == CollisionSide.Top)
                {
                    //stomped
                }
                else
                {
                    //freeze all other moving enemies
                }
            }
            else if(other is Pipe)
            {
                //reverse direction
            }
        }
    }
    
}
