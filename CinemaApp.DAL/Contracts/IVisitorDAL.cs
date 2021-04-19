using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;
using Visitor = CinemaApp.Domain.Visitor;

namespace CinemaApp.DAL.Contracts
{
    public interface IVisitorDAL
    {
        Task<Visitor> InsertAsync(VisitorUpdateModel visitor);
        Task<IEnumerable<Visitor>> GetAsync();
        Task<Visitor> GetAsync(IVisitorIdentity visitorId);
        Task<Visitor> UpdateAsync(VisitorUpdateModel visitor);
    }
}