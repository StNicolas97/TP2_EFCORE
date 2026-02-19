namespace TP2_EFCORE.Models
{
    public class Inscription
    {
        public int Id { get; set; }

        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; } = null!;

        public int CoursGroupeId { get; set; }
        public CoursGroupe CoursGroupe { get; set; } = null!;

        public DateTime DateInscription { get; private set; }
    }
}
