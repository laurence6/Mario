using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    using Event;

    internal class Mario : GameObject
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY)
        {
            location = new Vector2(dstX, dstY);
            State = new MarioStateSmallRightIdle(this);

            RigidBody.Mass = 1f;
            RigidBody.ApplyForce(WorldForce.Friction);
            EventManager.Instance.Subscribe(e => { State.Jump(); RigidBody.ApplyForce(new Vector2(0, -7000)); },
                EventEnum.KeyUpDown);
            EventManager.Instance.Subscribe(e => { State.Crouch(); RigidBody.ApplyForce(new Vector2(0, 7000)); },
                EventEnum.KeyDownDown);
            EventManager.Instance.Subscribe(e => { State.Left(); RigidBody.ApplyForce(new Vector2(-7000, 0)); },
                EventEnum.KeyLeftDown);
            EventManager.Instance.Subscribe(e => { State.Right(); RigidBody.ApplyForce(new Vector2(7000, 0)); },
                EventEnum.KeyRightDown);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(0, -700)),
                EventEnum.KeyUpHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(0, 700)),
                EventEnum.KeyDownHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(-700, 0)),
                EventEnum.KeyLeftHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(700, 0)),
                EventEnum.KeyRightHold);

            EventManager.Instance.Subscribe(e =>
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
    }
}
