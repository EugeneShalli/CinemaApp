using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class FilmUpdateModel: BaseFilm, IFilmIdentity
    {
        public int Id { get; set; }
    }
}