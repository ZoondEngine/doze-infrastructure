using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Nt.Server.Database.Models
{
    [Table("user_subscriptions")]
    public class UserSubscription
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("is_locked")]
        public bool IsLocked { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("bought_at")]
        public DateTime BoughtAt { get; set; }

        [Column("expired_at")]
        public DateTime ExpiredAt { get; set; }
    }
}
