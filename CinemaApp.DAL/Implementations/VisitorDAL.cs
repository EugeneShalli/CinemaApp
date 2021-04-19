using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using Visitor = CinemaApp.DAL.Entity.Visitor;

namespace CinemaApp.DAL.Implementations
{
    public class VisitorDAL:IVisitorDAL 
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public VisitorDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<CinemaApp.Domain.Visitor> InsertAsync(VisitorUpdateModel visitor)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Visitor>(visitor));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Visitor>(result.Entity);
        }

        public async Task<IEnumerable<CinemaApp.Domain.Visitor>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<CinemaApp.Domain.Visitor>>(
                await this.Context.Visitor.ToListAsync());
        }

        public async Task<CinemaApp.Domain.Visitor> GetAsync(IVisitorIdentity visitor)
        {
            var result = await this.Get(visitor);

            return this.Mapper.Map<CinemaApp.Domain.Visitor>(result);
        }

        private async Task<Visitor> Get(IVisitorIdentity visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }
            
            return await this.Context.Visitor.FirstOrDefaultAsync(x => x.Id == visitor.Id);
        }

        public async Task<CinemaApp.Domain.Visitor> UpdateAsync(VisitorUpdateModel visitor)
        {
            var existing = await this.Get(visitor);

            var result = this.Mapper.Map(visitor, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Visitor>(result);
        }
    }
}