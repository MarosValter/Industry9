using System;
using Fluxor;
using industry9.Client.Data.Store.Base;
using industry9.Client.Data.Store.Base.Actions;
using industry9.Common.Enums;
using StrawberryShake;

namespace industry9.Client.Data.Store.Extensions
{
    public static class OperationResultExtensions
    {
        public static void DispatchToast(this IOperationResult result, IDispatcher dispatcher, string successMessage, string errorTitle)
        {
            if (!result.IsErrorResult())
            {
                var successAction = new ApiResultAction(successMessage, ToastType.Success);
                dispatcher.Dispatch(successAction);
                return;
            }

            foreach (var error in result.Errors)
            {
                var errorAction = new ApiResultAction(error.Message, ToastType.Danger, errorTitle);
                dispatcher.Dispatch(errorAction);
            }
        }

        public static void DispatchToast(this IOperationResult result, IDispatcher dispatcher,
            string objectName,  CRUDOperation operation)
        {
            string title;
            string message;
            switch (operation)
            {
                case CRUDOperation.Create:
                    title = $"Create {objectName}";
                    message = $"{objectName} successfully created";
                    break;
                case CRUDOperation.Update:
                    title = $"Update {objectName}";
                    message = $"{objectName} successfully updated";
                    break;
                case CRUDOperation.Delete:
                    title = $"Delete {objectName}";
                    message = $"{objectName} successfully deleted";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }

            DispatchToast(result, dispatcher, message, title);
        }
    }
}
