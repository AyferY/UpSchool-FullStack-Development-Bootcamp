using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using UpStorage.Domain.Dtos;
using UpStorage.Domain.Entities;
using UpStorage.Infrastructure.Contexts;

namespace UpStorage.WebApi.Hubs
{
    public class UpStorageLogHub : Hub
    {
        public async Task SendLogNotificationAsync(UpStorageLogDto log)
        {
            await Clients.AllExcept(Context.ConnectionId).SendAsync("UpStorageLogAdded", log);
        }
    }
}