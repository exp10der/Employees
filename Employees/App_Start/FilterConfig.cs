namespace Employees
{
    using System.Web.Mvc;
    using Infrastructure.Data;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new TransactionFilter());
        }
    }
}