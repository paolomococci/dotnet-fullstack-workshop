using MediatR;

namespace Biking.Application.TrekLists.Commands.UpdateTrekList
{
    public class UpdateTrekListCommand : IRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
