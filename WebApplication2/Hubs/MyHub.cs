using Microsoft.AspNetCore.SignalR;

namespace WebApplication2.Hubs
{
    public class MyHub : Hub
    {

        public async Task AddContact(string value)
        {
            await Clients.All.SendAsync("ReceiveContact", value);
        }
        public async Task AddMessege(string value, string person)
        {
            await Clients.All.SendAsync("ReceiveMessege", value, person);
        }
    }
}