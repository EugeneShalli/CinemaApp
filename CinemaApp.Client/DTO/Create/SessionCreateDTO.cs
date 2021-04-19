using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace CinemaApp.Client.DTO.Create
{
    public class SessionCreateDTO
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        public string Room { get; set; }
        [Required(ErrorMessage = "FilmId is required")]
        public int FilmId { get; set; }
    }
}