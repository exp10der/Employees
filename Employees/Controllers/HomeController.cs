namespace Employees.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Features.Home;
    using MediatR;

    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _mediator.SendAsync(new Index.Query());

            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Create.Command());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Create.Command model)
        {
            _mediator.Send(model);

            throw new NotImplementedException();
        }
    }
}