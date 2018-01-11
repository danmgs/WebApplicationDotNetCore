using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDotNetCore.Models.Config
{
    public class ElasticSearchSettings
    {
        public string IndexName { get; set; }
        public string TypeName { get; set; }
        public string EndpointUrl { get; set; }
    }
}
