using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using UpStorage.Domain.Dtos;
using UpStorage.Domain.Entities;
using UpStorage.Infrastructure.Contexts;

namespace UpStorage.WebApi.Hubs
{
    public class UpStorageHub : Hub
    {
        private readonly UpStorageDbContext _dbContext;
        public UpStorageHub(UpStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SendLogNotificationAsync(UpStorageLogDto log)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("UpStorageLogAdded", log);
        }
        public async Task<bool> AddProductAsync(UpStorageProductDto productDto)
        {
            try
            {
                var product = new Product()
                {
                    CreatedOn = DateTimeOffset.Now,
                    OrderId = productDto.OrderId,
                    Id = productDto.Id,
                    Name = productDto.Name,
                    IsOnSale = productDto.IsOnSale,
                    Picture = productDto.Picture,
                    Price = productDto.Price,
                    SalePrice = productDto.SalePrice,
                };

                await _dbContext.Products.AddAsync(product);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            await Clients.AllExcept(Context.ConnectionId).SendAsync("AddedProduct", productDto);

            return true;
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