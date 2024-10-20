using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_VacanGio.Models
{
    [Table("Utente")]
    public class Utente
    {
        [Key]
        public int UtenteID { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public int? Telefono { get; set; }
        public string? Email { get; set; }
        //public virtual ICollection<Recensione> Recensione { get; set; } = new List<Recensione>();


    }
}
