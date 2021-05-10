using Fluxor;
using industry9.Client.Data.Store.Base.Actions;
using industry9.Client.Data.Store.States;

namespace industry9.Client.Data.Store.Features.Notification.Reducers
{
    public class NotificationReducer
    {
        [ReducerMethod]
        public static NotificationState ReduceApiResultAction(NotificationState state, ApiResultAction action)
            => new NotificationState(new Base.Notification(action.Message, action.Type, action.Title));
    }
}
