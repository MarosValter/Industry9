using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using industry9.Shared.Dto.DataSourceDefinition.Properties;

namespace industry9.Shared.Dto.DataSourceDefinition
{
    public class DataSourceDefinitionData
    {
        public string Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DataSourceType Type { get; set; }

        public IList<string> Inputs { get; set; }

        public IDataSourcePropertiesData Properties { get; set; }

        public IList<ExportedColumnData> Columns { get; set; }

        public DataSourceDefinitionData()
        {
            Created = DateTime.Now;
            Inputs = Enumerable.Empty<string>().ToList();
            Columns = Enumerable.Empty<ExportedColumnData>().ToList();
        }
    }
}
