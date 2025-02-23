using Newtonsoft.Json;
using System.Collections.Generic;

namespace Store.Data.Entities
{
    public class Category
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        //[StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
