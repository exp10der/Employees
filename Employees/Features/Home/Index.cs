namespace Employees.Features.Home
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Infrastructure;
    using MediatR;

    public class Index
    {
        public class Query : IAsyncRequest<List<Model>>
        {
        }

        public class Model
        {
            public int Id { get; set; }
            public string FullName { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, List<Model>>
        {
            private readonly ApplicationDbContext _context;

            public QueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Model>> Handle(Query message)
            {
                return await _context.Employees
                    .ProjectToListAsync<Model>();
            }
        }
    }
}