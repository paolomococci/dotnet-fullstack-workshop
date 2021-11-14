using MediatR;
using Voyage.Domain.Enums;

namespace Voyage.Application.TrekPackages.Commands.UpdateTrekPackageDetail
{
    public class UpdateTrekPackageDetailCommand : IRequest
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
    }
}
