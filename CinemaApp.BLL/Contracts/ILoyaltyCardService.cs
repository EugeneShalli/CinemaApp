using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Contracts
{
    public interface ILoyaltyCardService
    {
        Task<IEnumerable<LoyaltyCard>> GetAsync();
        Task<LoyaltyCard> GetAsync(ILoyaltyCardIdentity id);
        Task<LoyaltyCard> CreateAsync(LoyaltyCardUpdateModel loyaltycard);
        Task<LoyaltyCard> UpdateAsync(LoyaltyCardUpdateModel loyaltycard);
        Task ValidateAsync(ILoyaltyCardContainer loyaltycardContainer);
    }
}