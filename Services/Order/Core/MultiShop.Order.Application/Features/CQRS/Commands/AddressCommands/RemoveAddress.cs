namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddress
    {
        public int AddressID { get; set; }
        public RemoveAddress(int addressID)
        {
            AddressID = addressID;
        }
    }
}
