namespace TP2_EFCORE.Models
{
    public class Moniteur
    {
        public int Id { get; set; }
        public int NoLicence { get; set; }

        //Navigations
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public ICollection<OccurenceCours> Occurences { get; set; }
        public ICollection<CoursGroupe> Groupes { get; set; }
    }
}