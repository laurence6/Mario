using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public class Mario : ISprite
    {
        protected const int screenWidth = 800, screenHeight = 480;
        protected const int textureFrameCount = 4;

        public Rectangle DrawDst = new Rectangle(
            (screenWidth - MarioState.marioWidth * MarioState.zoom) / 2,
            (screenHeight - MarioState.marioHeight * MarioState.zoom) / 2,
            MarioState.marioWidth * MarioState.zoom, MarioState.marioHeight * MarioState.zoom);
        public Rectangle DrawSrc = new Rectangle(180, 0, MarioState.marioWidth, MarioState.marioHeight);

        public MarioState State;

        public Mario()
        {
            State = new MarioStateRightIdle(this);
        }

        public void Update()
        {
            State.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            State.Draw(spriteBatch, textures);
        }
    }

    public abstract class MarioState
    {
        public const int marioWidth = 30, marioHeight = 15;
        public const int bigMarioWidth = 30, bigMarioHeight = 32;
        public const int deadMarioWidth = 15, deadMarioHeight = 14;
        public const int zoom = 4;
        
        protected Mario mario;

        protected MarioState(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Left()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public virtual void Right()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public virtual void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public virtual void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public virtual void Small()
        {
            mario.State = new MarioStateSmall(mario);
        }

        public virtual void Big()
        {
            mario.State = new MarioStateBig(mario);
        }

        public virtual void Fire()
        {
            mario.State = new MarioStateFire(mario);
        }

        public virtual void Dead()
        {
            mario.State = new MarioStateDead(mario);
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["mario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

    public class MarioStateLeftIdle : MarioState
    {
        public MarioStateLeftIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateLeftRun(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 150;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateLeftRun : MarioState
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;

        public MarioStateLeftRun(Mario mario) : base(mario)
        {
            frameCount = 0;
        }

        public override void Left()
        {
        }

        public override void Right()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftCrouch(mario);
        }

        public override void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite)
                {
                    case 0:
                        mario.DrawSrc.X = 120;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 1:
                    case 3:
                        mario.DrawSrc.X = 90;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 2:
                        mario.DrawSrc.X = 60;
                        mario.DrawSrc.Y = 0;
                        break;
                    default:
                        break;
                }
            }
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateLeftJump : MarioState
    {
        public MarioStateLeftJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 30;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateLeftCrouch : MarioState
    {
        public MarioStateLeftCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateLeftCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateRightIdle : MarioState
    {
        public MarioStateRightIdle(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
            mario.State = new MarioStateLeftIdle(mario);
        }

        public override void Right()
        {
            mario.State = new MarioStateRightRun(mario);
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateRightRun : MarioState
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;

        public MarioStateRightRun(Mario mario) : base(mario)
        {
            frameCount = 0;
        }

        public override void Left()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public override void Update()
        {
            if (frameCount++ / framesPerSprite >= 4)
            {
                frameCount = 0;
            }
            if (frameCount % framesPerSprite == 0)
            {
                switch (frameCount / framesPerSprite)
                {
                    case 0:
                        mario.DrawSrc.X = 210;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 1:
                    case 3:
                        mario.DrawSrc.X = 240;
                        mario.DrawSrc.Y = 0;
                        break;
                    case 2:
                        mario.DrawSrc.X = 270;
                        mario.DrawSrc.Y = 0;
                        break;
                    default:
                        break;
                }
            }
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateRightJump : MarioState
    {
        public MarioStateRightJump(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightJump(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 300;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateRightCrouch : MarioState
    {
        public MarioStateRightCrouch(Mario mario) : base(mario)
        {
        }

        public override void Jump()
        {
            mario.State = new MarioStateRightIdle(mario);
        }

        public override void Crouch()
        {
            mario.State = new MarioStateRightCrouch(mario);
        }

        public override void Update()
        {
            mario.DrawSrc.X = 330;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }
    }

    public class MarioStateSmall : MarioState
    {
        public MarioStateSmall(Mario mario) : base(mario)
        {
        }

        public override void Small()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = marioWidth;
            mario.DrawSrc.Height = marioHeight;
            mario.DrawDst.Width = marioWidth * zoom;
            mario.DrawDst.Height = marioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["mario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

    public class MarioStateBig : MarioState
    {
        public MarioStateBig(Mario mario) : base(mario)
        {
        }

        public override void Big()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = bigMarioWidth;
            mario.DrawSrc.Height = bigMarioHeight;
            mario.DrawDst.Width = bigMarioWidth * zoom;
            mario.DrawDst.Height = bigMarioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["bigmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

    public class MarioStateFire : MarioState
    {
        public MarioStateFire(Mario mario) : base(mario)
        {
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 180;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = bigMarioWidth;
            mario.DrawSrc.Height = bigMarioHeight;
            mario.DrawDst.Width = bigMarioWidth * zoom;
            mario.DrawDst.Height = bigMarioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["biggermario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }

    public class MarioStateDead : MarioState
    {
        public MarioStateDead(Mario mario) : base(mario)
        {
        }

        public override void Left()
        {
        }

        public override void Right()
        {
        }

        public override void Jump()
        {
        }

        public override void Crouch()
        {
        }

        public override void Dead()
        {
        }

        public override void Update()
        {
            mario.DrawSrc.X = 0;
            mario.DrawSrc.Y = 0;
            mario.DrawSrc.Width = deadMarioWidth;
            mario.DrawSrc.Height = deadMarioHeight;
            mario.DrawDst.Width = deadMarioWidth * zoom;
            mario.DrawDst.Height = deadMarioHeight * zoom;
        }

        public override void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["deadmario"], mario.DrawDst, mario.DrawSrc, Color.White);
        }
    }
}
