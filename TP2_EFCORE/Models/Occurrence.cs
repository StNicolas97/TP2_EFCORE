namespace TP2_EFCORE.Models
{
    public class Occurrence
    {
        public int Id { get; set; }

        public int GroupeId { get; set; }
        public CoursGroupe Groupe { get; set; }

        public int MoniteurDeCeCoursId { get; set; }
        public Moniteur MoniteurDeCeCours { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public ICollection<PresenceCours> PresencesCours { get; set; } = new List<PresenceCours>();
    }
}
