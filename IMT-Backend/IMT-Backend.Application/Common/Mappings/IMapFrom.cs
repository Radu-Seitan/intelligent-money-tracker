using AutoMapper;

namespace IMT_Backend.Application.Common.Mappings
{
    public interface IMapFrom<T>
        {
            void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
        }
}
