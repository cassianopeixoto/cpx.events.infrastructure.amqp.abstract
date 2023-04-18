using CPX.Events.Abstract;
using CPX.Events.Infrastructure.AMQP.Abstract.Test.Mocks;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IPublishServiceTest
{
    [Fact]
    public void Should_be_able_to_call_Publish()
    {
        // Arrange
        var createdAt = DateTimeOffset.UtcNow;
        var @event = new FooEvent(createdAt);
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var publishServiceMock = new Mock<IPublishService>();
        publishServiceMock.Setup(o => o.Publish(@event)).Verifiable();
        var publishService = publishServiceMock.Object;
        // Act
        publishService.Publish(@event);
        // Assert
        var methodInfo = publishService.GetType().GetMethod("Publish");
        Assert.NotNull(methodInfo);
        if (methodInfo is not null)
        {
            var parameters = methodInfo.GetParameters();
            Assert.Single(parameters);
            var eventType = parameters.SingleOrDefault(o => o.ParameterType == typeof(Event));
            Assert.NotNull(eventType);
        }

        publishServiceMock.VerifyAll();
    }
}