namespace Ballastlane.Data.Repositories
{
    /// <summary>
    /// Interface for user login.
    /// </summary>
    public interface ILoginRepository
    {
        /// <summary>
        /// It verifies if username and password existis in the database.
        /// </summary>
        /// <param name="username">User email.</param>
        /// <param name="password">Password.</param>
        /// <returns>Task<bool></returns>
        bool Login(string username, string password);
    }
}
