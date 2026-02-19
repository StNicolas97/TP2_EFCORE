namespace TP2_EFCORE.Models
{
    public class PresenceCours
    {
        public int OccurrenceDuCoursId { get; set; }
        public Occurrence OccurrenceDuCours { get; set; }

        public int ParticipantId { get; set; }
        public Utilisateur Participant { get; set; }
    }
}
