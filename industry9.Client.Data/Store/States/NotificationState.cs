using industry9.Client.Data.Store.Base;

namespace industry9.Client.Data.Store.States
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
