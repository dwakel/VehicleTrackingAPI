using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Gps.Api.Service
{
    public interface ILocationHubService
    {
        Task PinpointLocation(string lat, string lon);
    }

    public class LocationHub : Hub<ILocationHubService>
    {
    }
}