namespace Employees.Infrastructure
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