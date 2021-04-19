using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class SessionUpdateModel:BaseSession, ISessionIdentity
    {
        public int Id { get; set; }
    }
}