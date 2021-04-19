using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.DAL.Contracts
{
    public interface IFilmDAL
    {
        Task<Film> InsertAsync(FilmUpdateModel film);
        Task<IEnumerable<Film>> GetAsync();
        Task<Film> GetAsync(IFilmIdentity filmId);
        Task<Film> UpdateAsync(FilmUpdateModel film);
    }
}