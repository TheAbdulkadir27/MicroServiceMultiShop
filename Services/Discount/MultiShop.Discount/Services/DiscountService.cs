using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dappercontext;
        public DiscountService(DapperContext dappercontext)
        {
            _dappercontext = dappercontext;
        }
        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string Query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values(@code,@rate,@ısactive,@ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@ısactive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);
            using (var connection = _dappercontext.CreateConnection())
            {
                await connection.ExecuteAsync(Query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string Query = "delete from Coupons where CouponID=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using (var connection = _dappercontext.CreateConnection())
            {
                await connection.ExecuteAsync(Query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string Query = "select *from Coupons";
            using (var connection = _dappercontext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(Query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "select *from Coupons where CouponID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _dappercontext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code, Rate=@rate, IsActive=@ısactive, ValidDate=@ValidDate where CouponID=@ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", updateCouponDto.CouponID);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@ısactive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            using (var connection = _dappercontext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
