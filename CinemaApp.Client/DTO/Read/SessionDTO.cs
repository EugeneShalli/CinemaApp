using System;

namespace CinemaApp.Client.DTO.Read
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Room { get; set; }
        public int FilmId { get; set; }
    }
}