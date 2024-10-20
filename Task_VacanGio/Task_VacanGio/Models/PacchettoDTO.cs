namespace Task_VacanGio.Models
{
    public class PacchettoDTO
    {
        public string? Cod { get; set; }
        public string? Nom { get; set; }
        public decimal? Pre { get; set; }
        public int? Dur { get; set; }
        public DateOnly? Din { get; set; }
        public DateOnly? Dfi { get; set; }
        public List<RecensioneDTO> Ele { get; set; } = new List<RecensioneDTO>();

    }
}
