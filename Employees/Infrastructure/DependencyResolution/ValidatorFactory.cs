namespace Employees.Infrastructure.DependencyResolution
{
    using System;
    using FluentValidation;
    using StructureMap;

    public class ValidatorFactory : ValidatorFactoryBase
    {
        private readonly Func<IContainer> _container;

        public ValidatorFactory(Func<IContainer> container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return _container().TryGetInstance(validatorType) as IValidator;
        }
    }
}