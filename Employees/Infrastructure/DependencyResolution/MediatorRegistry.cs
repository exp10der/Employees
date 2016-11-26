namespace Employees.Infrastructure.DependencyResolution
{
    using MediatR;
    using StructureMap;

    public class MediatorRegistry : Registry
    {
        public MediatorRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IMediator>();
                scan.AssemblyContainingType<MediatorRegistry>();

                scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                scan.WithDefaultConventions();
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
        }
    }
}