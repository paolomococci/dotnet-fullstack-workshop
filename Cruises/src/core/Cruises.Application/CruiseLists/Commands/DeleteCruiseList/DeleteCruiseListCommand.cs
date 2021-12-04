using MediatR;

namespace Cruises.Application.CruiseLists.Commands.DeleteCruiseList
{
  public class DeleteCruiseListCommand
    : IRequest
  {
    public int Id { get; set; }
  }
}
