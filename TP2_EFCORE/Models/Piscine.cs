using System.ComponentModel.DataAnnotations;

namespace TP2_EFCORE.Models
{
    public class Piscine
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nom {  get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }

        [MaxLength(6)]
        public string CodePostal { get; set; }
        public int CapaciteMaximale { get; set; }

        public ICollection<Groupe> Groupes { get; set; }

    }
}