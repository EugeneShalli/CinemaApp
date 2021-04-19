using System;
using CinemaApp.Client.DTO.Create;
using CinemaApp.Domain;

namespace CinemaApp.Client.DTO.Read
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int VisitorId { get; set; }
        public int FilmId { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}