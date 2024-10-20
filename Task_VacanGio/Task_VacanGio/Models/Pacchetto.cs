using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_VacanGio.Models
{
    [Table("Pacchetto")]

    public class Pacchetto
    {
        [Key]
        public int PacchettoID { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public decimal? Prezzo { get; set; }
        public int? Durata { get; set; }
        public DateOnly? DataInizio { get; set; } = null!;
        public DateOnly? DataFine { get; set; } = null!;

        //public virtual ICollection<Recensione> Recensione { get; set; } = new List<Recensione>();

    }
}
