using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FredsBoats.Web.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        [Column("commentid")]
        public int CommentId { get; set; }

        [Column("content")]
        public string Content { get; set; } = string.Empty;

        [Column("author")]
        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("fkboatid")]
        public int BoatId { get; set; }

        public ICollection<Boat> Boats { get; set; } = new List<Boat>();
    }
}