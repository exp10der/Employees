namespace Employees
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using FluentValidation;
    using FluentValidation.Mvc;
    using Infrastructure.DependencyResolution;
    using Infrastructure.Mapping;
    using StructureMap;
    using StructureMap.TypeRules;

    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get { return (IContainer) HttpContext.Current.Items["_Container"]; }
            set { HttpContext.Current.Items["_Container"] = value; }
        }

        protected void Application_Start()
        {
            AutoMapperInitializer.Initialize();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container ?? IoC.Container));

            IoC.Container.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                cfg.AddRegistry(new MediatorRegistry());
                cfg.For<ModelValidatorProvider>().Use<FluentValidationModelValidatorProvider>();
                cfg.For<IValidatorFactory>().Use(new ValidatorFactory(() => Container ?? IoC.Container));
                cfg.For<IFilterProvider>().Use(new FilterProvider(() => Container ?? IoC.Container));
                cfg.Policies.SetAllProperties(
                    sc =>
                    {
                        sc.Matching(
                            p =>
                                p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                                p.DeclaringType.Namespace.StartsWith("Employees") && !p.PropertyType.IsPrimitive &&
                                (p.PropertyType != typeof(string)));
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