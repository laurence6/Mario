﻿using Microsoft.Xna.Framework;

namespace MarioPirates
{
    using Event;

    internal class Star : GameObjectRigidBody
    {
        private const int starWidth = 14, starHeight = 16;

        public Star(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            size = new Point(starWidth * 2, starHeight * 2);
            Sprite = SpriteFactory.Instance.CreateSprite("stars");
            RigidBody.Mass = 0.05f;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.Instance.TriggerEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
