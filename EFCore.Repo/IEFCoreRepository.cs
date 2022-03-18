using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Repo
{
    public interface IEFCoreRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<Heroi[]> GetAllHerois(bool incluirBatalha);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha);
        Task<Heroi> GetHeroiByNome(string nome, bool incluirBatalha);
    }
}
