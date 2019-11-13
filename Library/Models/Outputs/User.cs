using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class User
    {
        [JsonProperty(PropertyName = "user_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "user_name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "user_updated_by")]
        public int UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "user_deleted_by")]
        public int DeletedBy { get; set; }
        [JsonProperty(PropertyName = "user_updated_on")]
        public DateTime UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "user_deleted_on")]
        public DateTime DeletedOn { get; set; }
        [JsonProperty(PropertyName = "user_is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
