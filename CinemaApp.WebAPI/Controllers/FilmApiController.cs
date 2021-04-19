using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.BLL.Contracts;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Client.DTO.Read;
using CinemaApp.Client.DTO.Update;
using CinemaApp.Domain.Models;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/film")]
    public class FilmApiController: ControllerBase
    {
        private IFilmService FilmService{ get;}
        private ILogger<FilmApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public FilmApiController(ILogger<FilmApiController> logger, IMapper mapper, IFilmService filmService)
        {
            this.Logger = logger;
            this.FilmService = filmService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<FilmDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<FilmDTO>>(await this.FilmService.GetAsync());
        }
        
        [HttpGet("{filmId}")]
        public async Task<FilmDTO> GetAsync(int filmId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {filmId}");
            return this.Mapper.Map<FilmDTO>(await this.FilmService.GetAsync(new FilmIdentityModel(filmId)));
        }
        
        [HttpPatch]
        public async Task<FilmDTO> PatchAsync(FilmUpdateDTO film)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.FilmService.UpdateAsync(this.Mapper.Map<FilmUpdateModel>(film));
            return this.Mapper.Map<FilmDTO>(result);
        }
        
        [HttpPut]
        public async Task<FilmDTO> PutAsync(FilmCreateDTO film)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.FilmService.CreateAsync(this.Mapper.Map<FilmUpdateModel>(film));
            return this.Mapper.Map<FilmDTO>(result);
        }
    }
}