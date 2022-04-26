using IMT_Backend.Application.Common.Mappings;
using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.DTOs
{
    public class StoreDto : IMapFrom<Store>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid? ImageId { get; set; }
    }
}
