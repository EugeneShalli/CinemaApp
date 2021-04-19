using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class LoyaltyCardIdentityModel:ILoyaltyCardIdentity
    {
        public int Id { get; }

        public LoyaltyCardIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}