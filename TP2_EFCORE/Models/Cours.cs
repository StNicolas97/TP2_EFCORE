namespace TP2_EFCORE.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int NombreMaximalSuggere { get; set; }
        public int DureeDuCoursMinutes { get; set; }
        
        //Navigations
        public int? CoursPrealableId { get; set; }
        public Cours? CoursPrealable { get; set; }

        public ICollection<Groupe> Groupes { get; set; }

    }
}