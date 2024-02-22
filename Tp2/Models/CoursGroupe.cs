namespace Tp2.Models
{
    public class CoursGroupe
    {
        public int Id { get; set; }
        public int NumeroGroupe { get; set; }
        public int CoursId { get; set; }
        public Cours Cours { get; set; }
        public int MoniteurParDefaultId { get; set; }
        public Moniteurs MoniteurParDefault { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int PiscineId { get; set; }
        public Piscines Piscine { get; set; }
    }
}
