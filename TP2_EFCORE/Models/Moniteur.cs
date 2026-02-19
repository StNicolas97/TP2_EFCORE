using System.ComponentModel.DataAnnotations;

namespace TP2_EFCORE.Models
{
    public class Moniteur
    {
        public int Id { get; set; }

        //nav vers Utilisateur
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        [Required]
        public string NoLicence { get; set; } = string.Empty;

        //liens vers autres tables
        public ICollection<Occurrence> Occurrences { get; set; } = new List<Occurrence>();
        public ICollection<CoursGroupe> GroupesParDefault { get; set; } = new List<CoursGroupe>();

    }
}
