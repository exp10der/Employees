namespace Employees.Infrastructure.DependencyResolution
{
    using StructureMap;

    public class IoC
    {
        static IoC()
        {
            Container = new Container();
        }

        public static IContainer Container { get; set; }
    }
}