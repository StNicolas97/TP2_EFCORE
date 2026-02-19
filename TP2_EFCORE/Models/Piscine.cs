using System.ComponentModel.DataAnnotations;

namespace TP2_EFCORE.Models
{
    public class Piscine
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nom { get; set; } = string.Empty;

        [Required]
        public string Adresse { get; set; } = string.Empty;

        [Required]
        public string Ville { get; set; } = string.Empty;

        [MaxLength(6)]
        [Required]
        public string CodePostal { get; set; } = string.Empty;

        [Required]
        public int CapaciteMaximale { get; set; }

        //Piscine est en relation avec groupe donc:
        public ICollection<CoursGroupe> Groupes { get; set; } = new List<CoursGroupe>();
    }
}
