using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.DAL.Entity
{
    public class LoyaltyCard
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Class { get; set; }
        public string Annotation { get; set;}
    }
}