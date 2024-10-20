using Task_VacanGio.Models;

namespace Task_VacanGio.Repos
{
    public class TrattaRepo
    {

        private readonly VacanGioContext _context;
      

        public TrattaRepo(VacanGioContext context)
        {
            _context = context;
           
        }

        public IEnumerable<Pacchetto> GetByCodiceDestination(int id)
        {
            return _context.Tratte
            .Where(tratta => tratta.DestinazioneRif == id)
            .Join(_context.Pacchetti,
                  tratta => tratta.PacchettoRif,
                  pacchetto => pacchetto.PacchettoID,
                  (tratta, pacchetto) => pacchetto)
            .Distinct().ToList();
            //return (IEnumerable<Pacchetto>)_context.Tratte.ToList();
        }


    }
}
