using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.DAL.Entity
{
    public class Visitor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public int? LoyaltyCardId { get; set; }
        public LoyaltyCard LoyaltyCard { get; set; }
        
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}