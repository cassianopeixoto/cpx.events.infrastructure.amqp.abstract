using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IPublishServiceTest
{
    [Fact]
    public void Should_check_if_Publish_method_exists()
    {
        var publishServiceType = typeof(IPublishService);
        var methodInfo = publishServiceType.GetMethod("Publish");

        Assert.NotNull(methodInfo);

        if (methodInfo is not null)
        {
            var returnType = methodInfo.ReturnType;
            Assert.Equal(typeof(void), returnType);

            var parameters = methodInfo.GetParameters();
            Assert.Single(parameters);

            var eventType = parameters.SingleOrDefault(o => o.ParameterType == typeof(Event));
            Assert.NotNull(eventType);
        }
    }
}