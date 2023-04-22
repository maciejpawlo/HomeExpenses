using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Domain.Entities.User
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
