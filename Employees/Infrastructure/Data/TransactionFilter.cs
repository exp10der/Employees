namespace Employees.Infrastructure.Data
{
    using System.Web.Mvc;

    public class TransactionFilter : ActionFilterAttribute
    {
        public ApplicationDbContext Context { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // BeginTransaction
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // CloseTransaction
        }
    }
}