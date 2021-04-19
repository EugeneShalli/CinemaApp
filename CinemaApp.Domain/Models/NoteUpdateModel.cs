using CinemaApp.Domain.Base;
using CinemaApp.Domain.Contracts;

namespace CinemaApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity, IVisitorContainer,ISessionContainer, IFilmContainer
    {
        public int Id { get; set; }
        
    }
}