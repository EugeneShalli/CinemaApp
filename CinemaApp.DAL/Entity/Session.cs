using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.DAL.Entity
{
    public class Session
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public string Room { get; set; }
        
        public int? FilmID { get; set; }
        public Film Film { get; set; }
        
        // public List<Session> Users { get; set; } = new List<Session>();
    }
}