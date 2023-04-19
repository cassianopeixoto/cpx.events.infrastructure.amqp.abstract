using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface IPublishService
{
    void Publish(string routingKey, Event @event);
}
