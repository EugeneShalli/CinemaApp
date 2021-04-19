using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.BLL.Contracts;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Client.DTO.Read;
using CinemaApp.Client.DTO.Update;
using CinemaApp.DAL;
using CinemaApp.Domain.Models;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/session")]
    public class SessionApiController : ControllerBase
    {
        private ISessionService SessionService{ get;}
        private ILogger<SessionApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public SessionApiController(ILogger<SessionApiController> logger, IMapper mapper, ISessionService sessionService)
        {
            this.Logger = logger;
            this.SessionService = sessionService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<SessionDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for ");
            return this.Mapper.Map<IEnumerable<SessionDTO>>(await this.SessionService.GetAsync());
        }
        
        [HttpGet("{sessionId}")]
        public async Task<SessionDTO> GetAsync(int sessionId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<SessionDTO>(await this.SessionService.GetAsync(new SessionIdentityModel(sessionId)));
        }
        
        [HttpPatch]
        public async Task<SessionDTO> PatchAsync(SessionUpdateDTO session)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.SessionService.UpdateAsync(this.Mapper.Map<SessionUpdateModel>(session));
            return this.Mapper.Map<SessionDTO>(result);
        }
        
        [HttpPut]
        public async Task<SessionDTO> PutAsync(SessionCreateDTO session)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.SessionService.CreateAsync(this.Mapper.Map<SessionUpdateModel>(session));
            return this.Mapper.Map<SessionDTO>(result);
        }
    }
}