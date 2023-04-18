using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract;

public interface IPublishService
{
    void Publish(Event @event);
}
