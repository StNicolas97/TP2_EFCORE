using TP2_EFCORE.Models;

namespace TP2_EFCORE.Models
{
    public class Groupe
    {
        public int Id { get; set; }
        public int NumeroGroupe { get; set; }
        public DateTime DateDebut {  get; set; }
        public DateTime DateFin {  get; set; }

        //Navigation
        public int CoursId { get; set; }
        public Cours Cours { get; set; }

        public int PiscineId { get; set; }
        public Piscine Piscine { get; set; }

        public int MoniteurParDefautId { get; set; }
        public Moniteur Moniteur {  get; set; }

        public ICollection<Occurence> Occurences { get; set; }
        public ICollection<Inscription> Inscriptions { get; set; }
    }
}