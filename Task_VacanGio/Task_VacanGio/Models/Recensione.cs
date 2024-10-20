using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_VacanGio.Models
{
    [Table("Recensione")]

    public class Recensione
    {
        [Key]
        public int RecensioneID { get; set; }
        public string Codice { get; set; } = null!;
        public int? Voto { get; set; }
        public string Commento { get; set; } = null!;
        public DateOnly? DataRecensione { get; set; } = null!;

        [Column("UtenteRIF")]
        public int UtenteRif { get; set; }
        [Column("PacchettoRIF")]
        public int PacchettoRif { get; set; }
        //public virtual Utente UtenteRifNavigation { get; set; } = null!;
        //public virtual Pacchetto PacchettoRifNavigation { get; set; } = null!;






    }
}
