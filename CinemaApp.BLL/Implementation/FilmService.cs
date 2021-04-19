using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.BLL.Contracts;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Implementation
{
    public class FilmService:IFilmService
    {
        private IFilmDAL FilmDAL { get; }
        
        public FilmService(IFilmDAL filmDAL)
        {
            this.FilmDAL = filmDAL;
        }
        
        public async Task<Film> CreateAsync(FilmUpdateModel film) {
            return await this.FilmDAL.InsertAsync(film);
        }
        
        public async Task<Film> UpdateAsync(FilmUpdateModel film) {
            return await this.FilmDAL.UpdateAsync(film);
        }
        
        public Task<IEnumerable<Film>> GetAsync() {
            return this.FilmDAL.GetAsync();
        }
        
        public Task<Film> GetAsync(IFilmIdentity id)
        {
            return this.FilmDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IFilmContainer filmContainer)
        {
            if (filmContainer == null)
            {
                throw new ArgumentNullException(nameof(filmContainer));
            }
            if (filmContainer.FilmId.HasValue )
            {
                var department = await this.FilmDAL.GetAsync(new FilmIdentityModel(filmContainer.FilmId.Value));
                if(department == null)
                    throw new InvalidOperationException($"Department not found by id {filmContainer.FilmId}");
            }
        }
    }
}