using System.ComponentModel.DataAnnotations;
using CinemaApp.Domain;

namespace CinemaApp.Client.DTO.Create
{
    public class NoteCreateDTO
    {
        [Required(ErrorMessage = "SessionId is required")]
        public int SessionId { get; set; }
        [Required(ErrorMessage = "VisitorId is required")]
        public int VisitorId { get; set; }
        [Required(ErrorMessage = "FilmId is required")]
        public int FilmId { get; set; }
    }
}