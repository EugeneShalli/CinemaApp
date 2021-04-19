using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.BLL.Contracts;
using CinemaApp.Client.DTO;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Client.DTO.Read;
using CinemaApp.Client.DTO.Update;
using CinemaApp.Domain.Models;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/visitor")]
    public class VisitorApiController : ControllerBase
    {
        private IVisitorService VisitorService{ get;}
        private ILogger<VisitorApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public VisitorApiController(ILogger<VisitorApiController> logger, IMapper mapper, IVisitorService visitorService)
        {
            this.Logger = logger;
            this.VisitorService = visitorService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<VisitorDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<VisitorDTO>>(await this.VisitorService.GetAsync());
        }
        
        [HttpGet("{visitorId}")]
        public async Task<VisitorDTO> GetAsync(int visitorId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {visitorId}");
            return this.Mapper.Map<VisitorDTO>(await this.VisitorService.GetAsync(new VisitorIdentityModel(visitorId)));
        }
        
        [HttpPatch]
        public async Task<VisitorDTO> PatchAsync(VisitorUpdateDTO visitor)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.VisitorService.UpdateAsync(this.Mapper.Map<VisitorUpdateModel>(visitor));
            return this.Mapper.Map<VisitorDTO>(result);
        }
        
        [HttpPut]
        public async Task<VisitorDTO> PutAsync(VisitorCreateDTO visitor)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.VisitorService.CreateAsync(this.Mapper.Map<VisitorUpdateModel>(visitor));
            return this.Mapper.Map<VisitorDTO>(result);
        }
    }
}