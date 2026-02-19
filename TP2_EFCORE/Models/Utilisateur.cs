using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2_EFCORE.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required]
        public string Prenom { get; set; } = string.Empty;
        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public DateTime DateCreationCompte { get; set; }

        [NotMapped]
        public string NomComplet => $"{Prenom} {Nom}";

        // Navigations
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
        public ICollection<PresenceCours> PresencesCours { get; set; } = new List<PresenceCours>();
        public Moniteur? Moniteur { get; set; }
    }
}
