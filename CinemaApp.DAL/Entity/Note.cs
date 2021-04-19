using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.DAL.Entity
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public int? FilmId { get; set; }
        public Film Film { get; set; }
        public DateTime DateVisit { get; set; }
    }
}