namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIDQuery
    {
        public int id { get; set; }
        public GetAddressByIDQuery(int id)
        {
            this.id = id;
        }
    }
}
