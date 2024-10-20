namespace Task_VacanGio.Models
{
    public class RecensioneDTO
    {
        public string? Cod { get; set; }
        public int? Vot { get; set; }
        public string? Comm { get; set; }
        public DateOnly? Dtr { get; set; }
        public UtenteDTO? Ute { get; set; }
        public PacchettoDTO? Pac { get; set; }


    }
}
