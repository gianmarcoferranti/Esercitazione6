using Microsoft.EntityFrameworkCore;
using Task_VacanGio.Models;

namespace Task_VacanGio.Repos
{
    public class UtenteRepo : IRepo<Utente>
    {
        private readonly VacanGioContext _context;

        public UtenteRepo(VacanGioContext context)
        {
            _context = context;
        }

        public bool Create(Utente entity)
        {
            bool risultato = false;
            try
            {
                _context.Utenti.Add(entity);
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

        public bool Elimina(Utente varVid)
        {
            bool risultato = false;
            try
            {
                var uteFind = _context.Utenti.SingleOrDefault(s => s.Codice == varVid.Codice);
                if (uteFind != null)
                {
                    _context.Utenti.Remove(uteFind);
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

        public Utente? Get(int id)
        {
            return _context.Utenti.Find(id);
        }
        public Utente? GetByCodice(string cod)
        {
            return _context.Utenti.FirstOrDefault(v => v.Codice == cod);
        }

        public IEnumerable<Utente> GetAll()
        {
            return _context.Utenti.ToList();
        }

        public bool Update(Utente entity)
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
