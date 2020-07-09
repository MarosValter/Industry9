using industry9.Shared.Store.Base;

namespace industry9.Shared.Store.States
{
    public class NotificationState
    {
        public Notification LastNotification { get; }

        public NotificationState(Notification lastNotification)
        {
            LastNotification = lastNotification;
        }
    }
}
