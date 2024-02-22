using System.ComponentModel.DataAnnotations;

namespace Tp2.Models
{
    public class Piscines
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        [MaxLength(6)]
        public string CodePostal { get; set; }
        public int CapaciteMaximale { get; set; }
    }
}
