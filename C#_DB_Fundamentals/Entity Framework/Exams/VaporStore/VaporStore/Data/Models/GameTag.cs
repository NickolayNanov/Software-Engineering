using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class GameTag
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }

        [Required]
        public int TagId { get; set; }

        [Required]
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; }
    }
}
