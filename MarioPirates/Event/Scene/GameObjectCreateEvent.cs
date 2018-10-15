namespace MarioPirates.Event
{
    internal class GameObjectCreateEvent : IEvent
    {
        public EventEnum EventType => EventEnum.GameObjectCreate;

        public readonly GameObjectParam param;

        public GameObjectCreateEvent(GameObjectParam param) => this.param = param;
    }
}
