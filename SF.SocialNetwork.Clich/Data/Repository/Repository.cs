using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SF.SocialNetwork.Clich.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public DbSet<T> Set { get; private set; }

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }

        public async Task Create(T item)
        {
            await Task.Run(() => Set.Add(item));
            await Task.Run(() => _db.SaveChanges());
        }

        public async Task Delete(T id)
        {
            await Task.Run(() => Set.Remove(id));
            await Task.Run(() => _db.SaveChanges());
        }

        public async Task<T> Get(int id)
        {
            return await Task.Run(() => Set.Find(id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => Set);
        }

        public async Task Update(T item)
        {
            await Task.Run(() => Set.Update(item));
            await Task.Run(() => _db.SaveChanges());
        }
    }
}
