using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doze.Nt.Server.Database.Models
{
    [Table("store_products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("creator_id")]
        public int CreatorId { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("available")]
        public bool IsAvailable { get; set; }
    }
}
