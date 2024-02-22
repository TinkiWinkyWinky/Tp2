using System.ComponentModel.DataAnnotations.Schema;

namespace Tp2.Models
{
    public class Inscriptions
    {
        public int Id { get; set; }
        public int UtilisateurId { get; set; }
        public Utilisateurs Utilisateur { get; set; }
        public int CoursGroupeId { get; set; }
        public CoursGroupe CoursGroupe { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateInscription { get; private set; }
    }
}
