using AutoMapper;
using Cruises.Application.Common.Mappings;
using Cruises.Domain.Entities;
using Cruises.Domain.Enums;

namespace Cruises.Application.Dtos.Cruise
{
  public class CruisePackageDto
    : IMapFrom<CruisePackage>
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
      profile.CreateMap<CruisePackage, CruisePackageDto>()
      .ForMember(
        cruisePackageDto => cruisePackageDto.Currency,
        iMemberConfigurationExpression => iMemberConfigurationExpression
          .MapFrom(
            cruisePackage => (int)cruisePackage.Currency
          )
      );
    }
  }
}
