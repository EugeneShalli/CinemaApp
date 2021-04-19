using CinemaApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CinemaApp.DAL.Contracts;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using Film = CinemaApp.DAL.Entity.Film;

namespace CinemaApp.DAL.Implementations
{
    public class FilmDAL:IFilmDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public FilmDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<CinemaApp.Domain.Film> InsertAsync(FilmUpdateModel film)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Film>(film));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Film>(result.Entity);
        }

        public async Task<IEnumerable<CinemaApp.Domain.Film>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<CinemaApp.Domain.Film>>(
                await this.Context.Film.ToListAsync());
        }

        public async Task<CinemaApp.Domain.Film> GetAsync(IFilmIdentity film)
        {
            var result = await this.Get(film);

            return this.Mapper.Map<CinemaApp.Domain.Film>(result);
        }

        private async Task<Film> Get(IFilmIdentity film)
        {
            if (film == null)
            {
                throw new ArgumentNullException(nameof(film));
            }
            
            return await this.Context.Film.FirstOrDefaultAsync(x => x.Id == film.Id);
        }

        public async Task<CinemaApp.Domain.Film> UpdateAsync(FilmUpdateModel film)
        {
            var existing = await this.Get(film);

            var result = this.Mapper.Map(film, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<CinemaApp.Domain.Film>(result);
        }
    }
}