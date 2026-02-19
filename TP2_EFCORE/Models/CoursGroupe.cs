namespace TP2_EFCORE.Models
{
    public class CoursGroupe
    {
        public int Id { get; set; }
        public int NumeroGroupe { get; set; }

        public int CoursId { get; set; }
        public Cours Cours { get; set; }

        public int MoniteurParDefaultId { get; set; }
        public Moniteur MoniteurParDefault { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public int PiscineId { get; set; }
        public Piscine Piscine { get; set; }

        public ICollection<OccurrenceCours> Occurrences { get; set; } = new List<OccurrenceCours>();
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
    }

}
