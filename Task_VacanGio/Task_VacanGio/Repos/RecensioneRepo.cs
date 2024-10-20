using Microsoft.EntityFrameworkCore;
using Task_VacanGio.Models;

namespace Task_VacanGio.Repos
{
    public class RecensioneRepo
    {
        private readonly VacanGioContext _context;

        public RecensioneRepo(VacanGioContext context)
        {
            _context = context;
        }

        public bool Create(Recensione entity)
        {
            bool risultato = false;
            try
            {
                _context.Recensioni.Add(entity);
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

        public bool Elimina(Recensione varVid)
        {
            bool risultato = false;
            try
            {
                var receFind = _context.Recensioni.SingleOrDefault(s => s.Codice == varVid.Codice);
                if (receFind != null)
                {
                    _context.Recensioni.Remove(receFind);
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

        public Recensione? Get(int id)
        {
            return _context.Recensioni.Find(id);
        }
        public Recensione? GetByCodice(string cod)
        {
            return _context.Recensioni.FirstOrDefault(v => v.Codice == cod);
        }
        public IEnumerable<Recensione>? GetByIdUtente(int id)
        {
            return _context.Recensioni.Where(v => v.UtenteRif == id).ToList();
        }


        public IEnumerable<Recensione> GetAll()
        {
            return _context.Recensioni.ToList();
        }

        public bool Update(Recensione entity)
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
