using IMT_Backend.Application.Common.Mappings;
using IMT_Backend.Domain.Entities;

namespace IMT_Backend.Application.Common.DTOs
{
    public class UserDto : IMapFrom<User>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public double Sum { get; set; }
    }
}
