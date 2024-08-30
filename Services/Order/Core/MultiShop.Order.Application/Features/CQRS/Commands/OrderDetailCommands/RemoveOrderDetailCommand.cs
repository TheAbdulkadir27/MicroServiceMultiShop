namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public int id { get; set; }
        public RemoveOrderDetailCommand(int id)
        {
            this.id = id;
        }
    }
}
