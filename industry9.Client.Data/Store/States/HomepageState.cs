using industry9.Client.Data.Dto.Dashboard;

namespace industry9.Client.Data.Store.States
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
