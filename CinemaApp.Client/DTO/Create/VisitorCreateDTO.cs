using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Client.DTO.Create
{
    public class VisitorCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "LoyaltyCardID is required")]
        public int LoyaltyCardId { get; set; }
    }
}