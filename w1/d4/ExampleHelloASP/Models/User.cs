namespace ExampleHelloASP.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // cannot overwrite the default constructor
        // because dotnet requires the default 'parameterless constructor'
        // to be intact in order to automatically create a new instance
        // from a form post
        
        // public User(string fn, string ln, string email)
        // {
        //     FirstName = fn;
        //     LastName = ln;
        //     Email = email;
        // }
    }

}