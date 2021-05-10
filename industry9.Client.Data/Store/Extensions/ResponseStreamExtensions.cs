//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Threading;
//using System.Threading.Tasks;
//using HotChocolate.Execution;
//using StrawberryShake;

//namespace industry9.Client.Data.Store.Extensions
//{
//    public static class ResponseStreamExtensions
//    {
//        public static async IAsyncEnumerable<IOperationResult<T>> Cancellable<T>(this IResponseStream<T> source, [EnumeratorCancellation] CancellationToken cancellationToken)
//            where T : class
//        {
//            if (source == null)
//            {
//                throw new ArgumentNullException(nameof(source));
//            }

//            cancellationToken.ThrowIfCancellationRequested();

//            await foreach (var item in source.ReadResultsAsync().WithCancellation(cancellationToken))
//            {
//                cancellationToken.ThrowIfCancellationRequested();
//                yield return item.;
//            }

//            await source.DisposeAsync();
//        }
//    }
//}
