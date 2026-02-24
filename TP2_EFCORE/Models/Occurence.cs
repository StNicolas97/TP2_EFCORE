namespace TP2_EFCORE.Models
{
    public class Occurence
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        //Navigations
        public int GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        public int MoniteurDeCoursId { get; set; }
        public Moniteur Moniteur { get; set; }

        public ICollection<PresenceCours> PresencesCours { get; set; }

    }
}
