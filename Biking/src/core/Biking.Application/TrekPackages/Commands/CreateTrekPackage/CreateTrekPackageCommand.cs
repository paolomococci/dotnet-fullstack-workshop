using MediatR;

namespace Biking.Application.TrekPackages.Commands.CreateTrekPackage
{
    public class CreateTrekPackageCommand : IRequest<int>
    {
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
