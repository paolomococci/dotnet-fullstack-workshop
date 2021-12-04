using MediatR;

namespace Trekking.Application.TrekLists.Commands.CreateTrekList
{
  public class CreateTrekListCommand : IRequest<int>
  {
    public string Country { get; set; }
    public string City { get; set; }
  }
}
