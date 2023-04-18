using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IEventHandlerTest
{
    [Fact]
    public void Should_check_the_constraints_of_class()
    {
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
    }

    [Fact]
    public void Should_check_if_HandleAsync_method_exists()
    {
        var methodName = "HandleAsync";
        var eventHandlerType = typeof(IEventHandler<>);
        var methodInfo = eventHandlerType.GetMethod(methodName);

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
    }
}