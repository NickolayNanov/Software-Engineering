﻿namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }

        public Developer()
        {
            this.Games = new HashSet<Game>();
        }
    }
}
