using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class VisitorIdentityModel:IVisitorIdentity
    {
        public int Id { get; }

        public VisitorIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}