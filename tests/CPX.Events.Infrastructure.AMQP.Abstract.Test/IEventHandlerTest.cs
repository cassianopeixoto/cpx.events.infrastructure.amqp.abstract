using CPX.Events.Abstract;
using CPX.Events.Infrastructure.AMQP.Abstract.Test.Mocks;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IEventHandlerTest
{
    [Fact]
    public async Task Should_be_able_to_call_HandleAsync()
    {
        // Arrange
        var createdAt = DateTimeOffset.UtcNow;
        var @event = new FooEvent(createdAt);
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var eventHandlerMock = new Mock<IEventHandler<Event>>();
        eventHandlerMock.Setup(o => o.HandleAsync(@event, cancellationToken)).Verifiable();
        var eventHandler = eventHandlerMock.Object;
        // Act
        await eventHandler.HandleAsync(@event, cancellationToken);
        // Assert
        var eventHandlerType = typeof(IEventHandler<>);
        var getGenericArguments = eventHandlerType.GetGenericArguments();
        Assert.Single(getGenericArguments);

        var getGenericArgument = getGenericArguments.SingleOrDefault();
        Assert.NotNull(getGenericArgument);

        if (getGenericArgument is not null)
        {
            var genericParameterConstraints = getGenericArgument.GetGenericParameterConstraints();
            Assert.Single(genericParameterConstraints);

            var constraintType = genericParameterConstraints.SingleOrDefault(o => o == typeof(Event));
            Assert.NotNull(constraintType);
        }

        var methodInfo = eventHandler.GetType().GetMethod("HandleAsync");
        Assert.NotNull(methodInfo);
        if (methodInfo is not null)
        {
            var parameters = methodInfo.GetParameters();
            Assert.Equal(2, parameters.Length);
            var eventType = parameters.SingleOrDefault(o => o.ParameterType == typeof(Event));
            Assert.NotNull(eventType);
            var cancellationTokenType = parameters.SingleOrDefault(o => o.ParameterType == typeof(CancellationToken));
            Assert.NotNull(cancellationTokenType);
        }

        eventHandlerMock.VerifyAll();
    }
}