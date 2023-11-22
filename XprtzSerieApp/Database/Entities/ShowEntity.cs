using System.ComponentModel.DataAnnotations;

namespace XprtzSerieApp.Database.Entities
{
    public class ShowEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public DateTime Premiered { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
