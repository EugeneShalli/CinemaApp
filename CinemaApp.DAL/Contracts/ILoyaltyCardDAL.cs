using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.DAL.Contracts
{
    public interface ILoyaltyCardDAL
    {
        Task<LoyaltyCard> InsertAsync(LoyaltyCardUpdateModel loyaltycard);
        Task<IEnumerable<LoyaltyCard>> GetAsync();
        Task<LoyaltyCard> GetAsync(ILoyaltyCardIdentity loyaltycardId);
        Task<LoyaltyCard> UpdateAsync(LoyaltyCardUpdateModel loyaltycard);
    }
}