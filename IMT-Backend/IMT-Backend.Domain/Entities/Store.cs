using IMT_Backend.Domain.Common;

namespace IMT_Backend.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public Guid? ImageId { get; set; }
        public AppImage Image { get; set; }
    }
}
