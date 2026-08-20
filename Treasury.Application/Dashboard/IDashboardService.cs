using Treasury.Domain.Entities;

namespace Treasury.Application.Dashboard;

public interface IDashboardService
{
    Task<DashboardModel> GetDashboardAsync();

}
