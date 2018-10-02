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
            EventManager.Instance.Subscribe(e => { State.Jump(); RigidBody.ApplyForce(new Vector2(00, -7000)); }, 
                EventEnum.KeyUpDown, EventEnum.KeyWDown, EventEnum.KeyDownUp, EventEnum.KeySUp);
            EventManager.Instance.Subscribe(e => { State.Crouch(); RigidBody.ApplyForce(new Vector2(00, 7000)); }, 
                EventEnum.KeyDownDown, EventEnum.KeySDown, EventEnum.KeyUpUp, EventEnum.KeyWUp);
            EventManager.Instance.Subscribe(e => { State.Left(); RigidBody.ApplyForce(new Vector2(-7000, 00)); }, 
                EventEnum.KeyLeftDown, EventEnum.KeyADown, EventEnum.KeyRightUp, EventEnum.KeyDUp);
            EventManager.Instance.Subscribe(e => { State.Right(); RigidBody.ApplyForce(new Vector2(7000, 00)); }, 
                EventEnum.KeyRightDown, EventEnum.KeyDDown, EventEnum.KeyLeftUp, EventEnum.KeyAUp);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(00, -700)), EventEnum.KeyUpHold, EventEnum.KeyWHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(00, 700)), EventEnum.KeyDownHold, EventEnum.KeySHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(-700, 00)), EventEnum.KeyLeftHold, EventEnum.KeyAHold);
            EventManager.Instance.Subscribe(e => RigidBody.ApplyForce(new Vector2(700, 00)), EventEnum.KeyRightHold, EventEnum.KeyDHold);

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
