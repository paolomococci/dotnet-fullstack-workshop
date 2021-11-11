using AutoMapper;
using Voyage.Application.Common.Mappings;
using Voyage.Domain.Entities;
using Voyage.Domain.Enums;

namespace Voyage.Application.Dtos.Trek
{
    public class TrekPackageDto : IMapFrom<TrekPackage>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Name { get; set; }
        public string Hope { get; set; }
        public string MapLocation { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }
        public bool Confirmation { get; set; }
        public Currency Currency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrekPackage, TrekPackageDto>().ForMember(
                trekPackageDto => trekPackageDto.Currency,
                iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(
                    trekPackage => (int)trekPackage.Currency
                )
            );
        }
    }
}
