using CinemaApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using LoyaltyCard = CinemaApp.DAL.Entity.LoyaltyCard;

namespace CinemaApp.DAL.Implementations
{
    public class LoyaltyCardDAL:ILoyaltyCardDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public LoyaltyCardDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<CinemaApp.Domain.LoyaltyCard> InsertAsync(LoyaltyCardUpdateModel loyaltycard)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<LoyaltyCard>(loyaltycard));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.LoyaltyCard>(result.Entity);
        }

        public async Task<IEnumerable<CinemaApp.Domain.LoyaltyCard>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<CinemaApp.Domain.LoyaltyCard>>(
                await this.Context.LoyaltyCard.ToListAsync());
        }

        public async Task<CinemaApp.Domain.LoyaltyCard> GetAsync(ILoyaltyCardIdentity loyaltycard)
        {
            var result = await this.Get(loyaltycard);

            return this.Mapper.Map<CinemaApp.Domain.LoyaltyCard>(result);
        }

        private async Task<LoyaltyCard> Get(ILoyaltyCardIdentity loyaltycard)
        {
            if (loyaltycard == null)
            {
                throw new ArgumentNullException(nameof(loyaltycard));
            }
            
            return await this.Context.LoyaltyCard.FirstOrDefaultAsync(x => x.Id == loyaltycard.Id);
        }

        public async Task<CinemaApp.Domain.LoyaltyCard> UpdateAsync(LoyaltyCardUpdateModel loyaltycard)
        {
            var existing = await this.Get(loyaltycard);

            var result = this.Mapper.Map(loyaltycard, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.LoyaltyCard>(result);
        }
    }
}