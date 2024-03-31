using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Bamanna.DouDian.Queries.Container;

namespace Bamanna.DouDian.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}