using Microsoft.EntityFrameworkCore;
using Task_VacanGio.Models;

namespace Task_VacanGio.Repos
{
    public class DestinazioneRepo : IRepo<Destinazione>
    {
        private readonly VacanGioContext _context;

        public DestinazioneRepo(VacanGioContext context)
        {
            _context = context;
        }

        public bool Create(Destinazione entity)
        {
            bool risultato = false;
            try
            {
                _context.Destinazioni.Add(entity);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Elimina(Destinazione varDest)
        {
            bool risultato = false;
            try
            {
                var destFind = _context.Destinazioni.SingleOrDefault(s => s.Codice == varDest.Codice);
                if (destFind != null)
                {
                    _context.Destinazioni.Remove(destFind);
                    _context.SaveChanges();
                    risultato = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                risultato = false;
            }
            return risultato;

        }

        public Destinazione? Get(int id)
        {
            return _context.Destinazioni.Find(id);
        }
        public Destinazione? GetByCodice(string cod)
        {
            return _context.Destinazioni.FirstOrDefault(v => v.Codice == cod);
        }

        public IEnumerable<Destinazione> GetAll()
        {
            return _context.Destinazioni.ToList();
        }

        public bool Update(Destinazione entity)
        {
            bool risultato = false;
            try
            {
                _context.Update(entity).State = EntityState.Modified;
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return risultato;
        }

    }
}
