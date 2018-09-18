using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public struct IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int n1, int n2)
        {
            x = n1;
            y = n2;
        }
    }
    
    public interface IMarioState
    {
        void Left();
        void Right();
        void Jump();
        void Crouch();
        void Small();
        void Big();
        void Fire();
        void Dead();
        void Update();
    }

    public class Mario : ISprite
    {
        private IMarioState state;

        private const int screenWidth = 800, screenHeight = 480;
        private const int marioWidth = 30, marioHeight = 15, zoom = 4;
        private const int textureFrameCount = 4;

        private Rectangle dst = new Rectangle(
            (screenWidth - marioWidth * zoom) / 2,
            (screenHeight - marioHeight * zoom) / 2,
            marioWidth * zoom, marioHeight * zoom);
        private Rectangle src = new Rectangle(180, 0, marioWidth, marioHeight);

        public Mario()
        {
            this.state = new MarioStateRightIdle(this);
        }

        public void Update()
        {
            this.state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Draw(textures["mario"], dst, src, Color.White);
        }

        public IMarioState State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }

        public IntVector2 SourceRectangleXY
        {
            get
            {
                return new IntVector2(this.src.X, this.src.Y);
            }
            set
            {
                this.src.X = value.x;
                this.src.Y = value.y;
            }
        }
    }

    public abstract class MarioState : IMarioState
    {
        protected Mario mario;

        protected MarioState(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Left()
        {
            this.mario.State = new MarioStateLeftIdle(this.mario);
        }

        public virtual void Right()
        {
            this.mario.State = new MarioStateRightIdle(this.mario);
        }

        public virtual void Jump()
        {
            this.mario.State = new MarioStateRightJump(this.mario);
        }

        public virtual void Crouch()
        {
            this.mario.State = new MarioStateRightCrouch(this.mario);
        }

        public virtual void Small()
        {
            this.mario.State = new MarioStateSmall(this.mario);
        }

        public virtual void Big()
        {
            this.mario.State = new MarioStateBig(this.mario);
        }

        public virtual void Fire()
        {
            this.mario.State = new MarioStateFire(this.mario);
        }

        public virtual void Dead()
        {
            this.mario.State = new MarioStateDead(this.mario);
        }

        public abstract void Update();
    }

    public class MarioStateLeftIdle : MarioState
    {
        public MarioStateLeftIdle(Mario mario)
            : base(mario)
        {
        }

        public override void Left()
        {
            base.mario.State = new MarioStateLeftRun(base.mario);
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateLeftJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateLeftCrouch(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(150, 0);
        }
    }

    public class MarioStateLeftRun : MarioState
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;

        public MarioStateLeftRun(Mario mario)
            : base(mario)
        {
            this.frameCount = 0;
        }

        public override void Left()
        {
            base.mario.State = new MarioStateLeftIdle(base.mario);
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateLeftJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateLeftCrouch(base.mario);
        }

        public override void Update()
        {
            if (frameCount == 0)
            {
                base.mario.SourceRectangleXY = new IntVector2(120, 0);
            }
            else if (frameCount == framesPerSprite || frameCount == framesPerSprite * 3)
            {
                base.mario.SourceRectangleXY = new IntVector2(90, 0);
            }
            else if (frameCount == framesPerSprite * 2)
            {
                base.mario.SourceRectangleXY = new IntVector2(60, 0);
            }

            this.frameCount++;

            if (frameCount >= framesPerSprite * 4)
            {
                frameCount = 0;
            }
        }
    }

    public class MarioStateLeftJump : MarioState
    {
        public MarioStateLeftJump(Mario mario)
            : base(mario)
        {
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateLeftJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateLeftIdle(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(30, 0);
        }
    }

    public class MarioStateLeftCrouch : MarioState
    {
        public MarioStateLeftCrouch(Mario mario)
            : base(mario)
        {
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateLeftIdle(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateLeftCrouch(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(0, 0);
        }
    }

    public class MarioStateRightIdle : MarioState
    {
        public MarioStateRightIdle(Mario mario)
            : base(mario)
        {
        }

        public override void Right()
        {
            base.mario.State = new MarioStateRightRun(base.mario);
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateRightJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateRightCrouch(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(180, 0);
        }
    }

    public class MarioStateRightRun : MarioState
    {
        private const uint framesPerSprite = 15;
        private uint frameCount;
        
        public MarioStateRightRun(Mario mario)
            : base(mario)
        {
            this.frameCount = 0;
        }

        public override void Right()
        {
            base.mario.State = new MarioStateRightIdle(base.mario);
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateRightJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateRightCrouch(base.mario);
        }

        public override void Update()
        {
            if (frameCount == 0)
            {
                base.mario.SourceRectangleXY = new IntVector2(210, 0);
            }
            else if (frameCount == framesPerSprite || frameCount == framesPerSprite * 3)
            {
                base.mario.SourceRectangleXY = new IntVector2(240, 0);
            }
            else if (frameCount == framesPerSprite * 2)
            {
                base.mario.SourceRectangleXY = new IntVector2(270, 0);
            }

            this.frameCount++;

            if (frameCount >= framesPerSprite * 4)
            {
                frameCount = 0;
            }
        }
    }

    public class MarioStateRightJump : MarioState
    {
        public MarioStateRightJump(Mario mario)
            : base(mario)
        {
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateRightJump(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateRightIdle(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(300, 0);
        }
    }

    public class MarioStateRightCrouch : MarioState
    {
        public MarioStateRightCrouch(Mario mario)
            : base(mario)
        {
        }

        public override void Jump()
        {
            base.mario.State = new MarioStateRightIdle(base.mario);
        }

        public override void Crouch()
        {
            base.mario.State = new MarioStateRightCrouch(base.mario);
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(330, 0);
        }
    }

    public class MarioStateSmall : MarioState
    {
        public MarioStateSmall(Mario mario)
            : base(mario)
        {
        }

        public override void Small()
        {
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(0, 0);
        }
    }

    public class MarioStateBig : MarioState
    {
        public MarioStateBig(Mario mario)
            : base(mario)
        {
        }

        public override void Big()
        {
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(0, 0);
        }
    }

    public class MarioStateFire : MarioState
    {
        public MarioStateFire(Mario mario)
            : base(mario)
        {
        }

        public override void Fire()
        {
        }

        public override void Update()
        {
            base.mario.SourceRectangleXY = new IntVector2(0, 0);
        }
    }

    public class MarioStateDead : MarioState
    {
        public MarioStateDead(Mario mario)
            : base(mario)
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
            base.mario.SourceRectangleXY = new IntVector2(0, 0);
        }
    }
}
