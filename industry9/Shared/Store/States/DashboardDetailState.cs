using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class DashboardDetailState : IHistoryState
    {
        public bool IsLoading { get; }
        public bool EditMode { get; }
        public IDashboardDetail Dashboard { get; }

        public bool CanUndo { get; }

        public DashboardDetailState(bool isLoading, bool editMode, IDashboardDetail dashboard, bool canUndo = false)
        {
            IsLoading = isLoading;
            EditMode = editMode;
            Dashboard = dashboard;
            CanUndo = canUndo;
        }
    }
}
