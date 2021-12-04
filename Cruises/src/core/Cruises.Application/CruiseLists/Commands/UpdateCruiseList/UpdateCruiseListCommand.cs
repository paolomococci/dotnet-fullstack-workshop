using MediatR;

namespace Cruises.Application.CruiseLists.Commands.UpdateCruiseList
{
  public class UpdateCruiseListCommand
     : IRequest
  {
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
  }
}
