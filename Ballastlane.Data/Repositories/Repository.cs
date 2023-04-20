using Microsoft.EntityFrameworkCore;

namespace Ballastlane.Data.Repositories
{
    /// <summary>
    /// Generic class that implements IRepository for a CRUD.
    /// </summary>
    /// <typeparam name="TEntity">Generic type.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// It retrieves a collection of type TEntity.
        /// </summary>
        /// <returns>Task<IEnumerable<TEntity>></returns>
        public async Task<IEnumerable<TEntity>> Get() => await _dbSet.ToListAsync();

        /// <summary>
        /// It retrieves an entity of type TEntity
        /// </summary>
        /// <param name="id">Record Id.</param>
        /// <returns>Task<TEntity></returns>
        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);

        /// <summary>
        /// It creates a new record of type TEntity
        /// </summary>
        /// <param name="entity">Generic TEntity</param>
        /// <returns>Task</returns>
        public async Task Create(TEntity entity) => await _dbSet.AddAsync(entity);

        /// <summary>
        /// It updates a record of type TEntity
        /// </summary>
        /// <param name="entity">Generic TEntity</param>
        /// <returns>Task</returns>
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// It delete a record of type TEntity
        /// </summary>
        /// <param name="id">Record Id.</param>
        /// <returns>Task</returns>
        public async Task Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// It saves changes in the database.
        /// </summary>
        /// <returns>Task</returns>
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
