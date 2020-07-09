namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class UpsertDashboardResultAction
    {
        public bool SaveChanges { get; }
        public IDashboardDetail Dashboard { get; }

        public UpsertDashboardResultAction(IDashboardDetail dashboard, bool saveChanges = false)
        {
            Dashboard = dashboard;
            SaveChanges = saveChanges;
        }
    }
}
