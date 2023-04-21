using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface ISubscribeService : IDisposable
{
    void Subscribe<TEvent>(string routingKey, CancellationToken cancellationToken) where TEvent : Event;
}