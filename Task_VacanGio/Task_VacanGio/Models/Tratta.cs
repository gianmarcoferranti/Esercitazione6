using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_VacanGio.Models
{
    [Table("Tratta")]

    public class Tratta
    {
        [Key]
        public int TrattaID { get; set; }

        public int DestinazioneRif { get; set; }
        public int PacchettoRif { get; set; }

        [ForeignKey("DestinazioneRif")]
        public Destinazione Destinazione { get; set; } = null!;

        [ForeignKey("PacchettoRif")]
        public Pacchetto Pacchetto { get; set; } = null!;


    }
}
