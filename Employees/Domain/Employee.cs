namespace Employees.Domain
{
    using DelegateDecompiler;

    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Computed]
        public string FullName => FirstName + " " + LastName;

        public string Email { get; set; }
    }
}