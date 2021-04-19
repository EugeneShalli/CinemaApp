using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinemaApp.BLL.Contracts;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Client.DTO.Update;
using CinemaApp.Domain.Models;

namespace CinemaApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/loyaltycard")]
    public class LoyaltyCardApiController: ControllerBase
    {
        private ILoyaltyCardService LoyaltyCardService{ get;}
        private ILogger<LoyaltyCardApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public LoyaltyCardApiController(ILogger<LoyaltyCardApiController> logger, IMapper mapper, ILoyaltyCardService loyaltycardService)
        {
            this.Logger = logger;
            this.LoyaltyCardService = loyaltycardService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<LoyaltyCardDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<LoyaltyCardDTO>>(await this.LoyaltyCardService.GetAsync());
        }
        
        [HttpGet("{loyaltycardId}")]
        public async Task<LoyaltyCardDTO> GetAsync(int loyaltycardId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {loyaltycardId}");
            return this.Mapper.Map<LoyaltyCardDTO>(await this.LoyaltyCardService.GetAsync(new LoyaltyCardIdentityModel(loyaltycardId)));
        }
        
        [HttpPatch]
        public async Task<LoyaltyCardDTO> PatchAsync(LoyaltyCardUpdateDTO loyaltycard)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.LoyaltyCardService.UpdateAsync(this.Mapper.Map<LoyaltyCardUpdateModel>(loyaltycard));
            return this.Mapper.Map<LoyaltyCardDTO>(result);
        }
        
        [HttpPut]
        public async Task<LoyaltyCardDTO> PutAsync(LoyaltyCardCreateDTO loyaltycard)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.LoyaltyCardService.CreateAsync(this.Mapper.Map<LoyaltyCardUpdateModel>(loyaltycard));
            return this.Mapper.Map<LoyaltyCardDTO>(result);
        }
    }
}