using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test.Mocks;

public sealed class FooEvent : Event
{
    public FooEvent(DateTimeOffset createdAt) : base(createdAt)
    {
    }
}