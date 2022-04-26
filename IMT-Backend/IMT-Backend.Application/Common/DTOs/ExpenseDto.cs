using IMT_Backend.Application.Common.Mappings;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Application.Common.DTOs
{
    public class ExpenseDto : IMapFrom<Expense>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public double Quantity { get; set; }
        public ExpenseCategory Category { get; set; }
        public string UserId { get; set; }
        public int StoreId { get; set; }
    }
}
