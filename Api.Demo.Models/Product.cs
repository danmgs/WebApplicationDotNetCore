using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Demo.Models
{
    [ElasticsearchType(Name = "default", IdProperty = "_id")]
    //[ElasticsearchType(Name = "default")]
    public class Product
    {
        [Text(Name = "_id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Sold { get; set; }

        [Text(Name = "in_stock")]
        public int InStock { get; set; }

        [Text(Name = "is_active")]
        public bool IsActive { get; set; }

        public DateTime Created { get; set; }

        public List<String> Tags { get; set; }
    }
}
