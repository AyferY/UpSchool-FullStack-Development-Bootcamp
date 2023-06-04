using Microsoft.AspNetCore.SignalR;
using UpStorage.Domain.Dtos;
using UpStorage.Domain.Entities;
using UpStorage.Infrastructure.Contexts;

namespace UpStorage.WebApi.Hubs
{
    public class UpStorageProductHub : Hub
    {
        private readonly UpStorageDbContext _dbContext;
        public UpStorageProductHub(UpStorageDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
