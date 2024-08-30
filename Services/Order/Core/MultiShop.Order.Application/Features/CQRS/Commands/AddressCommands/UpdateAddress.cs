namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class UpdateAddress
    {
        public int AddressId { get; set; }
        public string UserID { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
