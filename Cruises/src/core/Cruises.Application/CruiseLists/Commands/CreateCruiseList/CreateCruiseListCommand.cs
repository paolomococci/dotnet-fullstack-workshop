using MediatR;

namespace Cruises.Application.CruiseLists.Commands.CreateCruiseList
{
  public class CreateCruiseListCommand
    : IRequest<int>
  {
    public string Country { get; set; }
    public string City { get; set; }
  }
}
