namespace Tp2.Models
{
    public class Moniteurs
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateurs Utilisateur { get; set; }
        public string NoLicence { get; set; }
    }
}
