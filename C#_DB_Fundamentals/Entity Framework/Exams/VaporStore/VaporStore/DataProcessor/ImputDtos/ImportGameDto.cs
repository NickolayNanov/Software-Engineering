namespace VaporStore.DataProcessor.ImputDtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportUserDto
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [MinLength(1)]
        public List<string> Tags { get; set; }
    }
}
