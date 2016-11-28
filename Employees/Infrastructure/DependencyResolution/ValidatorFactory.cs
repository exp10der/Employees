namespace Employees.Infrastructure.DependencyResolution
{
    using System;
    using FluentValidation;
    using StructureMap;

    public class ValidatorFactory : ValidatorFactoryBase
    {
        public IContainer Container
        {
            get { throw new NotImplementedException("Need add Property Injection"); }
            set { throw new NotImplementedException("Need add Property Injection"); }
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return Container.TryGetInstance(validatorType) as IValidator;
        }
    }
}