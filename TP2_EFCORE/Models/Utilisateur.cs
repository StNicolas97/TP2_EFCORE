using System.ComponentModel.DataAnnotations.Schema;

namespace TP2_EFCORE.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Prenom {  get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateCreationCompte  { get; set; }

        [NotMapped]
        public string NomComplet => $"{Nom} {Prenom}";

        //Navigations
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
        public ICollection<PresenceCours> PresencesCours { get; set; } = new List<PresenceCours>();

        public Moniteur? Moniteur { get; set; }
    }
}
