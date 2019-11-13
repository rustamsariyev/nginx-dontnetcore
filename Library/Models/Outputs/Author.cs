using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class Author
    {
        [JsonProperty(PropertyName = "author_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "author_name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "updated_by")]
        public int UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "deleted_by")]
        public int DeletedBy { get; set; }
        [JsonProperty(PropertyName = "updated_on")]
        public int UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "deleted_on")]
        public int DeletedOn { get; set; }
        [JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
