using System.Linq;
using System.Threading.Tasks;
using Contatos.Domain;
using Contatos.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Repository.Repository
{
    public class ContatosRepository : IContatosRepository
    {
        public Context _context { get; set; }
        public ContatosRepository(Context context)
        {
            this._context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<Contato> GetContatoAsyncById(int ContatoId)
        {
            IQueryable<Contato> query = _context.Contatos;

           return await query.Where(cnt => cnt.Id == ContatoId).FirstOrDefaultAsync();

        }

        public async Task<Contato[]> GetContatoAsyncByName(string Name)
        {
            IQueryable<Contato> query = _context.Contatos;

           return await query.Where(cnt => cnt.Nome.Contains(Name)).ToArrayAsync();
        }


        public async Task<Contato[]> GetContatoAsyncAll(int Page, int Size)
        {
            IQueryable<Contato> query = _context.Contatos;



           return await query.Skip(Page).Take(Size).ToArrayAsync();

        }

    }
}