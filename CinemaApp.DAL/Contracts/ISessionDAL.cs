using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.DAL.Contracts
{
    public interface ISessionDAL
    {
        Task<Session> InsertAsync(SessionUpdateModel session);
        Task<IEnumerable<Session>> GetAsync();
        Task<Session> GetAsync(ISessionIdentity sessionId);
        Task<Session> UpdateAsync(SessionUpdateModel session);
    }
}