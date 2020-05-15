using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.Dashboard
{
    public class DashboardState : IHistoryState
    {
        public bool IsLoading { get; }
        public bool EditMode { get; }
        public IDashboard SelectedDashboard { get; }

        public bool CanUndo { get; }

        public DashboardState(bool isLoading, bool editMode, IDashboard selectedDashboard, bool canUndo = false)
        {
            IsLoading = isLoading;
            EditMode = editMode;
            SelectedDashboard = selectedDashboard;
            CanUndo = canUndo;
        }
    }
}
