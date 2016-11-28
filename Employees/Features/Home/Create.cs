namespace Employees.Features.Home
{
    using AutoMapper;
    using Domain;
    using FluentValidation;
    using Infrastructure;
    using MediatR;

    public class Create
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(m => m.UserName).NotNull().Length(3, 50);
                RuleFor(m => m.FirstName).NotNull().Length(3, 50);
                RuleFor(m => m.LastName).NotNull().Length(3, 50);
                RuleFor(m => m.Email).NotNull();
            }
        }

        public class Command : IRequest
        {
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class CommandHandler : RequestHandler<Command>
        {
            private readonly ApplicationDbContext _context;

            public CommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            protected override void HandleCore(Command message)
            {
                var employee = Mapper.Map<Command, Employee>(message);

                _context.Employees.Add(employee);
            }
        }
    }
}