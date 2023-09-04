namespace ProjectManagement.Modules.AuthUser.Domain.Entities
{
    public class ApplicationUserDomain
    {
        public ApplicationUserDomain(string email, string userName, string name, string lastName)
        {
            Email = email;
            UserName = userName;
            Name = name;
            LastName = lastName;
        }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }


    }
}
