using industry9.Shared.Dto.Dashboard;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class HomepageState// : IHistoryState
    {
        public bool IsLoading { get; }
        public DashboardData Dashboard { get; }

        //public bool CanUndo { get; }

        public HomepageState(bool isLoading, DashboardData dashboard, bool canUndo = false)
        {
            IsLoading = isLoading;
            Dashboard = dashboard;
            //CanUndo = canUndo;
        }
    }
}
