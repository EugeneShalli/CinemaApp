using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain
{
    public class Visitor:BaseVisitor,ILoyaltyCardContainer
    {
        
        public int Id { get; set; }
        public int? LoyaltyCardId { get; set; }
    }
}