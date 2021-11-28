using MediatR;

namespace Trekking.Application.TrekPackages.Commands.UpdateTrekPackage
{
    public class UpdateTrekPackageCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
