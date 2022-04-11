using IMT_Backend.Domain.Common;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Domain.Entities
{
    public class Income : BaseEntity
    {
        public double Quantity { get; set; }
        public IncomeCategory Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
