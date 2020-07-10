﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public DataSourceDefinitionData()
        {
            Created = DateTime.Now;
            Inputs = Enumerable.Empty<string>().ToList();
        }
    }
}
