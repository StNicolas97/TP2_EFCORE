namespace TP2_EFCORE.Models
{
    public class PresenceCours
    {
        public int OccurenceDuCoursId { get; set; }
        public Occurence Occurence {  get; set; }

        public int ParticipantId { get; set; }
        public Utilisateur Utilisateur {  get; set; }
    }
}
