using MediatR;

namespace Voyage.Application.TrekPackages.Commands.DeleteTrekPackage
{
    public class DeleteTrekPackageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
