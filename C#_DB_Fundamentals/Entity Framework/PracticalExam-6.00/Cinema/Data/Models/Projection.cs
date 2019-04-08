namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Projection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }
        
        [Required]
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }

        [Required]
        public int HallId { get; set; }

        [Required]
        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Projection()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}
