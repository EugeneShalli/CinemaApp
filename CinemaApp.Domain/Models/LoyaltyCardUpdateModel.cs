using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class LoyaltyCardUpdateModel:BaseLoyaltyCard, ILoyaltyCardIdentity
    {
        public int Id { get; set; }
    }
}