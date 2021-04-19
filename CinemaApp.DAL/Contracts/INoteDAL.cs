using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.DAL.Contracts
{
    public interface INoteDAL
    {
        Task<Note> InsertAsync(NoteUpdateModel note);
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity noteId);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}