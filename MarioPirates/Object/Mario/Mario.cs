using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    using Event;

    internal class Mario : GameObjectRigidBody
    {
        public MarioState State { get; set; }
        public Dictionary<string, Sprite> Sprites { get; set; }

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            Sprites = new Dictionary<string, Sprite>();
            LoadSprites();

            State = new MarioState(this);

            RigidBody.Mass = 1f;
            RigidBody.ApplyForce(WorldForce.Friction);

            SubscribeInputMoving();
            SubscribeInputTransition();
        }

        private void LoadSprites()
        {
            List<string> list = 
                new JavaScriptSerializer().Deserialize<List<string>>(ReadAllText("Content\\MarioSpritesList.json"));
            foreach (var s in list)
                Sprites.Add(s, SpriteFactory.CreateSprite(s));
        }

        private void SubscribeInputMoving()
        {
            EventManager.Subscribe(e =>
            {
                if (!(State.IsDead()))
                    RigidBody.ApplyForce(new Vector2(0, -2000));
            }, EventEnum.KeyUpHold);
            EventManager.Subscribe(e =>
            {
                if (!(State.IsDead()))
                    RigidBody.ApplyForce(new Vector2(0, 2000));
            }, EventEnum.KeyDownHold);
            EventManager.Subscribe(e =>
            {
                if (!(State.IsDead()))
                    RigidBody.ApplyForce(new Vector2(-2000, 0));
            }, EventEnum.KeyLeftHold);
            EventManager.Subscribe(e =>
            {
                if (!(State.IsDead()))
                    RigidBody.ApplyForce(new Vector2(2000, 0));
            }, EventEnum.KeyRightHold);

            EventManager.Subscribe(e => State.Left(), EventEnum.KeyLeftHold);
            EventManager.Subscribe(e => State.Right(), EventEnum.KeyRightHold);
            EventManager.Subscribe(e => State.Jump(), EventEnum.KeyUpHold);
            EventManager.Subscribe(e => State.Crouch(), EventEnum.KeyDownHold);
            EventManager.Subscribe(e =>
            {
                if (!(State.IsJump() || State.IsCrouch()))
                {
                    if (RigidBody.Force.X != 0)
                        State.Run();
                    else
                        State.Idle();
                }
            }, EventEnum.KeyLeftHold, EventEnum.KeyRightHold);
            EventManager.Subscribe(e => State.Idle(), 
                EventEnum.KeyUpUp, EventEnum.KeyDownUp, EventEnum.KeyLeftUp, EventEnum.KeyRightUp);
        }

        private void SubscribeInputTransition()
        {
            EventManager.Subscribe(e =>
            {
                switch ((e as KeyDownEvent).Key)
                {
                    case Keys.Y:
                        State.Small();
                        break;
                    case Keys.U:
                        State.Big();
                        break;
                    case Keys.I:
                        State.Fire();
                        break;
                    case Keys.O:
                        State.Dead();
                        break;
                    case Keys.P:
                        State.Star();
                        break;
                }
            }, EventEnum.KeyDown);
        }

        public override void OnCollide(GameObject obj, CollisionSide side)
        {
            // Response to collision with items.
            if (obj is Coin)
            {
                // Score up
            }
            else if (obj is Flower)
            {
                State.Fire();
            }
            else if (obj is GreenMushroom)
            {
                // Life up
            }
            else if (obj is Pipe && side == CollisionSide.Bottom)
            {
                // Get in the pipe
            }
            else if (obj is RedMushroom)
            {
                State.Big();
            }
            else if (obj is Star)
            {
                State.Star();
            }

            // Response to collsion with enemies
            if (obj is Goomba || obj is Koopa)
            {
                if (!(side == CollisionSide.Bottom || State.IsInvincible()))
                {
                    RigidBody.CollideLayerMask = 0b10;
                    State.Dead();
                }
            }
        }
    }
}
