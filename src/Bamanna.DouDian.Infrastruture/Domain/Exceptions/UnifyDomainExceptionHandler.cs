using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;

namespace Unify.Exceptions
{
    public class UnifyDomainExceptionHandler : IEventHandler<AbpHandledExceptionData>, ITransientDependency
{
    public void HandleEvent(AbpHandledExceptionData eventData)
    {
        //TODO: Check eventData.Exception!
    }
}
}
