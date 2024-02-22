namespace Tp2.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int NombreMaximalSuggere { get; set; }
        public int DurreeDuCoursMinutes { get; set; }
        public int? CoursPrealableId { get; set; }
        public Cours CoursPrealable { get; set; }
    }
}
