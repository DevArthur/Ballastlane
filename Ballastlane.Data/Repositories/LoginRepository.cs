namespace Ballastlane.Data.Repositories
{
    /// <summary>
    /// Class for user login.
    /// </summary>
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// It verifies if username and password existis in the database.
        /// </summary>
        /// <param name="username">User email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Task<bool></returns>
        public bool Login(string username, string password)
        {
            var user = _context.Users.Where(x => x.Email.Equals(username) && x.Password.Equals(password));
            return user.Count() > 0;
        }
    }
}
