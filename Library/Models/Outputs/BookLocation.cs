using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class BookLocation
    {
        [JsonProperty(PropertyName = "book_location_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "section")]
        public string Section { get; set; }
        [JsonProperty(PropertyName = "shelf")]
        public string Shelf { get; set; }
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
