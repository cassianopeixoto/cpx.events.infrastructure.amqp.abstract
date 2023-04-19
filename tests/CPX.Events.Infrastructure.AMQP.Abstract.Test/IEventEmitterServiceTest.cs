using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IEventEmitterServiceTest
{
    [Fact]
    public void Should_check_if_Emit_method_exists()
    {
        var eventEmitterServiceType = typeof(IEventEmitterService);
        var methodInfo = eventEmitterServiceType.GetMethod("Emit");

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