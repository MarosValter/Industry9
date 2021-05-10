using Fluxor;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Notification
{
    public class NotificationFeature : Feature<NotificationState>
    {
        public override string GetName() => "Notification";

        protected override NotificationState GetInitialState() => new NotificationState(null);
    }
}
