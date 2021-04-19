using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Contracts
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetAsync();
        Task<Session> GetAsync(ISessionIdentity id);
        Task<Session> CreateAsync(SessionUpdateModel session);
        Task<Session> UpdateAsync(SessionUpdateModel session);
        Task ValidateAsync(ISessionContainer sessionContainer);
    }
}