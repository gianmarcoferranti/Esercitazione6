namespace Task_VacanGio.Models
{
    public class UtenteDTO
    {
        public string? Cod { get; set; }
        public string? Nom { get; set; }
        public string? Cog { get; set; }
        public int? Tel { get; set; }
        public string? Ema { get; set; }
        public List<RecensioneDTO> Ele { get; set; } = new List<RecensioneDTO>();

    }
}
