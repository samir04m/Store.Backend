using Newtonsoft.Json;

namespace Store.Data.Entities
{
    public class Product
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        //[StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        //[StringLength(500)]
        [JsonProperty("description")]
        public string Description { get; set; }

        //[StringLength(500)]
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        //[Required]
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
