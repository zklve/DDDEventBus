
namespace Framework.EventBus
{
    public interface IEventHandler<T>
        where T : BaseEvent
    {
        void Handle(T eventData);
    }
}
