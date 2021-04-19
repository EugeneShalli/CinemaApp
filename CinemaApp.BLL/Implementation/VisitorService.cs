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
    public class VisitorService: IVisitorService
    {
        private IVisitorDAL VisitorDAL { get; }
        private ILoyaltyCardService LoyaltyCardService { get; }
        
        public VisitorService(IVisitorDAL visitorDAL, ILoyaltyCardService loyaltycardService)
        {
            this.VisitorDAL = visitorDAL;
            this.LoyaltyCardService = loyaltycardService;
        }
        
        public async Task<Visitor> CreateAsync(VisitorUpdateModel visitor) {
            await this.LoyaltyCardService.ValidateAsync(visitor);
            return await this.VisitorDAL.InsertAsync(visitor);
        }
        
        public async Task<Visitor> UpdateAsync(VisitorUpdateModel visitor) {
            await this.LoyaltyCardService.ValidateAsync(visitor);
            return await this.VisitorDAL.UpdateAsync(visitor);
        }
        
        public Task<IEnumerable<Visitor>> GetAsync() {
            return this.VisitorDAL.GetAsync();
        }
        
        public Task<Visitor> GetAsync(IVisitorIdentity id)
        {
            return this.VisitorDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IVisitorContainer visitorContainer)
        {
            if (visitorContainer == null)
            {
                throw new ArgumentNullException(nameof(visitorContainer));
            }
            if (visitorContainer.VisitorId.HasValue)
            {
                var department = await this.VisitorDAL.GetAsync(new VisitorIdentityModel(visitorContainer.VisitorId.Value));
                if( department == null)
                    throw new InvalidOperationException($"Department not found by id {visitorContainer.VisitorId}");
            }
        }
    }
}