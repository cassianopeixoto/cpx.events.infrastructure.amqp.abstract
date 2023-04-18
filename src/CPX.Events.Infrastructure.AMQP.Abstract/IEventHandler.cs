using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface IEventHandler<TEvent> where TEvent : Event
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
}