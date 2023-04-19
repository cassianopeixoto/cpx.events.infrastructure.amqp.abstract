using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface IEventEmitterService
{
    void Emit(Event @event);
}
