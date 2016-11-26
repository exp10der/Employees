namespace Employees.Features.Home
{
    using AutoMapper;
    using Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, Index.Model>();
        }
    }
}