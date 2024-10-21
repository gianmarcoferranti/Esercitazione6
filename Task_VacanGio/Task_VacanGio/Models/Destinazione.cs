using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_VacanGio.Models
{
    [Table("Destinazione")]
    public class Destinazione
    {
        [Key]
        public int DestinazioneID { get; set; }
        public string Codice { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string? Descrizione { get; set; }
        public string Paese { get; set; } = null!;
        public string? Immagine { get; set; }
    }
}
