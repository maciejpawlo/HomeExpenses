using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeExpenses.Domain.Core.Entities
{
    internal interface ITrackableEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
