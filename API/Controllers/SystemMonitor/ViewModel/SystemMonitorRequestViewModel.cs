namespace API.Controllers.SystemMonitor.ViewModel;

public class SystemMonitorRequestViewModel
{
    public int CpuUsage { get; set; }
    public float MemoryUsagePercentage { get; set; }
    public DateTime Timestamp { get; set; }
}
