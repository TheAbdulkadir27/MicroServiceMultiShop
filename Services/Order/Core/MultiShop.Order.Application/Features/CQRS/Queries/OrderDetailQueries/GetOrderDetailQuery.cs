namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery
    {
        public int id { get; set; }
        public GetOrderDetailQuery(int id)
        {
            this.id = id;
        }
    }
}
