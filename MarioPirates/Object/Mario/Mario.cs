﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    using Event;

    internal class Mario : GameObjectRigidBody
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY)
        {
            location = new Vector2(dstX, dstY);
            State = new MarioStateSmallRightIdle(this);

            RigidBody.Mass = 1f;
            RigidBody.ApplyForce(WorldForce.Friction);

            EventManager.Instance.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(0, -1000));
            }, EventEnum.KeyUpHold);
            EventManager.Instance.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(0, 1000));
            }, EventEnum.KeyDownHold);
            EventManager.Instance.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead ||
                    State is MarioStateStarSmall || State is MarioStateStarBig))
                    RigidBody.ApplyForce(new Vector2(-1000, 0));
            }, EventEnum.KeyLeftHold);
            EventManager.Instance.Subscribe(e =>
            {
                if (!(State is MarioStateDead || State is MarioStateStarDead))
                    RigidBody.ApplyForce(new Vector2(1000, 0));
            }, EventEnum.KeyRightHold);

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
