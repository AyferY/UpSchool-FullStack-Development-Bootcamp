using Microsoft.AspNetCore.SignalR;
using UpStorage.Domain.Dtos;
using UpStorage.Domain.Entities;
using UpStorage.Infrastructure.Contexts;

namespace UpStorage.WebApi.Hubs
{
    public class UpStorageOrderEventHub:Hub
    {
        private readonly UpStorageDbContext _dbContext;
        public UpStorageOrderEventHub(UpStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddOrderEventAsync(UpStorageOrderEventDto orderEventDto)
        {
            try
            {
                var orderEvent = new OrderEvent()
                {
                    OrderId = orderEventDto.OrderId,
                    Status = orderEventDto.Status
                };

                await _dbContext.OrderEvents.AddAsync(orderEvent);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            await Clients.AllExcept(Context.ConnectionId).SendAsync("AddedOrderEvent", orderEventDto);

            return true;
        }
    }
}
