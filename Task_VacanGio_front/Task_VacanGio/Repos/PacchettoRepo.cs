using Microsoft.EntityFrameworkCore;
using Task_VacanGio.Models;

namespace Task_VacanGio.Repos
{
    public class PacchettoRepo : IRepo<Pacchetto>
    {

        private readonly VacanGioContext _context;

        public PacchettoRepo(VacanGioContext context)
        {
            _context = context;
        }

        public bool Create(Pacchetto entity)
        {
            bool risultato = false;
            try
            {
                _context.Pacchetti.Add(entity);
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

        public bool Elimina(Pacchetto varPac)
        {
            bool risultato = false;
            try
            {
                var pacchettoFind = _context.Pacchetti.SingleOrDefault(s => s.Codice == varPac.Codice);
                if (pacchettoFind != null)
                {
                    _context.Pacchetti.Remove(pacchettoFind);
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

        public Pacchetto? Get(int id)
        {
            return _context.Pacchetti.Find(id);
        }
        public Pacchetto? GetByCodice(string cod)
        {
            return _context.Pacchetti.FirstOrDefault(v => v.Codice == cod);
        }
   

        public IEnumerable<Pacchetto> GetAll()
        {
            return _context.Pacchetti.ToList();
        }

        public bool Update(Pacchetto entity)
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
