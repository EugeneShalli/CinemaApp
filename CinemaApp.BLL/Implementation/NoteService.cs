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
    public class NoteService:INoteService
    {
        private INoteDAL NoteDAL { get; }
        private IVisitorService VisitorService { get; }
        private ISessionService SessionService { get; }
        private IFilmService FilmService { get; }
        public NoteService(INoteDAL noteDAL, IVisitorService visitorService, ISessionService sessionService, IFilmService filmService)
        {
            this.NoteDAL = noteDAL;
            this.VisitorService = visitorService;
            this.SessionService = sessionService;
            this.FilmService = filmService;
        }
        
        public async Task<Note> CreateAsync(NoteUpdateModel note) {
            await this.VisitorService.ValidateAsync(note);
            await this.SessionService.ValidateAsync(note);
            await this.FilmService.ValidateAsync(note);
            return await this.NoteDAL.InsertAsync(note);
        }
        
        public async Task<Note> UpdateAsync(NoteUpdateModel note) {
            return await this.NoteDAL.UpdateAsync(note);
        }
        
        public Task<IEnumerable<Note>> GetAsync() {
            return this.NoteDAL.GetAsync();
        }
        
        public Task<Note> GetAsync(INoteIdentity id)
        {
            return this.NoteDAL.GetAsync(id);
        }
    }
}