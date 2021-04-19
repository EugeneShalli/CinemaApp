using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaApp.Domain;
using CinemaApp.Domain.Contracts;
using CinemaApp.Domain.Models;

namespace CinemaApp.BLL.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity id);
        Task<Note> CreateAsync(NoteUpdateModel note);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}