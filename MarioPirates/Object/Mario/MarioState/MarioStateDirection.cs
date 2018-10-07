using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MarioStateDirection
    {
        private bool left;
    
        public MarioStateDirection(bool isLeft = false)
        {
            left = isLeft;
        }

        public void Left()
        {
            left = true;
        }

        public void Right()
        {
            left = false;
        }
        
        public string GetString()
        {
            if (left)
                return "left";
            else
                return "right";
        }
    }
}
