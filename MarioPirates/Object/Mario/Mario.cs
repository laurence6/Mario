using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;
    using Microsoft.Xna.Framework.Input;

    internal class Mario : GameObject
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY)
        {
            location = new Point(dstX, dstY);
            State = new MarioStateSmallRightIdle(this);

            EventManager.Instance.Subscribe(e => State.Jump(), EventEnum.KeyUpDown, EventEnum.KeyDownUp);
            EventManager.Instance.Subscribe(e => State.Crouch(), EventEnum.KeyDownDown, EventEnum.KeyUpUp);
            EventManager.Instance.Subscribe(e => State.Left(), EventEnum.KeyLeftDown, EventEnum.KeyRightUp);
            EventManager.Instance.Subscribe(e => State.Right(), EventEnum.KeyRightDown, EventEnum.KeyLeftUp);

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
                }
            }, EventEnum.KeyDown);
        }
    }
}
