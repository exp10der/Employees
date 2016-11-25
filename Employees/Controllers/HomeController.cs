namespace Employees.Controllers
{
    using System.Diagnostics;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IFooDefaultConventions _fooDefaultConventions;

        public HomeController(IFooDefaultConventions fooDefaultConventions)
        {
            _fooDefaultConventions = fooDefaultConventions;
        }

        public ActionResult Index()
        {
            Debug.Print(_fooDefaultConventions.Foo());
            return View();
        }
    }

    public interface IFooDefaultConventions
    {
        string Foo();
    }

    public class FooDefaultConventions : IFooDefaultConventions
    {
        public string Foo()
        {
            return "Foo";
        }
    }
}