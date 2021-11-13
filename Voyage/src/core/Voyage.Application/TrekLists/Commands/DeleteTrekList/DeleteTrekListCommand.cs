using MediatR;

namespace Voyage.Application.TrekLists.Commands.DeleteTrekList
{
    public class DeleteTrekListCommand : IRequest
    {
        public int Id { get; set; }
    }
}
