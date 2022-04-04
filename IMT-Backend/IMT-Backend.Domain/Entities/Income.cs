using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public IncomeCategory Category { get; set; }
    }
}
