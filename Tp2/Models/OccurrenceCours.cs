namespace Tp2.Models
{
    public class OccurrenceCours
    {
        public int Id { get; set; }
        public int GroupeId { get; set; }
        public CoursGroupe Groupe { get; set; }
        public int MoniteurDeCeCoursId { get; set; }
        public Moniteurs MoniteurDeCeCours { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public ICollection<Utilisateurs> Utilisateurs { get; set; }
        public ICollection<PresenceCours> PresenceCours { get; set; }
    }
}
