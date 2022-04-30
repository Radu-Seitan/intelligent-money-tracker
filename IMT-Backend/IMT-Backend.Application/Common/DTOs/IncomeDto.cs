using IMT_Backend.Application.Common.Mappings;
using IMT_Backend.Domain.Entities;
using IMT_Backend.Domain.Enums;

namespace IMT_Backend.Application.Common.DTOs
{
    public class IncomeDto : IMapFrom<Income>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public double Quantity { get; set; }
        public IncomeCategory Category { get; set; }
        public string UserId { get; set; }
    }
}
