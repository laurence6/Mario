using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    using Event;

    internal class Mario : GameObjectRigidBody
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY) : base(dstX, dstY, 0, 0)
        {
            State = new MarioStateSmallRightIdle(this);

            RigidBody.Mass = 1f;
            RigidBody.ApplyForce(WorldForce.Friction);

            SubscribeInputMoving();
            SubscribeInputTransition();
        }

        private void SubscribeInputMoving()
        {
            EventManager.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(0, -2000));
            }, EventEnum.KeyUpHold);
            EventManager.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(0, 2000));
            }, EventEnum.KeyDownHold);
            EventManager.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(-2000, 0));
            }, EventEnum.KeyLeftHold);
            EventManager.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(2000, 0));
            }, EventEnum.KeyRightHold);

            EventManager.Subscribe(e => State.Jump(), EventEnum.KeyUpDown, EventEnum.KeyDownUp);
            EventManager.Subscribe(e => State.Crouch(), EventEnum.KeyDownDown, EventEnum.KeyUpUp);
            EventManager.Subscribe(e => State.Left(), EventEnum.KeyLeftDown, EventEnum.KeyRightUp);
            EventManager.Subscribe(e => State.Right(), EventEnum.KeyRightDown, EventEnum.KeyLeftUp);
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
                if (!(side == CollisionSide.Bottom || State is MarioStateStarBig || State is MarioStateStarSmall))
                {
                    RigidBody.CollideLayerMask = 0b10;
                    State.Dead();
                }
            }
        }
    }
}
