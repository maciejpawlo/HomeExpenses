using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Tracking.Domain.Entities.Expense
{
    public enum ExpenseType
    {
        Groceries,
        Car,
        Pets,
        Chemicals,
        Utilities, // gas, electricity, fuel, cell/telephone, and water
        Shelter, // mortgage payments, property taxes, or rent; maintenance and repairs; and insurance
        Furnishing, // table, chair
        Electronics, // tv, washing machine, dish washer
        Other
    }
}
