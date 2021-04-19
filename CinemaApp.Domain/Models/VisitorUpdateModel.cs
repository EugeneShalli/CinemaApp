using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class VisitorUpdateModel: BaseVisitor, IVisitorIdentity, ILoyaltyCardContainer
    {
        public int Id { get; set; }
        public int? LoyaltyCardId { get; set; }
    }
}