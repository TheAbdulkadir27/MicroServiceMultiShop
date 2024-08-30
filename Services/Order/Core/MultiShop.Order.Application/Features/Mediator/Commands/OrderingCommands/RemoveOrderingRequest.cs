using MediatR;
namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class RemoveOrderingRequest : IRequest
    {
        public int id { get; set; }
        public RemoveOrderingRequest(int id)
        {
            this.id = id;
        }
    }
}
