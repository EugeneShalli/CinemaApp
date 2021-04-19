using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Contracts
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAsync();
        Task<Film> GetAsync(IFilmIdentity id);
        Task<Film> CreateAsync(FilmUpdateModel film);
        Task<Film> UpdateAsync(FilmUpdateModel film);
        Task ValidateAsync(IFilmContainer filmContainer);
    }
}