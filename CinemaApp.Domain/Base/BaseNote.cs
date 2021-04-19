using System;

namespace CinemaApp.Domain.Base
{
    public class BaseNote
    {
        public int? VisitorId { get; set; }
        public int? SessionId { get; set; }
        
        public int? FilmId { get; set; }
    
    }
}