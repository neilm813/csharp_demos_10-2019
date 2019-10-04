namespace ExampleHelloASP.Models
{
    public class HomePage
    {
        public string FirstName { get; set; }
        public User Guest { get; set; }
        public string[] Places { get; set; }
        public HomePage(User guest, string[] places)
        {
            Guest = guest;
            Places = places;
        }
    }

}