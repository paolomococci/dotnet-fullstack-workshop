using MediatR;

namespace Biking.Application.TrekLists.Commands.DeleteTrekList
{
    public class DeleteTrekListCommand : IRequest
    {
        public int Id { get; set; }
    }
}
