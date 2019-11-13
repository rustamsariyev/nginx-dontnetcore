using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class UserBasket
    {
        [JsonProperty(PropertyName = "user_basket_id")]
        public int BasketId { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "book_id")]
        public int BookId { get; set; }
        [JsonProperty(PropertyName = "pick_up_date")]
        public DateTime PickUpDate { get; set; }
        [JsonProperty(PropertyName = "deadline_date")]
        public DateTime DeadlineDate { get; set; }
        [JsonProperty(PropertyName = "IsSubmitted")]
        public Boolean IsSubmitted { get; set; }
        [JsonProperty(PropertyName = "IsAccepted")]
        public Boolean IsAccepted { get; set; }
    }
}
