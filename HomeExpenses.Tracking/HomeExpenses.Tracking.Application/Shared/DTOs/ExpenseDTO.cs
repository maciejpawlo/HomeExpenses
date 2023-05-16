using HomeExpenses.Tracking.Domain.Entities.Expense;

namespace HomeExpenses.Tracking.Application.Shared.DTOs
{
    public class ExpenseDTO
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string? Comment { get; set; }
        public ExpenseType Type { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
