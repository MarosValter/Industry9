using industry9.Shared.Dto.Dashboard;
using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class HomepageState : IHistoryState
    {
        public bool IsLoading { get; }
        public bool EditMode { get; }
        public DashboardData Dashboard { get; }

        public bool CanUndo { get; }

        public HomepageState(bool isLoading, bool editMode, DashboardData dashboard, bool canUndo = false)
        {
            IsLoading = isLoading;
            EditMode = editMode;
            Dashboard = dashboard;
            CanUndo = canUndo;
        }
    }
}
