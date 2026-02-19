using System.ComponentModel.DataAnnotations;

namespace TP2_EFCORE.Models
{
    public class Cours
    {

        public int Id { get; set; }

        [Required]
        public string Titre { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int NombreMaximalSuggere { get; set; }
        [Required]
        public int DureeDuCoursMinutes { get; set; }

        // navigations
        public int? CoursPrealableId { get; set; }
        public Cours? CoursPrealable { get; set; }

        public ICollection<Cours> CoursSuivants { get; set; } = new List<Cours>();
        public ICollection<CoursGroupe> Groupes { get; set; } = new List<CoursGroupe>();


    }
}
