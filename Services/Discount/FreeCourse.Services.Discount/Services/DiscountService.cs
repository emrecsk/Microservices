using Dapper;
using FreeCourse.Shared.DTOs;
using Npgsql;
using System.Data;

namespace FreeCourse.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL"));
        }

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("DELETE FROM discount WHERE Id=@Id", new { Id = id });
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("SELECT * FROM discount");
            return Response<List<Models.Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discount = await _dbConnection.QueryFirstOrDefaultAsync<Models.Discount>("SELECT * FROM discount WHERE Code=@Code AND UserId=@UserId", new { Code = code, UserId = userId });

            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Discount not found", 404);
            }
            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<Models.Discount>> GetById(int id)
        {
            var discount = await _dbConnection.QueryFirstOrDefaultAsync<Models.Discount>("SELECT * FROM discount WHERE Id=@Id", new { Id = id });
            if (discount == null)
            {
                return Response<Models.Discount>.Fail("Discount not found", 404);
            }
            return Response<Models.Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("INSERT INTO discount (UserId, Code, Rate) VALUES (@UserId, @Code, @Rate)", discount);
            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("An error occurred while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("UPDATE discount SET UserId=@UserId, Code=@Code, Rate=@Rate WHERE Id=@Id", new
            {
                Id = discount.Id,
                UserId = discount.UserId,
                Code = discount.Code,
                Rate = discount.Rate
            });

            if (status > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("An error occurred while updating", 500);
        }
    }
}
