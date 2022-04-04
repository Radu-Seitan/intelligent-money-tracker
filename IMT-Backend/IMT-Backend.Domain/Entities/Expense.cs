using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}
