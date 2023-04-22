using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class IEventEmitterServiceTest
{
    [Fact]
    public void Should_check_the_constraints_of_class()
    {
        var eventHandlerType = typeof(IEventEmitterService<>);

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
    public void Should_check_if_Emit_method_exists()
    {
        var methodName = "Emit";
        var eventEmitterServiceType = typeof(IEventEmitterService<>);
        var methodInfo = eventEmitterServiceType.GetMethod(methodName);

        Assert.NotNull(methodInfo);

        if (methodInfo is not null)
        {
            var returnType = methodInfo.ReturnType;
            Assert.Equal(typeof(void), returnType);

            var parameters = methodInfo.GetParameters();
            Assert.Single(parameters);

            var eventType = parameters.SingleOrDefault(o => o.ParameterType.BaseType == typeof(Event));
            Assert.NotNull(eventType);
        }
    }
}