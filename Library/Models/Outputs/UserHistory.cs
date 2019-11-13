using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class UserHistory
    {
        [JsonProperty(PropertyName = "user_history_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "book_id")]
        public int BookId { get; set; }
        [JsonProperty(PropertyName = "return_date")]
        public int ReturnDate { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
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
        [JsonProperty(PropertyName ="pick_up_date")]
        public DateTime PickUpDate { get; set; }
        [JsonProperty(PropertyName = "is_returned")]
        public DateTime IsReturned { get; set; }
    }
}
