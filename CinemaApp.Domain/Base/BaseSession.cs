using System;

namespace CinemaApp.Domain.Base
{
    public class BaseSession
    {
        public DateTime Date { get; set; }
        public string Room { get; set; }
        
        public int? FilmId { get; set; }
    }
}