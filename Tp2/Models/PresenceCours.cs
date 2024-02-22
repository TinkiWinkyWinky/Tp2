namespace Tp2.Models
{
    public class PresenceCours
    {
        public OccurrenceCours OccurrenceDuCours { get; set; }
        public int OccurrenceDuCoursId { get; set; }
        public Utilisateurs Participant { get; set; }
        public int ParticipantId { get; set; }
    }
}
