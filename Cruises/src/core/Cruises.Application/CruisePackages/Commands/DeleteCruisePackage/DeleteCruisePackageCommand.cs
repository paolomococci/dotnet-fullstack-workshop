using MediatR;

namespace Cruises.Application.CruisePackages.Commands.DeleteCruisePackage
{
  public class DeleteCruisePackageCommand
     : IRequest
  {
    public int Id { get; set; }
  }
}
