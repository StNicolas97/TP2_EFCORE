namespace TP2_EFCORE.Models
{
    public class Moniteur
    {
        public int Id { get; set; }
        public string NoLicence { get; set; }

        //Navigations
        public int UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public ICollection<Occurence> Occurences { get; set; }
        public ICollection<Groupe> Groupes { get; set; }
    }
}