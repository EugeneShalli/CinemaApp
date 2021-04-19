using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.BLL.Contracts;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Implementation
{
    public class SessionService:ISessionService
    {
        private ISessionDAL SessionDAL { get; }
        
        public SessionService(ISessionDAL sessionDAL)
        {
            this.SessionDAL = sessionDAL;
        }
        
        public async Task<Session> CreateAsync(SessionUpdateModel session) {
            return await this.SessionDAL.InsertAsync(session);
        }
        
        public async Task<Session> UpdateAsync(SessionUpdateModel session) {
            return await this.SessionDAL.UpdateAsync(session);
        }
        
        public Task<IEnumerable<Session>> GetAsync() {
            return this.SessionDAL.GetAsync();
        }
        
        public Task<Session> GetAsync(ISessionIdentity id)
        {
            return this.SessionDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(ISessionContainer sessionContainer)
        {
            if (sessionContainer == null)
            {
                throw new ArgumentNullException(nameof(sessionContainer));
            }
     
            if (sessionContainer.SessionId.HasValue)
            {
                var department = await this.SessionDAL.GetAsync(new SessionIdentityModel((int) sessionContainer.SessionId));
                if(department == null) 
                    throw new InvalidOperationException($"Session not found by id {sessionContainer.SessionId}");
            }
        }
    }
}