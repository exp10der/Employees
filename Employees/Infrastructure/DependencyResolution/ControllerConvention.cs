namespace Employees.Infrastructure.DependencyResolution
{
    using System.Linq;
    using System.Web.Mvc;
    using StructureMap;
    using StructureMap.Graph;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    public class ControllerConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.FindTypes(TypeClassification.Concretes).Where(type => type.CanBeCastTo<Controller>()))
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}