using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class FilmIdentityModel:IFilmIdentity
    {
        public int Id { get; }

        public FilmIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}