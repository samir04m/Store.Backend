using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Store.Business.DTOs
{
    public class ProductDto
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [JsonProperty("description")]
        public string Description { get; set; }

        [StringLength(500)]
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [Required]
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }
    }
}
