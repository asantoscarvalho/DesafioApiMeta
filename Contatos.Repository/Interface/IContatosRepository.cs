using System.Threading.Tasks;
using Contatos.Domain;

namespace Contatos.Repository.Interface
{
    public interface IContatosRepository
    {
        void Add<T>(T entity) where T : class;

         void Update<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;

         Task<bool> SaveChangesAsync();

         Task<Contato> GetContatoAsyncById(int ContatoId);

         Task<Contato[]> GetContatoAsyncByName(string Name);

         Task<Contato[]> GetContatoAsyncAll(int Page, int Size);
    }
}