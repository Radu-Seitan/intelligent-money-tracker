using IMT_Backend.Domain.Common;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public float Quantity { get; set; }
        public ExpenseCategory Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
