namespace Ballastlane.Data.Models.Entities
{
    /// <summary>
    /// Abstraction of a user.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
