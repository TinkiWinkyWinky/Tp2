using System.ComponentModel.DataAnnotations.Schema;

namespace Tp2.Models
{
    public class Utilisateurs
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime DateCreationCompte { get; set; }
        [NotMapped]
        public string NomComplet => $"{Prenom} {Nom}";
        public ICollection<OccurrenceCours> Occurrences { get; set; }
        public ICollection<PresenceCours> PresenceCours { get; set; }
        public ICollection<Inscriptions> Inscriptions { get; set; }
    }
}
