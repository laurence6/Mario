﻿using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class GameObject : GameObjectBase
    {
        private Vector2 location;
        public override Vector2 Location
        {
            get => IsLocationAbsolute ? location + Camera.Ins.Offset : location;
            set => location = IsLocationAbsolute ? value - Camera.Ins.Offset : value;
        }

        public override Point Size { get; set; }

        protected GameObject(float locX, float locY, int sizeX, int sizeY) : base(locX, locY, sizeX, sizeY)
        {
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}