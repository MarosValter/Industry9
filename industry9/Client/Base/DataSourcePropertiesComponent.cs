using System.Threading.Tasks;
using industry9.Client.Data.Dto.DataSourceDefinition.Properties;
using Microsoft.AspNetCore.Components;

namespace industry9.Client.Base
{
    public class DataSourcePropertiesComponent<TProperties> : ComponentBase
        where TProperties : class, IDataSourcePropertiesData, new()
    {
        protected TProperties PropertiesInternal = new TProperties();

        [Parameter]
        public IDataSourcePropertiesData Properties
        {
            get => PropertiesInternal;
            set => PropertiesInternal = value as TProperties ?? PropertiesInternal;
        }

        [Parameter]
        public EventCallback<IDataSourcePropertiesData> PropertiesChanged { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await PropertiesChanged.InvokeAsync(PropertiesInternal);
            }
        }
    }
}
