namespace Ballastlane.Data.Repositories
{
    /// <summary>
    /// Generic interface repository for a CRUD.
    /// </summary>
    /// <typeparam name="TEntity">Generic type.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// It retrieves a collection of type TEntity.
        /// </summary>
        /// <returns>Task<IEnumerable<TEntity>></returns>
        Task<IEnumerable<TEntity>> Get();

        /// <summary>
        /// It retrieves an entity of type TEntity
        /// </summary>
        /// <param name="id">Record Id.</param>
        /// <returns>Task<TEntity></returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// It creates a new record of type TEntity
        /// </summary>
        /// <param name="entity">Generic TEntity</param>
        /// <returns>Task</returns>
        Task Create(TEntity entity);

        /// <summary>
        /// It updates a record of type TEntity
        /// </summary>
        /// <param name="entity">Generic TEntity</param>
        /// <returns>Task</returns>
        void Update(TEntity entity);

        /// <summary>
        /// It delete a record of type TEntity
        /// </summary>
        /// <param name="id">Record Id.</param>
        /// <returns>Task</returns>
        Task Delete(int id);

        /// <summary>
        /// It saves changes in the database.
        /// </summary>
        /// <returns>Task</returns>
        Task Save();
    }
}
