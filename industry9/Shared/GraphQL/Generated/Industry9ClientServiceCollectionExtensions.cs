using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Pipelines;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Serializers;
using StrawberryShake.Transport;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public static partial class industry9ClientServiceCollectionExtensions
    {
        private const string _clientName = "industry9Client";

        public static IOperationClientBuilder Addindustry9Client(
            this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<IIndustry9Client, Industry9Client>();

            serviceCollection.AddSingleton<IOperationExecutorFactory>(sp =>
                new HttpOperationExecutorFactory(
                    _clientName,
                    sp.GetRequiredService<IHttpClientFactory>().CreateClient,
                    sp.GetRequiredService<IClientOptions>().GetOperationPipeline<IHttpOperationContext>(_clientName),
                    sp.GetRequiredService<IClientOptions>().GetOperationFormatter(_clientName),
                    sp.GetRequiredService<IClientOptions>().GetResultParsers(_clientName)));

            serviceCollection.AddSingleton<IOperationStreamExecutorFactory>(sp =>
                new SocketOperationStreamExecutorFactory(
                    _clientName,
                    sp.GetRequiredService<ISocketConnectionPool>().RentAsync,
                    sp.GetRequiredService<ISubscriptionManager>(),
                    sp.GetRequiredService<IClientOptions>().GetOperationFormatter(_clientName),
                    sp.GetRequiredService<IClientOptions>().GetResultParsers(_clientName)));

            IOperationClientBuilder builder = serviceCollection.AddOperationClientOptions(_clientName)
                .AddValueSerializer(() => new WidgetTypeValueSerializer())
                .AddValueSerializer(() => new DataSourceTypeValueSerializer())
                .AddValueSerializer(() => new DashboardInputSerializer())
                .AddValueSerializer(() => new LabelDataInputSerializer())
                .AddValueSerializer(() => new WidgetInputSerializer())
                .AddValueSerializer(() => new ColumnMappingDataInputSerializer())
                .AddValueSerializer(() => new DataSourceDefinitionInputSerializer())
                .AddResultParser(serializers => new GetDashboardsResultParser(serializers))
                .AddResultParser(serializers => new GetDashboardResultParser(serializers))
                .AddResultParser(serializers => new GetWidgetsResultParser(serializers))
                .AddResultParser(serializers => new GetWidgetResultParser(serializers))
                .AddResultParser(serializers => new GetDataSourceDefinitionsResultParser(serializers))
                .AddResultParser(serializers => new GetDataSourceDefinitionResultParser(serializers))
                .AddResultParser(serializers => new UpsertDashboardResultParser(serializers))
                .AddResultParser(serializers => new DeleteDashboardResultParser(serializers))
                .AddResultParser(serializers => new UpsertWidgetResultParser(serializers))
                .AddResultParser(serializers => new DeleteWidgetResultParser(serializers))
                .AddResultParser(serializers => new UpsertDataSourceDefinitionResultParser(serializers))
                .AddResultParser(serializers => new DeleteDataSourceDefinitionResultParser(serializers))
                .AddResultParser(serializers => new OnDataReceivedResultParser(serializers))
                .AddOperationFormatter(serializers => new JsonOperationFormatter(serializers))
                .AddHttpOperationPipeline(b => b.UseHttpDefaultPipeline());

            serviceCollection.TryAddSingleton<ISubscriptionManager, SubscriptionManager>();
            serviceCollection.TryAddSingleton<IOperationExecutorPool, OperationExecutorPool>();
            serviceCollection.TryAddEnumerable(new ServiceDescriptor(
                typeof(ISocketConnectionInterceptor),
                typeof(MessagePipelineHandler),
                ServiceLifetime.Singleton));
            return builder;
        }

    }
}
