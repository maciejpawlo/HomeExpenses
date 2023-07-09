using HomeExpenses.Tracking.Application.Shared.Exceptions;
using HomeExpenses.Tracking.Domain.Entities.Expense;
using HomeExpenses.Tracking.Domain.Entities.User;
using HomeExpenses.Tracking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

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
                throw new NotFoundException($"Could not find user with given id: {id}"); 
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
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException($"Could not update user with id: {user.Id}, because it does not exist");
            }
        }
    }
}
