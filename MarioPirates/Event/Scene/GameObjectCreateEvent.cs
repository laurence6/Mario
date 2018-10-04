namespace MarioPirates.Event
{
    internal class GameObjectCreateEvent : IEvent
    {
        public EventEnum EventType => EventEnum.GameObjectCreate;

        public GameObjectParam Param { get; private set; }

        public GameObjectCreateEvent(GameObjectParam param)
        {
            Param = param;
        }
    }
}
