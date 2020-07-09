using Fluxor;
using industry9.Shared.Store.States;

namespace industry9.Shared.Store.Features.Notification
{
    public class NotificationFeature : Feature<NotificationState>
    {
        public override string GetName() => "Notification";

        protected override NotificationState GetInitialState() => new NotificationState(null);
    }
}
