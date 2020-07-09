namespace industry9.Shared.Store.Features.Dashboard.Actions
{
    public class DeleteDashboardAction
    {
        public string Id { get; }

        public DeleteDashboardAction(string id)
        {
            Id = id;
        }
    }
}
