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
    public class LoyaltyCardService:ILoyaltyCardService
    {
        private ILoyaltyCardDAL LoyaltyCardDAL { get; }
        
        public LoyaltyCardService(ILoyaltyCardDAL loyaltycardDAL)
        {
            this.LoyaltyCardDAL = loyaltycardDAL;
        }
        
        public async Task<LoyaltyCard> CreateAsync(LoyaltyCardUpdateModel loyaltycard) {
            return await this.LoyaltyCardDAL.InsertAsync(loyaltycard);
        }
        
        public async Task<LoyaltyCard> UpdateAsync(LoyaltyCardUpdateModel loyaltycard) {
            return await this.LoyaltyCardDAL.UpdateAsync(loyaltycard);
        }
        
        public Task<IEnumerable<LoyaltyCard>> GetAsync() {
            return this.LoyaltyCardDAL.GetAsync();
        }
        
        public Task<LoyaltyCard> GetAsync(ILoyaltyCardIdentity id)
        {
            return this.LoyaltyCardDAL.GetAsync(id);
        }
        public async Task ValidateAsync(ILoyaltyCardContainer loyaltycardContainer){
            if (loyaltycardContainer == null)
            {
                throw new ArgumentNullException(nameof(loyaltycardContainer));
            }
            else
            {
                if (loyaltycardContainer.LoyaltyCardId.HasValue)
                {
                    var department = await this.LoyaltyCardDAL.GetAsync(new LoyaltyCardIdentityModel(loyaltycardContainer.LoyaltyCardId.Value));
                    if (department == null)
                        throw new InvalidOperationException($"LoyaltyCard not found by id {loyaltycardContainer.LoyaltyCardId}");
                }
            }
        }
    }
}