namespace Employees.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
    using DelegateDecompiler;
    using Infrastructure;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFooDefaultConventions _fooDefaultConventions;

        public HomeController(IFooDefaultConventions fooDefaultConventions, ApplicationDbContext context)
        {
            _fooDefaultConventions = fooDefaultConventions;
            _context = context;

            var test = _context.Employees.Decompile().ToList();
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