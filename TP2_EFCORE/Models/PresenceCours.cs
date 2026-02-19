namespace TP2_EFCORE.Models
{
    public class PresenceCours
    {
        public int OccurrenceDuCoursId { get; set; }
        public OccurrenceCours OccurrenceDuCours { get; set; } = default!;

        public int ParticipantId { get; set; }
        public Utilisateur Participant { get; set; } = default!;
    }
}
