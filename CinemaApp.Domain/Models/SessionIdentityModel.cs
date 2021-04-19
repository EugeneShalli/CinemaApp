using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class SessionIdentityModel:ISessionIdentity
    {
        public int Id { get; }

        public SessionIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}