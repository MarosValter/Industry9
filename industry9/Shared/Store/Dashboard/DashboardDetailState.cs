using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.Dashboard
{
    public class DashboardDetailState : IHistoryState
    {
        public bool IsLoading { get; }
        public bool EditMode { get; }
        public IDashboardDetail SelectedDashboard { get; }

        public bool CanUndo { get; }

        public DashboardDetailState(bool isLoading, bool editMode, IDashboardDetail selectedDashboard, bool canUndo = false)
        {
            IsLoading = isLoading;
            EditMode = editMode;
            SelectedDashboard = selectedDashboard;
            CanUndo = canUndo;
        }
    }
}
