using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface IEventEmitterService<TEvent> where TEvent : Event
{
    void Emit(TEvent @event);
}
