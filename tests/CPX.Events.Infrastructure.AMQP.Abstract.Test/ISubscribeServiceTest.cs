using CPX.Events.Abstract;
using CPX.Events.Infrastructure.AMQP.Abstract.Test.Mocks;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class ISubscribeServiceTest
{
    [Fact]
    public void Should_be_able_to_call_Publish()
    {
        // Arrange
        var routingKey = "foo.created";
        var createdAt = DateTimeOffset.UtcNow;
        var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        var subscribeServiceMock = new Mock<ISubscribeService>();
        subscribeServiceMock.Setup(o => o.Subscribe<FooEvent>(routingKey)).Verifiable();
        var subscribeService = subscribeServiceMock.Object;
        // Act
        subscribeService.Subscribe<FooEvent>(routingKey);
        // Assert
        var methodInfo = subscribeService.GetType().GetMethod("Subscribe");
        Assert.NotNull(methodInfo);
        if (methodInfo is not null)
        {
            var parameters = methodInfo.GetParameters();
            Assert.Single(parameters);
            var stringType = parameters.SingleOrDefault(o => o.ParameterType == typeof(string));
            Assert.NotNull(stringType);

            var genericArgs = methodInfo.GetGenericArguments();
            Assert.Single(genericArgs);

            var genericArg = genericArgs.SingleOrDefault();
            Assert.NotNull(genericArg);

            if (genericArg is not null)
            {
                var genericParameterConstraints = genericArg.GetGenericParameterConstraints();
                Assert.Single(genericParameterConstraints);

                var constraintType = genericParameterConstraints.SingleOrDefault(o => o == typeof(Event));
                Assert.NotNull(constraintType);
            }
        }

        subscribeServiceMock.VerifyAll();
    }
}