using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Client.DTO.Create
{
    public class LoyaltyCardCreateDTO
    {
        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }
        public string Annotation { get; set;}
    }
}