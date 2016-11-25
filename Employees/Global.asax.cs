namespace Employees
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Infrastructure;
    using StructureMap;

    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer) HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container ?? IoC.Container));

            IoC.Container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });
        }

        public void Application_BeginRequest()
        {
            Container = IoC.Container.GetNestedContainer();
        }

        public void Application_EndRequest()
        {
            Container.Dispose();
            Container = null;
        }
    }
}