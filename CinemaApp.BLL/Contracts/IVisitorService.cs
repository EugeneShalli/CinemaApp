using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Contracts
{
    public interface IVisitorService
    {
        Task<IEnumerable<Visitor>> GetAsync();
        Task<Visitor> GetAsync(IVisitorIdentity id);
        Task<Visitor> CreateAsync(VisitorUpdateModel visitor);
        Task<Visitor> UpdateAsync(VisitorUpdateModel visitor);
        Task ValidateAsync(IVisitorContainer visitorContainer);
    }
}