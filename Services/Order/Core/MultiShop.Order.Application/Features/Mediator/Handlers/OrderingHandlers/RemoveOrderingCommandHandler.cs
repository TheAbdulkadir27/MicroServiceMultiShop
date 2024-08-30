using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.İnterfaces;
using MultiShop.Order.Domain.Entities;
namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingRequest>
    {
        private readonly IRepository<Ordering> _repository;
        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderingRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(await _repository.GetByIDAsync(request.id));
        }
    }
}
