using MediatR;

namespace Trekking.Application.TrekLists.Commands.DeleteTrekList
{
    public class DeleteTrekListCommand : IRequest
    {
        public int Id { get; set; }
    }
}
