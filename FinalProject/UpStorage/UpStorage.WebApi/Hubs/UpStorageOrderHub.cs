using Microsoft.AspNetCore.SignalR;
using UpStorage.Domain.Dtos;
using UpStorage.Domain.Entities;
using UpStorage.Infrastructure.Contexts;

namespace UpStorage.WebApi.Hubs
{
    public class UpStorageOrderHub: Hub
    {
        private readonly UpStorageDbContext _dbContext;
        public UpStorageOrderHub(UpStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddOrderAsync(UpStorageOrderDto orderDto)
        {
            try
            {
                var order = new Order()
                {
                    CreatedOn = orderDto.CreatedOn,
                    Id = orderDto.Id,
                    RequestedAmount = orderDto.RequestedAmount,
                    ProductCrawlType = orderDto.ProductCrawlType,
                    TotalFoundAmount = orderDto.TotalFoundAmount
                };

                await _dbContext.Orders.AddAsync(order);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            await Clients.AllExcept(Context.ConnectionId).SendAsync("AddedOrder", orderDto);

            return true;
        }
    }
}
