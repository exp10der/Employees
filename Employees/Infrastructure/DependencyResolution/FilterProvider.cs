namespace Employees.Infrastructure.DependencyResolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using StructureMap;

    public class FilterProvider : FilterAttributeFilterProvider
    {
        private readonly Func<IContainer> _container;

        public FilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            var container = _container();

            foreach (var filter in filters.Concat(GlobalFilters.Filters))
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}