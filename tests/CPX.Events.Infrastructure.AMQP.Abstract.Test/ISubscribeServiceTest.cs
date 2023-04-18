using CPX.Events.Abstract;

namespace CPX.Events.Infrastructure.AMQP.Abstract.Test;

public sealed class ISubscribeServiceTest
{
    [Fact]
    public void Should_check_if_Subscribe_method_exists()
    {
        var subscribeServiceType = typeof(ISubscribeService);
        var methodInfo = subscribeServiceType.GetMethod("Subscribe");
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
    }
}