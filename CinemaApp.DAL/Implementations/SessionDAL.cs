using CinemaApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using Session = CinemaApp.DAL.Entity.Session;


namespace CinemaApp.DAL.Implementations
{
    public class SessionDAL:ISessionDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public SessionDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<CinemaApp.Domain.Session> InsertAsync(SessionUpdateModel session)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Session>(session));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Session>(result.Entity);
        }

        public async Task<IEnumerable<CinemaApp.Domain.Session>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<CinemaApp.Domain.Session>>(
                await this.Context.Session.ToListAsync());
        }

        public async Task<CinemaApp.Domain.Session> GetAsync(ISessionIdentity session)
        {
            var result = await this.Get(session);

            return this.Mapper.Map<CinemaApp.Domain.Session>(result);
        }

        private async Task<Session> Get(ISessionIdentity session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            return await this.Context.Session.FirstOrDefaultAsync(x => x.Id == session.Id);
        }

        public async Task<CinemaApp.Domain.Session> UpdateAsync(SessionUpdateModel session)
        {
            var existing = await this.Get(session);

            var result = this.Mapper.Map(session, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Session>(result);
        }
    }
}