using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface ISubscribeService
{
    void Subscribe<TEvent>(string routingKey) where TEvent : Event;
}