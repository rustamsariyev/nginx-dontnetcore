﻿using Library.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Outputs
{
    public class Book
    {
        [JsonProperty(PropertyName = "book_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "book_name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "author_id")]
        public int AuhorId { get; set; }
        [JsonProperty(PropertyName = "language_id")]
        public int LanguageId { get; set; }
        [JsonProperty(PropertyName = "publishing_house_id")]
        public int PublishingHouseId { get; set; }
        [JsonProperty(PropertyName = "category_id")]
        public int CategoryId { get; set; }
        [JsonProperty(PropertyName = "book_location_id")]
        public int LocationId { get; set; }
        [JsonProperty(PropertyName = "updated_by")]
        public int? UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "deleted_by")]
        public int? DeletedBy { get; set; }
        [JsonProperty(PropertyName = "updated_on")]
        public int? UpdatedOn { get; set; }
        [JsonProperty(PropertyName = "deleted_on")]
        public int? DeletedOn { get; set; }
        [JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }
        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }
    }
}
