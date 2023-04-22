using HomeExpenses.Tracking.Domain.Entities.User;
using HomeExpenses.Tracking.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrackingDbContext dbContext;

        public UserRepository(TrackingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var userToDelete = await GetByIdAsync(id);
            if (userToDelete is null)
                return; //TODO: throw not found exception
            dbContext.Users.Remove(userToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
