using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Mario : GameObject
    {
        protected const int screenWidth = 800, screenHeight = 480;
        protected const int textureFrameCount = 4;

        public MarioState State;

        public Rectangle DrawSrc = new Rectangle(180, 0, MarioStateSmall.marioWidth, MarioStateSmall.marioHeight);
        public Rectangle DrawDst = new Rectangle(0, 0, MarioStateSmall.marioWidth * MarioState.zoom, MarioStateSmall.marioHeight * MarioState.zoom);

        public Mario(int dstX, int dstY)
        {
            State = new MarioStateSmallRightIdle(this, dstX, dstY);
        }
    }
}
