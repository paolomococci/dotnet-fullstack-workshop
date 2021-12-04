using MediatR;

namespace Cruises.Application.CruisePackages.Commands.UpdateCruisePackage
{
  public class UpdateCruisePackageCommand
    : IRequest
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
