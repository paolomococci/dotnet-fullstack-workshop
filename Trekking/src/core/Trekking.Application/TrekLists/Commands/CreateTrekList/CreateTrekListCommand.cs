using MediatR;

namespace Trekking.Application.TrekLists.Commands
{
    public class CreateTrekListCommand : IRequest<int>
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
