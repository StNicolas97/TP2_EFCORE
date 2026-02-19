namespace TP2_EFCORE.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public int NumeroGroupe { get; set; }

        public int CoursId { get; set; }
        public Cours Cours { get; set; } = null!;

        public int MoniteurParDefaultId { get; set; }
        public Moniteur MoniteurParDefault { get; set; } = null!;

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public int PiscineId { get; set; }
        public Piscine Piscine { get; set; } = null!;

        public ICollection<Occurrence> Occurrences { get; set; } = new List<Occurrence>();
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    }
}
