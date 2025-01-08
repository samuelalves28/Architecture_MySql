using API.Controllers.SystemMonitor.ViewModel;
using API.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers.SystemMonitor;

[Route("api/adm/systemmonitor")]

public class SystemMonitorController(IHubContext<SystemMonitorHub> hubContext) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> ReceiveData([FromBody] SystemMonitorRequestViewModel systemMonitorRequestViewModel)
    {
        await hubContext.Clients.All.SendAsync("ReceiveSystemData", systemMonitorRequestViewModel);
        return Ok();
    }
}