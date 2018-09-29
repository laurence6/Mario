namespace MarioPirates
{
    using Event;

    internal static class Physics
    {
        public static void Reset()
        {
            EventManager.Instance.Subscribe(e =>
            {
                var collideEvent = e as CollideEvent;
                collideEvent.Object1.OnCollide(collideEvent.Object2);
                collideEvent.Object2.OnCollide(collideEvent.Object1);
            });
        }

        public static void TestCollide(GameObject o1, GameObject o2)
        {
            if ((o1.RigidBody ?? o2.RigidBody) == null)
                return;

            if ((o1.RigidBody.CollideMask & o2.RigidBody.CollideMask) != 0 &&
                o1.RigidBody.Bound.Intersects(o2.RigidBody.Bound))
                EventManager.Instance.EnqueueEvent(new CollideEvent(o1, o2));
        }
    }
}
