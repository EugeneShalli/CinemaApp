using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Client.DTO.Create
{
    public class FilmCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Genre { get; set;}
        public string Language { get; set;}
        public string Country { get; set;}
    }
}