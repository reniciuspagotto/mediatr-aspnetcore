namespace MediatRWithAspNetCore.Entities
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }

        public Customer(string firstName, string lastName, string cellPhone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            CellPhone = cellPhone;
            Email = email;
        }
    }
}
